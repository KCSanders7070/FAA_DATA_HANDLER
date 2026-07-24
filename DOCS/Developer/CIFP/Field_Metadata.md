# GENERAL
The following breaks down what is expected with each field ARINC 424 Standard definition used by the FAA to construct the CIFP file.

The field ID (ex: "5.2", "5.10", "5.100") references the ARINC chapter `5`.`Section`.

The Metadata category depicts what is expected to be stored to the property after parsing, not what is in the source file. For example, the Max Length of a field in the source file may be 5 characters but after parsing, the value has a decimal inserted and is now 6 characters long; The metadata will show 6 in this scenario.

## 5.2 - Record Type

- SUMMARY
  - Record types are either "standard" (S) or "tailored" (T).

- METADATA
  - Type: string
  - MaxLength: 8 (expected)
  - Trimmed: N
  - Converted: Y

- RETURNS
  - "Standard" or "Tailored". Otherwise, the unexpected value found in the CIFP field.

- DETAILS
  - Record types are divided into "standard" (S) and "tailored" (T) groups based on the first column.

## 5.3 - Customer/Area Code

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 3
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies the customer or area the data is intended for, such as nations (Ex: USA, CAN, EUR) or operators (Ex: UAL, DAL).

## 5.4 - Section Code

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Single character identifying the data section or domain, such as NAVAIDS (D), AIRPORT (P), ENROUTE (E), etc.

## 5.5 - Sub-Section Code

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Defines the specific subsection within a major database section where the record resides; used with Section Code and record identifier to reference related data such as fixes, procedures, communications, and routes.

## 5.6 - Airport/Heliport ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Contains the ICAO airport/heliport identifier to which the record's data applies. If there is no published ICAO Airport Identifier, then the published FAA Airport Identifier will be used.

## 5.7 - Route Type

- SUMMARY
  - Category of route represented by the record, including Enroute Airways, Preferred Routes, and Airport/Heliport SID, STAR, and Approach procedures. For Airport and Heliport Approach Routes, the field consists of a primary route type and up to two route type qualifiers that further define the procedure. Values differ based upon record type. Alternate missed approaches are not included in the CIFP. Route type for the missed approach will reflect the route type of the final approach.

- METADATA
  - Type: string
  - MaxLength: Variable
  - Trimmed: N
  - Converted: Y

- RETURNS
  - "(D) Direct Route", "(O) Officially Designated Airways, except RNAV, Helicopter Airways", "(1) SID Runway Transition", etc... Otherwise, the unexpected value found in the CIFP field.

- DETAILS
  - Defines the category of route represented by the record, including Enroute Airways, Preferred Routes, and Airport/Heliport SID, STAR, and Approach procedures. For Airport and Heliport Approach Routes, the field consists of a primary route type and up to two route type qualifiers that further define the procedure. Values differ based upon record type.

## 5.8 - Route ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: EnrouteAWY=5, PrefRTE=10
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies a route of flight or traffic flow using the naming conventions published on aeronautical charts and related navigation documents. Route identifiers may represent Enroute Airways, Preferred Routes, North Atlantic routes, European Traffic Orientation System routes, or other structured routing systems. For routes without official identifiers, the identifier may be derived from the origin and destination fixes or constructed according to established naming rules. Maximum length is 5 characters for Enroute Airways and 10 characters for Preferred Routes. Examples: Enroute Airways - V216, C1150, UB414; Preferred Routes - N111B, TOS13, TOS14WK, CYYLCYYC, SCNDICANRY.

## 5.9 - SID/STAR Route ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 6
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies a SID or STAR using an abbreviated name that combines the basic, validity, and route indicators according to established naming rules. Ex: DEPU2, SCK4, TRP7, 41M3, MONTH6

## 5.10 - Approach Route ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 6
  - Trimmed: N
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Defines the identifier of an approach route, including provisions for multiple procedures, circle-to-land operations, and helicopter approaches. Runway-dependent procedures use alphanumeric codes with optional multiple indicators (Ex: I26L, R29, V08-A). Circle-to-land procedures use four-character alpha identifiers with an optional fifth character for multiples (Ex: VORA, VOR-B, NDB-1). Helicopter-to-runway identifiers start with the approach type followed by a three-digit runway/course number and optional multiple indicator (Ex: I13L, V175, N175B). Helicopter-to-helipad identifiers use the approach type plus the pad designation, with no multiple indicator in this field (Ex: IA127, VBRAVO, N23, RWESTA). Col: 1=Approach type (alpha, same as RouteType field) __ Col:2-3=RwyId in tens of degrees (01-36) __ Col: 4=Rwy designation (L=Left, R=Right, C=Center, T=True North, dash=placeholder, blank=unused) __ Col: 5=Multiple indicator (alphanumeric or blank) __ 6=Blank.

