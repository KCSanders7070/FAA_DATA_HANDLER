using FAA_DATA_HANDLER.Models.CIFP;
using FAA_DATA_HANDLER.Parsers.CIFP;
using System;
using System.Diagnostics;
using System.IO;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Entry point for parsing the FAA CIFP file.
    /// </summary>
    /// <remarks>
    /// Reads FAACIFP18 line by line and hands each record to the parser for its type. Every record is
    /// exactly 132 characters, so dispatch is a couple of character tests rather than any string work.
    /// <para><b>Where the subsection code lives depends on the section.</b> This is the one thing that
    /// makes CIFP dispatch non-obvious, and getting it wrong silently drops whole record types:</para>
    /// <list type="bullet">
    ///   <item>Sections A, D, E and U carry the subsection at index 5.</item>
    ///   <item>Section H carries it at index 12.</item>
    ///   <item>Section P carries it at index 12, EXCEPT Terminal Navaids (PN), which use index 5.</item>
    /// </list>
    /// <para>Terminal Waypoints (PC) and Heliport Terminal Waypoints (HC) are the trap: they share the
    /// 4.1.4.1 Waypoint layout with Enroute Waypoints (EA), but EA carries its subsection at index 5
    /// while PC and HC carry theirs at index 12 with index 5 blank.</para>
    /// <para>A record is a continuation when its Continuation Record Number is neither '0' nor '1'.
    /// That column sits at a different index per record type, so it is read from the per-type constant
    /// rather than a single shared offset.</para>
    /// </remarks>
    public static class CifpParserController
    {
        /// <summary>The fixed width of every CIFP data record.</summary>
        public const int RecordLength = 132;

        /// <summary>
        /// Parses a CIFP file into <paramref name="cifpDataCollections"/>.
        /// </summary>
        /// <param name="faaCifp18FilePath">Full path to the FAACIFP18 file.</param>
        /// <param name="cifpDataCollections">Destination for every parsed record.</param>
        /// <param name="options">Parse options; defaults are used when null.</param>
        /// <returns>A summary of what was read, including anything that did not match.</returns>
        public static CifpParseReport Parse(
            string faaCifp18FilePath,
            CifpDataCollections cifpDataCollections,
            CifpParseOptions? options = null)
        {
            options ??= new CifpParseOptions();
            var report = new CifpParseReport();
            var stopwatch = Stopwatch.StartNew();

            if (!File.Exists(faaCifp18FilePath))
                throw new FileNotFoundException("CIFP file not found.", faaCifp18FilePath);

            bool keepRaw = options.KeepRawRecord;
            int maxSamples = options.MaxSamplesPerIssue;

            foreach (string rawLine in File.ReadLines(faaCifp18FilePath))
            {
                report.TotalLines++;
                ReadOnlySpan<char> line = rawLine.AsSpan();

                if (line.IsWhiteSpace())
                {
                    report.BlankLines++;
                    continue;
                }

                if (line.StartsWith("HDR"))
                {
                    report.HeaderRecords++;
                    HeaderInfoCifpParser.Parse(line, cifpDataCollections, keepRaw);
                    continue;
                }

                if (line.Length != RecordLength)
                {
                    report.WrongLengthLines++;
                    report.Sample($"length {line.Length}, expected {RecordLength}", rawLine, maxSamples);
                    continue;
                }

                if (!Dispatch(line, cifpDataCollections, report, keepRaw))
                {
                    report.UnmatchedLines++;
                    report.Sample($"unknown record type '{line[4]}{line[5]}{line[12]}'", rawLine, maxSamples);

                    if (options.ThrowOnUnknownRecord)
                        throw new InvalidDataException($"Unrecognized CIFP record type on line {report.TotalLines}: {rawLine}");
                }
            }

            stopwatch.Stop();
            report.Elapsed = stopwatch.Elapsed;
            return report;
        }

        /// <summary>
        /// Routes one 132-character record to its parser.
        /// </summary>
        /// <returns>False when the record's section and subsection match no known type.</returns>
        private static bool Dispatch(
            ReadOnlySpan<char> line,
            CifpDataCollections cifpDataCollections,
            CifpParseReport report,
            bool keepRaw)
        {
            char sectionCode = line[4];

            // The subsection column is not in the same place for every section.
            char subsectionCode = sectionCode switch
            {
                'A' or 'D' or 'E' or 'U' => line[5],
                'H' => line[12],
                'P' => line[5] == 'N' ? 'N' : line[12],
                _ => '\0'
            };

            switch (sectionCode)
            {
                // ---- Section 'A' : MORA ------------------------------------------
                case 'A':
                    switch (subsectionCode)
                    {
                        case 'S':
                            // Grid MORA (AS) - no continuation record number field
                            GridMoraCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "AS");
                            return true;

                        default:
                            return false;
                    }

                // ---- Section 'D' : Navaid ----------------------------------------
                case 'D':
                    switch (subsectionCode)
                    {
                        case ' ':
                            // VHF Navaids (D) - continuation record number at index 21
                            VhfNavaidsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "D");
                            return true;

                        case 'B':
                            // NDB Navaids (DB) - continuation record number at index 21
                            NdbNavaidsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "DB");
                            return true;

                        default:
                            return false;
                    }

                // ---- Section 'E' : Enroute ---------------------------------------
                case 'E':
                    switch (subsectionCode)
                    {
                        case 'A':
                            // Enroute Waypoints (EA) - continuation record number at index 21
                            EnrouteWaypointsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "EA");
                            return true;

                        case 'R':
                            // Airways (ER) - continuation record number at index 38
                            AirwaysCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "ER");
                            return true;

                        default:
                            return false;
                    }

                // ---- Section 'H' : Heliport --------------------------------------
                case 'H':
                    switch (subsectionCode)
                    {
                        case 'A':
                            // Heliports (HA) - continuation record number at index 21
                            HeliportsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "HA");
                            return true;

                        case 'C':
                            // Heliport Terminal Waypoints (HC) - continuation record number at index 21
                            HeliportTerminalWaypointsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "HC");
                            return true;

                        case 'D':
                            // Heliport SIDs (HD) - continuation record number at index 38
                            HeliportStandardInstrumentDeparturesCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "HD");
                            return true;

                        case 'F':
                            // Heliport Approaches (HF) - continuation record number at index 38
                            if (IsContinuation(line[38]))
                            {
                                HeliportApproachProceduresContinuationCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.ContinuationRecords, "HF");
                            }
                            else
                            {
                                HeliportApproachProceduresCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.PrimaryRecords, "HF");
                            }
                            return true;

                        case 'S':
                            // Heliport MSA (HS) - continuation record number at index 38
                            HeliportMinimumSectorAltitudeCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "HS");
                            return true;

                        default:
                            return false;
                    }

                // ---- Section 'P' : Airport ---------------------------------------
                case 'P':
                    switch (subsectionCode)
                    {
                        case 'A':
                            // Airports (PA) - continuation record number at index 21
                            AirportsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PA");
                            return true;

                        case 'C':
                            // Terminal Waypoints (PC) - continuation record number at index 21
                            TerminalWaypointsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PC");
                            return true;

                        case 'D':
                            // SIDs (PD) - continuation record number at index 38
                            StandardInstrumentDeparturesCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PD");
                            return true;

                        case 'E':
                            // STARs (PE) - continuation record number at index 38
                            StandardTerminalArrivalRoutesCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PE");
                            return true;

                        case 'F':
                            // Airport Approaches (PF) - continuation record number at index 38
                            if (IsContinuation(line[38]))
                            {
                                AirportApproachProceduresContinuationCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.ContinuationRecords, "PF");
                            }
                            else
                            {
                                AirportApproachProceduresCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.PrimaryRecords, "PF");
                            }
                            return true;

                        case 'G':
                            // Runways (PG) - continuation record number at index 21
                            RunwaysCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PG");
                            return true;

                        case 'I':
                            // Localizer and Glide Slope (PI) - continuation record number at index 21
                            LocalizerAndGlideSlopeCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PI");
                            return true;

                        case 'N':
                            // Terminal Navaids (PN) - continuation record number at index 21
                            TerminalNavaidsCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PN");
                            return true;

                        case 'P':
                            // Path Point (PP) - continuation record number at index 26
                            if (IsContinuation(line[26]))
                            {
                                PathPointContinuationCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.ContinuationRecords, "PP");
                            }
                            else
                            {
                                PathPointCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.PrimaryRecords, "PP");
                            }
                            return true;

                        case 'S':
                            // Airport MSA (PS) - continuation record number at index 38
                            AirportMinimumSectorAltitudeCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "PS");
                            return true;

                        default:
                            return false;
                    }

                // ---- Section 'U' : Airspace --------------------------------------
                case 'U':
                    switch (subsectionCode)
                    {
                        case 'C':
                            // Class B/C/D Airspace (UC) - continuation record number at index 24
                            ControlledClassAirspaceBCDCifpParser.Parse(line, cifpDataCollections, keepRaw);
                            Count(report.PrimaryRecords, "UC");
                            return true;

                        case 'R':
                            // Special Use Airspace (UR) - continuation record number at index 24
                            if (IsContinuation(line[24]))
                            {
                                SpecialUseRestrictiveContinuationCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.ContinuationRecords, "UR");
                            }
                            else
                            {
                                SpecialUseRestrictiveCifpParser.Parse(line, cifpDataCollections, keepRaw);
                                Count(report.PrimaryRecords, "UR");
                            }
                            return true;

                        default:
                            return false;
                    }

                default:
                    return false;
            }
        }

        /// <summary>
        /// True when a Continuation Record Number marks a continuation rather than a primary record.
        /// </summary>
        /// <remarks>
        /// ARINC 424 uses '0' when no continuation follows and '1' on a primary that does have one.
        /// Continuations themselves are numbered '2' through '9' and then 'A' through 'Z'. Only PF, HF,
        /// PP and UR actually carry continuations in the FAA CIFP, and only ever one each.
        /// </remarks>
        private static bool IsContinuation(char continuationRecordNumber)
            => continuationRecordNumber != '0' && continuationRecordNumber != '1';

        private static void Count(System.Collections.Generic.Dictionary<string, int> counter, string key)
        {
            counter.TryGetValue(key, out int existing);
            counter[key] = existing + 1;
        }
    }
}