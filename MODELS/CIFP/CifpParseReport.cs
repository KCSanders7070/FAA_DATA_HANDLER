using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// What one parse run actually saw: counts by record type plus anything that did not fit.
    /// </summary>
    /// <remarks>
    /// The point of this is to make a bad cycle obvious immediately. A new record type, a shifted
    /// column, or a truncated download all show up here as unmatched or wrong-length lines rather
    /// than as silently missing data downstream.
    /// </remarks>
    public sealed class CifpParseReport
    {
        /// <summary>Total lines read, including header records.</summary>
        public int TotalLines { get; set; }

        /// <summary>Header (HDR) records read.</summary>
        public int HeaderRecords { get; set; }

        /// <summary>Primary records parsed, keyed by section+subsection (for example "PA").</summary>
        public Dictionary<string, int> PrimaryRecords { get; } = new();

        /// <summary>Continuation records parsed, keyed by section+subsection.</summary>
        public Dictionary<string, int> ContinuationRecords { get; } = new();

        /// <summary>Lines whose section/subsection matched no known record type.</summary>
        public int UnmatchedLines { get; set; }

        /// <summary>Lines that were not exactly 132 characters.</summary>
        public int WrongLengthLines { get; set; }

        /// <summary>Blank lines skipped.</summary>
        public int BlankLines { get; set; }

        /// <summary>Sample source lines for each problem seen, for diagnosis.</summary>
        public Dictionary<string, List<string>> Samples { get; } = new();

        /// <summary>How long the parse took.</summary>
        public TimeSpan Elapsed { get; set; }

        /// <summary>True when every non-blank line was matched and correctly sized.</summary>
        public bool IsClean => UnmatchedLines == 0 && WrongLengthLines == 0;

        internal void Sample(string issue, string line, int max)
        {
            if (!Samples.TryGetValue(issue, out List<string>? list))
            {
                list = new List<string>();
                Samples[issue] = list;
            }

            if (list.Count < max)
                list.Add(line);
        }

        /// <summary>Renders the report as a readable block of text.</summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"CIFP parse summary  ({Elapsed.TotalSeconds:F2}s)");
            sb.AppendLine($"  total lines        {TotalLines,10:N0}");
            sb.AppendLine($"  header records     {HeaderRecords,10:N0}");

            int primary = PrimaryRecords.Values.Sum();
            int continuation = ContinuationRecords.Values.Sum();
            sb.AppendLine($"  primary records    {primary,10:N0}");
            sb.AppendLine($"  continuations      {continuation,10:N0}");

            if (BlankLines > 0)
                sb.AppendLine($"  blank lines        {BlankLines,10:N0}");

            if (WrongLengthLines > 0)
                sb.AppendLine($"  WRONG LENGTH       {WrongLengthLines,10:N0}   <-- expected 132 characters");

            if (UnmatchedLines > 0)
                sb.AppendLine($"  UNMATCHED          {UnmatchedLines,10:N0}   <-- unknown record type");

            sb.AppendLine();
            sb.AppendLine("  by record type:");
            foreach (KeyValuePair<string, int> pair in PrimaryRecords.OrderBy(p => p.Key))
            {
                ContinuationRecords.TryGetValue(pair.Key, out int cont);
                string suffix = cont > 0 ? $"  (+{cont:N0} continuation)" : string.Empty;
                sb.AppendLine($"    {pair.Key,-4} {pair.Value,10:N0}{suffix}");
            }

            if (Samples.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("  samples:");
                foreach (KeyValuePair<string, List<string>> pair in Samples)
                {
                    sb.AppendLine($"    {pair.Key}:");
                    foreach (string line in pair.Value)
                        sb.AppendLine($"      {line}");
                }
            }

            return sb.ToString();
        }
    }
}