## 5.11 - Transition ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 5
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies the transition segment connecting phases of flight, such as enroute-to-terminal, terminal-to-enroute, terminal-to-approach, or runway/helipad-to-terminal operations. The value is derived from the Route Type field (5.7) according to established route-structure rules and identifies the specific transition associated with the procedure.

## 5.12 - Sequence Number

- SUMMARY
  - Defines the position of a record within an ordered sequence used to describe routes, boundaries, multi-record conditions, or procedure areas. For route and boundary records, it establishes the record's location within the overall path or boundary definition. For multi-record data structures, it identifies the order of primary records required to fully define the feature. In TAA records, Sequence 1=Straight-In Area, 2=Left Base Area, and 3=Right Base Area, with only applicable areas present. Sequence numbers are assigned during data assembly to maintain unique ordering within a route, boundary, or condition and allow records to be reconstructed in proper flight sequence. Enroute airway fixes that occur at geographic boundaries may appear in multiple areas while retaining the same sequence number, with uniqueness maintained by the Boundary Code. Length varies by record type: 4 digits (Enroute Airways, Preferred Routes, FIR/UIR, Restrictive Airspace) __ 3 digits (SID/STAR, Approach, Company Routes) __ 2 digits (VHF Navaid Limitation Continuations) __ 1 digit (MSA, TAA, Cruise Tables). Examples: 0010, 0135, 2076, 120, 030, 01, 84, 3.. [Converted] to int and removed prefixed zeros.

- METADATA
  - Type: int
  - MaxLength: 4
  - Trimmed: Y
  - Converted: Y

- RETURNS
  - int #, ##, ##, ###

- DETAILS
  - Defines the position of a record within an ordered sequence used to describe routes, boundaries, multi-record conditions, or procedure areas. For route and boundary records, it establishes the record's location within the overall path or boundary definition. For multi-record data structures, it identifies the order of primary records required to fully define the feature. In TAA records, Sequence 1=Straight-In Area, 2=Left Base Area, and 3=Right Base Area, with only applicable areas present. Sequence numbers are assigned during data assembly to maintain unique ordering within a route, boundary, or condition and allow records to be reconstructed in proper flight sequence. Enroute airway fixes that occur at geographic boundaries may appear in multiple areas while retaining the same sequence number, with uniqueness maintained by the Boundary Code. Length varies by record type: 4 digits (Enroute Airways, Preferred Routes, FIR/UIR, Restrictive Airspace) __ 3 digits (SID/STAR, Approach, Company Routes) __ 2 digits (VHF Navaid Limitation Continuations) __ 1 digit (MSA, TAA, Cruise Tables). Examples: 0010, 0135, 2076, 120, 030, 01, 84, 3.

## 5.13 - Fix ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 5
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies a fix using its published or derived identifier, which may represent a waypoint, VHF NAVAID, NDB, airport, or runway. (Ex: SHARP, DEN43, BHM, RW27L, KGRR).

## 5.14 - ICAO [Location] Code

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 2
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Two-character ICAO code used for geographic categorization, typically based on ICAO Doc 7910. U.S. codes begin with 'K' followed by a digit for regional subdivision (e.g., K1, K7). Used for airports with at least one hard-surfaced runway or supporting enroute airway structure. If no ICAO identifier is published, the FAA identifier is used instead.

## 5.16 - Continuation Record Number

- SUMMARY
  - ???

- METADATA
  - Type: int
  - MaxLength: 1
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies the position of a continuation record in a sequence; primary records use '0' if no continuation follows, '1' if they do, with continuations numbered '2'–'9' and then 'A'–'Z' as needed.

## 5.17 - Waypoint Description Code

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Identifies the type and operational function of a fix within a route, procedure, or airspace structure. Because a single fix may appear in multiple routes or serve different purposes within the same route, this code defines the fix's specific role at each occurrence, including fix type, fly-over or fly-by behavior, charting status, and route-function characteristics. Code "G" is used for Runway-as-Waypoint and Helipad-as-Waypoint entries.

## 5.18 - Boundary Code

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Identifies the geographic area boundary crossed by a continuous route, indicating the area being entered or exited when an enroute airway passes between adjacent geographical regions. Used to maintain route continuity and uniqueness when fixes are duplicated across boundary crossings.

## 5.19 - Level

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the airway structure classification to which the record belongs. Ex: "All Altitudes", "High Level Airways", "Low Level Airways"

## 5.20 - Turn Direction

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the required direction of turns within terminal procedures and course reversals: L=Left turn, R=Right turn, E=Either direction. Used in conjunction with Path and Termination definitions to define maneuvering requirements.

## 5.21 - Path and Termination

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 2
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the path geometry and termination condition for a single segment of an ATC terminal procedure. The field uses standardized Path and Termination codes to describe how the aircraft is to navigate the segment and where that segment ends, as defined in the Path and Terminator specification. Refer to ARINC 424 Attachment 5 for more info.

## 5.22 - Turn Direction Valid

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Indicates that a turn must be completed before intercepting the path defined by the Path and Termination leg: Y=Turn required prior to beginning the leg. The direction of the required turn is specified by the Turn Direction field.

## 5.23 - Recommended NAVAID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Specifies the recommended navigational aid (Navaid) to reference a waypoint or an airport/heliport, using a 1-4 character identifier. May include VHF, NDB, Localizer, TACAN, GLS, or MLS facilities. (Ex: P, PP, DEN, LAX, ILAX, MJFK).

## 5.24 - Theta

- SUMMARY
  - ???

- METADATA
  - Type: decimal
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the magnetic bearing from the Recommended Navaid to the waypoint identified by the Fix Identifier, expressed in degrees and tenths with the decimal suppressed. Values are derived from official sources when available and are used according to Path and Termination coding rules (Ex: 0000, 0756, 1217, 1800).

## 5.25 - Rho

- SUMMARY
  - ???

- METADATA
  - Type: decimal
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the geodesic distance from the Recommended Navaid to the waypoint identified by the Fix Identifier, expressed in nautical miles and tenths with the decimal suppressed. Values are derived from official sources when available and are used according to Path and Termination coding rules (Ex: 0000, 0216, 0142, 1074).

## 5.26 - Outbound Magnetic Course

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the published outbound magnetic course from the Fix Identifier waypoint and is also used for course, heading, and radial values in SID, STAR, and Approach procedures as required by Path and Termination coding rules. Values are expressed in degrees and tenths with the decimal suppressed; procedures charted in true degrees use a trailing “T” in place of the tenths digit.

## 5.27 - Route Distance From, Holding Distance/Time

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines a distance or holding value associated with the route segment. [Enroute Airways] Distance from the current Fix Identifier (5.13) to the next waypoint. [SID, STAR, Approach procedures] May represent segment distance, along-track distance, excursion distance, DME distance, or other values determined by the Path and Termination type. [Holding patterns], May contain holding time expressed in minutes and tenths, prefixed with “T”. Distances are recorded in nautical miles and tenths with the decimal suppressed (Ex: 1076, 2822, 0208, 0016), while holding times use the format T010 meaning "Time 1.0min".

## 5.28 - Inbound Magnetic Course

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the published inbound magnetic course to the waypoint identified by the Fix Identifier, expressed in degrees and tenths with the decimal suppressed. For routes charted in true degrees, the final character is “T” instead of the tenths digit. In SID, STAR, and Approach procedures, inbound course information for HX racetrack course-reversal legs is stored in the Outbound Magnetic Course field rather than a dedicated inbound course field (Ex: 2760, 0231, 194T).

## 5.29 - Altitude Description

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines how altitude constraints apply at a waypoint, including crossing at a specified altitude, at or above, at or below, between upper and lower limits, recommended altitudes, or cases where multiple altitude values are associated with the same fix.

## 5.30 - Altitude/Minimum Altitude

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 5
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the reference altitude associated with a route segment, holding pattern, terminal procedure fix, Path and Termination leg, or Preferred Route. Values may represent minimum enroute altitudes (MEA, MFA, etc.), holding altitudes, procedure altitudes, or the lowest altitude in a blocked-altitude range. Altitudes are expressed in feet with 1-foot resolution or as flight levels using the format “FL” followed by hundreds of feet.

## 5.31 - File Record Number

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 5
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Provides a sequential record number assigned during file assembly for housekeeping and reference purposes. Record numbers begin at 00001 and increment for each record in the file, restarting at 00000 after reaching 99999. Values may change with each file update and are not intended as permanent identifiers (Ex: 10640, 00420, 31462).

## 5.32 - Cycle Date [AIRAC Cycle ID]

- SUMMARY
  - ???

- METADATA
  - Type: int
  - MaxLength: 4
  - Trimmed: N
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies the AIRAC cycle in which the record was added or last revised. The first two digits represent the year, and the last two digits represent the 28-day update cycle number within that year. The value changes whenever most ARINC 424 data fields are modified, but remains unchanged if the record data has not changed. Changes to Dynamic Magnetic Variation, Frequency Protection, Continuation Record Number, or File Record Number do not require a Cycle Date update.

## 5.33 - VOR/NDB Identifier

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies the VHF, MF, or LF facility by its official government-assigned 1-4 character code (Ex: DEN, 6YA, PPI, TIKX).

## 5.34 - VOR/NDB Frequency

- SUMMARY
  - ???

- METADATA
  - Type: decimal
  - MaxLength: 5
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the operating frequency of the associated VOR or NDB NAVAID. VOR frequencies are encoded in MHz and NDB frequencies in kHz, with the decimal point suppressed. (Ex: VHF 11630=116.30 MHz, 11795=117.95 MHz __ NDB 03620=362.0 kHz, 17040=1704.0 kHz). FAA NOTE: If a VOR frequency is unavailable, the VOR Frequency field will contain 00000. For all other Navaids, an unavailable frequency will result in blank coding.

## 5.35 - NAVAID Class

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 5
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Provides a 5-character coded classification describing a NAVAID's type, usable range or power level, transmitted signal characteristics, and electronic or aeronautical collocation relationships. Each character position conveys specific classification information, with meanings varying by NAVAID type (VHF, NDB, Localizer, Marker, or Locator). FAA NOTE: Navaid Class 3 will be coded as "H" for high, "L" for low, and "T" for terminal altitude description. Where undetermined, the field will be coded with "U". Navaid Class 5 will carry an "N" for VORTACs if the VOR coordinates and the TACAN coordinates are 0.1 NM or greater distance from each other.

## 5.36 - Latitude

- SUMMARY
  - ???

- METADATA
  - Type: double
  - MaxLength: Variable
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the latitude of the navigational feature using one alpha character ('N' or 'S') followed by eight digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (Ex: N39513881).

## 5.37 - Longitude

- SUMMARY
  - ???

- METADATA
  - Type: double
  - MaxLength: Variable
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the longitude of the navigational feature, encoded as E or W followed by degrees, minutes, seconds, tenths, and hundredths of seconds with all separators suppressed. "E" is used for positions on the 0-degree or 180-degree meridians. (Ex: W104450794)

## 5.38 - DME ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies a DME, TACAN, or the DME component of a VOR/DME or VORTAC; blank if no DME exists or if VOR and DME share the same code, otherwise shows the DME identifier (Ex: MCR, DEN, IDVR, DN, blank).

## 5.39 - Magnetic Variation

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 5
  - Trimmed: Y
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the angular difference between True North and Magnetic North; format is one character (E, W, or T) followed by four digits for degrees and tenths (Ex: E0140, W0075, T0000). Note: Differences between Magnetic Variation and Dynamic-Magnetic Variation.

## 5.40 - DME Elevation

- SUMMARY
  - ???

- METADATA
  - Type: int
  - MaxLength: 5
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the elevation of a DME component in feet relative to MSL, using a leading - if below sea level (Ex: 00530, -0140).

## 5.41 - Region Code

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: Y
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Identifies whether a waypoint or holding pattern is enroute or terminal. "ENRT"=enroute waypoint/NAVAID. However, terminal waypoints and holding patterns use the associated airport identifier. For holding patterns, the value matches the classification of the holding fix. (Ex: ENRT, KLAX, 9V9)

## 5.42 - Waypoint Type

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 3
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the type and function of the waypoint per record type.

## 5.43 - Waypoint Name/Description

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 25
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Full name or definition waypoint.

## 5.44 - Localizer/MLS/GLS ID

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: Y
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Identifies the Localizer, MLS facility, or GLS Reference Path associated with the record. Runway records may contain two identifiers to support multiple landing systems serving the same runway, such as an ILS and an LDA. (Ex: Localizer=IDEN, ISTX, IDU, PP __ MLS=MDEN, MSTX, MLAX __ GLS=LFBL, EGLC, KSAN)

## 5.45 - Localizer Frequency

- SUMMARY
  - ???

- METADATA
  - Type: decimal
  - MaxLength: 5
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the VHF frequency of the associated localizer, encoded in MHz with 50 kHz resolution and the decimal point suppressed. (Ex: 11030=110.30 MHz, 11195=111.95 MHz)

## 5.46 - Runway Identifier

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 5
  - Trimmed: Y
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the runway ID associated with runway data or ILS/MLS records, formatted as “RW” plus a two-digit number (01–36) and optional suffix: C (Center), L (Left), R (Right), T (True degrees), or special types W (Water), S (Soft-surface), G (Glider), U (Ultralight), numeric (Assault Strip); e.g., RW26L, RW08R, RW26C, RW05, RW17T. Note: Non-numeric runway identifiers (5.46) are included and will not carry the prefixed ‘RW’ characters.

## 5.47 - Localizer Bearing

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Defines the magnetic bearing of the localizer course for an ILS or GLS approach, expressed in degrees and tenths with the decimal suppressed. If the course is charted in true degrees, the final character is "T" instead of the tenths digit. (Ex: 2570=257.0 deg __ 0147=14.7 deg __ 2910=291.0 deg __ 347T=347 deg True)

## 5.48 - Localizer Position

- SUMMARY
  - ???

- METADATA
  - Type: int
  - MaxLength: 4
  - Trimmed: N
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Specifies the distance in feet from the localizer, azimuth, or back azimuth antenna to the referenced runway end, with 1-foot resolution. (Ex: 0950=950 ft __ 1000=1000 ft)

## 5.49 - Localizer/Azimuth Position Reference

- SUMMARY
  - ???

- METADATA
  - Type: string
  - MaxLength: 1
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Indicates the antenna's position relative to the runway: [Localizer/Azimuth] "@"=beyond stop end __ "+"=ahead of approach end __ "-"=offset to one side of runway. [Back Azimuth] "@"=ahead of approach end __ "+"=beyond stop end __ "-"=offset to one side of runway

## 5.50 - Glide Slope Position

- SUMMARY
  - ???

- METADATA
  - Type: int
  - MaxLength: 4
  - Trimmed: N
  - Converted: N

- RETURNS
  - ???

- DETAILS
  - Specifies the distance in feet from the runway threshold to the glide slope or MLS elevation antenna, measured along a line perpendicular to the runway centerline at the antenna location, with 1-foot resolution. (Ex: 0980=980 ft __ 1417=1417 ft)

## 5.51 - Localizer Width

- SUMMARY
  - ???

- METADATA
  - Type: int
  - MaxLength: 4
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the localizer course width of an ILS facility, expressed in degrees, tenths, and hundredths with the decimal suppressed. (Ex: 0500=5.00 deg __ 0400=4.00 deg __ 0350=3.50 deg)

## 5.52 - Glide Slope Angle

- SUMMARY
  - ???

- METADATA
  - Type: decimal
  - MaxLength: 3
  - Trimmed: N
  - Converted: Y

- RETURNS
  - ???

- DETAILS
  - Specifies the glide slope angle for an ILS/GLS approach or the minimum authorized elevation angle for an MLS procedure, expressed in degrees, tenths, and hundredths with the decimal suppressed. (Ex: 275=2.75 deg __ 300=3.00 deg)

## 5.53 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.54 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.55 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.57 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.58 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.59 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.66 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.67 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.68 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.69 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.70 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.71 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.72 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.73 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.74 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.79 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.80 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.81 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.82 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.90 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.91 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.107 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.108 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.109 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.115 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.118 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.119 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.120 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.121 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.126 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.127 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.128 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.129 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.130 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.131 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.132 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.133 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.134 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.138 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.140 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.141 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.142 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.143 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.144 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.145 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.146 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.147 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.149 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.150 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.164 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.165 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.176 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.177 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.178 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.179 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.180 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.195 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.196 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.197 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.204 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.211 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.212 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.213 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.214 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.215 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.216 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.222 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.223 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.224 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.225 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.226 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.227 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.228 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.229 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.244 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.249 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.254 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.255 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.256 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.257 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.258 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.259 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.261 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.262 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.263 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.264 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.265 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.266 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.267 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.268 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.269 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.270 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.271 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.272 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.275 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???

## 5.276 - ???

- SUMMARY
  - ???

- METADATA
  - Type: ???
  - MaxLength: ???
  - Trimmed: ???
  - Converted: ???

- RETURNS
  - ???

- DETAILS
  - ???
