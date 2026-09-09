# CIFP Field Reference

Every ARINC 424 field the FAA CIFP actually uses, with what it carries, how it is encoded,
and what the parser hands back.

Built from ARINC 424-18 Chapter 5, ARINC 424-19A where the FAA applies it, ARINC 424
Attachment 5 for the path and terminator concept, and the FAA/AIS CIFP readme. Every value
table below was checked against the 396,430 records in FAACIFP18 cycle 2607, so each code is
marked with whether it actually appears in FAA data or is only defined by the standard.

## How to read an entry

- **SUMMARY** — one line on what the field carries.
- **METADATA** — length, type, whether the parser trims it, and whether a converter decodes it.
- **CONVERTER** — the `CifpFieldConverter` method that decodes this field, and its return type.
- **USED ON** — which record types carry it and at which zero-based column.
- **RETURNS** — what the converter hands back.
- **VALUES** — the full code table. `[observed]` means the code appears in cycle 2607;
  `[not in cycle]` means the standard defines it but the FAA does not currently use it.
- **DETAILS** — how the encoding works, in plain language.
- **FAA NOTES** — where the FAA deviates from, or pins down, the generic ARINC definition.
- **WATCH OUT** — traps found while validating against the real file.

A field marked *Never populated by the FAA* is defined by ARINC 424 and reserved in the record
layout, but blank on every record in the file. The property still exists so the column map stays
complete and so a future cycle that starts using it is picked up without a layout change.

---

## Index

- [5.2 — Record Type](#52-record-type)
- [5.3 — Customer/Area Code](#53-customerarea-code)
- [5.4 — Section Code](#54-section-code)
- [5.5 — Subsection Code](#55-subsection-code)
- [5.6 — Airport/Heliport Identifier](#56-airportheliport-identifier)
- [5.7 — Route Type](#57-route-type)
- [5.8 — Route Identifier](#58-route-identifier)
- [5.9 — SID/STAR Route Identifier](#59-sidstar-route-identifier)
- [5.10 — Approach Route Identifier](#510-approach-route-identifier)
- [5.11 — Transition Identifier](#511-transition-identifier)
- [5.12 — Sequence Number](#512-sequence-number)
- [5.13 — Fix Identifier](#513-fix-identifier)
- [5.14 — ICAO Code](#514-icao-code)
- [5.16 — Continuation Record Number](#516-continuation-record-number)
- [5.17 — Waypoint Description Code](#517-waypoint-description-code)
- [5.18 — Boundary Code](#518-boundary-code)
- [5.19 — Level](#519-level)
- [5.20 — Turn Direction](#520-turn-direction)
- [5.21 — Path and Termination](#521-path-and-termination)
- [5.22 — Turn Direction Valid](#522-turn-direction-valid)
- [5.23 — Recommended NAVAID](#523-recommended-navaid)
- [5.24 — Theta](#524-theta)
- [5.25 — Rho](#525-rho)
- [5.26 — Outbound Magnetic Course](#526-outbound-magnetic-course)
- [5.27 — Route Distance From / Holding Distance or Time](#527-route-distance-from--holding-distance-or-time)
- [5.28 — Inbound Magnetic Course](#528-inbound-magnetic-course)
- [5.29 — Altitude Description](#529-altitude-description)
- [5.30 — Altitude/Minimum Altitude](#530-altitudeminimum-altitude)
- [5.31 — File Record Number](#531-file-record-number)
- [5.32 — Cycle Date](#532-cycle-date)
- [5.33 — VOR/NDB Identifier](#533-vorndb-identifier)
- [5.34 — VOR/NDB Frequency](#534-vorndb-frequency)
- [5.35 — NAVAID Class](#535-navaid-class)
- [5.36 — Latitude](#536-latitude)
- [5.37 — Longitude](#537-longitude)
- [5.38 — DME Identifier](#538-dme-identifier)
- [5.39 — Magnetic Variation](#539-magnetic-variation)
- [5.40 — DME Elevation](#540-dme-elevation)
- [5.41 — Region Code](#541-region-code)
- [5.42 — Waypoint Type](#542-waypoint-type)
- [5.43 — Waypoint Name/Description](#543-waypoint-namedescription)
- [5.44 — Localizer/MLS/GLS Identifier](#544-localizermlsgls-identifier)
- [5.45 — Localizer Frequency](#545-localizer-frequency)
- [5.46 — Runway Identifier](#546-runway-identifier)
- [5.47 — Localizer Bearing](#547-localizer-bearing)
- [5.48 — Localizer Position](#548-localizer-position)
- [5.49 — Localizer/Azimuth Position Reference](#549-localizerazimuth-position-reference)
- [5.50 — Glide Slope Position / Elevation Position](#550-glide-slope-position--elevation-position)
- [5.51 — Localizer Width](#551-localizer-width)
- [5.52 — Glide Slope Angle / Minimum Elevation Angle](#552-glide-slope-angle--minimum-elevation-angle)
- [5.53 — Transition Altitude / Transition Level](#553-transition-altitude--transition-level)
- [5.54 — Longest Runway](#554-longest-runway)
- [5.55 — Airport/Heliport Elevation](#555-airportheliport-elevation)
- [5.57 — Runway Length](#557-runway-length)
- [5.58 — Runway Magnetic Bearing](#558-runway-magnetic-bearing)
- [5.59 — Runway Description](#559-runway-description)
- [5.66 — Station Declination](#566-station-declination)
- [5.67 — Threshold Crossing Height](#567-threshold-crossing-height)
- [5.68 — Landing Threshold Elevation](#568-landing-threshold-elevation)
- [5.69 — Threshold Displacement Distance](#569-threshold-displacement-distance)
- [5.70 — Vertical Angle](#570-vertical-angle)
- [5.71 — Name Field](#571-name-field)
- [5.72 — Speed Limit](#572-speed-limit)
- [5.73 — Speed Limit Altitude](#573-speed-limit-altitude)
- [5.74 — Component Elevation](#574-component-elevation)
- [5.79 — Stopway](#579-stopway)
- [5.80 — ILS/MLS/GLS Category](#580-ilsmlsgls-category)
- [5.81 — ATC Indicator](#581-atc-indicator)
- [5.82 — Waypoint Usage](#582-waypoint-usage)
- [5.90 — ILS/DME Bias](#590-ilsdme-bias)
- [5.91 — Continuation Record Application Type](#591-continuation-record-application-type)
- [5.107 — ATA/IATA Designator](#5107-ataiata-designator)
- [5.108 — IFR Capability](#5108-ifr-capability)
- [5.109 — Runway Width](#5109-runway-width)
- [5.115 — Directional Restriction](#5115-directional-restriction)
- [5.118 — Boundary Via](#5118-boundary-via)
- [5.119 — Arc Distance](#5119-arc-distance)
- [5.120 — Arc Bearing](#5120-arc-bearing)
- [5.121 — Lower/Upper Limit](#5121-lowerupper-limit)
- [5.126 — Restrictive Airspace Name](#5126-restrictive-airspace-name)
- [5.127 — Maximum Altitude](#5127-maximum-altitude)
- [5.128 — Restrictive Airspace Type](#5128-restrictive-airspace-type)
- [5.129 — Restrictive Airspace Designation](#5129-restrictive-airspace-designation)
- [5.130 — Multiple Code](#5130-multiple-code)
- [5.131 — Time Code](#5131-time-code)
- [5.132 — NOTAM](#5132-notam)
- [5.133 — Unit Indicator](#5133-unit-indicator)
- [5.134 — Cruise Table Identifier](#5134-cruise-table-identifier)
- [5.138 — Time Indicator](#5138-time-indicator)
- [5.140 — Controlling Agency](#5140-controlling-agency)
- [5.141 — Starting Latitude](#5141-starting-latitude)
- [5.142 — Starting Longitude](#5142-starting-longitude)
- [5.143 — Grid MORA](#5143-grid-mora)
- [5.144 — Center Fix](#5144-center-fix)
- [5.145 — Radius Limit](#5145-radius-limit)
- [5.146 — Sector Bearing](#5146-sector-bearing)
- [5.147 — Sector Altitude](#5147-sector-altitude)
- [5.149 — Figure of Merit](#5149-figure-of-merit)
- [5.150 — Frequency Protection Distance](#5150-frequency-protection-distance)
- [5.164 — EU Indicator](#5164-eu-indicator)
- [5.165 — Magnetic/True Indicator](#5165-magnetictrue-indicator)
- [5.176 — Pad Dimensions](#5176-pad-dimensions)
- [5.177 — Public/Military Indicator](#5177-publicmilitary-indicator)
- [5.178 — Time Zone](#5178-time-zone)
- [5.179 — Daylight Time Indicator](#5179-daylight-time-indicator)
- [5.180 — Pad Identifier](#5180-pad-identifier)
- [5.195 — Time of Operation](#5195-time-of-operation)
- [5.196 — Name Format Indicator](#5196-name-format-indicator)
- [5.197 — Datum Code](#5197-datum-code)
- [5.204 — ARC Radius](#5204-arc-radius)
- [5.211 — Required Navigation Performance](#5211-required-navigation-performance)
- [5.212 — Runway Gradient](#5212-runway-gradient)
- [5.213 — Controlled Airspace Type](#5213-controlled-airspace-type)
- [5.214 — Controlled Airspace Center](#5214-controlled-airspace-center)
- [5.215 — Controlled Airspace Classification](#5215-controlled-airspace-classification)
- [5.216 — Controlled Airspace Name](#5216-controlled-airspace-name)
- [5.222 — GNSS/FMS Indicator](#5222-gnssfms-indicator)
- [5.223 — Operation Type](#5223-operation-type)
- [5.224 — Route Indicator](#5224-route-indicator)
- [5.225 — Ellipsoidal Height](#5225-ellipsoidal-height)
- [5.226 — Glide Path Angle](#5226-glide-path-angle)
- [5.227 — Orthometric Height](#5227-orthometric-height)
- [5.228 — Course Width At Threshold](#5228-course-width-at-threshold)
- [5.229 — Final Approach Segment Data CRC Remainder](#5229-final-approach-segment-data-crc-remainder)
- [5.244 — GLS Channel / GNSS Channel Number](#5244-gls-channel--gnss-channel-number)
- [5.249 — Longest Runway Surface Code](#5249-longest-runway-surface-code)
- [5.254 — Fixed Radius Transition Indicator](#5254-fixed-radius-transition-indicator)
- [5.255 — SBAS Service Provider Identifier](#5255-sbas-service-provider-identifier)
- [5.256 — Reference Path Data Selector](#5256-reference-path-data-selector)
- [5.257 — Reference Path Identifier](#5257-reference-path-identifier)
- [5.258 — Approach Performance Designator](#5258-approach-performance-designator)
- [5.259 — Length Offset](#5259-length-offset)
- [5.261 — Speed Limit Description](#5261-speed-limit-description)
- [5.262 — Approach Type Identifier](#5262-approach-type-identifier)
- [5.263 — Horizontal Alert Limit](#5263-horizontal-alert-limit)
- [5.264 — Vertical Alert Limit](#5264-vertical-alert-limit)
- [5.265 — Path Point TCH](#5265-path-point-tch)
- [5.266 — TCH Units Indicator](#5266-tch-units-indicator)
- [5.267 — High Precision Latitude](#5267-high-precision-latitude)
- [5.268 — High Precision Longitude](#5268-high-precision-longitude)
- [5.269 — Helicopter Procedure Course](#5269-helicopter-procedure-course)
- [5.270 — TCH Value Indicator](#5270-tch-value-indicator)
- [5.271 — Procedure Turn](#5271-procedure-turn)
- [5.272 — TAA Sector Identifier](#5272-taa-sector-identifier)
- [5.275 — Level of Service Name](#5275-level-of-service-name)
- [5.276 — Level of Service Authorized](#5276-level-of-service-authorized)
- [5.297 — RNP Level of Service](#5297-rnp-level-of-service)

---

### 5.2 - Record Type

- SUMMARY
  - Column 1 flag saying whether the record belongs to the universally applicable dataset or to a customer-
    specific tailored set.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: S/T
  - When blank: Should not occur. Every 132-character CIFP row begins with this flag; a blank here means the line
    is not a data record (for example a file header) or the read is misaligned.

- CONVERTER
  - `CifpFieldConverter.Field52()` returns `string`

- USED ON
  - `AS` — col 0 (Record Type)
  - `D` — col 0 (Record Type)
  - `DB` — col 0 (Record Type)
  - `EA` — col 0 (Record Type)
  - `ER` — col 0 (Record Type)
  - `HA` — col 0 (Record Type)
  - `HC` — col 0 (Record Type)
  - `HD` — col 0 (Record Type)
  - `HF` — col 0 (Record Type)
  - `HF~cont` — col 0 (Record Type)
  - `HS` — col 0 (Record Type)
  - `PA` — col 0 (Record Type)
  - `PC` — col 0 (Record Type)
  - `PD` — col 0 (Record Type)
  - `PE` — col 0 (Record Type)
  - `PF` — col 0 (Record Type)
  - `PF~cont` — col 0 (Record Type)
  - `PG` — col 0 (Record Type)
  - `PI` — col 0 (Record Type)
  - `PN` — col 0 (Record Type)
  - `PP` — col 0 (Record Type)
  - `PP~cont` — col 0 (Record Type)
  - `PS` — col 0 (Record Type)
  - `UC` — col 0 (Record Type)
  - `UR` — col 0 (Record Type)
  - `UR~cont` — col 0 (Record Type)

- RETURNS
  - A RecordType enum value (Standard / Tailored), or null when the character is neither S nor T.

- VALUES
  - `S` [observed] — Standard - data suitable for any user of the dataset.
  - `T` [not in cycle] — Tailored - data placed on the file for one specific customer's use only.

- OBSERVED IN CYCLE 2607
  - `S`

- DETAILS
  - This is the very first character of every record and is the cheapest sanity check a
  - reader has: if position 0 is not 'S' (or 'T'), the line is not a normal ARINC 424 data
  - record. 'S' marks data intended for everybody; 'T' marks data a supplier added for one
  - named customer and which is not part of the general product. The FAA CIFP is a public
  - product, so every record in FAACIFP18 carries 'S'. Parsers should still recognise 'T'
  - rather than reject it, because the byte is legal in the standard.

- FAA NOTES
  - The FAA readme does not discuss this field. Across all 396,430 records the value is
  - always 'S'.

---

### 5.3 - Customer/Area Code

- SUMMARY
  - Three-letter code grouping each record into a broad geographic region (or, in airline-tailored files, naming
    the airline the record was built for).

- METADATA
  - Length: 3 characters
  - Character type: alpha
  - Kind: enum
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: CUST/AREA
  - Format: Three upper-case letters, no padding needed (all codes are exactly 3 characters).
  - When blank: The record type does not follow geographic boundaries, so no area applies. Never observed blank
    anywhere in the CIFP.

- USED ON
  - `D` — col 1-3 (Customer/Area Code)
  - `DB` — col 1-3 (Customer/Area Code)
  - `EA` — col 1-3 (Customer/Area Code)
  - `ER` — col 1-3 (Customer/Area Code)
  - `HA` — col 1-3 (Customer/Area Code)
  - `HC` — col 1-3 (Customer/Area Code)
  - `HD` — col 1-3 (Customer/Area Code)
  - `HF` — col 1-3 (Customer/Area Code)
  - `HF~cont` — col 1-3 (Customer/Area Code)
  - `HS` — col 1-3 (Customer/Area Code)
  - `PA` — col 1-3 (Customer/Area Code)
  - `PC` — col 1-3 (Customer/Area Code)
  - `PD` — col 1-3 (Customer/Area Code)
  - `PE` — col 1-3 (Customer/Area Code)
  - `PF` — col 1-3 (Customer/Area Code)
  - `PF~cont` — col 1-3 (Customer/Area Code)
  - `PG` — col 1-3 (Customer/Area Code)
  - `PI` — col 1-3 (Customer/Area Code)
  - `PN` — col 1-3 (Customer/Area Code)
  - `PP` — col 1-3 (Customer/Area Code)
  - `PP~cont` — col 1-3 (Customer/Area Code)
  - `PS` — col 1-3 (Customer/Area Code)
  - `UC` — col 1-3 (Customer/Area Code)
  - `UR` — col 1-3 (Customer/Area Code)
  - `UR~cont` — col 1-3 (Customer/Area Code)

- RETURNS
  - The trimmed three-letter code, or null when the slice is all blanks. A parser may additionally surface it as
    an AreaCode enum with the ten geographic members above.

- VALUES
  - `USA` [observed] — Continental United States
  - `CAN` [observed] — Canada and Alaska
  - `PAC` [observed] — Pacific
  - `LAM` [observed] — Latin America
  - `SAM` [not in cycle] — South America
  - `SPA` [observed] — South Pacific
  - `EUR` [not in cycle] — Europe
  - `EEU` [observed] — Eastern Europe
  - `MES` [not in cycle] — Middle East and South Asia
  - `AFR` [not in cycle] — Africa
  - `PDR` [not in cycle] — Preferred Route record marker (not an area). The FAA publishes no Preferred Route records, so this never appears.

- OBSERVED IN CYCLE 2607
  - `CAN`, `EEU`, `LAM`, `PAC`, `SPA`, `USA`

- DETAILS
  - In a standard (non-tailored) file this field buckets the record into one of ten
  - world regions. The FAA CIFP is a standard file, so the field always holds a
  - geographic area code, never an airline code and never the 'PDR' value reserved
  - for Preferred Route records. It sits at offsets 1-3 of every record and is
  - constant per record - it is not a per-fix pointer.
  - The area assigned reflects where the coded feature physically lies, which is why
  - a US-published dataset still contains Canadian, Pacific, Latin American and even
  - Eastern European entries: the FAA codes some foreign fixes that its own
  - procedures and airways reference.

- FAA NOTES
  - Fixes that NASR classifies as 'Offshore' may be given a Customer/Area Code of USA
  - paired with an ICAO Code (5.14) of 'K ' or 'P ' (single letter plus a blank).
  - Terminal waypoint (PC) records inherit the Customer/Area Code of their parent
  - airport regardless of where the waypoint itself sits, even though those same PC
  - records keep their own distinct ICAO Code (5.14). Do not infer geography for a PC
  - waypoint from this field.

- ARINC 424-19A DIFFERENCE
  - No substantive change; 424-19A only adds typographic quotation marks.

- WATCH OUT
  - Twelve enroute waypoint (EA) records carry 'EEU' (Eastern Europe) in a dataset that
  - is otherwise USA/CAN/PAC/LAM/SPA. Treat any non-USA value as legitimate rather than
  - as corruption, but do not assume the set is closed to the six observed codes - the
  - FAA can emit any of the ten standard area codes.

---

### 5.4 - Section Code

- SUMMARY
  - One letter naming the major database section a record belongs to - or, on pointer fields, the section of the
    record being referenced.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: SEC CODE
  - Format: Single upper-case letter, or blank on pointer instances.
  - When blank: On the reference instances of the field (Fix Section, Recommended NAVAID Section, Point Section,
    MSA Center Section) a blank means no record is being pointed at. The record's own Section Code at offset 4 is
    never blank.

- USED ON
  - `AS` — col 4 (Section Code)
  - `D` — col 4 (Section Code)
  - `DB` — col 4 (Section Code)
  - `EA` — col 4 (Section Code)
  - `ER` — col 4 (Section Code); col 36 (Section Code)
  - `HA` — col 4 (Section Code)
  - `HC` — col 4 (Section Code)
  - `HD` — col 4 (Section Code); col 36 (Fix Section Code); col 78 (RECD NAV Section); col 114 (Point Section Code)
  - `HF` — col 4 (Section Code); col 36 (Fix Section Code); col 78 (RECD NAV Section); col 114 (Point Section Code)
  - `HF~cont` — col 4 (Section Code); col 36 (Fix Section Code)
  - `HS` — col 4 (Section Code); col 20 (MSA Center Section Code)
  - `PA` — col 4 (Section Code)
  - `PC` — col 4 (Section Code)
  - `PD` — col 4 (Section Code); col 36 (Fix Section Code); col 78 (RECD NAV Section); col 114 (Point Section Code)
  - `PE` — col 4 (Section Code); col 36 (Fix Section Code); col 78 (RECD NAV Section); col 114 (Point Section Code)
  - `PF` — col 4 (Section Code); col 36 (Fix Section Code); col 78 (RECD NAV Section); col 114 (Point Section Code)
  - `PF~cont` — col 4 (Section Code); col 36 (Fix Section Code)
  - `PG` — col 4 (Section Code)
  - `PI` — col 4 (Section Code); col 108 (Supporting Facility Section Code)
  - `PN` — col 4 (Section Code)
  - `PP` — col 4 (Section Code)
  - `PP~cont` — col 4 (Section Code)
  - `PS` — col 4 (Section Code); col 20 (MSA Section Code)
  - `UC` — col 4 (Section Code); col 14 (Section Code)
  - `UR` — col 4 (Section Code)
  - `UR~cont` — col 4 (Section Code)

- RETURNS
  - The single character, unmodified, including a blank when the pointer instance is empty. Model as char? with
    null for blank on the pointer instances.

- VALUES
  - `A` [observed] — MORA (minimum off-route altitude grid)
  - `D` [observed] — NAVAID (VHF and NDB)
  - `E` [observed] — Enroute data (waypoints, airways, markers, holding, communications)
  - `H` [observed] — Heliport and heliport terminal data
  - `P` [observed] — Airport and airport terminal data
  - `R` [not in cycle] — Company routes
  - `T` [not in cycle] — Tables (cruising tables)
  - `G` [not in cycle] — Geographical reference (RNAV name table)
  - `U` [observed] — Airspace (controlled, FIR/UIR, restrictive)

- OBSERVED IN CYCLE 2607
  - `A`, `D`, `E`, `H`, `P`, `U`, ` `

- DETAILS
  - Section Code is the first half of the two-character record key. On the record's own
  - identity it always lives at offset 4. It is never sufficient by itself: 'P' covers
  - airports, runways, localizers, path points, terminal waypoints, terminal NDBs, SIDs,
  - STARs, approaches and MSAs alike, so it must always be read together with the
  - Subsection Code (5.5). See 5_5.yaml for the full section/subsection matrix and for
  - the crucial fact that the subsection is NOT always at a fixed offset.
  - The same field reference is reused several times inside a single record as a pointer
  - to another record. In SID/STAR/Approach records those pointer instances are the Fix
  - Section Code (offset 36), the Recommended NAVAID Section (offset 78) and the Point
  - Section Code (offset 114); in MSA records it is the MSA Center Section Code (offset
  - 20); in Enroute Airway records the fix section is at offset 36; in Localizer records
  - the Supporting Facility Section Code is at offset 108. Those instances are blank
  - whenever no reference is coded, so the parser must NOT trim them into empty strings
  - and then treat them as an error.

- FAA NOTES
  - The FAA readme does not call this field out directly, but it fixes the set of
  - sections the CIFP can contain: A (Grid MORA), D (VHF and NDB NAVAIDs), E (enroute
  - waypoints and airways), H (heliports and heli terminal data), P (airport and
  - terminal data) and U (controlled and special use airspace). No other section is
  - produced.

- ARINC 424-19A DIFFERENCE
  - The section list is unchanged in 424-19A. Only the subsection list grows (see 5.5).
  - Note that the automated extraction of the 424-19A text for '5.4' captured an
  - unrelated paragraph from Attachment 5, not the Section Code definition - do not
  - rely on /home/claude/cifp/fields/v19/5_4.txt.

- WATCH OUT
  - The five HDR (header) records at the top of the file are NOT ARINC data records but
  - are still 132 characters. At offset 4 they carry the digits '1'-'5' (from the literal
  - text HDR01..HDR05), so a naive dispatcher keyed on offset 4 will see section codes
  - '1','2','3','4','5'. Skip any line whose first three characters are 'HDR' before
  - dispatching.
  - The FAA's own header record is additionally shifted: per the readme, the Creation
  - Date on Header Record 1 drops a leading zero, so Creation Date, Creation Time and
  - Data Supplier are all one column to the left of the ARINC positions.

---

### 5.5 - Subsection Code

- SUMMARY
  - One letter that, combined with the Section Code, names the exact file a record belongs to - the primary key
    for record dispatch.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: SUB CODE
  - Format: Single upper-case letter, or blank (blank is itself a valid code under Section D).
  - When blank: Depends on context. Under Section D a blank subsection IS the code for a VHF NAVAID. On waypoint
    records the unused one of the two subsection slots is blank. On pointer instances a blank means no record is
    referenced.

- USED ON
  - `AS` — col 5 (Subsection Code)
  - `D` — col 5 (Subsection Code)
  - `DB` — col 5 (Subsection Code)
  - `EA` — col 5 (Subsection Code); col 12 (Subsection)
  - `ER` — col 5 (Subsection Code); col 37 (Subsection)
  - `HA` — col 12 (Subsection Code)
  - `HC` — col 12 (Subsection Code)
  - `HD` — col 12 (Subsection Code); col 37 (Fix Subsection Code); col 79 (RECD NAV Subsection); col 115 (Point Subsection Code)
  - `HF` — col 12 (Subsection Code); col 37 (Fix Subsection Code); col 79 (RECD NAV Subsection); col 115 (Point Subsection Code)
  - `HF~cont` — col 12 (Subsection Code); col 37 (Fix Subsection Code)
  - `HS` — col 12 (Subsection Code); col 21 (MSA Center Subsection Code)
  - `PA` — col 12 (Subsection Code)
  - `PC` — col 12 (Subsection Code)
  - `PD` — col 12 (Subsection Code); col 37 (Fix Subsection Code); col 79 (RECD NAV Subsection); col 115 (Point Subsection Code)
  - `PE` — col 12 (Subsection Code); col 37 (Fix Subsection Code); col 79 (RECD NAV Subsection); col 115 (Point Subsection Code)
  - `PF` — col 12 (Subsection Code); col 37 (Fix Subsection Code); col 79 (RECD NAV Subsection); col 115 (Point Subsection Code)
  - `PF~cont` — col 12 (Subsection Code); col 37 (Fix Subsection Code)
  - `PG` — col 12 (Subsection Code)
  - `PI` — col 12 (Subsection); col 109 (Supporting Facility Subsection Code)
  - `PN` — col 5 (Subsection Code)
  - `PP` — col 12 (Subsection Code)
  - `PP~cont` — col 12 (Subsection Code)
  - `PS` — col 12 (Subsection Code); col 21 (MSA Subsection Code)
  - `UC` — col 5 (Subsection Code); col 15 (Subsection Code)
  - `UR` — col 5 (Subsection Code)
  - `UR~cont` — col 5 (Subsection Code)

- RETURNS
  - The single character, unmodified. Combine with 5.4 into a two-character record key such as 'PF' or 'D ' (note
    the trailing blank for VHF NAVAID) and dispatch on that.

- VALUES
  - `A|S` [observed] — Section A (MORA) + S = Grid MORA. Produced by the FAA.
  - `D| ` [observed] — Section D (NAVAID) + blank = VHF NAVAID (VOR, VOR/DME, VORTAC, TACAN, ILS/DME, MLS/DME). Produced by the FAA.
  - `D|B` [observed] — Section D + B = NDB NAVAID. Produced by the FAA.
  - `D|T` [not in cycle] — Section D + T = TACAN duplicates. Added in 424-19A only; not in the FAA CIFP.
  - `E|A` [observed] — Section E (Enroute) + A = enroute waypoints. Produced by the FAA.
  - `E|M` [not in cycle] — Section E + M = airway markers. Not in the FAA CIFP.
  - `E|P` [not in cycle] — Section E + P = holding patterns. Not in the FAA CIFP (see the FAA note on Waypoint Description Code H).
  - `E|R` [observed] — Section E + R = airways and routes. Produced by the FAA.
  - `E|T` [not in cycle] — Section E + T = preferred routes. Not in the FAA CIFP.
  - `E|U` [not in cycle] — Section E + U = airway restrictions. Not in the FAA CIFP.
  - `E|V` [not in cycle] — Section E + V = enroute communications. Not in the FAA CIFP.
  - `H|A` [observed] — Section H (Heliport) + A = heliport reference points (pads). Produced by the FAA.
  - `H|C` [observed] — Section H + C = heliport terminal waypoints. Produced by the FAA.
  - `H|D` [observed] — Section H + D = heliport SIDs. Fifteen records carry H at offset 4 and D at offset 12 but the FAA readme does not list heliport SIDs as a CIFP record type - see anomalies.
  - `H|E` [not in cycle] — Section H + E = heliport STARs. Not in the FAA CIFP.
  - `H|F` [observed] — Section H + F = heliport approach procedures (primary and Level of Service continuation). Produced by the FAA.
  - `H|K` [not in cycle] — Section H + K = heliport TAA. Not in the FAA CIFP.
  - `H|S` [observed] — Section H + S = heliport MSA. Produced by the FAA.
  - `H|V` [not in cycle] — Section H + V = heliport communications. Not in the FAA CIFP.
  - `P|A` [observed] — Section P (Airport) + A = airport reference points. Produced by the FAA.
  - `P|B` [not in cycle] — Section P + B = gates. Not in the FAA CIFP.
  - `P|C` [observed] — Section P + C = airport terminal waypoints. Produced by the FAA. Subsection is at offset 12; offset 5 is blank.
  - `P|D` [observed] — Section P + D = SIDs. Produced by the FAA.
  - `P|E` [observed] — Section P + E = STARs. Produced by the FAA.
  - `P|F` [observed] — Section P + F = approach procedures (primary and Level of Service continuation). Produced by the FAA.
  - `P|G` [observed] — Section P + G = runways. Produced by the FAA.
  - `P|I` [observed] — Section P + I = localizer and glide slope. Produced by the FAA.
  - `P|K` [not in cycle] — Section P + K = terminal arrival altitudes (TAA). Not in the FAA CIFP - this is why 5.271 and 5.272 are never populated.
  - `P|L` [not in cycle] — Section P + L = MLS. Not in the FAA CIFP.
  - `P|M` [not in cycle] — Section P + M = localizer marker / locator. Not in the FAA CIFP.
  - `P|N` [observed] — Section P + N = terminal NDB. Produced by the FAA. Subsection is at offset 5, not offset 12.
  - `P|P` [observed] — Section P + P = path point (primary and continuation). Produced by the FAA.
  - `P|R` [not in cycle] — Section P + R = flight planning arrival/departure. Not in the FAA CIFP.
  - `P|S` [observed] — Section P + S = airport MSA. Produced by the FAA.
  - `P|T` [not in cycle] — Section P + T = GLS station. Not in the FAA CIFP.
  - `P|V` [not in cycle] — Section P + V = airport communications. Not in the FAA CIFP.
  - `R| ` [not in cycle] — Section R (Company Routes) + blank = company routes. Not in the FAA CIFP.
  - `R|A` [not in cycle] — Section R + A = alternate records. Not in the FAA CIFP.
  - `R|H` [not in cycle] — Section R + H = helicopter operation company routes. Added in 424-19A only; not in the FAA CIFP.
  - `T|C` [not in cycle] — Section T (Tables) + C = cruising tables. Not in the FAA CIFP.
  - `T|V` [not in cycle] — Section T + V = communication type translation. Added in 424-19A only; not in the FAA CIFP.
  - `G|N` [not in cycle] — Section G (Geographical Reference) + N = RNAV name table. Not in the FAA CIFP.
  - `U|C` [observed] — Section U (Airspace) + C = controlled airspace. Produced by the FAA (Class B, C and D).
  - `U|F` [not in cycle] — Section U + F = FIR/UIR. Not in the FAA CIFP.
  - `U|R` [observed] — Section U + R = restrictive airspace (primary and continuation). Produced by the FAA (special use airspace).

- OBSERVED IN CYCLE 2607
  - ` `, `A`, `B`, `C`, `D`, `E`, `F`, `G`, `I`, `N`, `P`, `R`, `S`

- DETAILS
  - Section Code (5.4) plus Subsection Code (5.5) is the record's type. The same pair is
  - reused as a pointer inside records to say what kind of record a referenced fix is.
  - CRITICAL - the subsection is not at a single fixed offset. Three different layouts
  - exist in the FAA CIFP:
  - offset 5 Grid MORA (AS), VHF NAVAID (D + blank), NDB NAVAID (DB),
  - Terminal NDB (PN), Enroute Waypoint (EA), Enroute Airway (ER),
  - Controlled Airspace (UC), Restrictive Airspace (UR)
  - offset 12 Airport (PA), Runway (PG), Localizer/Glide Slope (PI),
  - Path Point (PP), SID (PD), STAR (PE), Approach (PF), MSA (PS),
  - Heliport (HA), Heli Approach (HF), Heli MSA (HS)
  - both Waypoint records carry a subsection slot at offset 5 AND at offset 12
  - and use exactly one of them. Enroute waypoints put 'A' at offset 5 and
  - leave offset 12 blank; airport and heliport terminal waypoints leave
  - offset 5 blank and put 'C' at offset 12.
  - Terminal NDB (PN) is the exception that breaks the 'P means offset 12' rule: it
  - follows the NDB record layout and carries its 'N' at offset 5. A correct dispatcher
  - is therefore: read offset 4; for D/E/A/U read offset 5; for P read offset 5 first and
  - accept 'C' or 'N' there, otherwise read offset 12; for H read offset 12.
  - Pointer instances of this field in the FAA CIFP are: Fix Subsection Code (offset 37
  - on airways and on SID/STAR/Approach), Recommended NAVAID Subsection (offset 79),
  - Point Subsection Code (offset 115), MSA Center Subsection Code (offset 21),
  - Controlled Airspace Center Subsection (offset 15) and Localizer Supporting Facility
  - Subsection (offset 109).

- FAA NOTES
  - The CIFP contains only these twenty-one record kinds: AS, D (blank subsection), DB,
  - PN, PA, HA, PG, PI, PP (primary and continuation), PS, HS, EA, PC, HC, PD, PE, PF
  - (primary and Level of Service continuation), HF (primary and Level of Service
  - continuation), ER, UC, UR (primary and continuation). Everything else in the ARINC
  - matrix below is absent.
  - The FAA chooses between PC and EA for a named terminal waypoint: PC is used when the
  - waypoint serves exactly one airport and is not on an enroute airway; otherwise EA.
  - PC is also used for some unnamed terminal waypoints. Likewise PN is used for an NDB
  - only when it serves one airport, is not on an airway and has a five-letter name;
  - otherwise DB.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds three subsections to the matrix: D/T (TACAN duplicates), R/H (helicopter
  - operation company routes) and T/V (communication type translation), and relabels the
  - blank company-route subsection as the Master Airline File. None of these appear in
  - the FAA CIFP.

- WATCH OUT
  - 1. The subsection offset is layout-dependent (5 vs 12), and waypoint records carry
  - two subsection slots of which exactly one is populated. A dispatcher that reads a
  - single fixed offset silently loses records. The project's RecordIdIndexies.json
  - lists SubsectionIndex 5 for PC and HC; with that table 37,635 PC/HC records in the
  - 396,430-record file fail to classify. The correct index for PC and HC is 12.
  - 2. Fifteen records have Section H with 'D' at offset 12 (heliport SIDs), a record type
  - the FAA readme does not list and for which no layout CSV exists. Decide explicitly
  - whether to parse or skip them rather than letting them fall through.
  - 3. Under Section U, offset 12 is NOT a subsection - it is part of another field - so a
  - 'read offset 12 for everything' shortcut produces dozens of phantom subsection
  - codes for UC and UR records.
  - 4. On MSA records the MSA Center Subsection (offset 21) is frequently blank even
  - though a center fix identifier is present, and it also takes values (G = runway,
  - A, B, C, N) that point at record kinds outside the waypoint sections.

---

### 5.6 - Airport/Heliport Identifier

- SUMMARY
  - Four-character identifier of the airport or heliport that owns, or is referenced by, the data in the record.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: ARPT/HELI IDENT
  - When blank: The record is not tied to a single airport or heliport (enroute VHF NAVAIDs and all NDB NAVAID
    records leave it blank).

- USED ON
  - `D` — col 6-9 (Airport ICAO Identifier)
  - `DB` — col 6-9 (Airport ICAO Identifier)
  - `HA` — col 6-9 (Heliport Identifier)
  - `HC` — col 6-9 (Airport/Heliport Identifier)
  - `HD` — col 6-9 (Airport Identifier)
  - `HF` — col 6-9 (Airport Identifier)
  - `HF~cont` — col 6-9 (Airport Identifier)
  - `HS` — col 6-9 (Heliport Identifier)
  - `PA` — col 6-9 (Airport ICAO Identifier)
  - `PC` — col 6-9 (Airport/Heliport Identifier)
  - `PD` — col 6-9 (Airport Identifier)
  - `PE` — col 6-9 (Airport Identifier)
  - `PF` — col 6-9 (Airport Identifier)
  - `PF~cont` — col 6-9 (Airport Identifier)
  - `PG` — col 6-9 (Airport ICAO Identifier)
  - `PI` — col 6-9 (Airport Identifier)
  - `PN` — col 6-9 (Airport ICAO Identifier)
  - `PP` — col 6-9 (Airport Identifier)
  - `PP~cont` — col 6-9 (Airport Identifier)
  - `PS` — col 6-9 (Airport Identifier)

- RETURNS
  - Trimmed identifier string, or null when the four columns are blank.

- OBSERVED IN CYCLE 2607
  - `    `, `##A `, `##AK`, `##FL`, `AZ##`, `K###`, `KJFK`, `M## `, `OH##`, `XA##`

- DETAILS
  - Left-justified, blank-padded to four columns. The CIFP uses the published ICAO location
  - identifier when one exists; otherwise the published FAA identifier is used, which is often
  - only three characters and therefore leaves column four blank. Values are drawn from
  - [A-Z0-9] only. Inside the United States the leading "K"/"P" of an ICAO identifier is the
  - usual ICAO-lookalike convention, but the CIFP is full of bare three-character FAA
  - identifiers such as "00A", "M17" and "OH74", so do not assume four characters or a
  - leading letter.
  - In the FAACIFP18 file this field sits at zero-based offset 6, length 4, on: D (VHF NAVAID),
  - DB (NDB NAVAID), PN (terminal NDB), PA (airport), HA (heliport), PG (runway), PI
  - (localizer/glide slope), PS/HS (MSA), PP (path point, primary and continuation),
  - PD (SID), PE (STAR), PF/HF (approach, primary and continuation) and the undocumented
  - HD (heliport SID) records.
  - IMPORTANT: on EA, PC and HC waypoint records the same offset 6 length 4 slice is NOT this
  - field. It is Region Code (5.41), which carries the literal "ENRT" on enroute waypoints and
  - the parent airport identifier on terminal waypoints. Do not bind it to 5.6.
  - Measured on the real file: 18,975 distinct non-blank values across the record types listed
  - above (16,292 four-character, 2,682 three-character), plus 1,552 blank occurrences, all of
  - which are enroute D records (1,160 of 2,083) and every DB record (392 of 392).

- FAA NOTES
  - The FAA uses the published ICAO airport identifier when one exists; when there is none it
  - falls back to the published FAA identifier. On the Airport (PA) record the IATA field
  - (5.107) is used to carry the FAA identifier instead, and that IATA field is left blank
  - whenever the airport identifier here is already four characters long.

- WATCH OUT
  - The Field Value Examples file for 5.6 lists 524 digit-masked patterns; only a
  - representative sample is reproduced above. The full observed alphabet is
  - A-Z and 0-9 with blank padding, nothing else.

---

### 5.7 - Route Type

- SUMMARY
  - Classifies the airway, SID, STAR, approach or preferred route that the record belongs to; on approach records
    it is a three-part code made of a primary route type plus two qualifiers.

- METADATA
  - Length: 1 character
  - Character type: alphanumeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: RT TYPE
  - When blank: Route type not applicable. On approach qualifier columns, blank means the source documentation
    does not require a qualifier.

- CONVERTER
  - `CifpFieldConverter.Field57()` returns `string`

- USED ON
  - `ER` — col 44 (Route Type)
  - `HD` — col 19 (Route Type); col 118 (Apch Route Qualifier 1); col 119 (Apch Route Qualifier 2)
  - `HF` — col 19 (Route Type); col 118 (Apch Route Qualifier 1); col 119 (Apch Route Qualifier 2)
  - `HF~cont` — col 19 (Route Type); col 118 (Approach Route Type Qualifier 1); col 119 (Approach Route Type Qualifier 2)
  - `PD` — col 19 (Route Type); col 118 (Apch Route Qualifier 1); col 119 (Apch Route Qualifier 2)
  - `PE` — col 19 (Route Type); col 118 (Apch Route Qualifier 1); col 119 (Apch Route Qualifier 2)
  - `PF` — col 19 (Route Type); col 118 (Apch Route Qualifier 1); col 119 (Apch Route Qualifier 2)
  - `PF~cont` — col 19 (Route Type); col 118 (Approach Route Type Qualifier 1); col 119 (Approach Route Type Qualifier 2)

- RETURNS
  - A resolved description string (or an enum member) for the given code. The converter MUST take the record's
    section and subsection - and, for approaches, which of the three columns is being decoded - as parameters:
    Field57(char code, string sectionSubsection, RouteTypeSlot slot). Decoding a SID '4' against the approach
    table, or an approach 'R' against the enroute table, silently produces a wrong but plausible answer.

- VALUES (meaning depends on the record type)
  - **Enroute Airway** (`ER`, zero-based column 44)
    - `A` [not in cycle] — Airline-specific airway supplied as tailored data
    - `C` [not in cycle] — Control airway
    - `D` [not in cycle] — Direct route
    - `H` [not in cycle] — Helicopter airway
    - `O` [observed] — Officially designated airway other than an RNAV or helicopter airway (the conventional VOR/Jet airway structure)
    - `R` [observed] — RNAV airway (in the United States, the Q and T route structure)
    - `S` [not in cycle] — Undesignated ATS route
    - `T` [not in cycle] — TACAN airway (added in 424-19A)
  - **Airport SID / Heliport SID** (`PD, HD`, zero-based column 19)
    - `0` [not in cycle] — Engine-out SID
    - `1` [observed] — SID runway transition (conventional)
    - `2` [observed] — SID common route, or the whole SID when it has no transitions (conventional)
    - `3` [observed] — SID enroute transition (conventional)
    - `4` [observed] — RNAV SID runway transition
    - `5` [observed] — RNAV SID common route, or the whole RNAV SID
    - `6` [observed] — RNAV SID enroute transition
    - `F` [not in cycle] — FMS SID runway transition (424-18 only; removed in 424-19A)
    - `M` [not in cycle] — FMS SID common route (424-18 only; removed in 424-19A)
    - `S` [not in cycle] — FMS SID enroute transition (424-18 only; removed in 424-19A)
    - `T` [observed] — Vector SID runway transition
    - `V` [observed] — Vector SID enroute transition
    - `R` [not in cycle] — RNP SID runway transition (424-19A only; the FAA uses 4 instead)
    - `N` [not in cycle] — RNP SID common route (424-19A only; the FAA uses 5 instead)
    - `P` [not in cycle] — RNP SID enroute transition (424-19A only; the FAA uses 6 instead)
  - **Airport STAR / Heliport STAR** (`PE, HE`, zero-based column 19)
    - `1` [observed] — STAR enroute transition (conventional)
    - `2` [observed] — STAR common route, or the whole STAR when it has no transitions (conventional)
    - `3` [observed] — STAR runway transition (conventional)
    - `4` [observed] — RNAV STAR enroute transition
    - `5` [observed] — RNAV STAR common route, or the whole RNAV STAR
    - `6` [observed] — RNAV STAR runway transition
    - `7` [not in cycle] — Profile descent enroute transition (424-18 only)
    - `8` [not in cycle] — Profile descent common route (424-18 only)
    - `9` [not in cycle] — Profile descent runway transition (424-18 only)
    - `F` [not in cycle] — FMS STAR enroute transition (424-18 only)
    - `M` [not in cycle] — FMS STAR common route (424-18 only)
    - `S` [not in cycle] — FMS STAR runway transition (424-18 only)
    - `R` [not in cycle] — RNP STAR enroute transition (424-19A only; the FAA uses 4 instead)
    - `N` [not in cycle] — RNP STAR common route (424-19A only; the FAA uses 5 instead)
    - `P` [not in cycle] — RNP STAR runway transition (424-19A only; the FAA uses 6 instead)
  - **Airport Approach / Heliport Approach - primary route type** (`PF, HF (primary and continuation)`, zero-based column 19)
    - `A` [observed] — Approach transition (a feeder/initial segment leading into the final approach)
    - `B` [observed] — Localizer back course approach
    - `D` [observed] — VOR/DME approach
    - `F` [not in cycle] — Flight Management System (FMS) approach
    - `G` [not in cycle] — Instrument Guidance System (IGS) approach
    - `H` [observed] — RNAV approach with Required Navigation Performance, i.e. RNAV (RNP) (424-19A addition)
    - `I` [observed] — ILS approach
    - `J` [not in cycle] — GLS (GNSS Landing System) approach
    - `L` [observed] — Localizer-only approach (no glide slope)
    - `M` [not in cycle] — MLS approach
    - `N` [observed] — NDB approach
    - `P` [observed] — GPS approach (including GPS overlays of conventional procedures)
    - `Q` [observed] — NDB plus DME approach
    - `R` [observed] — RNAV approach - in the CIFP this is RNAV (GPS); the sensor detail is in Qualifier 1
    - `S` [observed] — VOR approach flown using a VOR/DME or VORTAC
    - `T` [not in cycle] — TACAN approach
    - `U` [not in cycle] — Simplified Directional Facility (SDF) approach
    - `V` [observed] — VOR approach (VOR with no DME capability)
    - `W` [not in cycle] — MLS Type A approach
    - `X` [observed] — Localizer Directional Aid (LDA) approach
    - `Y` [not in cycle] — MLS Type B and C approach
    - `Z` [not in cycle] — Missed approach coding
  - **Airport Approach / Heliport Approach - Route Qualifier 1** (`PF, HF (primary and continuation)`, zero-based column 118)
    - ` ` [observed] — No qualifier required by the source documentation
    - `A` [observed] — Advanced RNAV RNP, authorization (SAAAR/AR) NOT required; GNSS implied. 424-19A, valid only with route type H
    - `D` [observed] — DME is required for the procedure
    - `F` [observed] — RNAV RNP procedure requiring FAA SAAAR or ICAO AR authorization. 424-19A, valid only with route type H
    - `J` [observed] — GPS/GNSS required; DME/DME to the stated RNP is not authorized
    - `L` [not in cycle] — GBAS procedure
    - `N` [observed] — DME is not required for the procedure
    - `P` [observed] — GNSS required
    - `R` [not in cycle] — GPS/GNSS or DME/DME to the stated RNP is required
    - `T` [not in cycle] — DME/DME required for the procedure
    - `U` [not in cycle] — RNAV with the sensor unspecified
    - `V` [not in cycle] — VOR/DME RNAV
    - `W` [observed] — RNAV procedure authorized for SBAS only and requiring the ARINC 424 Path Point FAS Data Block
  - **Airport Approach / Heliport Approach - Route Qualifier 2** (`PF, HF (primary and continuation)`, zero-based column 119)
    - `A` [not in cycle] — Primary missed approach (only valid with route type Z, which the FAA does not emit)
    - `B` [not in cycle] — Secondary missed approach (only valid with route type Z)
    - `C` [observed] — Procedure published with circle-to-land minimums only
    - `E` [not in cycle] — Engine-out missed approach (only valid with route type Z)
    - `H` [observed] — Helicopter procedure with straight-in minimums (424-19A). The FAA uses it for copter approaches to helipads
    - `I` [not in cycle] — Helicopter procedure with circle-to-land minimums (424-19A)
    - `L` [not in cycle] — Helicopter minimums published without a straight-in / circle-to-land distinction (424-19A)
    - `S` [observed] — Procedure published with straight-in minimums, or with straight-in and circle-to-land minimums
  - **Preferred Route** (`ET`, zero-based column 19)
    - `C` [not in cycle] — North American Route for North Atlantic traffic
    - `D` [not in cycle] — Common-portion preferential route
    - `J` [not in cycle] — Pacific Oceanic Transition Route (PACOTS)
    - `M` [not in cycle] — TACAN route (Australia)
    - `N` [not in cycle] — North American Route for North Atlantic traffic, non-common portion
    - `O` [not in cycle] — Preferred/preferential overflight route (424-18 prints this as a zero; 424-19A corrects it to the letter O)
    - `P` [not in cycle] — Preferred route
    - `S` [not in cycle] — Traffic Orientation System (TOS) route
    - `T` [not in cycle] — Tower Enroute Control (TEC) route

- OBSERVED IN CYCLE 2607
  - ` `, `#`, `A`, `B`, `C`, `D`, `F`, `H`, `I`, `J`, `L`, `N`, `O`, `P`, `Q`, `R`, `S`, `T`, `V`, `W`, `X`

- DETAILS
  - This is the most context-dependent field in the whole specification. One character, but the
  - code table it is read against depends entirely on which record you are looking at.
  - Field width and position by record (all offsets zero-based, on 132-character records):
  - - ER Enroute Airway: 1 character at offset 44. (Offsets 19-20 on ER records are blank; the
  - route type moved to column 45 in Supplement 3 and never moved back.)
  - - PD Airport SID: 1 character at offset 19.
  - - PE Airport STAR: 1 character at offset 19.
  - - PF Airport Approach and HF Heliport Approach: THREE characters, but not contiguous.
  - Primary route type at offset 19, Approach Route Qualifier 1 at offset 118, Approach Route
  - Qualifier 2 at offset 119. The qualifiers were bolted onto columns 119-120 (1-based) in
  - Supplement 14 so that the rest of the primary record layout would not have to shift.
  - - PF/HF Level of Service continuation records: same three offsets, 19, 118 and 119, and the
  - qualifiers are deliberately repeated there so a continuation can be matched back to its
  - primary.
  - - ET Preferred Route: 1 character at offset 19. The CIFP contains no ET records.
  - Approach records repeat the identical route type and both qualifiers on every sequence of
  - every transition of a procedure. Qualifier 2 is the one thing that legitimately varies
  - within a procedure: approach transition and final approach segments carry the minimums code
  - while missed approach segments would carry the missed-approach code.
  - The undocumented HD (Heliport SID) records in the file behave like PD records: route type at
  - offset 19.

- FAA NOTES
  - Enroute airways: the FAA uses only "O" for conventional routes and "R" for RNAV routes.
  - Measured on 19,099 ER records: O = 13,304, R = 5,795, nothing else.
  - Approaches: ARINC 424-19 is applied for the route type at column 20 (offset 19) and for
  - Route Qualifier 1 at column 119 (offset 118). Concretely, RNAV (RNP) approaches get route
  - type "H" and Qualifier 1 "F". Measured: 3,157 PF records with H, every single one of them
  - paired with Qualifier 1 "F" and Qualifier 2 "S".
  - Alternate missed approaches (route type "Z") are NOT included in the CIFP. The missed
  - approach legs instead carry the SAME route type as the final approach they belong to, which
  - means you cannot identify a missed approach segment from this field - use the Transition
  - Identifier and the Waypoint Description Code instead. Measured: zero "Z" values in the file,
  - and zero Qualifier 2 values of A, B or E.
  - Qualifier 2 of "H" is used for copter approaches flown to helipads. Measured: 19 on PF, 11
  - on HF.
  - SID and STAR records leave both qualifier columns blank.

- ARINC 424-19A DIFFERENCE
  - Enroute: 424-19A adds "T" for TACAN airways. Not used by the FAA.
  - SID: 424-19A replaces the RNAV codes 4/5/6 with RNP codes R/N/P and removes the FMS codes
  - F/M/S, and it adds SID qualifier tables. The FAA still emits the 424-18 numeric codes
  - 4/5/6 for RNAV SID runway transition, common route and enroute transition.
  - STAR: 424-19A likewise replaces 4/5/6 with R/N/P and removes 7/8/9 and F/M/S. The FAA still
  - emits the 424-18 numeric codes.
  - Approach: 424-19A adds primary route type "H" = RNAV approach with Required Navigation
  - Performance; adds Qualifier 1 codes "F" (SAAAR/AR procedure) and "A" (advanced RNP, AR not
  - required), both valid only with route type H; and adds Qualifier 2 codes "H" (helicopter,
  - straight-in minimums), "I" (helicopter, circle-to-land) and "L" (helicopter minimums with no
  - straight-in/circling distinction). The FAA applies exactly these approach changes.

- WATCH OUT
  - 1. Approach Route Type Z never appears. The FAA carries missed approach legs under the same
  - route type as the final approach, so this field cannot be used to detect a missed
  - approach segment.
  - 2. Exactly ONE PD (SID) record in the whole file carries approach-style qualifiers:
  - KBUR SID "VNY4", route type "1", Qualifier 1 "N", Qualifier 2 "S". Every other one of the
  - 34,605 SID records and all 44,148 STAR records leave both qualifier columns blank. Do not
  - treat non-blank qualifiers on a SID as impossible.
  - 3. Exactly ONE PF record uses Qualifier 1 "A": KUIN approach "R31", route type "A",
  - Qualifier 1 "A", Qualifier 2 "S". 424-19A Note 8 says "A" is valid only with route type
  - "H", so this record violates the specification it is coded against.
  - 4. Route type "H" (RNAV RNP) is a 424-19A code that does not exist in 424-18 at all. A
  - parser built strictly from the 424-18 table will fail on 3,157 PF records.
  - 5. The Field Value Examples file for 5.7 merges every context into one list, so it shows a
  - digit placeholder and the letters A B C D F H I J L N O P Q R S T V W X together. Those
  - never all apply to the same record. Only the per-context tables above are usable.
  - 6. 424-18 prints the Preferred Route code for "Preferred/Preferential Overflight Routes" as
  - the digit 0; 424-19A shows the letter O. Moot for the CIFP, which has no ET records, but
  - worth knowing if the table is ever reused.

---

### 5.8 - Route Identifier

- SUMMARY
  - The published designator of the airway or preferred route the record belongs to, exactly as it appears on
    charts.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: ROUTE IDENT
  - When blank: Never blank in the CIFP; every ER record carries a route designator.

- USED ON
  - `ER` — col 13-17 (Route Identifier)

- RETURNS
  - Trimmed route designator string, or null.

- OBSERVED IN CYCLE 2607
  - `A### `, `AR#  `, `AR## `, `B##  `, `B### `, `BR##L`, `BR##V`, `BR#L `, `G#   `, `G##  `, `G### `, `H### `, `J#   `, `J##  `, `J### `, `J###R`, `L### `, `M### `, `N### `, `Q#   `, `Q##  `, `Q### `, `R#   `, `R##  ` … (35 total)

- DETAILS
  - Left justified, blank padded. Field width depends on the record:
  - - Enroute Airway: 5 characters maximum.
  - - Preferred Route: 10 characters maximum. The CIFP contains no preferred route records.
  - In the FAACIFP18 file it sits on the ER (Enroute Airway) record at zero-based offset 13,
  - length 5. Zero-based offset 18 is a RESERVED sixth column that allows six-character
  - identifiers and is used by some data suppliers to carry an ATS service suffix. The FAA
  - leaves it blank in all 19,099 ER records, so slicing 13..17 is sufficient here - but read
  - 13..18 if you want to be robust to the reserved column ever being used.
  - Measured: 1,466 distinct route identifiers. Structure is a one- or two-letter prefix
  - followed by one to four digits, occasionally with a trailing letter. First-character
  - distribution: V 9,250 records, T 3,969, J 1,945, Q 1,816, Y 451, A 315, R 308, B 305, M 283,
  - L 270, G 163, H 11, W 9, N 4.
  - Which route types they map to (5.7 at offset 44):
  - - Route type "O" (conventional): 971 distinct routes, prefixes V, J, Y, B, A, R, L, M, G, H,
  - N, W - the Victor and Jet airway structure plus Alaskan/oceanic designators.
  - - Route type "R" (RNAV): 495 distinct routes, prefixes T (285) and Q (208) plus two
  - six-character oddities.

- FAA NOTES
  - The FAA readme does not call out 5.8 by number, but the Airways paragraph is directly
  - relevant: US airways in the CIFP comprise enroute airways, area navigation routes, area
  - navigation IFR terminal transition routes and ATS routes. Non-US airways, including Canadian
  - airways, are no longer included.
  - Related: Level (5.19) at offset 45 is coded "L" when the identifier begins with V or T, "H"
  - when it begins with J or Q, and blank otherwise.

- WATCH OUT
  - A handful of identifiers do not fit the letter-plus-digits pattern and will break any regex
  - that assumes it: BR1L, BR2L, BR9L, BR10L, BR21V through BR71V, J804R, J889R, RTE1 through
  - RTE12, and TK routes. Notably J804R and J889R are coded as route type "R" (RNAV) despite the
  - conventional "J" Jet-route prefix.

---

### 5.9 - SID/STAR Route Identifier

- SUMMARY
  - Six-column name of the SID or STAR, made up of a basic indicator followed by a single-digit validity
    (revision) number.

- METADATA
  - Length: 6 characters
  - Character type: alphanumeric
  - Kind: composite
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: SID/STAR IDENT
  - Format: Left-justified: [basic indicator, 3-5 alphanumeric][validity digit 1-9], blank padded to 6
  - When blank: Never blank in the CIFP; every SID and STAR record carries an identifier.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `HD` — col 13-18 (SID/STAR/Approach Identifier)
  - `PD` — col 13-18 (SID/STAR/Approach Identifier)
  - `PE` — col 13-18 (SID/STAR/Approach Identifier)

- RETURNS
  - The trimmed six-column identifier as the primary value, plus a decomposition: BasicIndicator (everything up to
    but not including the final character of the trimmed token) and ValidityIndicator (the final character, as an
    int 1-9). Do not slice at fixed offsets - the parts are variable length.

- COLUMNS (this field packs several independent values)
  - **BasicIndicator** — offset 0, length 5
  - **ValidityIndicator** — offset 0, length 1

- OBSERVED IN CYCLE 2607
  - `##S#  `, `#U##  `, `AEX#  `, `ANCH# `, `BOTCH#`, `GARL# `, `HUDSN#`, `MONTH#`, `SARDI#`, `TEX#  `

- DETAILS
  - Six columns, left justified and blank padded. The name is assembled per the ARINC Chapter 7
  - naming rules from a basic indicator, a validity indicator and, in the general case, a route
  - indicator, abbreviated to fit six columns.
  - The parts are NOT at fixed column positions. The token is left justified and the validity
  - digit is the LAST non-blank character, so decomposition is: trim the slice, take the final
  - character as the validity indicator, and everything before it as the basic indicator.
  - - Basic indicator: the plain-language procedure name truncated to at most five characters,
  - e.g. "BOTCH", "TEX", "GARL". It is normally the name of a fix, but a bare navaid or airport
  - identifier is common on older procedures.
  - - Validity indicator: one digit, 1 through 9, that increments each time the procedure is
  - amended. "BOTCH3" is the third revision of the BOTCH departure.
  - - Route indicator: a trailing alpha character in the general ARINC scheme. It does NOT occur
  - in the CIFP - transitions are carried in Transition Identifier (5.11) instead.
  - Position: zero-based offset 13, length 6 on PD (Airport SID), PE (Airport STAR) and the
  - undocumented HD (Heliport SID) records. Note that PF and HF records use the same columns for
  - the Approach Procedure Identifier, which is field 5.10 with a completely different structure.
  - Measured across PD, PE and HD: 1,759 distinct identifiers. Trimmed lengths are 4 (174), 5
  - (40) and 6 (1,545); that is basic indicators of 3, 4 and 5 characters. Every single one ends
  - in a digit; no identifier contains an embedded blank or a non-alphanumeric character.
  - Validity digit distribution: 1 (382), 2 (341), 3 (298), 4 (246), 5 (184), 6 (106), 7 (96),
  - 8 (72), 9 (34).

- FAA NOTES
  - The FAA readme states that ARINC 424 version 19 is applied for the SID/STAR/Approach
  - Identifier at columns 14 through 19 (zero-based 13 through 18). In practice the 424-19A text
  - for 5.9 is word-for-word the same as 424-18, so this note matters for the approach
  - identifier (5.10) rather than for SID/STAR names. The related v19 approach rule - the route
  - identifier for the final and missed approach segments of RNAV (RNP) procedures is marked with
  - an H in column 14 - applies to 5.10, not here.

- ARINC 424-19A DIFFERENCE
  - None. The 424-19A section 5.9 text is identical in substance to 424-18.

- WATCH OUT
  - 1. The subfields listed above use offset 0 for both parts because the split is positional
  - only after trimming: BasicIndicator = trimmed[..^1], ValidityIndicator = trimmed[^1].
  - Any fixed-column decomposition is wrong for the 214 identifiers shorter than six
  - characters.
  - 2. Two identifiers start with a digit: "1U71" and "77S2". Code that assumes a SID/STAR name
  - begins with a letter will reject them.
  - 3. The Field Value Examples file for 5.9 lists 1,756 distinct masked values; only a
  - representative sample is reproduced above.

---

### 5.10 - Approach Route Identifier

- SUMMARY
  - Names the specific published approach procedure, encoding the approach type, the runway it serves, and a
    suffix that separates several approaches of the same type to the same runway.

- METADATA
  - Length: 6 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: APPROACH IDENT
  - Format: Type letter + runway/course/mnemonic + optional dash + optional suffix, left justified in 6 columns
  - When blank: Not an approach record. On the approach (PF/HF) records the FAA always populates this field.

- CONVERTER
  - `CifpFieldConverter.Field510()` returns `string`

- USED ON
  - `HF` — col 13-18 (SID/STAR/Approach Identifier)
  - `HF~cont` — col 13-18 (SID/STAR/Approach Identifier)
  - `PF` — col 13-18 (SID/STAR/Approach Identifier)
  - `PF~cont` — col 13-18 (SID/STAR/Approach Identifier)
  - `PP` — col 13-18 (Approach Procedure Ident)
  - `PP~cont` — col 13-18 (Approach Procedure Ident)

- RETURNS
  - The trimmed identifier string (null when the slice is all blanks), plus - if the converter is made structured
    - ApproachTypeLetter (char), RunwayNumber (int?), RunwayDesignator (char?), MultipleIndicator (char?) and a
    flag saying which of the three shapes was matched.

- OBSERVED IN CYCLE 2607
  - `B##   `, `B##L  `, `D##   `, `D##L  `, `D##R  `, `GPS-A `, `H##   `, `H##-X `, `H##-Y `, `H##-Z `, `H##CY `, `H##CZ `, `H##L  `, `H##LU `, `H##LW `, `H##LX `, `H##LY `, `H##LZ `, `H##R  `, `H##RU `, `H##RW `, `H##RX `, `H##RY `, `H##RZ ` … (107 total)

- DETAILS
  - Six left-justified characters, blank filled. Three distinct shapes exist and the shape is
  - decided by the content, not by a flag:
  - Runway-dependent form
  - col 1 approach-type letter, normally the same letter used in Route Type (5.7)
  - col 2-3 runway number, 01-36
  - col 4 runway designator L / R / C, T for a true-north-oriented runway,
  - or '-' as a filler when there is no designator but a suffix follows
  - col 5 multiple indicator (alphanumeric) or blank
  - col 6 blank
  - Circle-to-land form (no runway alignment)
  - col 1-3 three-letter procedure mnemonic (VOR, NDB, LOC, LDA, RNV, GPS, VDM, LBC, ...)
  - col 4 '-' filler when a suffix follows, otherwise blank
  - col 5 the published suffix letter or multiple indicator
  - col 6 blank
  - Helicopter / final-approach-course form
  - col 1 approach-type letter
  - col 2-4 three digits: runway designation or final approach course in whole degrees
  - col 5 multiple indicator, or T if the course is referenced to true north
  - col 6 blank
  - Because the shape is content-dependent, decide by inspecting col 2-4: two digits then a
  - designator means runway-dependent, three digits means the helicopter/course form, three
  - letters means circle-to-land.

- FAA NOTES
  - The FAA applies ARINC 424-19 (not -18) to this field, so the circle-to-land three-letter
  - mnemonic table of -19 is the one in force.
  - For RNAV (RNP) procedures the FAA puts H in column 1 of the identifier for the final and
  - missed approach segments (and H in Route Type column 20 with F in Route Qualifier 1). All of
  - the observed H## values are RNP procedures, not helicopter procedures.
  - Alternate missed approaches (Route Type Z) are not published in the CIFP.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds the explicit circle-to-land mapping table (route type letter to the three-letter
  - mnemonic, e.g. S/V -> VOR, N -> NDB, X -> LDA, R/H -> RNV, P -> GPS, D -> VDM, B -> LBC) and
  - allows a source-provided procedure suffix in column 4 that is not a multiple indicator. It also
  - adds the note that H in column 1 combined with Route Type H marks an RNAV RNP procedure. The
  - FAA follows -19 here.

- WATCH OUT
  - Both RNV-A and RNVA occur. RNV-A is the -19 spelling (dash filler in column 4, suffix in
  - column 5); RNVA is the older -18 spelling with the suffix in column 4. A converter that assumes
  - the suffix is always in column 5 will silently drop the A from RNVA. Do not assume the dash.
  - R### (three digits after R) exists in the data. Under -18/-19 that is the helicopter / final
  - approach course form, which collides visually with the runway-dependent R## form. Disambiguate
  - on whether column 4 is a digit.
  - H## is NOT a helicopter approach in the FAA CIFP - it is an RNAV (RNP) procedure. Anyone
  - mapping column 1 straight onto the Route Type 5.7 table will mislabel every RNP approach.
  - LDA-H exists; H here is a published procedure suffix, not a multiple indicator, which is legal
  - only under -19.

---

### 5.11 - Transition Identifier

- SUMMARY
  - Names the transition a procedure leg belongs to - the enroute transition, the runway transition, or the
    approach/missed-approach transition - so that legs can be grouped into the correct branch of a SID, STAR or
    approach.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: TRANS IDENT
  - When blank: This leg belongs to the common/core portion of the procedure, or to an approach final segment,
    which by rule carries no transition name.

- CONVERTER
  - `CifpFieldConverter.Field511()` returns `string`

- USED ON
  - `HD` — col 20-24 (Transition Identifier)
  - `HF` — col 20-24 (Transition Identifier)
  - `HF~cont` — col 20-24 (Transition Identifier)
  - `PD` — col 20-24 (Transition Identifier)
  - `PE` — col 20-24 (Transition Identifier)
  - `PF` — col 20-24 (Transition Identifier)
  - `PF~cont` — col 20-24 (Transition Identifier)

- RETURNS
  - The trimmed transition name, or null when the slice is all blanks. Callers usually also want a derived flag
    for the two reserved forms - IsAllRunways (value == "ALL") and IsBothParallels (matches RW\d\dB).

- OBSERVED IN CYCLE 2607
  - `     `, `ALL  `, `RW## `, `RW##B`, `RW##C`, `RW##L`, `RW##R`, `AABEE`, `ABI  `, `DEN  `, `KALDA`, `TURKI`

- DETAILS
  - Five left-justified alphanumeric characters, blank filled. What the field holds is decided by
  - the Route Type (5.7) of the same record:
  - SID runway transition legs -> runway identifier, e.g. RW09, RW27L
  - SID common legs -> blank, or RWnn / ALL when there is no separate runway transition
  - SID enroute transition legs -> the enroute fix or navaid identifier
  - STAR enroute transition legs -> the enroute fix or navaid identifier
  - STAR common legs -> blank, or RWnn / ALL
  - STAR runway transition legs -> runway identifier
  - Approach transition legs -> the approach transition name (usually the IAF)
  - Missed approach legs -> the missed approach holding fix, or the last fix on the path
  - Approach final segment legs -> blank
  - ALL means the leg is valid for two or more runways at the airport (or every pad at a heliport).
  - A trailing B, e.g. RW08B, means the transition serves both parallels of that runway number.

- FAA NOTES
  - The FAA CIFP readme does not add any rule of its own for this field beyond the general statement that the file
    follows ARINC 424-18.

- ARINC 424-19A DIFFERENCE
  - 424-19A collapses the SID/STAR route type mapping: only route types 1, 2 and 3 are used for SID/STAR (the -18
    alternates 4/5/6, F/M/S and the profile descent 7/8/9 are gone), and Note 4 restricts the missed approach
    transition identifier to legs whose Route Qualifier 2 is B. The field length, character type and the ALL /
    RWnnB conventions are unchanged.

- WATCH OUT
  - ALL and RWnnB are reserved words, not fix identifiers. Code that resolves the transition identifier against
    the waypoint tables must special-case them or it will throw on every SID/STAR common-route leg.

---

### 5.12 - Sequence Number

- SUMMARY
  - Orders the records that together define one thing - the legs of a route, the vertices of an airspace boundary,
    or the several primary records needed to describe one item.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: SEQ NR
  - Format: Zero-padded decimal, 4 columns on ER/UR/UC and 3 columns on PD/PE/PF/HF
  - When blank: Never blank on any record type that carries this field in the FAA CIFP.

- CONVERTER
  - `CifpFieldConverter.Field512()` returns `int?`

- USED ON
  - `ER` — col 25-28 (Sequence Number)
  - `HD` — col 26-28 (Sequence Number)
  - `HF` — col 26-28 (Sequence Number)
  - `HF~cont` — col 26-28 (Sequence Number)
  - `PD` — col 26-28 (Sequence Number)
  - `PE` — col 26-28 (Sequence Number)
  - `PF` — col 26-28 (Sequence Number)
  - `PF~cont` — col 26-28 (Sequence Number)
  - `UC` — col 20-23 (Sequence Number)
  - `UR` — col 20-23 (Sequence Number)
  - `UR~cont` — col 20-23 (Sequence Number)

- RETURNS
  - The integer value of the slice. Return null only if the slice is blank or non-numeric, which does not occur in
    a well-formed FAACIFP18.

- OBSERVED IN CYCLE 2607
  - `###`, `####`

- DETAILS
  - A zero-padded decimal counter. Its width depends on which record carries it:
  - 4 characters - enroute airways (ER), restrictive airspace (UR), controlled airspace (UC)
  - 3 characters - SID (PD), STAR (PE), approach (PF, HF)
  - Numbers are normally issued in steps of 10 so that a later revision can be inserted between two
  - existing records without renumbering the whole sequence; 011, 012, 013 in the observed data are
  - exactly such insertions. Sequence numbers are unique only within one route, one boundary or one
  - procedure transition - never treat the number alone as a key.
  - For an airway that crosses a boundary between two geographic areas, the fix on the boundary is
  - written twice with the same sequence number, once per area, and the two records are told apart
  - by the Boundary Code (5.18).

- FAA NOTES
  - The FAA readme adds no rule for this field. Note that the FAA MSA (PS, HS) record layout has no sequence
    number column at all, so the 1-character MSA/TAA/cruise-table variant described in ARINC never occurs in this
    file.

- ARINC 424-19A DIFFERENCE
  - No substantive change; -19A only re-words the paragraph and re-paginates.

- WATCH OUT
  - The 1-character and 2-character forms in the ARINC text (MSA/TAA/cruise table, VHF navaid limitation
    continuation) have no counterpart in the FAA CIFP - those record types either are not published or omit the
    field. A parser must key the width off the record type; there is no self-describing marker in the field.

---

### 5.13 - Fix Identifier

- SUMMARY
  - Holds the identifier of the fix this record is about - an enroute or terminal waypoint, a VHF or NDB navaid,
    an airport, or a runway threshold expressed as a fix.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: FIX IDENT
  - When blank: The leg has no terminating fix - typical of legs that end on an altitude, a heading intercept or a
    manual termination (VA, VI, VM, CA and similar path terminators).

- CONVERTER
  - `CifpFieldConverter.Field513()` returns `string`

- USED ON
  - `EA` — col 13-17 (Waypoint Identifier)
  - `ER` — col 29-33 (Fix Identifier)
  - `HC` — col 13-17 (Waypoint Identifier)
  - `HD` — col 29-33 (Fix Identifier)
  - `HF` — col 29-33 (Fix Identifier)
  - `HF~cont` — col 29-33 (Fix Identifier)
  - `PC` — col 13-17 (Waypoint Identifier)
  - `PD` — col 29-33 (Fix Identifier)
  - `PE` — col 29-33 (Fix Identifier)
  - `PF` — col 29-33 (Fix Identifier)
  - `PF~cont` — col 29-33 (Fix Identifier)

- RETURNS
  - The trimmed identifier, or null when the slice is blank. Pair it with the adjoining ICAO code, section and
    subsection to form the reference key.

- OBSERVED IN CYCLE 2607
  - `     `, `##F  `, `##FA `, `##LIH`, `##MKK`, `##N  `, `##T  `, `#K#  `, `#R#  `, `#W#  `, `AA   `, `AAALL`, `AB   `, `ABASN`, `ABI  `, `ABQ  `, `ABR  `, `ABSAW`, `ADM  `, `ADMCK`, `JN   `, `JNC  `, `JNETT`

- DETAILS
  - Up to five left-justified alphanumeric characters with no embedded blanks, padded on the right.
  - The identifier alone is not unique across the world; it is qualified by the ICAO Code (5.14),
  - Section Code (5.4) and Subsection Code (5.5) that immediately follow it in every record that
  - uses this field, and those four values together are what should be used as the lookup key.
  - Runway thresholds appear as RW plus the runway number and optional designator (RW18, RW35L).
  - Five-letter names are RNAV waypoints; three-letter names are almost always navaids.

- FAA NOTES
  - The FAA excludes waypoints whose identifiers are entirely numeric. Fixes classified as offshore
  - may carry an area code of USA with an ICAO code of "K " or "P " (letter followed by a blank).
  - Terminal waypoints are published as PC records when used at a single airport and not on an
  - airway, otherwise as EA records; NDBs get a PN record under the same conditions.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Blank is common and legitimate (15,572 procedure legs). Code that assumes every leg names a fix will fail on
    VA/VI/VM/CA legs.

---

### 5.14 - ICAO Code

- SUMMARY
  - A two-character geographic qualifier, based on the ICAO location indicator, that scopes an identifier so the
    same fix name in two parts of the world can be told apart.

- METADATA
  - Length: 2 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ICAO CODE
  - When blank: No geographic qualifier applies to this record, or the referenced object is not geographically
    categorised.

- CONVERTER
  - `CifpFieldConverter.Field514()` returns `string`

- USED ON
  - `D` — col 10-11 (Airport ICAO Location Code); col 19-20 (VOR ICAO Location Code)
  - `DB` — col 10-11 (Airport ICAO Location Code); col 19-20 (NDB ICAO Location Code)
  - `EA` — col 10-11 (Region ICAO Location Code); col 19-20 (Waypoint ICAO Location Code)
  - `ER` — col 34-35 (Fix ICAO Location Code); col 54-55 (Recommended NAVAIDICAO Location Code)
  - `HA` — col 10-11 (Heliport ICAO Location Code); col 68-69 (Recommended VHF Navaid ICAO Location Code)
  - `HC` — col 10-11 (Airport/Heliport ICAO Location Code); col 19-20 (Waypoint ICAO Location Code)
  - `HD` — col 10-11 (Airport ICAO Location Code); col 34-35 (Fix ICAO Location Code); col 54-55 (Recommended Navaid ICAO Location Code); col 112-113 (Point Reference ICAO Location Code)
  - `HF` — col 10-11 (Airport ICAO Location Code); col 34-35 (Fix ICAO Location Code); col 54-55 (Recommended Navaid ICAO Location Code); col 112-113 (Point Reference ICAO Location Code)
  - `HF~cont` — col 10-11 (Airport ICAO Location Code); col 34-35 (Fix ICAO Location Code)
  - `HS` — col 10-11 (Heliport ICAO Location Code); col 18-19 (MSA Center ICAO Location Code)
  - `PA` — col 10-11 (Airport ICAO Location Code); col 68-69 (Recommended Navaid ICAO Location Code)
  - `PC` — col 10-11 (Airport/Heliport ICAO Location Code); col 19-20 (Waypoint ICAO Location Code)
  - `PD` — col 10-11 (Airport ICAO Location Code); col 34-35 (Fix ICAO Location Code); col 54-55 (Recommended Navaid ICAO Location Code); col 112-113 (Point Reference ICAO Location Code)
  - `PE` — col 10-11 (Airport ICAO Location Code); col 34-35 (Fix ICAO Location Code); col 54-55 (Recommended Navaid ICAO Location Code); col 112-113 (Point Reference ICAO Location Code)
  - `PF` — col 10-11 (Airport ICAO Location Code); col 34-35 (Fix ICAO Location Code); col 54-55 (Recommended Navaid ICAO Location Code); col 112-113 (Point Reference ICAO Location Code)
  - `PF~cont` — col 10-11 (Airport ICAO Location Code); col 34-35 (Fix ICAO Location Code)
  - `PG` — col 10-11 (Airport ICAO Location Code)
  - `PI` — col 10-11 (Airport ICAO Location Code); col 106-107 (Supporting Facility ICAO Location Code)
  - `PN` — col 10-11 (Airport ICAO Location Code); col 19-20 (NDB ICAO Location Code)
  - `PP` — col 10-11 (Airport ICAO Location Code)
  - `PP~cont` — col 10-11 (Airport ICAO Location Code)
  - `PS` — col 10-11 (Airport ICAO Location Code); col 18-19 (MSA ICAO Location Code)
  - `UC` — col 6-7 (Airspace ICAO Location Code)
  - `UR` — col 6-7 (Airspace ICAO Location Code)
  - `UR~cont` — col 6-7 (Airspace ICAO Location Code)

- RETURNS
  - The two raw characters with the trailing blank preserved, or null when both characters are blank. Do not
    Trim() this field.

- OBSERVED IN CYCLE 2607
  - `  `, `CY`, `K `, `K#`, `MB`, `MD`, `MM`, `MT`, `MY`, `NS`, `NZ`, `P `, `PA`, `PF`, `PG`, `PH`, `PK`, `PM`, `PO`, `PP`, `PT`, `PW`, `TA`, `TB` … (33 total)

- DETAILS
  - Two characters, left justified. Normally the first one or two letters of the ICAO location
  - indicator for the region (PA for Alaska, PH for Hawaii, TJ for Puerto Rico, MM for Mexico,
  - CY for Canada).
  - The contiguous United States is too large for a single K, so ARINC subdivides it: the letter K
  - followed by a digit 1 through 7 identifying one of seven US regions. A bare "K " (K followed by
  - a blank) means the United States without a regional subdivision.
  - This field appears many times in a single record - once for the record's own object and once
  - for each cross-reference (fix, recommended navaid, MSA centre, airspace). Every occurrence is
  - two characters and follows the same rules.

- FAA NOTES
  - Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an
    ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC
    (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area
    code they inherit.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - "K " and "K1".."K7" are different values with different meanings, and a Trim() collapses "K " to "K", which
    then compares unequal to the padded form used elsewhere in the same file. Several codes observed here (MT, NS,
    NZ, PF, PM, PO, PP, PW, TA, TB, TK, TT, TX, UH, UL) belong to regions the FAA does not itself publish - they
    arrive as cross-references from records that point outside US airspace.

---

### 5.16 - Continuation Record Number

- SUMMARY
  - Marks whether a record is a primary record and whether continuation records follow it, and numbers the
    continuations in order.

- METADATA
  - Length: 1 character
  - Character type: alphanumeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: CONT NR
  - When blank: Does not occur in the FAA CIFP; every record that carries this column has a value.

- CONVERTER
  - `CifpFieldConverter.Field516()` returns `string`

- USED ON
  - `D` — col 21 (Continuation Record No.)
  - `DB` — col 21 (Continuation Record No.)
  - `EA` — col 21 (Continuation Record No.)
  - `ER` — col 38 (Continuation Record No.)
  - `HA` — col 21 (Continuation Record No.)
  - `HC` — col 21 (Continuation Record No.)
  - `HD` — col 38 (Continuation Record Number)
  - `HF` — col 38 (Continuation Record Number)
  - `HF~cont` — col 38 (Continuation Record Number)
  - `HS` — col 38 (Continuation Record Number)
  - `PA` — col 21 (Continuation Record Number)
  - `PC` — col 21 (Continuation Record No.)
  - `PD` — col 38 (Continuation Record Number)
  - `PE` — col 38 (Continuation Record Number)
  - `PF` — col 38 (Continuation Record Number)
  - `PF~cont` — col 38 (Continuation Record Number)
  - `PG` — col 21 (Continuation Record No.)
  - `PI` — col 21 (Continuation Record No.)
  - `PN` — col 21 (Continuation Record No.)
  - `PP` — col 26 (Continuation Record Number)
  - `PP~cont` — col 26 (Continuation Record Number)
  - `PS` — col 38 (Continuation Record No.)
  - `UC` — col 24 (Continuation Record Number)
  - `UR` — col 24 (Continuation Record No.)
  - `UR~cont` — col 24 (Continuation Record No.)

- RETURNS
  - The raw character, with helper predicates IsPrimary (0 or 1) and IsContinuation (anything else).

- VALUES
  - `0` [observed] — Primary record with no continuations
  - `1` [observed] — Primary record; one or more continuations follow
  - `2` [observed] — First continuation record
  - `3` [not in cycle] — Second continuation record
  - `4` [not in cycle] — Third continuation record
  - `5` [not in cycle] — Fourth continuation record
  - `6` [not in cycle] — Fifth continuation record
  - `7` [not in cycle] — Sixth continuation record
  - `8` [not in cycle] — Seventh continuation record
  - `9` [not in cycle] — Eighth continuation record
  - `A` [not in cycle] — Ninth continuation record; A-Z continue the count past 9

- OBSERVED IN CYCLE 2607
  - `0`, `1`, `2`

- DETAILS
  - One character:
  - 0 primary record, no continuation records exist for it
  - 1 primary record, and at least one continuation record follows
  - 2..9 continuation records, in order, starting at 2
  - A..Z continuations past the ninth, continuing the sequence
  - The critical consequence for a parser is that 0 and 1 both mean "read this with the primary
  - layout", while 2 and above mean "read this with the continuation layout for this record type".
  - Dispatching on "is it zero" is wrong.

- FAA NOTES
  - The FAA emits only 0, 1 and 2. Continuations exist for exactly two things: approach level-of-
  - service continuation records on PF/HF (6,742 pairs), and controlling agency continuation records
  - on UR (1,175 pairs). Every other record type in the file is 0 throughout.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Treating 1 as a continuation is the classic bug here - a 1 record is a primary record and must be read with
    the primary layout. Cruise tables, FIR/UIR and Grid MORA have no continuation column at all, so do not slice
    one out of an AS record (index 38 of a Grid MORA line is MORA data).

---

### 5.17 - Waypoint Description Code

- SUMMARY
  - Four independent single-character flags describing the fix on this leg: what kind of thing the fix is, whether
    it must be flown over or ends the segment, and two columns of approach/enroute function such as step-down fix,
    IAF, FAF or missed approach point.

- METADATA
  - Length: 4 characters
  - Character type: alpha
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: DESC CODE
  - Format: Four fixed single-character columns, blank-padded, no trimming
  - When blank: A blank in any one column means "this particular attribute does not apply to the fix"; it never
    means "no data". All four columns blank is a legitimate combination and occurs on legs with no fix at all.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `ER` — col 39-42 (Waypoint Description Code)
  - `HD` — col 39-42 (Waypoint Description Code)
  - `HF` — col 39-42 (Waypoint Description Code)
  - `PD` — col 39-42 (Waypoint Description Code)
  - `PE` — col 39-42 (Waypoint Description Code)
  - `PF` — col 39-42 (Waypoint Description Code)

- RETURNS
  - A four-member value carrying FixType, FlyOverOrEndOfSegment, FixFunction1 and FixFunction2 as nullable chars
    (or four small enums), with blanks mapped to null. Convenience predicates worth deriving: IsFlyOver (col41 is
    Y or B), IsEndOfSegment (col41 is E or B), IsFaf (col43 == F), IsMap (col43 == M), IsIaf (col43 is A, C or D),
    IsFirstMissedLeg (col42 == M), IsRfTurnFix (col42 == R).

- COLUMNS (this field packs several independent values)
  - **FixType** — offset 0, length 1
    - ` ` [observed] — No fix on this leg - the path terminator ends on an altitude, an intercept or a manual termination
    - `A` [observed] — The fix is an airport reference point
    - `E` [observed] — Essential waypoint - a named waypoint required to define the route (course change, airway crossing, segment start or end)
    - `F` [not in cycle] — Off-airway floating waypoint - published by the government but not part of any route structure
    - `G` [observed] — The fix is a runway threshold or a helipad
    - `H` [not in cycle] — The fix is a heliport reference point
    - `N` [observed] — The fix is an NDB navaid
    - `P` [not in cycle] — Phantom waypoint - created during procedure coding to sit on the nominal track
    - `R` [not in cycle] — Non-essential waypoint on an airway
    - `T` [not in cycle] — Transition-essential waypoint - used to move between the enroute and terminal structures
    - `V` [observed] — The fix is a VHF navaid
  - **FlyOverOrEndOfSegment** — offset 1, length 1
    - ` ` [observed] — Neither a fly-over fix nor the end of a continuous segment
    - `B` [observed] — Both at once - the fix is a fly-over fix and it also ends the continuous segment
    - `E` [observed] — End of the continuous segment: last leg of an airway, of a procedure transition, at a gap in an airway definition, or where the next leg changes ARINC area code
    - `U` [not in cycle] — Uncharted airway intersection - a waypoint on an airway that was not established by the government source (used only with E in column 40)
    - `Y` [observed] — Fly-over fix - the aircraft must pass over the fix before starting the manoeuvre defined by the next leg
  - **FixFunction1** — offset 2, length 1
    - ` ` [observed] — No column-42 function applies to this fix
    - `A` [not in cycle] — Unnamed step-down fix inside the final approach segment (between the FAF and the MAP)
    - `B` [not in cycle] — Unnamed step-down fix in the intermediate segment (between the FACF and the FAF)
    - `C` [not in cycle] — ATC compulsory reporting point
    - `G` [not in cycle] — Oceanic gateway waypoint - start or end of an organised track system
    - `M` [observed] — First leg of the missed approach procedure - coded on the leg that follows the leg carrying M in column 43
    - `P` [not in cycle] — Path point fix, supporting an RNAV GPS/GLS final approach segment data block
    - `R` [observed] — Fix at which the final approach course changes - the begin or end fix of an RF leg. 424-19A code; it outranks a step-down code at the same fix
    - `S` [observed] — Named step-down fix
  - **FixFunction2** — offset 3, length 1
    - ` ` [observed] — No column-43 function applies to this fix
    - `A` [observed] — Initial approach fix (IAF)
    - `B` [observed] — Intermediate approach fix (IF), not coded as a final approach course fix
    - `C` [not in cycle] — Initial approach fix that also has a published hold
    - `D` [observed] — Initial approach fix that is also the final approach course fix
    - `E` [not in cycle] — Final end point (FEP), used in the vertical coding of non-precision approaches
    - `F` [observed] — Final approach fix (FAF)
    - `G` [not in cycle] — 424-19A only: source-provided enroute waypoint without a hold
    - `H` [not in cycle] — Holding fix. In 424-19A this is narrowed to a source-provided waypoint with a hold
    - `I` [observed] — Final approach course fix (FACF)
    - `M` [observed] — Published missed approach point (MAP)
    - `N` [not in cycle] — 424-19A only: engine-out SID / missed approach disarm point

- OBSERVED IN CYCLE 2607
  - `    `, `  M `, ` E  `, ` Y M`, `A   `, `AE  `, `E   `, `E  A`, `E  B`, `E  D`, `E  F`, `E  I`, `E  M`, `E M `, `E R `, `E RF`, `E S `, `EB  `, `EB B`, `EBM `, `EE  `, `EE A`, `EE B`, `EY  ` … (58 total)

- DETAILS
  - Exactly four characters at a fixed offset, and they are NOT a single token. Read them as four
  - separate one-character enumerations:
  - offset 0 (spec column 40) - fix type: what the fix physically is
  - offset 1 (spec column 41) - fly-over and end-of-segment attribute
  - offset 2 (spec column 42) - fix function, group 1
  - offset 3 (spec column 43) - fix function, group 2
  - Each column is padded with a blank when its attribute does not apply, so "E F" means an
  - essential waypoint that is the final approach fix, with no fly-over and no group-1 function.
  - Never Trim() the slice and never compare the four characters as one string against a fixed list -
  - the combinations are open-ended.
  - Two combinations that regularly confuse implementers:
  - Column 41 = B is not a third value beside Y and E; it is the two of them together, used when a
  - source-designated fly-over fix also happens to end the continuous segment.
  - M can legitimately appear in both column 42 and column 43 of the same record. Column 43 M
  - marks the missed approach point itself; column 42 M marks the first leg of the missed approach,
  - which is the leg after the MAP. A runway fix that is not the designated MAP can put the two on
  - one line.

- FAA NOTES
  - The FAA readme overrides the generic ARINC rules in four places:
  - Compulsory reporting points are not flagged - C in column 42 is never coded, on any route.
  - R in column 42 is coded when a fix marks a course change in the final approach. This is a
  - 424-19A code, applied even though the file is otherwise 424-18.
  - The S (named step-down fix) attribute in column 42 is not coded for step-down fixes between
  - the FACF and the FAF; on RNAV (RNP) procedures it is also not coded between the FAF and the
  - MAP.
  - H (holding) is not used for arrival, SID or STAR holding, and holding pattern (EP) records are
  - not published, so there is nothing to reference. H does not appear anywhere in the file.

- ARINC 424-19A DIFFERENCE
  - 424-19A keeps the four-column structure and every -18 code, and adds: R in column 42 (fix used
  - for turning final approach / course change, on RF legs, outranking a step-down code at the same
  - fix); G and H in column 43 split apart source-provided enroute waypoints without and with a
  - hold; N in column 43 for the engine-out SID or missed approach disarm point. It also states
  - explicitly that column 40 is never blank on an enroute airway record but may be blank on a
  - terminal procedure leg whose path terminator references no fix. The FAA has adopted the -19A R
  - code while leaving the rest at -18.

- WATCH OUT
  - R in column 42 (79 records) is not defined anywhere in ARINC 424-18, which the CIFP claims to
  - follow. It is the 424-19A "fix used for turning final approach" code, and the FAA readme
  - confirms it is intentional. A switch built only from the -18 table will hit its default branch.
  - E RF exists: column 42 R (RF turn fix) together with column 43 F (FAF). Both attributes on one
  - fix is legal but easy to miss if the two columns are treated as mutually exclusive.
  - Column 41 B is under-documented in -18. It is the union of Y and E, not an independent state.
  - Nothing in the file uses column 42 A, B, C, G or P, and nothing uses column 43 C, E, G, H or N,
  - so any code path keyed on those will never execute against FAA data - but keep them in the
  - switch, because the ARINC codes are legal and other 424 sources do use them.
  - If you slice index 39-42 out of a PF/HF continuation record (continuation number 2) you get
  - level-of-service data, not a waypoint description code. Filter on the continuation number
  - first.

---

### 5.18 - Boundary Code

- SUMMARY
  - On an enroute airway leg, marks that the route crosses into a different world area at this point and names the
    area being entered or left.

- METADATA
  - Length: 1 character
  - Character type: alphanumeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: BDY CODE
  - When blank: The airway leg does not cross a geographic area boundary at this fix. This is the normal case -
    19,057 of 19,099 enroute airway primary records are blank.

- CONVERTER
  - `CifpFieldConverter.Field518()` returns `string`

- USED ON
  - `ER` — col 43 (Boundary Code)

- RETURNS
  - A BoundaryCode enum naming the world area, or null when the slice is blank.

- VALUES
  - `U` [observed] — United States (area code USA).
  - `C` [observed] — Canada and Alaska (area code CAN).
  - `P` [observed] — Pacific (area code PAC).
  - `L` [observed] — Latin America (area code LAM).
  - `S` [not in cycle] — South America (area code SAM).
  - `1` [not in cycle] — South Pacific (area code SPA).
  - `E` [not in cycle] — Europe (area code EUR).
  - `2` [not in cycle] — Eastern Europe (area code EEU).
  - `M` [not in cycle] — Middle East and South Asia (area code MES).
  - `A` [not in cycle] — Africa (area code AFR).

- OBSERVED IN CYCLE 2607
  - ` `, `C`, `L`, `P`, `U`

- DETAILS
  - Airways do not stop at political or dataset boundaries, so when a continuous route
  - passes from one of ARINC's ten world areas into another, the fix where the crossing
  - happens carries a one-character code for the area involved. The code letters are a
  - compressed form of the three-letter Area Codes used in field 5.3, and the mapping is
  - fixed. In the FAA CIFP this sits at offset 43 of the enroute airway (ER) record and is
  - populated on only a handful of legs at the edges of U.S. airspace.

- FAA NOTES
  - The readme says nothing about this field directly, but it does say non-U.S. airways -
  - including Canadian ones - are no longer carried. The 'C' entries that survive are
  - boundary markers on legs that leave U.S. airspace, not Canadian route data.

- ARINC 424-19A DIFFERENCE
  - 424-19A carries the same code table; only the surrounding wording changed.

- WATCH OUT
  - Two of the ten legal codes are digits ('1' South Pacific, '2' Eastern Europe), so a
  - parser must not assume this column is alphabetic even though the observed FAA subset is.

---

### 5.19 - Level

- SUMMARY
  - Says whether the airway or airspace record belongs to the low-altitude structure, the high-altitude structure,
    or applies at all altitudes.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LEVEL
  - When blank: No level assigned. On FAA airways this means the route identifier does not begin with V, T, J or
    Q. On Class B/C/D airspace records the field is always blank.

- CONVERTER
  - `CifpFieldConverter.Field519()` returns `string`

- USED ON
  - `ER` — col 45 (Level)
  - `UC` — col 25 (Level)
  - `UR` — col 25 (Level)

- RETURNS
  - An AirwayLevel enum (Both / High / Low), or null when blank.

- VALUES
  - `B` [observed] — Both - the record applies to all altitudes, high and low.
  - `H` [observed] — High level structure (jet routes, Q routes, high-altitude airspace).
  - `L` [observed] — Low level structure (Victor airways, T routes, low-altitude airspace).

- OBSERVED IN CYCLE 2607
  - ` `, `B`, `H`, `L`

- DETAILS
  - One character describing which altitude stratum the record is part of. It appears in
  - three different places in the FAA CIFP and at different offsets: offset 45 on enroute
  - airway (ER) records, and offset 25 on both restrictive airspace (UR) and controlled
  - airspace (UC) records. On UC records the FAA leaves it blank entirely; on UR records
  - it distinguishes low, high and all-altitude special-use volumes.

- FAA NOTES
  - The readme gives an explicit rule for airways and ATS routes: Level is 'L' when the route
  - identifier starts with V or T, 'H' when it starts with J or Q, and blank otherwise. That
  - rule is borne out by the data - 13,219 'L', 3,761 'H' and 2,119 blank on ER primaries.

- ARINC 424-19A DIFFERENCE
  - Same three codes; 424-19A just lays the table out one code per row.

- WATCH OUT
  - On restrictive airspace (UR) records offset 25 is Level only on PRIMARY records. On a UR
  - continuation record the same column is Application Type (5.91) and reads 'C'. A naive
  - slice over all UR records produces 1,175 bogus 'C' Levels. Always branch on the
  - continuation record number (offset 24) first.

---

### 5.20 - Turn Direction

- SUMMARY
  - Forces the direction of turn on a terminal procedure leg or course reversal.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TURN DIR
  - When blank: No turn direction is specified for this leg - the aircraft turns the short way, or the leg
    geometry makes the direction unambiguous.

- CONVERTER
  - `CifpFieldConverter.Field520()` returns `string`

- USED ON
  - `HD` — col 43 (Turn Direction)
  - `HF` — col 43 (Turn Direction)
  - `PD` — col 43 (Turn Direction)
  - `PE` — col 43 (Turn Direction)
  - `PF` — col 43 (Turn Direction)

- RETURNS
  - A TurnDirection enum (Left / Right / Either), or null when blank.

- VALUES
  - `L` [observed] — Turn left.
  - `R` [observed] — Turn right.
  - `E` [observed] — Either direction is acceptable.

- OBSERVED IN CYCLE 2607
  - ` `, `E`, `L`, `R`

- DETAILS
  - Sits at offset 43 of every SID (PD), STAR (PE) and approach (PF/HF) leg record. It names
  - the direction the aircraft must turn rather than letting the flight management system pick
  - the shorter way round. It matters most on course reversals (PI legs), holding patterns
  - (HA/HF/HM legs), and anywhere source documentation dictates a specific side. On its own
  - the field only constrains the turn onto the leg's own path; when Turn Direction Valid
  - (5.22) is 'Y' the turn is mandatory before the leg's path is captured.

- FAA NOTES
  - Not mentioned in the FAA readme. In practice only 25,904 of 201,114 procedure leg records
  - carry a direction, and 'E' (either) is essentially unused - it appears on just 2 records.

- WATCH OUT
  - A 'V' shows up at offset 43 if you slice the approach level-of-service continuation
  - records (PF/HF with continuation record number at offset 38 outside '0'/'1') using the
  - primary-record layout. It is not a turn direction - it is part of the continuation record's
  - own field set. Branch on offset 38 before reading this column.

---

### 5.21 - Path and Termination

- SUMMARY
  - Two-letter code defining both the geometry of the path flown on this procedure leg and the condition that ends
    it.

- METADATA
  - Length: 2 characters
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: PATH TERM
  - Format: Two upper-case letters, no padding, no blanks inside the pair.
  - When blank: Not a flyable leg record. Blank appears on procedure rows that are not leg definitions (6,742 rows
    in the shipped file once continuation records are included); a primary leg record always carries a code.

- CONVERTER
  - `CifpFieldConverter.Field521()` returns `string`

- USED ON
  - `HD` — col 47-48 (Path and Termination)
  - `HF` — col 47-48 (Path and Termination)
  - `PD` — col 47-48 (Path and Termination)
  - `PE` — col 47-48 (Path and Termination)
  - `PF` — col 47-48 (Path and Termination)

- RETURNS
  - A PathTermination enum value covering all 23 codes, or null when the two characters are blank. The converter
    should also expose the path half and the terminator half separately, since almost every downstream rule keys
    off one or the other.

- VALUES
  - `IF` [observed] — Initial Fix. Not a flown path at all - it plants the start of a procedure or transition on a named database fix so the next leg has somewhere to begin. Also used mid-sequence when a fix must be re-anchored (for example between an FX/HX/PI leg and the next leg when the altitude constraints at each end differ). 43,906 records - the second most common leg in the file.
  - `TF` [observed] — Track to a Fix. A great-circle track from the previous leg's termination fix to this record's fix. The default RNAV leg: both ends are known database fixes, so the path is fully determined without a course value. Preferred over CF whenever the resulting path is the same. 95,119 records - by far the most common leg.
  - `CF` [observed] — Course to a Fix. Fly the specified magnetic course (5.26) and terminate at this record's fix. Unlike TF the course is stated explicitly, which matters when the inbound course is published and must be flown even if it differs slightly from the direct track - classic final approach coding. The distance field must always be filled in on a CF; when the CF follows an intercept it holds the no-wind intercept distance. 12,878 records.
  - `DF` [observed] — Direct to a Fix. From an unspecified present position, proceed direct to this record's fix. Used whenever the previous leg ended somewhere unknown - at an altitude, a DME distance or a manual termination - so no track can be pre-computed. The preceding fix or termination must be overflown. 9,981 records.
  - `FA` [observed] — Fix to an Altitude. From the named fix, hold the specified track until reaching the altitude in Altitude 1. The end point is wherever the climb or descent reaches that altitude, so it is not a fixed geographic position. The altitude is always an at-or-above constraint. 64 records.
  - `FC` [observed] — Track from a Fix for a Distance. From the named fix, fly the specified track for the ALONG-PATH distance in field 5.27. Use FC (not FD) when the distance is measured along the path from the fix itself. Not used when the distance exceeds 60 NM and a CF follows. 600 records.
  - `FD` [not in cycle] — Track from a Fix to a DME Distance. From the named fix, fly the specified track until reaching a stated DME distance from the Recommended Navaid - the distance is slant range from a facility, not distance travelled. The termination point is overflown. Not used when the distance exceeds 60 NM and a CF follows. NOT PRESENT in the FAA CIFP.
  - `FM` [observed] — Track from a Fix to a Manual termination. From the named fix, fly the specified track until ATC intervenes - radar vectors, or an instruction to proceed. Used where a SID or STAR ends 'expect vectors'. On a SID the heading must come from source documentation. 1,703 records.
  - `CA` [observed] — Course to an Altitude. Fly the specified magnetic course until reaching an altitude; there is no fix and no defined end point on the ground. The workhorse first leg of a runway-transition departure ('climb runway heading to 1000') and a common first leg of a missed approach. Termination altitude is at-or-above. 9,664 records.
  - `CD` [observed] — Course to a DME Distance. Fly the specified course until reaching a stated DME distance from the Recommended Navaid. Overflies its termination point, so no turn anticipation. When a CD is followed by an AF leg, both must reference the same navaid at the same DME distance. Only 5 records in the whole file.
  - `CI` [observed] — Course to an Intercept. Fly the specified course until it intercepts the path of the NEXT leg; the leg has no end point of its own. If a Recommended Navaid is coded it must be the same navaid as the leg being intercepted. Only 16 records.
  - `CR` [not in cycle] — Course to a Radial termination. Fly the specified course until crossing a named radial from a specific VOR. Overflies its termination point. NOT PRESENT in the FAA CIFP.
  - `RF` [observed] — Constant Radius to a Fix. A circular arc of the radius in field 5.204, about a centre fix, tangent to the inbound and outbound tracks, ending at this record's fix. The RNP-AR curved-path leg. Limited to turns of at least 2 and at most 300 degrees; the neighbouring legs must be tangent to the arc except for IF/RF, RF/RF and RF/Hx combinations. Overflies its termination point. 1,439 records.
  - `AF` [observed] — Arc to a Fix. A DME arc flown at a constant distance from the Recommended Navaid, ending at this record's fix. Rho (5.25) is the arc radius, Theta (5.24) is the radial to the terminating fix and Outbound Magnetic Course (5.26) is the boundary radial where the arc begins. When the source's arc centre is a VOR/DME or VORTAC and the path is charted as a DME arc, AF must be used instead of RF. 1,210 records.
  - `VA` [observed] — Heading to an Altitude. Fly a HEADING - no wind correction - until reaching an altitude. Ground track is undefined, so the leg cannot end at a fix. Used off the runway when the published instruction is a heading rather than a course. Termination altitude is at-or-above. 2,074 records.
  - `VD` [observed] — Heading to a DME Distance. Fly a heading until reaching a stated DME distance from the Recommended Navaid. Overflies its termination point. If a VD is followed by an AF leg both must use the same navaid and the same distance. 71 records.
  - `VI` [observed] — Heading to an Intercept. Fly a heading until intercepting the next leg's path. If a Recommended Navaid is coded it must match the navaid of the leg being intercepted. Standard construction for 'fly heading 090, vectors to intercept the localizer'. 2,494 records.
  - `VM` [observed] — Heading to a Manual termination. Fly a heading until ATC intervenes. The usual way to end a STAR in vectors or to code a departure that hands off to radar. 1,790 records.
  - `VR` [observed] — Heading to a Radial termination. Fly a heading until crossing a named radial from a specific VOR. Overflies its termination point. 30 records.
  - `PI` [observed] — Procedure turn (the 45/180 course reversal). Starts at a named database fix, flies an outbound leg, turns 45 degrees, then reverses 180 degrees to intercept the next leg. The outbound course is coded 45 degrees off the reciprocal of the inbound course unless source says otherwise, a one-minute outbound leg is implied, and field 5.27 carries the MAXIMUM EXCURSION distance from the fix (not a path length). The PI fix must be the same fix that terminated the previous leg. Turn Direction (5.20) gives the direction of the 180-degree reversal. 1,076 records.
  - `HA` [observed] — Hold to an Altitude. Enter the holding pattern at the named fix and keep circling until reaching the altitude in Altitude 1, then leave. A climb-in-hold. Leg time or distance is in field 5.27; on RNP holds the turn radius is in 5.204. Termination altitude is at-or-above. Only 78 records.
  - `HF` [observed] — Hold, terminating at the Fix after a single circuit. One trip round the pattern and then continue on course - this is the 'hold in lieu of procedure turn' used to lose altitude or reverse course on an approach. Leg time or distance is in field 5.27. 6,691 records.
  - `HM` [observed] — Hold, Manual termination. Enter the pattern at the named fix and stay there until ATC clears you out. The standard end of a missed approach. Leg time or distance is in field 5.27. 10,225 records - the fourth most common leg in the file.

- OBSERVED IN CYCLE 2607
  - `AF`, `CA`, `CD`, `CF`, `CI`, `DF`, `FA`, `FC`, `FM`, `HA`, `HF`, `HM`, `IF`, `PI`, `RF`, `TF`, `VA`, `VD`, `VI`, `VM`, `VR`

- DETAILS
  - Offset 47, two characters, on every SID (PD), STAR (PE) and approach (PF/HF) leg record.
  - Read it as two halves: the FIRST letter is the PATH - how the aircraft gets there - and the
  - SECOND letter is the TERMINATOR - what makes the leg end.
  - Path letters:
  - I = initial (no path, an anchor point)
  - T = great-circle track between two fixes
  - C = course (a magnetic course, wind corrected, so ground track is controlled)
  - D = direct from wherever the aircraft happens to be
  - F = a track flown FROM a named fix
  - V = heading (NOT wind corrected - the aircraft flies the heading and drifts)
  - A = a DME arc
  - R = a constant-radius arc between two fixes
  - P = procedure turn
  - H = holding pattern
  - Terminator letters:
  - F = at a named fix A = at an altitude
  - D = at a DME distance R = at a VOR radial
  - C = after a distance I = at the intercept of the next leg
  - M = manual (ATC vectors / pilot discretion)
  - The critical operational distinction is C-legs versus V-legs. A course leg is corrected for
  - wind so the aircraft holds a track over the ground; a heading leg is not, so the ground path
  - is unpredictable and the leg must end on something other than a fix. That is why there is no
  - "VF" leg.
  - Which other columns matter depends entirely on this code. Recommended Navaid (5.23) is
  - required for AF, CD, CR, FD, VD and VR. Outbound Magnetic Course (5.26) carries a course on
  - C/F/T legs, a heading on V legs, the boundary radial on AF legs and the radial on CR/VR legs.
  - Route Distance/Time (5.27) carries a path length on CF/FC/PI legs, a DME distance on CD/FD/VD
  - legs, an along-track distance on RF legs and a holding time (T-prefixed) on HA/HF/HM legs.
  - Arc Radius (5.204) is required on RF legs and on RNP holding legs. Altitude 1 is the
  - termination altitude on CA/FA/VA/HA legs and is always an "at or above" constraint there.
  - Sequencing rules that a validator can enforce: a DF leg must follow anything that ends at an
  - unknown position (an altitude, DME or distance termination) and that termination must be
  - overflown; CD, CR, FD, RF, VD and VR all overfly their termination point, so turn anticipation
  - is not permitted on them; a PI leg must use the same fix as the leg that precedes it; when an
  - AF, CF, DF, RF, TF or holding leg is followed by an FX leg, the FX leg starts from the same
  - point; a TF is preferred over a CF whenever both would produce the same path.

- FAA NOTES
  - The FAA readme does not enumerate leg types, but two of its rules bear directly on this field.
  - RF legs are coded as fly-by except when followed by an Hx (holding) leg. And a CA leg may be
  - used as the first leg of a missed approach - when the source gives no mandatory altitude, the
  - FAA codes the lowest of the DA, the MDA, or 400 feet above airport elevation.

- ARINC 424-19A DIFFERENCE
  - Same 23 codes. 424-19A permits FM and VM as ending legs on a STAR runway transition, which
  - 424-18 does not.

- WATCH OUT
  - Two of the 23 standard codes never appear in the FAA CIFP: CR (course to a radial) and FD
  - (track from a fix to a DME distance). The converter should still handle them - non-FAA
  - procedure coding submitted to the FAA is included in the file and 'may not adhere to FAA
  - coding practices' per the readme.
  - CD and CI are effectively vestigial in this dataset (5 and 16 records respectively); do not
  - assume test coverage from real data will exercise them.
  - 6,742 procedure rows carry a blank here. Those are continuation records, not legs - branch on
  - the continuation record number at offset 38 before treating a row as a leg.

---

### 5.22 - Turn Direction Valid

- SUMMARY
  - Flags that the direction in Turn Direction (5.20) is a hard requirement that must be flown before joining this
    leg's path.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TDV
  - When blank: No turn is required before the leg's path is captured; Turn Direction (5.20), if present, only
    governs the turn onto the path itself.

- CONVERTER
  - `CifpFieldConverter.Field522()` returns `string`

- USED ON
  - `HD` — col 49 (Turn Direction Valid)
  - `HF` — col 49 (Turn Direction Valid)
  - `PD` — col 49 (Turn Direction Valid)
  - `PE` — col 49 (Turn Direction Valid)
  - `PF` — col 49 (Turn Direction Valid)

- RETURNS
  - true when the slice is 'Y', otherwise false.

- VALUES
  - `Y` [observed] — A turn in the direction given by field 5.20 is required before the leg path is captured.
  - ` ` [observed] — No pre-leg turn requirement.

- OBSERVED IN CYCLE 2607
  - ` `, `Y`

- DETAILS
  - A single 'Y' at offset 49 of a SID, STAR or approach leg record. It upgrades the Turn
  - Direction field from advisory to mandatory: the aircraft must complete a turn in the
  - stated direction before it captures the path the leg defines. The two fields are always
  - read together - a 'Y' here with a blank 5.20 is meaningless. Rare in practice: 1,506 of
  - 201,114 procedure leg records.

- FAA NOTES
  - Not addressed in the FAA readme.

---

### 5.23 - Recommended NAVAID

- SUMMARY
  - Identifier of the ground navaid that the leg, waypoint or airport is referenced to - the facility that Theta
    (5.24) and Rho (5.25) are measured from.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: RECD NAV
  - When blank: No reference facility applies. On RNAV/GPS coding there is usually no ground navaid to name; on
    the FAA's airport, heliport and airway records the field is left blank everywhere.

- USED ON
  - `ER` — col 50-53 (Recommended NAVAID)
  - `HA` — col 64-67 (Recommended VHF Navaid)
  - `HD` — col 50-53 (Recommended Navaid)
  - `HF` — col 50-53 (Recommended Navaid)
  - `PA` — col 64-67 (Recommended Navaid)
  - `PD` — col 50-53 (Recommended Navaid)
  - `PE` — col 50-53 (Recommended Navaid)
  - `PF` — col 50-53 (Recommended Navaid)

- RETURNS
  - The trimmed navaid identifier, or null when the slice is all spaces.

- OBSERVED IN CYCLE 2607
  - `    `, `FLL `, `DBN `, `AEX `, `PGO `, `MJFK`

- DETAILS
  - One to four characters, left justified and blank padded, naming a VOR, DME, VOR/DME,
  - VORTAC, TACAN, unbiased ILS/DME, NDB, locator, localizer, GLS reference path or MLS
  - azimuth. It is the anchor facility for the record: Theta is the magnetic bearing from
  - this facility to the record's fix and Rho is the distance from it. Several leg types
  - cannot be decoded without it - AF (the arc is centred on this navaid), CD, VD and FD (the
  - DME distance is measured from it), CR and VR (the radial belongs to it). The field is
  - immediately followed by a 2-character ICAO location code for the navaid, so do not read
  - more than four characters.
  - Coding rules worth knowing: on final approach coding it is the procedure's reference
  - facility; on CI and VI legs it must match the navaid of the leg being intercepted; on an
  - AF-AF pair both legs must use the same facility and the same DME distance.

- FAA NOTES
  - The readme does not mention the field. In the shipped file it is populated only on
  - procedure leg records (22,958 of 201,114 primaries, 1,968 distinct identifiers) and is
  - blank on all 13,321 airport records, all 6,134 heliport records and all 19,099 enroute
  - airway primary records - even though ARINC allows it on all three.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds MLS/DME to the list of acceptable VHF facilities, drops GLS from the general
  - list, and states explicitly that RNAV and GPS final approach coding carries no
  - recommended navaid at all.

- WATCH OUT
  - Slicing procedure records without first checking the continuation record number (offset 38)
  - pulls values such as ' ALN' and ' N ' out of the approach level-of-service continuation
  - records; those are fragments of 'LNAV/VNAV' text, not navaid identifiers.

---

### 5.24 - Theta

- SUMMARY
  - Magnetic bearing from the Recommended Navaid to this record's fix, in tenths of a degree with the decimal
    point removed.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: THETA
  - Format: DDDd - four digits, degrees in the first three positions and tenths in the last.
  - When blank: No bearing is defined for this record - either the leg type does not use one or no Recommended
    Navaid is coded. 176,912 of 201,114 procedure leg primaries are blank.

- CONVERTER
  - `CifpFieldConverter.Field524()` returns `double?`

- USED ON
  - `ER` — col 62-65 (Theta)
  - `HD` — col 62-65 (Theta)
  - `HF` — col 62-65 (Theta)
  - `PD` — col 62-65 (Theta)
  - `PE` — col 62-65 (Theta)
  - `PF` — col 62-65 (Theta)

- RETURNS
  - Bearing in decimal degrees (raw integer divided by 10.0), or null when blank.

- OBSERVED IN CYCLE 2607
  - `    `, `0000`, `1725`, `3525`, `2750`, `3600`

- DETAILS
  - Four characters at offset 62 on procedure leg records and enroute airway records. The value
  - is degrees times ten with no decimal point and leading zeros, so '0756' is 75.6 degrees and
  - '1800' is 180.0 degrees. It is a MAGNETIC bearing measured at the navaid named in field 5.23,
  - pointing at the fix named in this record - the theta of a classic theta/rho fix definition,
  - with Rho (5.25) supplying the distance. Whether the field is required, optional or ignored is
  - decided by the Path and Termination code: on an AF leg Theta is the radial to the arc's
  - terminating fix and is mandatory.
  - Observed range in the file is 0000 through 3600, i.e. 0.0 to 360.0 degrees. Note that 360.0
  - and 0.0 both occur, so do not normalise blindly if you need to round-trip the raw value.

- FAA NOTES
  - Not mentioned in the FAA readme.

- WATCH OUT
  - ARINC types the field as alpha/numeric rather than numeric, but every populated value in the
  - FAA file is four digits. Values like 'ALNA' turn up only if the approach level-of-service
  - continuation records are sliced with the primary layout - check offset 38 first.

---

### 5.25 - Rho

- SUMMARY
  - Geodesic distance from the Recommended Navaid to this record's fix, in tenths of a nautical mile with the
    decimal point removed.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: RHO
  - Format: DDDd - four digits, whole nautical miles in the first three positions and tenths in the last.
  - When blank: No distance is defined for this record. 178,376 of 201,114 procedure leg primaries are blank.

- CONVERTER
  - `CifpFieldConverter.Field525()` returns `double?`

- USED ON
  - `ER` — col 66-69 (Rho)
  - `HD` — col 66-69 (Rho)
  - `HF` — col 66-69 (Rho)
  - `PD` — col 66-69 (Rho)
  - `PE` — col 66-69 (Rho)
  - `PF` — col 66-69 (Rho)

- RETURNS
  - Distance in decimal nautical miles (raw integer divided by 10.0), or null when blank.

- OBSERVED IN CYCLE 2607
  - `    `, `0000`, `0100`, `0120`, `0150`, `0012`

- DETAILS
  - Four characters at offset 66 on procedure leg records and enroute airway records. The value is
  - nautical miles times ten, zero padded, so '0216' is 21.6 NM and '1074' is 107.4 NM. It is the
  - rho half of a theta/rho fix definition - the distance leg of the pair whose bearing is Theta
  - (5.24), measured from the facility in Recommended Navaid (5.23). This is a geodesic (over the
  - ground) distance, not a slant DME range, even though the reference facility is usually a DME.
  - On an AF leg Rho is the radius of the DME arc being flown and is mandatory.
  - Observed range in the file is 0000 through 9999, i.e. 0.0 to 999.9 NM.

- FAA NOTES
  - Not mentioned in the FAA readme.

- WATCH OUT
  - ARINC types the field as alpha/numeric, but every populated FAA value is four digits. 'V '
  - appears only when approach level-of-service continuation records are sliced with the primary
  - layout.

---

### 5.26 - Outbound Magnetic Course

- SUMMARY
  - The course, heading or radial for the leg, in tenths of a degree with the decimal point removed - magnetic
    unless the last character is 'T'.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: OB MAG CRS
  - Format: DDDd (tenths of a degree, magnetic) or DDDT (whole degrees true).
  - When blank: No course, heading or radial applies to this record. 145,046 of 201,114 procedure leg primaries
    and 1,720 of 19,099 airway primaries are blank.

- CONVERTER
  - `CifpFieldConverter.Field526()` returns `double?`

- USED ON
  - `ER` — col 70-73 (Outbound Magnetic Course)
  - `HD` — col 70-73 (Magnetic Course)
  - `HF` — col 70-73 (Magnetic Course)
  - `PD` — col 70-73 (Magnetic Course)
  - `PE` — col 70-73 (Magnetic Course)
  - `PF` — col 70-73 (Magnetic Course)

- RETURNS
  - Course in decimal degrees, plus a flag or separate property saying whether it is magnetic or true. Null when
    blank.

- OBSERVED IN CYCLE 2607
  - `    `, `2750`, `0950`, `1760`, `1800`, `3560`

- DETAILS
  - Four characters at offset 70 on both procedure leg records and enroute airway records. The
  - normal form is four digits meaning degrees times ten: '2760' is 276.0 degrees, '0231' is 23.1
  - degrees. Observed range is 0000 to 3600.
  - There is one escape hatch. If a route or procedure segment is charted in DEGREES TRUE rather
  - than magnetic, the tenths position (the last character) is replaced by the letter 'T' and the
  - first three characters carry whole degrees: '194T' means 194 degrees true. A parser that
  - blindly int-parses this field will throw on that form.
  - What the number MEANS depends entirely on the Path and Termination code in the same record.
  - On an airway record it is the outbound magnetic course from this fix toward the next one. On
  - C, F and T legs it is a wind-corrected COURSE. On V legs it is an uncorrected HEADING. On AF
  - legs it is the boundary radial at which the arc starts. On CR and VR legs it is the radial
  - being intercepted.

- FAA NOTES
  - Not mentioned in the readme, but the FAA never uses the true-degrees form: zero of the 3,544
  - distinct procedure values and zero airway values end in 'T'. Handle it anyway - non-FAA
  - procedure coding is admitted into the file.

- WATCH OUT
  - The 'T' suffix means this column cannot be treated as numeric. It is unused by the FAA today
  - but is legal ARINC and appears in non-FAA-authored procedure coding, which the readme says may
  - be present.

---

### 5.27 - Route Distance From / Holding Distance or Time

- SUMMARY
  - Either a distance in tenths of a nautical mile or, when prefixed with 'T', a holding leg time in tenths of a
    minute.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: RTE DIST FROM, HOLD DIST/TIME
  - Format: DDDD (tenths of a nautical mile) or TDDD (tenths of a minute).
  - When blank: The leg type does not require a distance or time. 164,126 of 201,114 procedure leg primaries and
    1,720 of 19,099 airway primaries are blank.

- CONVERTER
  - `CifpFieldConverter.Field527()` returns `double?`

- USED ON
  - `ER` — col 74-77 (Route Distance From)
  - `HD` — col 74-77 (Route Distance/Holding Distance or Time)
  - `HF` — col 74-77 (Route Distance/Holding Distance or Time)
  - `PD` — col 74-77 (Route Distance/Holding Distance or Time)
  - `PE` — col 74-77 (Route Distance/Holding Distance or Time)
  - `PF` — col 74-77 (Route Distance/Holding Distance or Time)

- RETURNS
  - A decoded value plus a unit discriminator - nautical miles when the slice is all digits, minutes when it
    starts with 'T'. Null when blank.

- OBSERVED IN CYCLE 2607
  - `    `, `0040`, `T010`, `0050`, `0070`, `T015`

- DETAILS
  - Four characters at offset 74 on procedure leg records and enroute airway records, and the most
  - overloaded numeric column in the leg. Two encodings share it:
  - - Four digits: nautical miles times ten. '1076' is 107.6 NM, '0040' is 4.0 NM.
  - - 'T' followed by three digits: minutes times ten. 'T010' is 1.0 minute, 'T015' is 1.5 minutes.
  - What the distance measures is decided by the Path and Termination code:
  - - Enroute airway record: distance from this fix to the next fix on the route.
  - - CF and FC legs: the along-path leg length (mandatory on every CF; when a CF follows an
  - intercept it is the no-wind intercept distance, and when a CF is the first missed-approach
  - leg it is measured from the runway or missed approach point).
  - - CD, FD and VD legs: the DME distance from the Recommended Navaid.
  - - RF legs: along-track distance.
  - - PI legs: the MAXIMUM EXCURSION distance from the fix, not a path length.
  - - HA, HF and HM legs: the holding leg length, or the 'T' form for holding leg time.
  - Observed range for the numeric form is 0001 to 9999 (0.1 to 999.9 NM).

- FAA NOTES
  - Not mentioned in the readme. In practice the FAA uses only two time values - 'T010' (4,320
  - records) and 'T015' (5 records) - so essentially every FAA holding leg is a standard one-minute
  - pattern.

- WATCH OUT
  - Never int-parse this column. 4,325 FAA records carry the 'T' time form and would throw.

---

### 5.28 - Inbound Magnetic Course

- SUMMARY
  - Published magnetic course inbound to the fix named in the record, expressed in tenths of a degree with the
    decimal point removed.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: IB MAG CRS
  - Format: DDDd where DDDd is degrees x 10 with the decimal suppressed, or DDDT for a true course.
  - When blank: No published inbound course for this airway segment.

- CONVERTER
  - `CifpFieldConverter.Field528()` returns `double?`

- USED ON
  - `ER` — col 78-81 (Inbound Magnetic Course)

- RETURNS
  - A double? of degrees (raw / 10.0) plus a bool telling the caller whether the course is true rather than
    magnetic. Return null for the all-blank slice.

- OBSERVED IN CYCLE 2607
  - `####`, `    `

- DETAILS
  - Four characters. Normally all four are digits and the value is degrees times ten,
  - so '2760' is 276.0 degrees and '0231' is 23.1 degrees. Divide by 10.0 to get
  - degrees. The permitted range is 0.0 through 360.0 inclusive; a value of 3600 is
  - used rather than 0000 for due north on a coded airway.
  - If the route is charted with true rather than magnetic courses, the fourth
  - character is the letter 'T' and the first three characters are whole degrees -
  - '194T' means 194 degrees true. The parser must therefore inspect position 3 before
  - parsing, and the model needs a companion boolean (IsTrueCourse) rather than only a
  - double.
  - In the FAA CIFP this field appears only on Enroute Airway (ER) records, at offset
  - 78. On SID/STAR/Approach records there is no dedicated inbound course field; for
  - racetrack (HA/HF/HM) legs the inbound course is carried in the Magnetic Course
  - field (5.26) instead.

- ARINC 424-19A DIFFERENCE
  - No substantive change; only typographic quoting differs in 424-19A.

- WATCH OUT
  - The 'T' variant is defined by ARINC but never occurs in the FAA CIFP: all 17,563
  - populated occurrences are four digits, and 1,536 airway records leave the field
  - blank. Observed numeric range is 0000 to 3600. Keep the 'T' branch anyway - it costs
  - nothing and the FAA codes true-referenced runways elsewhere (see 5.46).

---

### 5.29 - Altitude Description

- SUMMARY
  - Single character saying how the altitudes in the record are to be flown - at, at-or-above, at-or-below,
    between, or as a glide-slope / vertical-path pairing.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: ALT DESC
  - Format: One character from the code table; blank is a valid code.
  - When blank: Cross at the altitude in the first Altitude field. Blank is a real, meaningful code here - it is
    NOT 'no data'.

- USED ON
  - `HD` — col 82 (Altitude Description)
  - `HF` — col 82 (Altitude Description)
  - `PD` — col 82 (Altitude Description)
  - `PE` — col 82 (Altitude Description)
  - `PF` — col 82 (Altitude Description)

- RETURNS
  - The raw character (keeping blank distinct from null) or a mapped AltitudeDescription enum whose default member
    is 'At' for blank.

- VALUES
  - ` ` [observed] — At the altitude in Altitude 1 (also used for the Localizer Only altitude).
  - `+` [observed] — At or above the altitude in Altitude 1.
  - `-` [observed] — At or below the altitude in Altitude 1.
  - `B` [observed] — Block - at or above Altitude 1 and at or below Altitude 2; the higher value is written first.
  - `C` [not in cycle] — At or above the altitude in Altitude 2; conditional altitude termination, SID records only.
  - `D` [not in cycle] — At or above the altitude in Altitude 2 with a 'not before' condition. 424-19A only.
  - `G` [observed] — Glide slope MSL altitude in Altitude 2, cross at the Altitude 1 value; final approach fix of a precision approach.
  - `H` [observed] — Glide slope MSL altitude in Altitude 2, cross at or above the Altitude 1 value; final approach fix of a precision approach.
  - `I` [observed] — Glide slope intercept altitude in Altitude 2, cross at the Altitude 1 value; final approach course fix.
  - `J` [observed] — Glide slope intercept altitude in Altitude 2, cross at or above the Altitude 1 value; final approach course fix.
  - `V` [observed] — Coded vertical-angle altitude in Altitude 2, cross at or above the Altitude 1 value; step-down fixes.
  - `X` [observed] — Coded vertical-angle altitude in Altitude 2, cross at the Altitude 1 value; step-down fixes.
  - `Y` [not in cycle] — Coded vertical-angle altitude in Altitude 2, cross at or below the Altitude 1 value; step-down fixes.

- OBSERVED IN CYCLE 2607
  - ` `, `+`, `-`, `B`, `G`, `H`, `I`, `J`, `V`, `X`

- DETAILS
  - This code governs which of the two Altitude fields (5.30) are populated and what
  - they mean. Blank is the 'at' case, so a parser must not fold blank into null and
  - lose it.
  - Rough grouping of the codes:
  - - Simple constraints on Altitude 1: blank (at), '+' (at or above), '-' (at or below).
  - - Window across both altitudes: 'B' (at or above Altitude 1 down to at or below
  - Altitude 2 - the higher value appears first).
  - - Conditional on Altitude 2: 'C' (SID only, at or above the second altitude).
  - - Precision-approach glide slope pairings: 'G' and 'H' on the final approach fix,
  - 'I' and 'J' on the final approach course fix. In each pair the second letter is
  - the 'at or above' variant of the first. 'I'/'J' are used only when Altitude 1 on
  - the FACF is populated.
  - - Vertical-path pairings on step-down fixes and from the FACF inbound: 'V' (at or
  - above Altitude 1), 'X' (at Altitude 1), 'Y' (at or below Altitude 1), each with
  - the coded vertical angle altitude in Altitude 2.
  - On approach continuation records the same codes are reused to qualify the
  - Localizer Only (glide-slope-out) altitude.

- FAA NOTES
  - The FAA applies 424-19A Attachment 5 paragraph 6.10.3.2 to the Altitude 1 field of
  - circling procedures that are not straight-in aligned with a runway, so Altitude 1
  - semantics on those legs follow the v19 rule rather than the v18 rule.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds code 'D' - at or above the altitude in the second Altitude field with a
  - 'whichever is later' (not before) condition - and refines 'C' to 'whichever is
  - earlier'. 424-19A also adds 'D' to the list of codes that require an Altitude 2
  - value. 'D' does not occur in the FAA CIFP.

- WATCH OUT
  - 'X' appears exactly once in the whole file and 'G' only three times, so any test
  - fixture built by sampling will miss them - code the full table, not the observed
  - subset. 'C' and 'Y' never appear. 'B' appears on SID, STAR and approach records
  - (4,170 STAR occurrences) even though the ARINC note restricts approach use of 'B'
  - to approach transitions and missed approach segments.

---

### 5.30 - Altitude/Minimum Altitude

- SUMMARY
  - Five-column altitude that may be feet MSL, a negative elevation, a flight level, or one of two alphabetic
    sentinels meaning the minimum altitude is unknown or unestablished.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ALT / MIN ALT
  - Format: NNNNN feet | -NNNN feet below MSL | FLNNN flight level | UNKNN | NESTB | blank
  - When blank: No altitude constraint applies at this fix or for this direction of flight.

- CONVERTER
  - `CifpFieldConverter.Field530()` returns `int?`

- USED ON
  - `ER` — col 83-87 (Minimum Altitude 1); col 88-92 (Minimum Altitude 2)
  - `HD` — col 84-88 (Altitude1); col 89-93 (Altitude2)
  - `HF` — col 84-88 (Altitude1); col 89-93 (Altitude2)
  - `PD` — col 84-88 (Altitude1); col 89-93 (Altitude2)
  - `PE` — col 84-88 (Altitude1); col 89-93 (Altitude2)
  - `PF` — col 84-88 (Altitude1); col 89-93 (Altitude2)

- RETURNS
  - An int? of feet (negative allowed) together with a flag distinguishing an MSL altitude from a flight level,
    plus a small enum or nullable flag carrying UNKNN / NESTB. Return null for blank.

- VALUES
  - `UNKNN` [observed] — Minimum altitude unknown. Enroute Airway records only.
  - `NESTB` [not in cycle] — Minimum altitude not established by the appropriate authority. Enroute Airway records only.

- OBSERVED IN CYCLE 2607
  - `     `, `#####`, `-####`, `FL###`, `UNKNN`

- DETAILS
  - Four mutually exclusive encodings occupy the same five characters:
  - 1. Five digits - altitude in feet MSL, one-foot resolution. '05000' is 5,000 ft.
  - 2. '-' plus four digits - altitude below MSL, e.g. '-0012' is -12 ft. This occurs
  - at runway fixes whose threshold elevation is below sea level.
  - 3. 'FL' plus three digits - flight level in hundreds of feet. 'FL180' is FL180,
  - i.e. 18,000 ft pressure altitude. This is NOT the same quantity as an MSL
  - altitude and the model should keep the distinction.
  - 4. 'UNKNN' - the minimum altitude is unknown; 'NESTB' - no minimum altitude has
  - been established by the authority. Enroute Airway records only.
  - Which of the two Altitude fields is populated on a procedure record is dictated by
  - the Altitude Description (5.29). On Enroute Airways, Minimum Altitude 1 holds the
  - MEA/MFA; Minimum Altitude 2 is populated only when the segment has direction-
  - dependent minima, in which case field 1 is the value for the coded direction of
  - flight and field 2 the value for the reverse.
  - Offsets in the FAA CIFP: SID/STAR/Approach Altitude 1 at 84 and Altitude 2 at 89;
  - Enroute Airway Minimum Altitude 1 at 83 and Minimum Altitude 2 at 88.

- FAA NOTES
  - For airways the FAA codes the point-to-point MEA here. A conventional route gets the
  - conventional MEA; an RNAV route gets the GNSS MEA, falling back to the conventional
  - MEA when no GNSS value is published.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds 'D' to the list of Altitude Description codes that require an Altitude 2
  - value. Otherwise identical.

- WATCH OUT
  - 'UNKNN' occurs on 1,147 airway records; 'NESTB' never occurs. Negative altitudes
  - occur on exactly six approach records, all in Altitude 1. Flight levels appear in
  - SID Altitude 1 (131), STAR Altitude 1 (4,515) and STAR Altitude 2 (1,308) but never
  - in any approach altitude field. A converter that assumes 'always five digits' will
  - throw on roughly 6,000 records.

---

### 5.31 - File Record Number

- SUMMARY
  - Housekeeping reference number stamped on every record - in the FAA CIFP a per-record unique tag, not a
    sequential file position.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: FRN
  - Format: Five characters, left-padded with zeros when numeric; may contain letters; may be entirely blank.
  - When blank: The FAA readme explicitly allows a blank File Record Number field. A blank carries no meaning
    beyond 'no housekeeping number assigned'.

- USED ON
  - `AS` — col 123-127 (File Record No.)
  - `D` — col 123-127 (File Record No.)
  - `DB` — col 123-127 (File Record No.)
  - `EA` — col 123-127 (File Record No.)
  - `ER` — col 123-127 (File Record No)
  - `HA` — col 123-127 (File Record No.)
  - `HC` — col 123-127 (File Record No.)
  - `HD` — col 123-127 (File Record Number)
  - `HF` — col 123-127 (File Record Number)
  - `HF~cont` — col 123-127 (File Record Number)
  - `HS` — col 123-127 (File Record Number)
  - `PA` — col 123-127 (File Record Number)
  - `PC` — col 123-127 (File Record No.)
  - `PD` — col 123-127 (File Record Number)
  - `PE` — col 123-127 (File Record Number)
  - `PF` — col 123-127 (File Record Number)
  - `PF~cont` — col 123-127 (File Record Number)
  - `PG` — col 123-127 (File Record No.)
  - `PI` — col 123-127 (File Record No.)
  - `PN` — col 123-127 (File Record No.)
  - `PP` — col 123-127 (File Record Number)
  - `PP~cont` — col 123-127 (File Record Number)
  - `PS` — col 123-127 (File Record No.)
  - `UC` — col 123-127 (File Record Number)
  - `UR` — col 123-127 (File Record No.)
  - `UR~cont` — col 123-127 (File Record Number)

- RETURNS
  - The trimmed string, or null when blank. Never an integer.

- OBSERVED IN CYCLE 2607
  - `#####`

- DETAILS
  - ARINC describes this as a consecutive counter assigned during file assembly, running
  - 00001, 00002, ... and rolling over to 00000 after 99999, and declares the character
  - type Numeric. The FAA does not do this. Read the FAA note below before typing this
  - property.
  - It sits at offset 123 on every record type in the file, immediately before the Cycle
  - Date. A change to this field alone does not require a Cycle Date change.

- FAA NOTES
  - From the FAA CIFP readme, verbatim in substance: 'A unique number is assigned for each
  - record rather than consecutively for the entire dataset. Some file record numbers will
  - have alphabetic characters or blank fields.'
  - Two consequences the implementer must not miss:
  - - The value is NOT ordered and must never be used to sort records, to detect gaps,
  - or to reason about file position.
  - - The value is NOT guaranteed numeric. It must be modelled as a string. Typing it
  - as int / int? will throw or silently null out records as soon as the FAA emits an
  - alphabetic or blank value, and because it appears on every one of the 396,430
  - records, that failure mode is total rather than local.

- ARINC 424-19A DIFFERENCE
  - No substantive change; 424-19A is identical apart from typographic quoting.

- WATCH OUT
  - In the 2607 cycle examined, every one of the 396,430 records happens to carry five
  - digits, so an int-typed property would pass on this file and fail on a later one.
  - This is the single most dangerous 'it works on my cycle' trap in the field set -
  - the FAA readme states plainly that letters and blanks occur. Type it string and add
  - a unit test that feeds 'A123 ' and ' ' through the parser.
  - Values are also not unique in the way a naive reader might assume: they are unique
  - per record but restart per record kind rather than running across the dataset, so
  - the same five characters recur many times in one file.

---

### 5.32 - Cycle Date

- SUMMARY
  - Two-digit year plus two-digit 28-day update cycle recording when the record was added or last changed.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: CYCLE
  - Format: YYCC where YY is the two-digit year and CC is the two-digit cycle number 01-14.
  - When blank: Never blank in the FAA CIFP.

- CONVERTER
  - `CifpFieldConverter.Field532()` returns `string`

- USED ON
  - `AS` — col 128-131 (Cycle Date)
  - `D` — col 128-131 (Cycle Date)
  - `DB` — col 128-131 (Cycle Date)
  - `EA` — col 128-131 (Cycle Date)
  - `ER` — col 128-131 (Cycle Date)
  - `HA` — col 128-131 (Cycle Date)
  - `HC` — col 128-131 (Cycle Date)
  - `HD` — col 128-131 (Cycle Date)
  - `HF` — col 128-131 (Cycle Date)
  - `HF~cont` — col 128-131 (Cycle Date)
  - `HS` — col 128-131 (Cycle Date)
  - `PA` — col 128-131 (Cycle Date)
  - `PC` — col 128-131 (Cycle Date)
  - `PD` — col 128-131 (Cycle Date)
  - `PE` — col 128-131 (Cycle Date)
  - `PF` — col 128-131 (Cycle Date)
  - `PF~cont` — col 128-131 (Cycle Date)
  - `PG` — col 128-131 (Cycle Date)
  - `PI` — col 128-131 (Cycle Date)
  - `PN` — col 128-131 (Cycle Date)
  - `PP` — col 128-131 (Cycle Date)
  - `PP~cont` — col 128-131 (Cycle Date)
  - `PS` — col 128-131 (Cycle Date)
  - `UC` — col 128-131 (Cycle Date)
  - `UR` — col 128-131 (Cycle Date)
  - `UR~cont` — col 128-131 (Cycle Date)

- RETURNS
  - A small struct or record carrying int Year (four-digit, resolved by a century rule) and int Cycle, plus the
    original four characters for round-tripping. Do not attempt to convert to a DateTime without an AIRAC epoch
    table - the field names a 28-day window, not a day.

- OBSERVED IN CYCLE 2607
  - `####`

- DETAILS
  - Positions 0-1 are the last two digits of the year; positions 2-3 are the ordinal of
  - the 28-day AIRAC cycle within that year. '2605' is the fifth cycle of 2026. A normal
  - year has 13 cycles; occasionally a year has 14.
  - The value changes whenever any ARINC field on the record changes, with four
  - exceptions that are explicitly excluded from triggering a cycle bump: Dynamic
  - Magnetic Variation, Frequency Protection, Continuation Record Number and File Record
  - Number. If nothing changed, the cycle date is left alone - which is why a current
  - file contains records stamped many years earlier.
  - Present on every record type, at offset 128 (the last four characters of the line).

- FAA NOTES
  - The FAA states that cycle dates are set to the most recent cycle on every new record
  - and on every record it modifies. Consequently the newest cycle value in the file
  - identifies the CIFP volume itself.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Values in the 2607 file span from '1310' to '2607'. That 13-year spread is normal and
  - expected - it means the record has not been touched since 2013 - but a validator that
  - rejects 'stale' cycle dates will discard tens of thousands of perfectly good records
  - (14,577 records carry '1310' and 36,384 carry '1703').
  - Two-digit years mean a century rule is required. Because the file already contains
  - values from the 2010s and 2020s and none from the 1900s, treat all values as 20YY.

---

### 5.33 - VOR/NDB Identifier

- SUMMARY
  - Official one- to four-character identification code of the VHF or MF/LF navigation facility described by the
    record.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: VOR IDENT / NDB IDENT
  - Format: 1-4 characters left justified in a 4-column field, blank padded.
  - When blank: No facility identifier is coded. On the Localizer record's Supporting Facility Identifier this is
    the normal state in the FAA CIFP.

- USED ON
  - `D` — col 13-16 (VOR Identifier)
  - `DB` — col 13-16 (NDB Identifier)
  - `PI` — col 102-105 (Supporting Facility ID)
  - `PN` — col 13-16 (NDB Identifier)

- RETURNS
  - The trimmed identifier, or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `    `, `AA  `, `AAA `, `TIKX`

- DETAILS
  - Four columns, left justified, padded on the right with blanks. Official government
  - identifiers are one to four characters. They are usually alphabetic but may include
  - digits (the ARINC examples include '6YA'), so this must be treated as alphanumeric
  - text, never as a pure alpha token and never as a number.
  - Offsets in the FAA CIFP: VHF NAVAID (D) VOR Identifier at 13; NDB NAVAID (DB) and
  - Terminal NDB (PN) NDB Identifier at 13; Localizer/Glide Slope (PI) Supporting
  - Facility Identifier at 102.
  - Do not confuse this with 5.38 DME Identifier, which names the DME/TACAN component of
  - the same facility when its ident differs from the VOR's.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Two-character NDB identifiers are common in the CIFP (for example 'AA', 'IL', 'SW'),
  - which trips validators that assume a three-character minimum. There are 2,083 distinct
  - VOR identifiers, 358 distinct NDB identifiers on DB records and 150 on PN records.
  - The Localizer record's Supporting Facility Identifier (offset 102) is blank on all
  - 1,280 PI records - the FAA never populates it - so the ILS-to-supporting-NAVAID link
  - cannot be taken from this field.

---

### 5.34 - VOR/NDB Frequency

- SUMMARY
  - Five digits giving the NAVAID frequency with the decimal point removed - hundredths of a megahertz for VHF,
    tenths of a kilohertz for NDB.

- METADATA
  - Length: 5 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: VOR/NDB FREQ
  - Format: MMMdd for VHF (MHz x 100) or KKKKd for NDB (kHz x 10); '00000' on a VOR means not published.
  - When blank: No frequency is published for this facility. Per the FAA readme this is how an unavailable
    frequency is coded for every NAVAID except a VOR.

- CONVERTER
  - `CifpFieldConverter.Field534()` returns `double?`

- USED ON
  - `D` — col 22-26 (VOR Frequency)
  - `DB` — col 22-26 (NDB Frequency)
  - `PN` — col 22-26 (NDB Frequency)

- RETURNS
  - A double? of megahertz for VHF records and kilohertz for NDB records - or, better, a typed Frequency value
    carrying both the number and its unit. Return null for blanks and for the '00000' VOR sentinel.

- OBSERVED IN CYCLE 2607
  - `#####`

- DETAILS
  - The five columns are read differently depending on the record:
  - VHF NAVAID (section D, blank subsection): hundreds, tens, units, tenths and
  - hundredths of megahertz. '11630' is 116.30 MHz. Divide by 100.0.
  - NDB NAVAID (DB) and Terminal NDB (PN): thousands, hundreds, tens, units and tenths
  - of kilohertz. '03620' is 362.0 kHz. Divide by 10.0.
  - The scale factor therefore has to be chosen from the Section/Subsection code, not
  - from the digits. A shared converter should take the facility kind as an argument.
  - In the FAA CIFP the field is at offset 22 on D, DB and PN records.

- FAA NOTES
  - When a VOR frequency is unavailable the FAA writes '00000' into columns 23-27
  - (offsets 22-26) rather than leaving the field blank. For every other NAVAID an
  - unavailable frequency is coded as blanks. A converter must therefore treat '00000'
  - on a VHF NAVAID record as 'not published' rather than as 0.00 MHz.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Eleven VHF NAVAID records carry frequencies between 13360 and 13550 - that is 133.60
  - to 135.50 MHz, outside the 108.00-117.95 MHz VOR/ILS band. Every one of them has
  - Navaid Class column 2 (offset 28) set to 'M', the military TACAN code (channels 1-16
  - and 60-69). Do not range-validate VHF NAVAID frequencies to 108.00-117.95; the
  - observed range in the file is 108.15 to 135.50 MHz.
  - NDB frequencies observed run 201.0 to 530.0 kHz.
  - The '00000' unavailable-VOR sentinel does not occur in the 2607 cycle, so it will not
  - show up in testing against this file even though the FAA readme documents it.

---

### 5.35 - NAVAID Class

- SUMMARY
  - Five packed single-character codes describing facility type, secondary facility type, usable range or power,
    what extra information rides on the signal, and collocation.

- METADATA
  - Length: 5 characters
  - Character type: alpha
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: CLASS
  - Format: Five single-character columns, each independently coded; blanks are significant.
  - When blank: Blank in any individual column is meaningful, not missing: blank in the Additional Information
    column means voice IS carried on the frequency, and blank in the Collocation column means the components are
    collocated.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `D` — col 27-31 (NAVAID Class)
  - `DB` — col 27-31 (NDB Class)
  - `PN` — col 27-31 (NDB Class)

- RETURNS
  - A NavaidClass value object exposing the five raw characters plus decoded properties - HasVor, SecondaryType,
    ServiceVolume, WeatherBroadcast, VoiceOnFrequency, IsCollocated, RequiresBfo - with the record's
    Section/Subsection supplying the VHF-versus-NDB interpretation.

- COLUMNS (this field packs several independent values)
  - **NavaidType1** — offset 0, length 1
    - `V` [observed] — VOR component present (VHF NAVAID records).
    - `H` [observed] — NDB (NDB and Terminal NDB records).
    - `S` [not in cycle] — SABH - commercial broadcast station usable for navigation (NDB records).
    - ` ` [observed] — On a VHF NAVAID record, no VOR component - the facility is a DME, TACAN, ILS/DME or MLS/DME only. The VOR latitude and longitude are blank in this case.
  - **NavaidType2** — offset 1, length 1
    - `D` [observed] — DME (VHF NAVAID).
    - `T` [observed] — TACAN, channels 17-59 and 70-126 (VHF NAVAID).
    - `M` [observed] — Military TACAN, channels 1-16 and 60-69 (VHF NAVAID).
    - `I` [observed] — ILS/DME or ILS/TACAN (VHF NAVAID).
    - `N` [not in cycle] — MLS/DME/N (VHF NAVAID).
    - `P` [not in cycle] — MLS/DME/P (VHF NAVAID).
    - `M` [not in cycle] — Middle marker (NDB/marker records). Same letter as military TACAN - disambiguate by record type.
    - `I` [not in cycle] — Inner marker (NDB/marker records).
    - `O` [observed] — Outer marker (NDB/marker records).
    - `C` [not in cycle] — Back marker (NDB/marker records).
    - ` ` [observed] — No secondary component. On a VHF NAVAID the DME/TACAN latitude and longitude are blank in this case.
  - **RangePower** — offset 2, length 1
    - `T` [observed] — VHF: terminal service volume (roughly 25 NM below 12,000 ft per 424-19A).
    - `L` [observed] — VHF: low altitude service volume (roughly 40 NM up to 18,000 ft per 424-19A).
    - `H` [observed] — VHF: high altitude service volume (roughly 130 NM up to 60,000 ft per 424-19A). For NDB records, 200 watts or more.
    - `U` [observed] — VHF: undefined - the source does not define or restrict use by range or altitude. The FAA codes this when the altitude structure is undetermined and then sets Figure of Merit (5.149) to '3'.
    - `C` [not in cycle] — VHF: a TACAN frequency-paired with an ILS localizer of the same identifier at the same site; range is understood to be terminal. Only valid together with 'I' in the NAVAID Type 2 column.
    - `M` [observed] — NDB: 25 to less than 50 watts.
    - ` ` [observed] — NDB: 50 to 1,999 watts. Blank is a real power band here, not missing data.
    - `L` [not in cycle] — NDB: less than 25 watts.
  - **AdditionalInformation** — offset 3, length 1
    - `A` [observed] — Automatic transcribed weather broadcast. The FAA uses this single code for both HIWAS and TWEB.
    - `B` [not in cycle] — Scheduled (non-continuous) weather broadcast.
    - `W` [observed] — No voice on the frequency.
    - `D` [not in cycle] — Biased ILS/DME or ILS/TACAN - the zero-range reading is not at the transmitting antenna. VHF NAVAID records only.
    - ` ` [observed] — Voice is carried on the frequency. Blank is a real code here, not missing data.
  - **Collocation** — offset 4, length 1
    - `N` [observed] — VHF: the VOR and its paired DME/TACAN are not collocated. The FAA applies this to a VORTAC when the two positions are 0.1 NM or more apart; ARINC states the rule as a latitude or longitude difference of 1/10 arc minute or more. For frequency-paired ILS/DME and ILS/TACAN the character rides on the ILS/DME or ILS/TACAN record.
    - ` ` [observed] — VHF: components are collocated. NDB: no BFO required.
    - `B` [not in cycle] — NDB and marker/locator records: a beat frequency oscillator is required to hear the morse identifier. Not a collocation indication, but it shares the column; if both a collocation condition and a BFO condition exist, the collocation character wins.
    - `A` [not in cycle] — Marker/locator records (PM) only: marker and its associated locator differ by less than 1/10 arc minute. Not applicable to the FAA CIFP, which contains no PM records.

- OBSERVED IN CYCLE 2607
  - ` DHW `, ` DLW `, ` DTW `, ` DUW `, ` ITW `, ` ITWN`, ` MHW `, ` MLW `, ` MTW `, ` THW `, ` TLW `, ` TTW `, `H    `, `H  W `, `H HW `, `H MW `, `HO W `, `HOLW `, `HOMW `, `V L  `, `V LW `, `V TW `, `VDH  `, `VDHW ` … (42 total)

- DETAILS
  - Never trim this field and never treat it as a single token. Slice it into five
  - one-character sub-fields and interpret each according to the record type. Two
  - interpretation tables apply in the FAA CIFP; the third ARINC table (Airport/Heliport
  - Localizer Marker/Locator, PM records at columns 75-79) is irrelevant because the FAA
  - publishes no PM records.
  - VHF NAVAID (section D, blank subsection) - field at offset 27:
  - col 0 (offset 27) NAVAID Type 1 - 'V' if a VOR component is present, else blank.
  - col 1 (offset 28) NAVAID Type 2 - the DME/TACAN/ILS component, or blank.
  - col 2 (offset 29) Range/Power - service volume.
  - col 3 (offset 30) Additional Info- weather broadcast / voice / DME bias.
  - col 4 (offset 31) Collocation - VOR and DME/TACAN antenna separation.
  - The pair (col 0, col 1) is what actually names the facility: 'V' + blank is a VOR
  - only; 'V' + 'D' is a VOR/DME; 'V' + 'T' is a VORTAC; blank + 'D' is a DME only;
  - blank + 'T' is a TACAN; blank + 'M' is a military TACAN; blank + 'I' is an ILS/DME or
  - ILS/TACAN.
  - Latitude and longitude population is keyed off these columns (see 5.36/5.37): the VOR
  - lat/long is filled only when col 0 is 'V', and the DME/TACAN lat/long only when col 1
  - is one of D, I, M, N, P or T.
  - NDB NAVAID (DB) and Terminal NDB (PN) - field at offset 27:
  - col 0 (offset 27) NAVAID Type 1 - 'H' for NDB, 'S' for SABH.
  - col 1 (offset 28) NAVAID Type 2 - marine beacon or marker function.
  - col 2 (offset 29) Range/Power - transmitter power band.
  - col 3 (offset 30) Additional Info- weather broadcast / voice.
  - col 4 (offset 31) Collocation - carries BFO indication rather than collocation.

- FAA NOTES
  - Two FAA-specific rules override the generic ARINC text:
  - Class 3 (Range/Power, offset 29 - the third column): the FAA codes 'H' for high,
  - 'L' for low and 'T' for terminal altitude structure, and codes 'U' where the
  - altitude structure is undetermined. The FAA also derives the Figure of Merit (5.149)
  - from this column, using Figure of Merit '3' whenever the class is undetermined.
  - Class 5 (Collocation, offset 31 - the fifth column): the FAA writes 'N' for a VORTAC
  - when the VOR coordinates and the TACAN coordinates are 0.1 NM or more apart. Note
  - that this is a different threshold from the ARINC rule, which is expressed as a
  - latitude or longitude difference of 1/10 arc minute or more.
  - Class 4 (Additional Information, offset 30 - the fourth column): the FAA codes both
  - HIWAS (Hazardous Inflight Weather Advisory Service) and TWEB (Transcribed Weather
  - Broadcast) capability with the single letter 'A'. The ARINC definition of 'A' is
  - 'automatic transcribed weather broadcast', so under the FAA convention 'A' does not
  - distinguish HIWAS from TWEB - if the consumer needs that distinction it must come
  - from another source.

- ARINC 424-19A DIFFERENCE
  - 424-19A keeps the same code letters but documents the coverage each Range/Power code
  - implies - Terminal roughly 25 NM below 12,000 ft, Low Altitude roughly 40 NM up to
  - 18,000 ft, High Altitude roughly 130 NM up to 60,000 ft, Undefined meaning the source
  - does not define coverage - and adds plain-language explanations of the Additional
  - Information codes. No code values change.

- WATCH OUT
  - The observed value ' ITWN' is the ONLY occurrence of 'N' in the collocation column in
  - the whole file (157 records). Not one VORTAC in the 2607 cycle is flagged
  - non-collocated, even though the FAA readme describes exactly that rule. Do not write
  - a test that expects a 'VT..N' pattern.
  - 'S' (SABH), marker codes I/M/C in column 2, 'C' in the range column, 'B' (scheduled
  - broadcast) and 'B' (BFO) never appear. All 189 Terminal NDB (PN) records share a
  - single class value, 'HO W ' - an outer-marker-derived NDB with 50-1,999 watts and no
  - voice.
  - Because the FAA collapses HIWAS and TWEB onto 'A', the class field cannot answer
  - 'does this VOR broadcast HIWAS'.

---

### 5.36 - Latitude

- SUMMARY
  - Signed latitude packed as a hemisphere letter followed by eight digits of degrees, minutes, seconds and
    hundredths of a second.

- METADATA
  - Length: 9 characters
  - Character type: alphanumeric
  - Kind: coordinate
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LATITUDE
  - Format: N|S followed by DDMMSSss (2+2+2+2 digits, hundredths of a second)
  - When blank: No position is coded for this component of the record - for example the VOR latitude on a DME-only
    NAVAID, the glide slope latitude when no glide slope exists, or the arc origin latitude on an airspace
    boundary leg that is not an arc.

- CONVERTER
  - `CifpFieldConverter.Field536()` returns `double?`

- USED ON
  - `D` — col 32-40 (VOR Latitude); col 55-63 (DME Latitude)
  - `DB` — col 32-40 (NDB Latitude)
  - `EA` — col 32-40 (Waypoint Latitude)
  - `HA` — col 32-40 (Latitude)
  - `HC` — col 32-40 (Waypoint Latitude)
  - `PA` — col 32-40 (Airport Reference Pt. Latitude)
  - `PC` — col 32-40 (Waypoint Latitude)
  - `PG` — col 32-40 (Runway Latitude)
  - `PI` — col 32-40 (Localizer Latitude); col 55-63 (Glide Slope Latitude)
  - `PN` — col 32-40 (NDB Latitude)
  - `UC` — col 32-40 (Latitude); col 51-59 (Arc Origin Latitude)
  - `UR` — col 32-40 (Latitude); col 51-59 (Arc Origin Latitude)

- RETURNS
  - A double? of signed decimal degrees in the range -90.0 to +90.0, or null when the nine characters are all
    blank. Prefer returning latitude and longitude together as one coordinate value.

- OBSERVED IN CYCLE 2607
  - `         `, `N########`, `S########`

- DETAILS
  - Exactly nine characters, fixed width, no separators, no decimal point, always
  - zero-filled - there is no left- or right-justification question and the field must
  - NOT be trimmed before decoding.
  - Digit layout:
  - position 0 hemisphere, 'N' or 'S'
  - positions 1-2 DD degrees 00-90
  - positions 3-4 MM minutes 00-59
  - positions 5-6 SS seconds 00-59
  - positions 7-8 ss hundredths of a second 00-99
  - So 'N39513881' is N 39 deg 51 min 38.81 sec.
  - Conversion to signed decimal degrees:
  - deg = int(s[1..2])
  - min = int(s[3..4])
  - sec = int(s[5..6])
  - hundr = int(s[7..8])
  - magnitude = deg + (min / 60.0) + ((sec + hundr / 100.0) / 3600.0)
  - result = (s[0] == 'S') ? -magnitude : +magnitude
  - Equivalently, and with less floating-point error, work in integer hundredths of a
  - second: total = ((deg * 3600 + min * 60 + sec) * 100) + hundr, then divide by
  - 360000.0. Resolution is 1/100 second, about 0.31 m of latitude.
  - Sign convention: north is positive, south is negative. 'N' is used for a position
  - exactly on the equator, so a value of zero always arrives as 'N000000000'.
  - Latitude is always paired with a Longitude (5.37) at the immediately following
  - offsets - the pair is 19 characters wide. Decode them together and return a single
  - coordinate; a half-populated pair should be treated as no position.
  - Offsets in the FAA CIFP: 32 for the primary position on runway, localizer, airport,
  - heliport, NDB, terminal NDB, waypoint, controlled airspace and restrictive airspace
  - records; 55 for the secondary position (DME latitude on VHF NAVAID records, glide
  - slope latitude on localizer records); 51 for arc origin latitude on airspace records.
  - On VHF NAVAID records the VOR latitude at 32 is filled only when NAVAID Class column
  - 1 is 'V', and the DME latitude at 55 only when NAVAID Class column 2 is one of
  - D, I, M, N, P or T.

- ARINC 424-19A DIFFERENCE
  - No substantive change to the encoding. 424-19A extends the Figure 5-8 table of what
  - the coordinates mean per record type, adding helipad records and refining the
  - communications notes; none of that affects the decode.

- WATCH OUT
  - Southern-hemisphere positions do occur and are easy to miss in testing: 20 terminal
  - waypoints, 17 enroute waypoints, 8 runways, 3 airports, 2 DME positions, 1 VOR,
  - 1 localizer, 1 glide slope and 1 NDB are coded 'S'. A converter that ignores the
  - hemisphere letter will place them in the wrong hemisphere without erroring.
  - Blank is common and legitimate: 1,262 of 2,083 VHF NAVAID records have a blank VOR
  - latitude (they are DME/TACAN/ILS-DME facilities with no VOR component), 136 localizer
  - records have no glide slope latitude, and 28,203 restrictive-airspace records have a
  - blank arc origin latitude. Do not log these as data errors.

---

### 5.37 - Longitude

- SUMMARY
  - Signed longitude packed as a hemisphere letter followed by nine digits of degrees, minutes, seconds and
    hundredths of a second.

- METADATA
  - Length: 10 characters
  - Character type: alphanumeric
  - Kind: coordinate
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LONGITUDE
  - Format: E|W followed by DDDMMSSss (3+2+2+2 digits, hundredths of a second)
  - When blank: No position is coded for this component of the record. Always blank in lockstep with the paired
    latitude (5.36).

- CONVERTER
  - `CifpFieldConverter.Field537()` returns `double?`

- USED ON
  - `D` — col 41-50 (VOR Longitude); col 64-73 (DME Longitude)
  - `DB` — col 41-50 (NDB Longitude)
  - `EA` — col 41-50 (Waypoint Longitude)
  - `HA` — col 41-50 (Longitude)
  - `HC` — col 41-50 (Waypoint Longitude)
  - `PA` — col 41-50 (Airport Reference Pt. Longitude)
  - `PC` — col 41-50 (Waypoint Longitude)
  - `PG` — col 41-50 (Runway Longitude)
  - `PI` — col 41-50 (Localizer Longitude); col 64-73 (Glide Slope Longitude)
  - `PN` — col 41-50 (NDB Longitude)
  - `UC` — col 41-50 (Longitude); col 60-69 (Arc Origin Longitude)
  - `UR` — col 41-50 (Longitude); col 60-69 (Arc Origin Longitude)

- RETURNS
  - A double? of signed decimal degrees in the range -180.0 to +180.0, or null when the ten characters are all
    blank. Prefer returning it with the paired latitude as one coordinate value.

- OBSERVED IN CYCLE 2607
  - `          `, `E#########`, `W#########`

- DETAILS
  - Exactly ten characters - one more than latitude, because longitude needs three degree
  - digits. Fixed width, no separators, zero filled, never trimmed.
  - Digit layout:
  - position 0 hemisphere, 'E' or 'W'
  - positions 1-3 DDD degrees 000-180
  - positions 4-5 MM minutes 00-59
  - positions 6-7 SS seconds 00-59
  - positions 8-9 ss hundredths of a second 00-99
  - So 'W104450794' is W 104 deg 45 min 07.94 sec.
  - Conversion to signed decimal degrees:
  - deg = int(s[1..3])
  - min = int(s[4..5])
  - sec = int(s[6..7])
  - hundr = int(s[8..9])
  - magnitude = deg + (min / 60.0) + ((sec + hundr / 100.0) / 3600.0)
  - result = (s[0] == 'W') ? -magnitude : +magnitude
  - Integer-first alternative: total = ((deg * 3600 + min * 60 + sec) * 100) + hundr,
  - then divide by 360000.0.
  - Sign convention: east is positive, west is negative. 'E' is used for a position
  - exactly on the prime meridian and exactly on the 180th meridian, so both 0 and 180
  - arrive as 'E'. A consumer that normalises to the range (-180, +180] must decide what
  - to do with E180000000; leaving it as +180.0 is correct and safe.
  - Offsets in the FAA CIFP: 41 for the primary position (always latitude offset + 9);
  - 64 for the secondary position (DME longitude, glide slope longitude); 60 for arc
  - origin longitude on airspace records.

- ARINC 424-19A DIFFERENCE
  - No substantive change to the encoding. 424-19A expands Figure 5-8 with helipad
  - records (note 9) and reworks the enroute communications note (note 8) to allow a
  - sector reference rather than only a transmitter antenna. Neither affects the decode.

- WATCH OUT
  - Eastern longitudes are far more common than southern latitudes and cannot be treated
  - as an edge case: 491 enroute waypoints, 120 terminal waypoints, 52 restrictive
  - airspace points, 38 runways, 31 airports, 13 DME positions, 9 NDBs, 3 heliports,
  - 3 VORs, 3 localizers and 3 glide slopes carry 'E'. These are the Alaskan and Pacific
  - entries that cross the antimeridian and the small number of genuinely eastern
  - facilities. Any bounding-box or 'must be western hemisphere' validation will reject
  - real data.
  - Because the antimeridian is crossed, do not compute spans or centroids by naive
  - arithmetic on these values.

---

### 5.38 - DME Identifier

- SUMMARY
  - Identifier of the DME or TACAN component of a NAVAID, written only when it differs from the VOR identifier.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: DME IDENT
  - Format: 2-4 characters left justified in a 4-column field, blank padded.
  - When blank: Either the facility has no DME component at all, or it has one whose identifier is identical to
    the VOR identifier in 5.33. Blank does NOT mean 'no DME' on its own - check NAVAID Class column 2 (5.35,
    offset 28) to tell the two cases apart.

- USED ON
  - `D` — col 51-54 (DME Ident)

- RETURNS
  - The trimmed identifier, or null when blank. A model convenience property EffectiveDmeIdentifier should fall
    back to 5.33 when this is null and NAVAID Class column 2 is non-blank.

- OBSERVED IN CYCLE 2607
  - `    `, `AAT `, `IDVR`

- DETAILS
  - Two to four characters, left justified, blank padded, at offset 51 of the VHF NAVAID
  - (D) record. It names the DME or TACAN half of a co-sited facility.
  - The population rule is the part that matters:
  - - VOR/DME and VORTAC whose two components share an identifier: field is BLANK.
  - The DME identifier is the one in 5.33.
  - - VOR/DME and VORTAC whose components have different identifiers: field carries the
  - DME/TACAN identifier.
  - - TACAN-only, DME-only, ILS/DME and MLS/DME facilities: field ALWAYS carries the
  - identifier.
  - - Facility with no DME component at all: field is blank.
  - So resolving 'what is the DME ident for this record' requires reading NAVAID Class
  - column 2 first: if it is blank there is no DME component; otherwise the DME ident is
  - this field when populated and 5.33 when this field is blank.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - 821 of the 2,083 VHF NAVAID records leave this blank, which is the normal co-located
  - same-ident case rather than an error. There are 1,262 distinct populated values.
  - Identifiers here can be four characters (for example ILS-DME idents beginning with
  - 'I'), so a three-character assumption will truncate.

---

### 5.39 - Magnetic Variation

- SUMMARY
  - Angular difference between true and magnetic north at the record's location, given as a direction letter plus
    four digits of degrees and tenths.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: MAG VAR / D MAG VAR
  - Format: E|W|T followed by DDDd (degrees x 10, decimal suppressed); with 'T' the digits are always 0000.
  - When blank: No magnetic variation coded. Does not occur in the FAA CIFP for the record types that carry this
    field.

- CONVERTER
  - `CifpFieldConverter.Field539()` returns `double?`

- USED ON
  - `DB` — col 74-78 (Magnetic Variation)
  - `EA` — col 74-78 (Dynamic Mag. Variation)
  - `HA` — col 51-55 (Magnetic Variation)
  - `HC` — col 74-78 (Dynamic Mag. Variation)
  - `PA` — col 51-55 (Magnetic Variation)
  - `PC` — col 74-78 (Dynamic Mag. Variation)
  - `PN` — col 74-78 (Magnetic Variation)

- RETURNS
  - A double? of degrees carrying the chosen sign convention, plus a bool IsTrueOriented set when the leading
    character is 'T'. Return null only for an all-blank slice.

- VALUES
  - `E` [observed] — Variation is east of true north.
  - `W` [observed] — Variation is west of true north.
  - `T` [not in cycle] — The element is oriented to true north in an area where local variation is not zero; the four digits are all zero.

- OBSERVED IN CYCLE 2607
  - `E####`, `W####`

- DETAILS
  - Five characters:
  - position 0 'E', 'W' or 'T'
  - positions 1-4 degrees x 10, decimal point suppressed, zero filled
  - 'E0140' is 14.0 degrees east; 'W0035' is 3.5 degrees west. Divide positions 1-4 by
  - 10.0. The range of the numeric part is 0000 to 1800 (0.0 to 180.0 degrees).
  - 'T' is not a direction. It means the element defined by this record is oriented to
  - TRUE north even though the local variation is non-zero; when 'T' is present the four
  - digits are all zero. A model that stores only a signed double will silently turn a
  - true-referenced record into 'variation = 0 east', which is wrong, so carry a separate
  - flag.
  - Sign convention is a choice the consumer must make deliberately, because the file
  - gives a letter, not a sign. The common aviation convention is east positive / west
  - negative when the value is to be ADDED to a magnetic bearing to obtain true. State
  - the chosen convention in the model's XML doc so downstream code is not guessing.
  - The identically-formatted Dynamic Magnetic Variation is a computed, earth-model value
  - rather than a published epoch value; it lives on waypoint records and on the VHF
  - NAVAID continuation record. For VOR station orientation use Station Declination
  - (5.66), not this field.
  - Offsets in the FAA CIFP: 74 on NDB (DB), Terminal NDB (PN) and waypoint (EA, PC, HC)
  - records; 51 on airport (PA) and heliport (HA) records.

- FAA NOTES
  - The FAA computes variation from the World Magnetic Model, 2020 epoch. Where no
  - government-assigned variation exists, the CIFP dynamic magnetic variation is
  - calculated at the magnetic epoch of a specified cycle so that it stays aligned with
  - the NASR AWY.txt and ATS.txt files; for 2025 that reference was cycle 2504. Waypoint
  - records and DME-only facilities use the cycle 2504 epoch.
  - DME-only facilities carry no station declination in NASR, so the FAA computes a
  - magnetic variation with the WMM calculator to satisfy ERAM.
  - Where no variation is available to derive runway magnetic bearings (5.58), the FAA
  - computes one with the WMM calculator rather than leaving the bearing blank.

- ARINC 424-19A DIFFERENCE
  - No substantive change; 424-19A only rewraps and re-quotes the same text.

- WATCH OUT
  - 'T' never appears in the FAA CIFP - every occurrence of this field on every record
  - type is 'E' or 'W' - so the true-oriented branch will not be exercised by this file.
  - Keep it; the FAA does publish true-referenced runways (see the 'T' suffix in 5.46)
  - and could emit 'T' here.
  - Note the field is genuinely two different quantities sharing one reference number:
  - the published (epoch) variation on airport, heliport and NDB records, and the
  - computed dynamic variation on waypoint records. Naming the model property after the
  - record's own field name rather than after 5.39 avoids conflating them.

---

### 5.40 - DME Elevation

- SUMMARY
  - Elevation of the DME antenna in feet relative to mean sea level, with a leading minus sign when below sea
    level.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: DME ELEV
  - Format: NNNNN feet MSL, or -NNNN feet below MSL.
  - When blank: No DME elevation published, or the record has no DME component.

- CONVERTER
  - `CifpFieldConverter.Field540()` returns `int?`

- USED ON
  - `D` — col 79-83 (DME Elevation)

- RETURNS
  - An int? of feet MSL, negative when below sea level, or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `     `, `#####`, `-####`

- DETAILS
  - Five characters at offset 79 of the VHF NAVAID (D) record. Resolution is one foot.
  - Two encodings share the five columns:
  - - five digits, zero filled, for elevations at or above MSL - '00530' is 530 ft;
  - - a minus sign in the first column followed by four digits for elevations below
  - MSL - '-0140' is -140 ft.
  - Trim first, then parse with a signed integer parse (int.TryParse handles the leading
  - minus once the leading zeros are harmless).

- FAA NOTES
  - The FAA readme warns that the NASR NAV.txt subscriber file does not carry a DME
  - elevation when it differs from the associated VOR or TACAN facility. In those cases
  - the FAA populates this field with the VOR elevation instead. The value is therefore
  - not guaranteed to be the DME antenna's own elevation - treat it as 'elevation of the
  - facility', not as a survey-grade DME antenna height.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Only three of the 2,083 VHF NAVAID records carry a negative elevation and 28 are
  - blank, so the negative branch is easy to leave untested. Observed range is -124 ft to
  - 11,800 ft.

---

### 5.41 - Region Code

- SUMMARY
  - Four columns that either hold the literal 'ENRT', marking the waypoint as enroute, or hold the identifier of
    the airport that owns the terminal waypoint.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: REGN CODE
  - Format: 'ENRT' | airport or heliport identifier, left justified, blank padded to 4.
  - When blank: Never blank in the FAA CIFP.

- CONVERTER
  - `CifpFieldConverter.Field541()` returns `string`

- USED ON
  - `EA` — col 6-9 (Region Code)

- RETURNS
  - A trimmed string plus a bool IsEnroute (true when the trimmed value equals 'ENRT'). When IsEnroute is false
    the string is the owning airport or heliport identifier and can be used directly as a foreign key to the PA/HA
    record.

- VALUES
  - `ENRT` [observed] — Enroute waypoint - not tied to a terminal area.

- OBSERVED IN CYCLE 2607
  - `ENRT`, `KDEN`, `M## `, `##N `

- DETAILS
  - At offset 6 on waypoint records (EA, PC, HC). Two possible contents:
  - - 'ENRT' exactly - the record is an enroute waypoint.
  - - An airport or heliport identifier, left justified and blank padded - the record
  - is a terminal waypoint belonging to that airport or heliport. Four-character
  - ICAO identifiers fill the field; three-character FAA identifiers leave the fourth
  - column blank.
  - ARINC also defines this field for Holding Pattern records, where the content mirrors
  - the holding fix (ENRT for an enroute fix, the airport ident for a terminal fix). The
  - FAA publishes no holding pattern records, so that case does not arise here.
  - Because the field can be an airport identifier, it must be treated as alphanumeric -
  - three-character FAA identifiers can begin with a digit, and identifiers such as '9V9'
  - appear in the ARINC examples.

- FAA NOTES
  - The FAA readme does not name 5.41 directly, but its PC/EA selection rule determines
  - what lands here: a named terminal waypoint gets a PC record (and therefore an airport
  - identifier in this field) only when it is used at exactly one airport and is not on an
  - enroute airway; otherwise it becomes an EA record with 'ENRT'.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - All 32,401 EA records carry 'ENRT'. PC records carry 2,337 distinct airport
  - identifiers, of which a substantial share are three characters plus a trailing blank -
  - do not assume a four-character ICAO code. Heliport terminal waypoints (HC) carry
  - identifiers such as 'KJRA' and three-character forms alike.
  - 'ENRT' is a reserved token and is not a valid airport identifier, so testing for it
  - before treating the value as an airport key is safe.

---

### 5.42 - Waypoint Type

- SUMMARY
  - Three packed single-character codes classifying a waypoint - how it is formed, what role it plays in terminal
    procedures, and which procedure types publish it.

- METADATA
  - Length: 3 characters
  - Character type: alpha
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TYPE
  - Format: Three independent single-character columns; blanks are permitted in any column.
  - When blank: Each column is independently optional. A blank column means that classification is simply not
    asserted - it is not an error and not a fourth code.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `EA` — col 26-28 (Waypoint Type)
  - `HC` — col 26-28 (Waypoint Type)
  - `PC` — col 26-28 (Waypoint Type)

- RETURNS
  - A WaypointType value object exposing the three raw characters plus decoded Formation, Function and
    ProcedurePublication properties. Keep the raw characters - the FAA overloads column 1, so callers occasionally
    need the letter itself.

- COLUMNS (this field packs several independent values)
  - **WaypointFormation** — offset 0, length 1
    - `R` [observed] — FAA meaning - fix defined by ground-based components, including any fix definable only by radar. ARINC meaning - named intersection.
    - `W` [observed] — FAA meaning - fix defined by satellite-based components. ARINC meaning - RNAV waypoint.
    - `C` [observed] — FAA meaning - fix defined by both ground-based and satellite-based components. ARINC meaning - combined named intersection and RNAV waypoint.
    - `V` [observed] — VFR waypoint. Columns 2 and 3 are unused when this is set.
    - `I` [observed] — Unnamed, charted intersection.
    - `A` [observed] — Arc centre fix waypoint. Columns 2 and 3 are always blank when this is set. Terminal waypoints only.
    - `N` [not in cycle] — NDB or terminal NDB reproduced as a waypoint. Columns 2 and 3 are always blank when this is set.
    - `M` [not in cycle] — Middle marker used as a waypoint (424-19A widens this to middle or inner marker). Terminal waypoints only.
    - `O` [not in cycle] — Outer marker used as a waypoint (424-19A widens this to outer or back marker). Terminal waypoints only.
    - `U` [not in cycle] — Uncharted airway intersection. Enroute waypoints only.
    - ` ` [observed] — Not asserted. In the FAA CIFP this occurs on National Reference System grid waypoints, where column 2 carries the lat/long classification instead.
  - **WaypointFunction** — offset 1, length 1
    - `A` [not in cycle] — Final approach fix.
    - `B` [not in cycle] — Initial approach fix and final approach fix.
    - `C` [not in cycle] — Final approach course fix.
    - `D` [not in cycle] — Intermediate approach fix.
    - `E` [not in cycle] — Off-route intersection in the FAA National Reference System. Enroute waypoints only.
    - `F` [not in cycle] — Off-route intersection. Enroute waypoints only.
    - `I` [not in cycle] — Initial approach fix.
    - `K` [not in cycle] — Final approach course fix that is also an initial approach fix.
    - `L` [not in cycle] — Final approach course fix that is also an intermediate approach fix.
    - `M` [not in cycle] — Missed approach fix.
    - `N` [not in cycle] — Initial approach fix and missed approach fix.
    - `O` [not in cycle] — Oceanic entry/exit waypoint (424-19A calls it an oceanic gateway fix). Enroute waypoints only.
    - `P` [not in cycle] — Enroute - pitch and catch point in the FAA High Altitude Redesign. Terminal - unnamed step-down fix.
    - `R` [not in cycle] — RF leg fix not at a procedure fix location. Added by 424-19A; used only with column 1 set to C, R or W.
    - `S` [not in cycle] — Enroute - AACAA and SUA waypoints in the FAA High Altitude Redesign. Terminal - named step-down fix.
    - `U` [not in cycle] — FIR/UIR or controlled airspace intersection.
    - `V` [observed] — Latitude/longitude intersection on a full degree of latitude (424-18). Enroute waypoints only.
    - `W` [observed] — Latitude/longitude intersection on a half degree of latitude (424-18). Enroute waypoints only.
    - ` ` [observed] — No terminal-procedure function or airspace relationship asserted.
  - **ProcedurePublication** — offset 2, length 1
    - `D` [not in cycle] — Published for use in a SID.
    - `E` [not in cycle] — Published for use in a STAR.
    - `F` [not in cycle] — Published for use in an approach procedure.
    - `Z` [not in cycle] — Published for use in multiple terminal procedure types.
    - `G` [not in cycle] — Source-provided enroute waypoint. Added by 424-19A.
    - ` ` [observed] — Not published for terminal procedure use, or not asserted.

- OBSERVED IN CYCLE 2607
  - ` V `, ` W `, `A  `, `C  `, `I  `, `R  `, `V  `, `W  `

- DETAILS
  - Three columns at offset 26 of every waypoint record (EA, PC, HC). Never trim; slice
  - into three one-character sub-fields.
  - column 1 (offset 26) - what kind of point this is and how it is defined.
  - column 2 (offset 27) - the function it performs in a terminal procedure, or its
  - relationship to airspace boundaries and grid lines.
  - column 3 (offset 28) - which terminal procedure types publish it.
  - ARINC gives separate column-1/column-2 tables for enroute and terminal waypoints and
  - a shared table for column 3, and states that unless specifically prohibited any
  - combination of the three columns is valid. The prohibitions are:
  - - when column 1 is 'N' (NDB used as a waypoint), columns 2 and 3 are always blank;
  - - when column 1 is 'A' (arc centre fix), columns 2 and 3 are always blank;
  - - when column 1 is 'V' (VFR waypoint), columns 2 and 3 are not used.
  - In practice the FAA uses a much narrower vocabulary than ARINC defines - see
  - faa_notes and anomalies.

- FAA NOTES
  - The FAA readme redefines column 1 for the CIFP. Rather than the full ARINC list, the
  - FAA writes:
  - 'R' - the fix is defined by ground-based components. A fix that can only be defined
  - with RADAR is also coded 'R'.
  - 'W' - the fix is defined by satellite-based components.
  - 'C' - the fix is defined by both.
  - The ARINC meanings of these same letters ('R' named intersection, 'W' RNAV waypoint,
  - 'C' combined named intersection and RNAV) are close enough to be confusing but are
  - NOT what the FAA means. Document the FAA meaning in the model or downstream code will
  - mis-describe every waypoint in the file.
  - The FAA also states that Waypoint Name Format Indicator (5.196) is never populated,
  - so column 1 here is the only classification of how the fix is formed.
  - Waypoints with all-numeric identifiers are excluded from the CIFP entirely.

- ARINC 424-19A DIFFERENCE
  - 424-19A merges the enroute and terminal tables into one and adds a 'Use' column
  - saying whether each code is valid on EA, PC or both. New or changed entries relevant
  - here: column 1 gains 'R' = 'RF Leg Fix Not at Procedure Fix' (new note 5 - column 2
  - 'R' is used only with column 1 set to C, R or W), 'M' widens to middle OR inner
  - marker and 'O' to outer OR back marker, and column 2 'F' loses the FAA National
  - Reference System wording. 424-19A also relabels column 2 'V' as 'Latitude/Longitude
  - Fix, Half Degree of Latitude' and 'W' as 'Half Degree of Longitude', which
  - contradicts 424-18 (V = full degree of latitude, W = half degree of latitude). The
  - FAA CIFP follows 424-18 for this field, so use the v18 meanings.

- WATCH OUT
  - Column 3 is blank on every waypoint record in the file. The FAA never populates the
  - terminal-procedure publication column, so a consumer cannot learn from this field
  - whether a waypoint appears on a SID, STAR or approach.
  - Column 2 is populated on only 991 records, all enroute, all with column 1 BLANK -
  - these are the National Reference System grid waypoints (identifiers of the form
  - KL09G, KL18E and so on). This directly contradicts the FAA readme's statement that
  - column 1 designates R, W or C: for these 991 records column 1 asserts nothing. A
  - parser that requires a non-blank column 1 will reject them.
  - Column 1 in practice takes only six values: 'W' (49,655 records), 'R' (9,292),
  - 'C' (8,510), 'V' (672 VFR waypoints, EA only), 'A' (911 arc centre fixes, PC only)
  - and 'I' (5 unnamed charted intersections, PC only), plus the 991 blanks. Every other
  - ARINC code is absent.
  - Heliport terminal waypoints (HC) use only 'W '.

---

### 5.43 - Waypoint Name/Description

- SUMMARY
  - Twenty-five columns of free text spelling out a named waypoint's full name, or describing an unnamed waypoint.

- METADATA
  - Length: 25 characters
  - Character type: alphanumeric
  - Kind: freetext
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: NAME/DESC
  - Format: Up to 25 characters of free text, left justified, blank padded.
  - When blank: No name or description supplied. Does not occur in the FAA CIFP - every waypoint record has
    content here.

- USED ON
  - `EA` — col 98-122 (Waypoint Name/Description)
  - `HC` — col 98-122 (Waypoint Name/Description)
  - `PC` — col 98-122 (Waypoint Name/Description)

- RETURNS
  - The trimmed string, or null when the slice is blank. Do not attempt to parse structure out of it.

- OBSERVED IN CYCLE 2607
  - `AAARG                    `, `ZOTIK-MIL                `, `ZOTSA(CNF)               `, `GEORGETOWN               `, `(LIH 3150 0500)          `

- DETAILS
  - At offset 98 on waypoint records (EA, PC, HC). Left justified, right padded with
  - blanks, maximum 25 characters.
  - ARINC intends this to be the unabbreviated name of a named waypoint (so 'FORT SMITH'
  - for a fix whose five-letter identifier is something else) or a Chapter 7 style
  - description of an unnamed waypoint (radial/distance forms such as 'LOS235/110',
  - grid forms such as '6100N01234W (OCTA)', marker forms such as 'OM RW26L ALTUR').
  - The text is free-form and may legitimately contain spaces, parentheses, hyphens and
  - digits, so it must be modelled as a plain string with no character-class validation.
  - Do not collapse internal whitespace - only trim the trailing pad.

- FAA NOTES
  - The FAA readme says nothing directly about 5.43, but the observed behaviour is a
  - significant deviation from ARINC intent - see anomalies. Note also the related FAA
  - statement that Waypoint Name Format Indicator (5.196) is never populated, so there
  - is no companion field telling a consumer how to parse this text.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - In the FAA CIFP this field is almost never a spelled-out name. Across all 70,036
  - waypoint records only two contain a real expanded name (fix GERGN carries
  - 'GEORGETOWN' and fix RYAN carries 'RYAN'). Everything else falls into four shapes:
  - - 62,031 records simply repeat the five-character identifier.
  - - 4,532 records repeat the identifier with a '-MIL' suffix (military fix).
  - - 2,474 records repeat the identifier with a '(CNF)' suffix (computer navigation
  - fix).
  - - 991 records repeat the two-letter-plus-two-digit-plus-letter National Reference
  - System identifier.
  - - 5 records carry a parenthesised unnamed-waypoint description of the form
  - '(LIH 3150 0500)' - a NAVAID identifier, a bearing and a distance.
  - Consequences: do not use this field as a display name in preference to the
  - identifier, and do not assume '-MIL' or '(CNF)' are part of a name - they are
  - classification suffixes that a consumer may want lifted into their own boolean
  - properties (IsMilitary, IsComputerNavigationFix).

---

### 5.44 - Localizer/MLS/GLS Identifier

- SUMMARY
  - Identifier of the localizer, MLS facility or GLS reference path serving the record, up to four characters.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: LOC, MLS, GLS IDENT
  - Format: 1-4 characters left justified in a 4-column field, blank padded.
  - When blank: The runway has no landing system of this kind coded. On the Runway record's second identifier
    slot, blank is the normal case.

- USED ON
  - `PG` — col 81-84 (Localizer/MLS/GLS Ref Path Identifier); col 90-93 (Second Localizer/MLS/GLS Ref Path Ident)
  - `PI` — col 13-16 (Localizer Identifier)

- RETURNS
  - The trimmed identifier, or null when blank.

- OBSERVED IN CYCLE 2607
  - `    `, `IAAD`, `ICVG`

- DETAILS
  - Up to four characters, left justified, blank padded.
  - Two distinct roles in the FAA CIFP:
  - - Localizer/Glide Slope (PI) record, offset 13: the identifier of the localizer
  - itself. This is the primary key of the ILS component record.
  - - Runway (PG) record, offsets 81 and 90: 'Localizer/MLS/GLS Reference Path
  - Identifier' and 'Second Localizer/MLS/GLS Reference Path Identifier'. Two slots
  - exist so that a runway served by more than one landing system - for example an
  - ILS and an LDA - can point at both. These are foreign keys into the PI records.
  - A parser should treat the runway's two slots as an ordered pair and expose them as
  - a small collection rather than as two loosely related strings.

- FAA NOTES
  - The FAA adds PI (localizer and glide slope) records only for procedures that are
  - actually in the CIFP, so a runway can carry a blank identifier here even though the
  - real runway has an ILS - the absence means 'no CIFP procedure', not 'no ILS'.
  - ILS CAT II, ILS CAT III, PRM, converging ILS and GLS procedures are excluded from
  - the CIFP, so no GLS reference path identifiers occur.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Every one of the 1,280 localizer identifiers in the file is exactly four characters
  - and begins with the letter 'I'. Do not rely on that - ARINC permits two- and
  - three-character identifiers (its examples include 'IDU' and 'PP') and MLS
  - identifiers begin with 'M'.
  - On Runway records the first slot is populated on 1,276 of 16,805 runways and the
  - second on only 5. The overwhelming majority of runways carry no landing system
  - identifier at all, so null must be the expected case rather than an exception.

---

### 5.45 - Localizer Frequency

- SUMMARY
  - Localizer VHF frequency as five digits with the decimal point removed - megahertz times one hundred.

- METADATA
  - Length: 5 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: FREQ
  - Format: MMMdd - megahertz x 100 with the decimal suppressed.
  - When blank: No localizer frequency published. Does not occur in the FAA CIFP.

- CONVERTER
  - `CifpFieldConverter.Field545()` returns `double?`

- USED ON
  - `PI` — col 22-26 (Localizer Frequency)

- RETURNS
  - A double? of megahertz (raw / 100.0), or null when blank.

- OBSERVED IN CYCLE 2607
  - `#####`

- DETAILS
  - Five numeric characters at offset 22 of the Localizer/Glide Slope (PI) record.
  - Divide by 100.0 to get megahertz: '11030' is 110.30 MHz, '11195' is 111.95 MHz.
  - Localizer channels are spaced 50 kHz apart within the 108.10-111.95 MHz band, so the
  - last digit is always 0 or 5 and the value always ends in .x0 or .x5 megahertz. That
  - makes a cheap sanity check available: (value mod 5) should be 0.
  - Do not confuse this with 5.34 VOR/NDB Frequency, which uses the same five-column
  - megahertz-times-one-hundred encoding for VHF NAVAIDs but a completely different
  - kilohertz-times-ten encoding for NDBs. This field is always VHF.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - All 1,280 PI records carry five digits; observed range is 10830 to 11195, i.e.
  - 108.30 to 111.95 MHz. That is narrower than the nominal 108.10-111.95 localizer band,
  - so do not build a lookup keyed on the observed values alone.

---

### 5.46 - Runway Identifier

- SUMMARY
  - Five columns naming a runway, normally 'RW' plus a two-digit magnetic-heading designator plus an optional
    suffix letter, but in the FAA CIFP also a bare non-numeric designator such as N, SE or ALL.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: RUNWAY ID
  - Format: 'RW' + two digits + optional suffix (C, L, R, T, W, S, G, U or a digit), left justified and blank padded; OR a bare non-numeric designator (N, S, E, W, NE, NW, SE, SW, ALL, WAY) with no 'RW' prefix.
  - When blank: No runway is identified. Does not occur on Runway, Localizer or Path Point records in the FAA
    CIFP.

- CONVERTER
  - `CifpFieldConverter.Field546()` returns `string`

- USED ON
  - `PG` — col 13-17 (Runway Identifier)
  - `PI` — col 27-31 (Runway Identifier)
  - `PP` — col 19-23 (Runway or Helipad Identifier)
  - `PP~cont` — col 19-23 (Runway or Helipad Identifier)

- RETURNS
  - The trimmed raw identifier as the join key, plus decoded parts - int? DesignatorNumber (null for the bare non-
    numeric forms), char? Suffix, and an enum or bool distinguishing the 'RW' form from the bare water/seaplane
    form.

- VALUES
  - `C` [observed] — Suffix - centre runway of three parallel runways.
  - `L` [observed] — Suffix - left runway of two or three parallel runways.
  - `R` [observed] — Suffix - right runway of two or three parallel runways.
  - `T` [not in cycle] — Suffix - runway and associated flight manoeuvres referenced only in degrees true.
  - `W` [observed] — Suffix - water runway. FAA extension, not in ARINC.
  - `S` [observed] — Suffix - soft-surface runway. FAA extension, not in ARINC.
  - `G` [observed] — Suffix - glider runway. FAA extension, not in ARINC.
  - `U` [observed] — Suffix - ultralight runway. FAA extension, not in ARINC.
  - `0-9` [observed] — Suffix - assault strip, coded as a numeric character. FAA extension, not in ARINC.
  - ` ` [observed] — No suffix - a single runway on that heading.

- OBSERVED IN CYCLE 2607
  - `RW## `, `RW##L`, `RW##R`, `RW##C`, `RW##W`, `RW##U`, `RW##S`, `RW##G`, `RW###`, `N    `, `S    `, `E    `, `W    `, `NE   `, `NW   `, `SE   `, `SW   `, `ALL  `, `WAY  `

- DETAILS
  - ARINC form: the literal letters 'RW', then two digits 01-36, then an optional fifth
  - character. The field is left justified and blank padded, so a runway with no suffix
  - occupies four columns and one blank.
  - ARINC-defined fifth characters:
  - C centre runway of three parallels
  - L left runway of two or three parallels
  - R right runway of two or three parallels
  - T runway and its associated manoeuvres are referenced to degrees TRUE
  - ARINC explicitly says that other designations - North, South, East, West, STOL - are
  - not carried in an ARINC file. The FAA does not follow that rule; see faa_notes.
  - Offsets in the FAA CIFP: 13 on the Runway (PG) record; 27 on the Localizer/Glide
  - Slope (PI) record; 19 on the Path Point (PP) record, where the CSV layout labels it
  - '5.46 or 5.180' because helicopter procedures put a helipad identifier there instead.
  - Because the field is used as the join key between PG, PI and PP records, the parser
  - must preserve it byte-for-byte in addition to any decoded form - a runway 'RW09W'
  - and a runway 'RW09' are different runways at the same airport.

- FAA NOTES
  - Two FAA deviations, both stated in the CIFP readme, and both of which break a naive
  - regular expression of ^RW\d{2}[CLRT ]?$:
  - 1. Extra suffixes. The FAA includes runway-surface and use suffixes that ARINC does
  - not define:
  - W water runway
  - S soft-surface runway
  - G glider runway
  - U ultralight runway
  - a digit assault strip
  - So 'RW17W', 'RW13S', 'RW09G', 'RW26U' and 'RW05' followed by a digit are all
  - legitimate.
  - 2. Non-numeric runway identifiers are included AND they do not carry the 'RW'
  - prefix. These are the seaplane and water-landing designators: they appear as a
  - bare compass point or word, left justified and blank padded - 'N', 'S', 'E', 'W',
  - 'NE', 'NW', 'SE', 'SW', 'ALL' and 'WAY'. Note that 'W' as a standalone identifier
  - means the westerly water lane, whereas 'W' as the fifth character of 'RW17W'
  - means water surface - the same letter, two unrelated meanings, disambiguated only
  - by position.

- ARINC 424-19A DIFFERENCE
  - Identical text in 424-19A; the FAA suffix extensions are not in either version of
  - ARINC.

- WATCH OUT
  - Fifty of the 16,805 Runway records use the bare non-numeric form with no 'RW' prefix
  - ('N' 10, 'S' 10, 'E' 7, 'W' 7, 'NE' 6, 'SW' 6, 'NW' 1, 'SE' 1, 'ALL' 1, 'WAY' 1).
  - A regex anchored on 'RW' silently drops all of them.
  - 387 Runway records use an FAA-only suffix (345 water, 28 ultralight, 8 soft, 6
  - glider) and 18 use a numeric assault-strip suffix - so 405 records fail a
  - [CLRT]-only suffix validation.
  - The 'T' true-referenced suffix that ARINC defines never appears in this cycle.
  - Localizer (PI) records use only the four ARINC-standard forms, and Path Point (PP)
  - records only RW##, RW##L, RW##R and RW##C - the exotic identifiers are confined to
  - Runway records, so a shared converter must still tolerate them everywhere.

---

### 5.47 - Localizer Bearing

- SUMMARY
  - Magnetic bearing of the localizer front course (or GLS approach course) in tenths of a degree with the decimal
    point removed.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LOC BRG
  - Format: DDDd - degrees x 10 with the decimal suppressed - or DDDT for a true course.
  - When blank: No localizer course published. Does not occur in the FAA CIFP.

- CONVERTER
  - `CifpFieldConverter.Field547()` returns `double?`

- USED ON
  - `PI` — col 51-54 (Localizer Bearing)

- RETURNS
  - A double? of degrees (raw / 10.0) plus a bool IsTrueCourse. Null only for a blank slice.

- OBSERVED IN CYCLE 2607
  - `####`

- DETAILS
  - Four characters at offset 51 of the Localizer/Glide Slope (PI) record.
  - Normal case: four digits, degrees times ten. '2570' is 257.0 degrees magnetic;
  - '0147' is 14.7 degrees. Divide by 10.0.
  - True-course case: if the localizer course is charted in degrees true, the fourth
  - character is the letter 'T' and the first three characters are whole degrees -
  - '347T' is 347 degrees true. Inspect position 3 before parsing and carry a companion
  - IsTrueCourse flag on the model.
  - This is the same encoding as 5.28 Inbound Magnetic Course and 5.26 Magnetic Course;
  - a single shared converter can serve all three.
  - Range is 0.1 to 360.0 degrees; due north is coded 3600, not 0000.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - All 1,280 PI records carry four digits; the 'T' form does not occur. Observed range
  - is 0001 to 3600, i.e. 0.1 to 360.0 degrees - note that a leading-zero value such as
  - '0001' is a real 0.1-degree course, so the raw string must not be trimmed of leading
  - zeros before scaling.

---

### 5.48 - Localizer Position

- SUMMARY
  - Distance in feet from the localizer (or MLS azimuth) antenna to the runway end, at one-foot resolution.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: LOC FR RW END / AZ/BAZ FR RW END
  - Format: NNNN - feet, zero filled, unsigned.
  - When blank: No antenna offset published.

- CONVERTER
  - `CifpFieldConverter.Field548()` returns `int?`

- USED ON
  - `PI` — col 74-77 (Localizer Position)

- RETURNS
  - An int? of feet, returned together with the decoded 5.49 reference so that callers never see a bare magnitude.
    Null when blank.

- OBSERVED IN CYCLE 2607
  - `####`

- DETAILS
  - Four numeric characters, zero filled, at offset 74 of the Localizer/Glide Slope (PI)
  - record. Values are plain unsigned feet: '0950' is 950 ft, '1000' is 1,000 ft.
  - The field carries magnitude only. Which runway end the distance is measured from, and
  - on which side of it the antenna sits, is carried by the companion Localizer/Azimuth
  - Position Reference field (5.49) in the very next column. The two must be read
  - together:
  - 5.49 blank - the antenna is beyond the stop end of the runway (the normal
  - localizer geometry);
  - 5.49 '+' - the antenna is ahead of the approach end of the runway;
  - 5.49 '-' - the antenna is off to one side of the runway.
  - For Back Azimuth positions the same magnitude is read against a different reference
  - set - see 5.49.
  - Because the field is only four columns, the maximum expressible offset is 9,999 ft.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - All 1,280 PI records carry four digits; observed range is 0072 to 9999 ft. The value
  - 9999 sits exactly on the field's maximum, so treat it with suspicion - it may be a
  - saturated placeholder rather than a measured 9,999 ft.

---

### 5.49 - Localizer/Azimuth Position Reference

- SUMMARY
  - Single character saying where the antenna sits relative to the runway, qualifying the distance in 5.48.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: LOC/AZ POS REF
  - Format: One character - blank, '+' or '-'.
  - When blank: For a localizer or MLS azimuth antenna, blank means the antenna is beyond the stop end of the
    runway - the standard geometry. For a back azimuth antenna, blank means the antenna is ahead of the approach
    end. Blank is a CODE here, not missing data.

- USED ON
  - `PI` — col 78 (Localizer Position Reference)

- RETURNS
  - The raw character preserved (blank distinct from null), or a three-member enum whose default is the blank
    case. Return it alongside 5.48 so the pair is always interpreted together.

- VALUES
  - ` ` [observed] — Localizer/azimuth - antenna beyond the stop end of the runway. Back azimuth - antenna ahead of the approach end.
  - `+` [not in cycle] — Localizer/azimuth - antenna ahead of the approach end of the runway. Back azimuth - antenna beyond the stop end.
  - `-` [observed] — Antenna is off to one side of the runway; the 5.48 distance is a lateral offset, not a longitudinal one.

- OBSERVED IN CYCLE 2607
  - ` `, `-`

- DETAILS
  - One character at offset 78 of the Localizer/Glide Slope (PI) record, immediately
  - after the four-digit Localizer Position (5.48). The ARINC field title is literally
  - written as the three symbols it can take, '@, +, -', where '@' is the document's
  - notation for a blank.
  - The meaning of each character depends on whether the antenna is a localizer / MLS
  - azimuth or an MLS back azimuth, because the two are referenced to opposite ends of
  - the runway:
  - Localizer and Azimuth antennas
  - blank antenna is beyond the stop end of the runway
  - '+' antenna is ahead of the approach end of the runway
  - '-' antenna is off to one side of the runway
  - Back Azimuth antennas
  - blank antenna is ahead of the approach end of the runway
  - '+' antenna is beyond the stop end of the runway
  - '-' antenna is off to one side of the runway
  - The '-' case is the one that breaks naive geometry: it does not mean 'negative
  - distance', it means the distance in 5.48 is a lateral offset from the runway
  - centreline rather than a longitudinal one. Code that blindly negates 5.48 when it
  - sees '-' will place the antenna in the wrong place.
  - Since the FAA CIFP has no MLS records, only the localizer interpretation applies.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - '+' never occurs in the FAA CIFP: 1,225 of the 1,280 PI records are blank and 55 are
  - '-'. Because blank is by far the commonest value AND is a meaningful code, any
  - parser that calls Trim() on this slice and then treats string.Empty as 'no data'
  - will destroy 96 percent of the field's information.

---

### 5.50 - Glide Slope Position / Elevation Position

- SUMMARY
  - Distance in feet from the runway threshold to the glide slope antenna, measured along the runway.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: GS FR RW THRES
  - When blank: No glide slope component exists for this localizer (localizer-only / LDA-without-glideslope
    installations).

- CONVERTER
  - `CifpFieldConverter.Field550()` returns `int?`

- USED ON
  - `PI` — col 79-82 (Glide Slope Position)

- RETURNS
  - Distance in feet as int?, or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `    `, `####`

- DETAILS
  - Four zero-padded digits giving whole feet, resolution one foot. The distance is taken from
  - the runway threshold to the point where a line drawn perpendicular to the runway centreline
  - passes through the antenna, so it is a longitudinal offset, not a slant range.
  - In the CIFP this field appears only on the PI (Airport and Heliport Localizer and Glide
  - Slope) record at zero-based offset 79, length 4. Observed over 1,280 PI records: 1,144
  - populated, 136 blank. The populated range runs 0320 to 1581 feet.

---

### 5.51 - Localizer Width

- SUMMARY
  - Full course width of the localizer, in degrees, with the decimal point removed.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LOC WIDTH
  - When blank: Never blank in the CIFP; every localizer record carries a course width.

- CONVERTER
  - `CifpFieldConverter.Field551()` returns `decimal?`

- USED ON
  - `PI` — col 83-86 (Localizer Width)

- RETURNS
  - Course width in degrees as decimal? (raw integer / 100).

- OBSERVED IN CYCLE 2607
  - `####`

- DETAILS
  - Four digits encoding degrees, tenths and hundredths of a degree: divide the integer by 100
  - to get degrees. "0600" is 6.00 degrees, "0350" is 3.50 degrees. This is the total course
  - width (the angular sector between the full-scale left and full-scale right deflection
  - limits), not a half-width.
  - Appears only on the PI record at zero-based offset 83, length 4. All 1,280 PI records are
  - populated. Observed range 0236 (2.36 degrees) to 0652 (6.52 degrees); the single most common
  - value is 0600 (277 records), the standard 6-degree width.

---

### 5.52 - Glide Slope Angle / Minimum Elevation Angle

- SUMMARY
  - Glide slope angle in degrees with the decimal point removed (three digits, hundredths resolution).

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: GS ANGLE
  - When blank: No glide slope is installed for this localizer, so no angle is defined.

- CONVERTER
  - `CifpFieldConverter.Field552()` returns `decimal?`

- USED ON
  - `PI` — col 87-89 (Glide Slope Angle)

- RETURNS
  - Glide slope angle in degrees as decimal? (raw integer / 100), or null when blank.

- OBSERVED IN CYCLE 2607
  - `   `, `###`

- DETAILS
  - Three digits giving degrees, tenths and hundredths: divide by 100. "300" is a 3.00 degree
  - glide slope, "275" is 2.75 degrees. On MLS records the same field would carry the minimum
  - elevation angle, but the CIFP contains no MLS records so only the ILS glide slope meaning
  - applies.
  - Appears only on the PI record at zero-based offset 87, length 3. Of 1,280 PI records, 1,144
  - are populated and 136 are blank (localizer-only and LDA-without-glideslope facilities). The
  - blank set is exactly the same 136 records that are blank in 5.50, 5.67 (glide slope height)
  - and 5.74 (glide slope elevation).

- WATCH OUT
  - Twenty-seven distinct values occur; 3.00 degrees dominates with 1,072 of the 1,144 populated
  - records. The extremes are 205 (2.05 degrees) and 392 (3.92 degrees).

---

### 5.53 - Transition Altitude / Transition Level

- SUMMARY
  - Altitude in feet at which altimeter setting changes between local (QNH) and standard (QNE), carried on
    airport, heliport and procedure records.

- METADATA
  - Length: 5 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TRANS ALTITUDE/LEVEL
  - When blank: The altitude is not published, is unknown to ATC, or varies between procedures at that
    airport/heliport. On procedure records it also means simply that this leg is not the first leg of the
    transition.

- CONVERTER
  - `CifpFieldConverter.Field553()` returns `int?`

- USED ON
  - `HA` — col 70-74 (Transition Altitude); col 75-79 (Transition Level)
  - `HD` — col 94-98 (Transition Altitude)
  - `HF` — col 94-98 (Transition Altitude)
  - `PA` — col 70-74 (Transitions Altitude); col 75-79 (Transition Level)
  - `PD` — col 94-98 (Transition Altitude)
  - `PE` — col 94-98 (Transition Altitude)
  - `PF` — col 94-98 (Transition Altitude)

- RETURNS
  - Altitude in feet as int?, or null when blank. Two separate model properties on PA/HA (TransitionAltitude and
    TransitionLevel).

- OBSERVED IN CYCLE 2607
  - `     `, `#####`

- DETAILS
  - Five numeric characters, whole feet, resolution one foot, zero padded. Two distinct uses
  - share the field id:
  - - Transition Altitude: the altitude at or below which vertical position is expressed as an
  - MSL altitude on the local altimeter setting.
  - - Transition Level: the lowest usable flight level above the transition layer, i.e. flown on
  - the standard 29.92 inHg / 1013.2 hPa setting.
  - Where it lives in the CIFP (all zero-based offsets):
  - - PA Airport record: Transition Altitude at 70 length 5, Transition Level at 75 length 5.
  - - HA Heliport record: Transition Altitude at 70 length 5, Transition Level at 75 length 5.
  - - PD, PE, PF, HF and the undocumented HD procedure records: Transition Altitude at 94
  - length 5. It is coded on the first leg of each transition only, and left blank on all
  - subsequent legs.
  - Do NOT slice offset 94 on a continuation record. On the PF/HF continuation (continuation
  - record number > 1, Application Type 5.91 = "W") columns 89 through 104 zero-based carry
  - RNP-authorization data, which is why a naive slice at 94..98 produces garbage such as
  - "##A##" (54 occurrences) and "## " (245 occurrences).

- FAA NOTES
  - The FAA codes a constant 18000 everywhere it codes this field at all - that is the United
  - States transition altitude. Measured: PA 13,263 of 13,321 records = "18000", 58 blank;
  - HA 6,104 of 6,134 = "18000", 30 blank; PD 10,373 of 34,605 populated, all "18000";
  - PE 9,644 of 44,148, all "18000"; PF primary 32,375 of 122,323, all "18000".

- WATCH OUT
  - The FAA writes "18000" into the Transition LEVEL field on PA and HA records as well as into
  - the Transition Altitude field. ARINC defines Transition Level as a flight level, so a
  - strictly conforming reader would expect something like "FL180" or "18000" interpreted as a
  - level rather than an altitude. Every populated PA/HA record has both fields equal to 18000;
  - treat the level as FL180 if you need a level, but store what the file says.
  - The "##A##" and "## " patterns seen at offset 94 come only from PF continuation records
  - and are a layout collision, not real transition altitudes. Dispatch on the continuation
  - record number before slicing.

---

### 5.54 - Longest Runway

- SUMMARY
  - Length of the airport's longest runway, expressed in hundreds of feet.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LONGEST RWY
  - When blank: Never blank in the CIFP; every Airport record carries a value.

- CONVERTER
  - `CifpFieldConverter.Field554()` returns `int?`

- USED ON
  - `PA` — col 27-29 (Longest Runway)

- RETURNS
  - Length in FEET as int? (raw three-digit value multiplied by 100).

- OBSERVED IN CYCLE 2607
  - `###`

- DETAILS
  - Three zero-padded digits. The stored number is HUNDREDS of feet, so "040" is 4,000 ft and
  - "111" is 11,100 ft. Multiply by 100 to get feet. ARINC intends this to be the longest
  - hard-surfaced operational runway available without restriction, falling back to the longest
  - operational runway of any surface when no qualifying hard surface exists.
  - Appears only on the PA Airport record at zero-based offset 27, length 3. All 13,321 PA
  - records are populated. Observed range "001" (100 ft, SWORD FLIGHT PARK) to "260"
  - (26,000 ft, LIBBY CAMPS); 146 distinct values.
  - Note the adjacent field: offset 31 is Longest Runway Surface Code (5.249). Read it together
  - with this field if you need to know whether the length refers to a hard surface.

- FAA NOTES
  - The FAA readme states plainly that this field may not always represent the longest
  - HARD-SURFACE runway at the airport, which directly contradicts the ARINC definition. The
  - real file bears this out: the three longest values in the whole dataset - 260 (LIBBY CAMPS),
  - 250 (LONG LAKE) and 211 (CONCHAS LAKE) - are all water landing areas, not pavement. Never
  - present this value to a user as a hard-surface runway length without also checking 5.249.

- WATCH OUT
  - Contradicts the ARINC definition: the FAA does not guarantee a hard surface. Values above
  - about 180 are almost always seaplane/water landing areas.

---

### 5.55 - Airport/Heliport Elevation

- SUMMARY
  - Elevation of the airport or heliport in feet relative to mean sea level, signed.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ELEV
  - When blank: Never blank in the CIFP.

- CONVERTER
  - `CifpFieldConverter.Field555()` returns `int?`

- USED ON
  - `HA` — col 56-60 (Heliport Elevation)
  - `PA` — col 56-60 (Airport Elevation)

- RETURNS
  - Signed elevation in feet as int?.

- OBSERVED IN CYCLE 2607
  - `#####`, `-####`

- DETAILS
  - Five characters, whole feet, resolution one foot. For elevations at or above MSL all five
  - columns are digits and the value is zero padded, e.g. "02171". For elevations below MSL the
  - first column holds a minus sign and the remaining four are digits, e.g. "-0142". There is no
  - plus sign for positive values. The airport elevation is normally the highest point of any
  - landing surface on the field.
  - Where it lives: PA Airport record at zero-based offset 56 length 5; HA Heliport record at
  - zero-based offset 56 length 5.
  - Measured: PA 13,313 positive / 8 negative, none blank; HA 6,127 positive / 7 negative, none
  - blank. Observed range runs from -0114 to 09934 feet.

- WATCH OUT
  - Because the minus sign consumes a column, negative elevations have only four digits of
  - magnitude. Parse as: if slice[0] == '-' then -int(slice[1..4]) else int(slice).

---

### 5.57 - Runway Length

- SUMMARY
  - Overall physical length of the runway surface in feet.

- METADATA
  - Length: 5 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: RUNWAY LENGTH
  - When blank: Never blank in the CIFP.

- CONVERTER
  - `CifpFieldConverter.Field557()` returns `int?`

- USED ON
  - `PG` — col 22-26 (Runway Length)

- RETURNS
  - Runway length in feet as int?.

- OBSERVED IN CYCLE 2607
  - `#####`

- DETAILS
  - Five zero-padded digits, whole feet, resolution one foot. This is the overall pavement or
  - surface length declared suitable and available for ground operations. It IGNORES displaced
  - thresholds and EXCLUDES stopways, overruns and clearways, so it is not the landing distance
  - available and not the take-off run available. To derive operational lengths you must combine
  - it with Threshold Displacement Distance (5.69) and Stopway (5.79) - and note that the FAA
  - never populates 5.79.
  - Also note that the runway latitude/longitude in the same record is the Landing Threshold
  - Point, which may be displaced, so a great-circle distance between the two runway-end records
  - will not equal this value.
  - Appears only on the PG Runway record at zero-based offset 22, length 5. All 16,805 PG
  - records are populated. Observed range 00164 to 17302 feet.

---

### 5.58 - Runway Magnetic Bearing

- SUMMARY
  - Bearing of the runway centreline in degrees and tenths, decimal point suppressed, with an optional trailing T
    marking a true rather than magnetic bearing.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: RWY BRG
  - Format: DDDt where DDD is degrees and t is either the tenths digit or the letter T
  - When blank: No bearing is defined for this runway - in the CIFP this happens only on non-numeric runway
    designators such as NW, SE, ALL and WAY.

- CONVERTER
  - `CifpFieldConverter.Field558()` returns `decimal?`

- USED ON
  - `PG` — col 27-30 (Runway Magnetic Bearing)

- RETURNS
  - Bearing in degrees as decimal? (raw digits / 10), plus a bool IsTrueBearing set when column 4 is 'T'. Null
    bearing when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `    `, `####`

- DETAILS
  - Four columns. Normally all four are digits giving degrees and tenths of a degree with the
  - decimal point removed: "1800" is 180.0 degrees, "0605" is 60.5 degrees, "3600" is 360.0
  - degrees. If the runway is charted with a TRUE bearing rather than a magnetic one, the fourth
  - column holds the letter "T" in place of the tenths digit, e.g. "347T" meaning 347 degrees
  - true. The converter must therefore return both a numeric bearing and a flag saying whether
  - it is magnetic or true.
  - Appears only on the PG Runway record at zero-based offset 27, length 4.
  - Measured on the real file: 16,801 of 16,805 PG records carry four digits; 4 are blank; ZERO
  - records use the trailing "T" form. The blank cases are runways whose identifier is not a
  - numeric heading - 13FD RWNW and RWSE, 16WI RWALL and RWWAY. Observed numeric range 0001 to
  - 3600.

- FAA NOTES
  - When the source data has no magnetic variation available to convert a true bearing to a
  - magnetic one, the FAA computes the variation with the World Magnetic Model (WMM) calculator
  - and publishes a magnetic bearing anyway. That is why the "T" form never appears in the CIFP:
  - the FAA always resolves to magnetic rather than falling back to the true-bearing encoding.

- ARINC 424-19A DIFFERENCE
  - 424-19A widens the definition to helipad records as well as runways, where the value is
  - usually the bearing of a former fixed-wing runway that has been converted to helicopter use,
  - or a specific approach bearing supplied by the government source. The CIFP contains no
  - helipad (PK) records, so this makes no practical difference here.

- WATCH OUT
  - Four PG records have a blank bearing. They are the non-numeric runway designators the FAA
  - includes per its readme (water/soft-surface style designators NW, SE, ALL, WAY). Any code
  - that assumes a runway bearing is always present will throw on these.

---

### 5.59 - Runway Description

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Optional free-text remark about the runway, such as a surface treatment or an operating restriction.

- METADATA
  - Length: 22 characters
  - Character type: alphanumeric
  - Kind: freetext
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: RUNWAY DESCRIPTION
  - When blank: No supplementary runway remark is supplied.

- USED ON
  - `PG` — col 101-122 (Runway Description)

- RETURNS
  - Trimmed remark string, or null. In the CIFP this is always null.

- OBSERVED IN CYCLE 2607
  - `                      `

- DETAILS
  - Twenty-two characters of unstructured text whose contents are chosen when the record is
  - assembled. ARINC gives examples like "GROOVED" or "SINGLE ENG. ONLY". There is no code
  - table and no parsing rule; treat it as an opaque string.
  - Appears only on the PG Runway record at zero-based offset 101, length 22.
  - Measured on the real file: all 16,805 PG records have this field entirely blank. The FAA
  - does not use it. Keep the property in the model for completeness but expect null.

---

### 5.66 - Station Declination

- SUMMARY
  - Angular offset between true north and the reference the facility is aligned to, given as a direction letter
    followed by degrees and tenths.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: STN DEC
  - When blank: Never blank in the CIFP on either record type that carries it.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `D` — col 74-78 (Station Declination)
  - `PI` — col 90-94 (Station Declination)

- RETURNS
  - Signed declination in degrees as decimal?: +(digits/10) for 'E', -(digits/10) for 'W', 0 for 'T' and 'G'. Also
    expose the raw direction letter so callers can distinguish a true-north or grid-north alignment from a genuine
    zero declination.

- COLUMNS (this field packs several independent values)
  - **DeclinationDirection** — offset 0, length 1
    - `E` [observed] — Declination is east of true north (positive)
    - `W` [observed] — Declination is west of true north (negative)
    - `T` [not in cycle] — Station is aligned to true north even though local variation is non-zero; magnitude columns are zero
    - `G` [not in cycle] — Station is aligned to grid north; the true declination cannot be expressed, magnitude columns are zero
  - **DeclinationMagnitude** — offset 1, length 4

- OBSERVED IN CYCLE 2607
  - `E####`, `W####`

- DETAILS
  - Five columns split into two independent parts. Column 1 (zero-based offset +0) is a
  - direction/orientation letter; columns 2 to 5 (offset +1, length 4) are degrees and tenths of
  - a degree with the decimal point suppressed, so "0072" means 7.2 degrees.
  - For a VHF NAVAID the value is the difference between true north and the zero-degree radial
  - as measured at the last site check. For an ILS localizer it is the difference between true
  - north and magnetic north at the antenna site at the time the localizer course bearing was
  - established. It is deliberately NOT the same thing as Magnetic Variation (5.39): station
  - declination is frozen at the time of the site check, while magnetic variation is a modelled
  - present-day value.
  - When column 1 is "T" or "G", ARINC requires the magnitude columns to be all zeros.
  - Where it lives: D VHF NAVAID record at zero-based offset 74 length 5; PI Localizer and
  - Glide Slope record at zero-based offset 90 length 5.
  - Measured: all 2,083 D records populated (1,187 E, 896 W); all 1,280 PI records populated
  - (559 E, 721 W). Neither T nor G ever appears. Observed magnitudes E0000 to E0210 and
  - W0000 to W0210.

- WATCH OUT
  - ARINC's commentary warns that a 'G' in column 1 means the value is unknown rather than zero.
  - It never occurs in the CIFP, but a converter that collapses everything to a signed number
  - will silently misreport such a record if the FAA ever emits one - keep the letter.

---

### 5.67 - Threshold Crossing Height

- SUMMARY
  - Height in feet above the landing threshold at which a nominal glide path crosses it.

- METADATA
  - Length: 2 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TCH
  - When blank: No glide path exists for this facility (localizer-only or LDA-without-glideslope installations on
    the PI record).

- CONVERTER
  - `CifpFieldConverter.Field567()` returns `int?`

- USED ON
  - `PG` — col 75-76 (Threshold Crossing Height)
  - `PI` — col 95-96 (Glide Slope Height at Landing Threshold)

- RETURNS
  - Threshold crossing height in feet as int?, or null when blank. Field width must be supplied by the caller (2
    on PG/PI, 3 on approach continuations).

- OBSERVED IN CYCLE 2607
  - `  `, `##`

- DETAILS
  - Whole feet. The field width DEPENDS ON THE RECORD:
  - - 2 characters on Airport/Heliport ILS (PI), MLS and Runway (PG) records.
  - - 3 characters on Airport/Heliport Approach Continuation records.
  - In the FAACIFP18 file only the two-character form occurs, at:
  - - PG Runway record, zero-based offset 75, length 2 (labelled Threshold Crossing Height).
  - - PI Localizer/Glide Slope record, zero-based offset 95, length 2 (labelled Glide Slope
  - Height at Landing Threshold).
  - The two are not interchangeable. The runway record carries a single representative TCH for
  - the runway, selected in priority order: the ILS/MLS glide slope height, else the published
  - RNAV procedure TCH, else a published VGSI TCH, else a default. The ILS record carries the
  - actual glide slope height at the threshold. They can differ, sometimes significantly, and a
  - procedure-versus-threshold altitude comparison should be made against the procedure value,
  - not the runway value.
  - Note the adjacent PG field at offset 80: TCH Value Indicator (5.270) tells you which source
  - the runway TCH came from. Read it alongside this field.
  - Measured: all 16,805 PG records populated, range 04 to 88 feet; 50 is by far the most common
  - (9,837 records) and 40 second (2,123). PI: 1,144 of 1,280 populated, 136 blank - the same
  - 136 glide-slope-less facilities that are blank in 5.50, 5.52 and 5.74.

- ARINC 424-19A DIFFERENCE
  - 424-18 says the fallback default when nothing else is available is 50 feet. 424-19A replaces
  - that with a table: 40 feet on runway records whose approaches are all published for Category
  - A and B aircraft only, and on runways shorter than 6,000 ft with no published approach;
  - 50 feet where at least one approach is published for Category C or D aircraft, and on
  - runways of 6,000 ft or more with no published approach. The heavy 50/40 clustering in the
  - real file is consistent with the 424-19A table being applied.

---

### 5.68 - Landing Threshold Elevation

- SUMMARY
  - Elevation in feet MSL of the landing threshold of the runway described by the record.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LANDING THRES ELEV
  - When blank: Never blank in the CIFP.

- CONVERTER
  - `CifpFieldConverter.Field568()` returns `int?`

- USED ON
  - `PG` — col 66-70 (Landing Threshold Elevation)

- RETURNS
  - Signed threshold elevation in feet as int?.

- OBSERVED IN CYCLE 2607
  - `#####`, `-####`

- DETAILS
  - Five characters, whole feet, resolution one foot. At or above MSL the five columns are all
  - digits, zero padded. Below MSL the first column is a minus sign and the remaining four are
  - digits. No plus sign is used.
  - This is the elevation of the threshold itself, which is the point the runway
  - latitude/longitude in the same record describes, so it is not necessarily the airport
  - elevation (5.55) and not necessarily the highest point on the runway.
  - Appears only on the PG Runway record at zero-based offset 66, length 5.
  - Measured: all 16,805 PG records populated - 16,779 positive, 26 negative. Observed range
  - -0024 to 09931 feet.

- WATCH OUT
  - Same packed-sign encoding as 5.55 and 5.74: the minus sign eats a digit column, so a
  - negative value has only four digits of magnitude.

---

### 5.69 - Threshold Displacement Distance

- SUMMARY
  - Distance in feet from the physical end of the runway to a threshold that is not located at that end.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: DSPLCD THR
  - When blank: Never blank in the CIFP; an undisplaced threshold is coded 0000, not blank.

- CONVERTER
  - `CifpFieldConverter.Field569()` returns `int?`

- USED ON
  - `PG` — col 71-74 (Displaced Threshold Distance)

- RETURNS
  - Displacement in feet as int?; 0 means the threshold is not displaced.

- OBSERVED IN CYCLE 2607
  - `####`

- DETAILS
  - Four zero-padded digits, whole feet. Measured along the runway from the extremity of the
  - pavement to the displaced landing threshold. A value of 0000 means the threshold is at the
  - runway end, i.e. not displaced. Use this together with Runway Length (5.57) and Stopway
  - (5.79) to work out landing distance available.
  - Appears only on the PG Runway record at zero-based offset 71, length 4.
  - Measured: all 16,805 PG records populated. 14,785 are "0000" (no displacement); the largest
  - observed displacement is 4251 feet.

---

### 5.70 - Vertical Angle

- SUMMARY
  - Descent angle in degrees for the vertical path flown from the coded fix, with the decimal point suppressed and
    a leading minus marking descent.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: VERT ANGLE
  - Format: s### where s is '-' for descent or blank, and ### is degrees to two decimal places with the point removed
  - When blank: No vertical path is defined for this leg.

- CONVERTER
  - `CifpFieldConverter.Field570()` returns `double?`

- USED ON
  - `HD` — col 102-105 (Vertical Angle)
  - `HF` — col 102-105 (Vertical Angle)
  - `PD` — col 102-105 (Vertical Angle)
  - `PE` — col 102-105 (Vertical Angle)
  - `PF` — col 102-105 (Vertical Angle)

- RETURNS
  - Descent angle in degrees as a NEGATIVE decimal? (raw digits / 100, negated when column 1 is '-'), null when
    blank. Expose the FAA ' 000' case distinctly - suggest a companion bool such as NoPublishedDescentAngle - so
    callers do not mistake it for a 0.00 degree glide path.

- OBSERVED IN CYCLE 2607
  - `    `, ` ###`, `-###`

- DETAILS
  - Four columns. Column 1 is the sign (a minus for descending flight, blank otherwise) and
  - columns 2 to 4 are degrees, tenths and hundredths of a degree with the decimal point
  - suppressed. "-300" is a 3.00 degree descent; "-375" is 3.75 degrees. The maximum
  - representable angle is 9.99 degrees.
  - Semantically the angle is a backward projection: the aircraft flies at the last coded
  - altitude and then descends on this angle, projected back from the fix and altitude at which
  - the angle is coded. Vertical angles are only ever provided for DESCENDING navigation - there
  - is no climb encoding.
  - Sources, in priority order: where a navaid provides an electronic glide slope, the angle is
  - that glide slope's angle; where a VNAV angle is published, it is that; otherwise the data
  - supplier computes it.
  - Position: zero-based offset 102, length 4 on PD, PE, PF, HF and the undocumented HD
  - procedure records.
  - Measured on the real file: PD and PE never populate it (all 34,605 and all 44,148 blank).
  - PF primary records: 107,466 blank, 13,950 with a negative angle, 907 with " 000". HF: 21
  - blank, 2 with " 000". Observed negative range -205 (2.05 degrees) to -891 (8.91 degrees).

- FAA NOTES
  - The FAA codes "000" - which appears in the slice as a blank sign column followed by three
  - zeros, i.e. " 000" - for circling procedures and for dive-and-drive procedures. It also
  - codes "000" for straight-in aligned procedures when Flight Inspection has identified
  - obstacles in the visual areas. So a zero here does NOT mean a level path; it is a positive
  - statement that no continuous descent angle is published for that procedure. Measured: 907
  - PF records and 2 HF records carry " 000".

- ARINC 424-19A DIFFERENCE
  - 424-19A only clarifies the wording of the definition and tightens the Attachment 5 coding
  - rules (the vertical angle must be coded on both the FAF and the fix carrying the missed
  - approach point). The encoding is unchanged. Note that the extracted v19 text file for this
  - field in this repository is corrupt - it contains Supplement 16 change-log pages instead of
  - the section 5.70 body - so rely on the 424-18 text.

- WATCH OUT
  - 1. Two PF CONTINUATION records show digits at offsets 102-105 ("## " pattern). They are not
  - vertical angles. On the Level of Service continuation the 424-19A layout puts an
  - RNP Authorized flag at offset 101 and an RNP Level of Service value at offsets 102-104.
  - Dispatch on the continuation record number (offset 38) before slicing this field.
  - 2. The " 000" value is FAA-specific and is not described anywhere in ARINC 424-18. Reading
  - it naively yields "descend at 0.00 degrees", which is operationally wrong.

---

### 5.71 - Name Field

- SUMMARY
  - Plain-language facility name for a navaid, airport or heliport, taken from official government publications.

- METADATA
  - Length: 30 characters
  - Character type: alphanumeric
  - Kind: freetext
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: NAME
  - When blank: No name is supplied. Does not occur in the CIFP - every record that carries this field has a name.

- USED ON
  - `D` — col 93-122 (VOR Name)
  - `DB` — col 93-122 (NDB Name)
  - `HA` — col 93-122 (Heliport Name)
  - `PA` — col 93-122 (Airport Name)
  - `PN` — col 93-122 (NDB Name)

- RETURNS
  - Trimmed name string, or null if the field were ever blank.

- DETAILS
  - Thirty columns of free text, left justified and blank padded to the right. ARINC labels the
  - character type as "Alpha", but that is inaccurate: real values contain digits, apostrophes,
  - hyphens, slashes, ampersands, parentheses, commas, periods, quotation marks and the hash
  - sign. The observed character set in FAACIFP18 is exactly:
  - space " # & ' ( ) , - . / 0-9 A-Z. There are no lowercase letters.
  - A parenthetical suffix after the official name is used to disambiguate location, e.g.
  - "LOWE AHP (FORT RUCKER)". Names are truncated to fit thirty columns rather than abbreviated
  - intelligently, so partial words at the end are normal, e.g. "HARTSFIELD/JACKSON ATLAN" and
  - "DETROIT METRO WAYNE COUN".
  - Where it lives (zero-based offset 93, length 30 in every case):
  - - D VHF NAVAID record: VOR Name
  - - DB NDB NAVAID record: NDB Name
  - - PN Terminal NDB record: NDB Name
  - - PA Airport record: Airport Name
  - - HA Heliport record: Heliport Name
  - Measured: 19,178 distinct values across those five record types, none blank, none with a
  - leading space, longest exactly 30 characters (i.e. truncated to the field width).

- WATCH OUT
  - There is no Field Value Examples file for 5.71 because the extractor masks digits and lists
  - unique values, which for free-text names would reproduce most of the dataset. Treat the
  - field as free text: no validation, no code table, and no assumption that it is alphabetic
  - despite what the ARINC character-type line says.

---

### 5.72 - Speed Limit

- SUMMARY
  - Speed restriction in knots indicated airspeed, applied either at a procedure fix or across an airport's
    terminal area.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: SPEED LIMIT
  - When blank: No speed restriction applies at this fix, or none is published for this airport/heliport terminal
    area.

- CONVERTER
  - `CifpFieldConverter.Field572()` returns `int?`

- USED ON
  - `HA` — col 61-63 (Speed Limit)
  - `HD` — col 99-101 (Speed Limit)
  - `HF` — col 99-101 (Speed Limit)
  - `PA` — col 61-63 (Speed Limit)
  - `PD` — col 99-101 (Speed Limit)
  - `PE` — col 99-101 (Speed Limit)
  - `PF` — col 99-101 (Speed Limit)

- RETURNS
  - Speed limit in knots IAS as int?, or null when blank. Always pair it with Speed Limit Description (5.261)
    before presenting it as a restriction.

- OBSERVED IN CYCLE 2607
  - `   `, `###`

- DETAILS
  - Three zero-padded digits, knots indicated airspeed (KIAS). Two uses:
  - - On Airport (PA) and Heliport (HA) records, offset 61 length 3: the maximum speed allowed
  - for all flights departing or arriving in that terminal area at and below the Speed Limit
  - Altitude (5.73).
  - - On SID/STAR/Approach records (PD, PE, PF, HF and the undocumented HD), offset 99 length 3:
  - a speed restriction attached to the fix coded in that leg. It must be read together with
  - Speed Limit Description (5.261) at offset 117, which says whether the value is a mandatory,
  - at-or-below or at-or-above restriction.
  - Propagation rules differ by procedure type and matter for anyone rendering a procedure:
  - - On a SID, the limit applies BACKWARDS - to every leg from the start of the procedure (or
  - from the previous coded speed limit) up to and including the leg on which it is coded.
  - - On a STAR or an approach, the limit applies FORWARDS from the leg on which it is coded
  - until superseded by another limit or until the end of the procedure.
  - Measured: PA and HA never populate it - all 13,321 PA and all 6,134 HA records are blank.
  - On procedures: PD 763 of 34,605 populated (175 to 290 kt), PE 5,378 of 44,148 (190 to
  - 300 kt), PF primary 3,374 of 122,323 (070 to 310 kt), HF 11 of 23.

- FAA NOTES
  - The FAA leaves the airport and heliport terminal-area speed limit blank throughout, which is
  - consistent with it also leaving Speed Limit Altitude (5.73) blank. Only procedure legs carry
  - speed limits.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds one rule: when the limit is coded on a leg whose Path and Termination (5.21) is
  - HA, HF or HM, the speed limit is valid for the duration of that holding leg.

- WATCH OUT
  - On PF CONTINUATION records the slice at offset 99-101 shows patterns such as "# " (52
  - records) and "#A#" (2 records). These are not speed limits - the Level of Service
  - continuation layout puts RNP authorization data across those columns. Dispatch on the
  - continuation record number at offset 38 before slicing.

---

### 5.73 - Speed Limit Altitude

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Altitude at and below which the terminal-area speed limit in 5.72 applies.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: SPEED LIMIT ALT
  - When blank: No terminal-area speed limit altitude is published. In the CIFP this is always the case.

- CONVERTER
  - `CifpFieldConverter.Field573()` returns `int?`

- USED ON
  - `HA` — col 22-26 (Speed Limit Altitude)
  - `PA` — col 22-26 (Speed Limit Altitude)

- RETURNS
  - Altitude in feet as int?, converting an 'F'-prefixed flight level by multiplying the level by 100. Null in
    every CIFP record.

- OBSERVED IN CYCLE 2607
  - `     `

- DETAILS
  - Five characters, in one of two forms:
  - - Whole feet MSL, zero padded, e.g. "10000".
  - - A flight level written as the letter F followed by the level, e.g. "F125" for FL125,
  - left justified and blank padded.
  - Appears on the Airport (PA) and Heliport (HA) records at zero-based offset 22, length 5.
  - Measured: all 13,321 PA records and all 6,134 HA records have this field blank. The FAA
  - supplies no terminal-area speed limit altitude, which matches it also leaving Speed Limit
  - (5.72) blank on those records.

- WATCH OUT
  - Never populated by the FAA, so the flight-level form is untested against real data. If it
  - ever appears, note that "F125" is only four characters in a five-column field - the value is
  - left justified, not zero padded like the feet form.

---

### 5.74 - Component Elevation

- SUMMARY
  - Elevation in feet MSL of a specific navigation component: the glide slope, MLS elevation, azimuth or back
    azimuth antenna, or the GLS ground station.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: GS ELEV
  - When blank: The component does not exist for this facility - on the CIFP's PI records, no glide slope is
    installed.

- CONVERTER
  - `CifpFieldConverter.Field574()` returns `int?`

- USED ON
  - `PI` — col 97-101 (Glide Slope Elevation)

- RETURNS
  - Signed component elevation in feet as int?, or null when blank.

- OBSERVED IN CYCLE 2607
  - `     `, `#####`, `-####`

- DETAILS
  - Five characters, whole feet, referenced to MSL. All digits and zero padded for elevations at
  - or above MSL; a minus sign in the first column and four digits for elevations below MSL.
  - The field id covers several differently named fields that share one encoding:
  - - Glide Slope Elevation on a Localizer record.
  - - Elevation, Azimuth and Back Azimuth component elevations on MLS records.
  - - GLS ground station elevation on a GLS record.
  - In the CIFP only the first applies. It sits on the PI (Airport and Heliport Localizer and
  - Glide Slope) record at zero-based offset 97, length 5, as Glide Slope Elevation.
  - Measured: of 1,280 PI records, 1,141 positive, 3 negative, 136 blank. The 136 blanks are the
  - same localizer-only and LDA-without-glideslope facilities that are blank in 5.50, 5.52 and
  - 5.67. Observed range -0004 to 07659 feet.

- WATCH OUT
  - Same packed-sign encoding as 5.55 and 5.68; a negative elevation carries only four digits of
  - magnitude.

---

### 5.79 - Stopway

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Length in feet of the paved deceleration area beyond the departure end of the runway.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: STOPWAY
  - When blank: No stopway length is supplied. In the CIFP this is always the case.

- CONVERTER
  - `CifpFieldConverter.Field579()` returns `int?`

- USED ON
  - `PG` — col 86-89 (Stopway)

- RETURNS
  - Stopway length in feet as int?, or null. In the CIFP always null.

- OBSERVED IN CYCLE 2607
  - `    `

- DETAILS
  - Four zero-padded digits, whole feet. A stopway is the area beyond the take-off runway, at
  - least as wide as the runway and centred on its extended centreline, designated for
  - decelerating an aeroplane during a rejected take-off. It is not usable for landing or
  - take-off roll, so it is excluded from Runway Length (5.57) and must be added separately when
  - computing accelerate-stop distance available.
  - Appears only on the PG Runway record at zero-based offset 86, length 4.
  - Measured: all 16,805 PG records have this field blank. The FAA supplies no stopway data in
  - the CIFP.

- WATCH OUT
  - Because 5.79 is never populated, any operational-length calculation described in ARINC
  - Figure 5-9 that depends on stopway cannot be completed from CIFP data alone.

---

### 5.80 - ILS/MLS/GLS Category

- SUMMARY
  - Performance category of an ILS/MLS/GLS facility, or the classification of a non-ILS localizer-type
    installation such as LDA, SDF or IGS.

- METADATA
  - Length: 1 character
  - Character type: alphanumeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: CAT
  - When blank: No localizer, MLS or GLS facility is associated with this runway end.

- CONVERTER
  - `CifpFieldConverter.Field580()` returns `string`

- USED ON
  - `PG` — col 85 (Localizer/MLS/GLS Category/Class); col 94 (Second Localizer/MLS/GLS Category/Class)
  - `PI` — col 17 (ILS Category)

- RETURNS
  - A resolved category/classification description (or enum member) for the character, or null when blank. Note
    the letter 'I' is a value in this table - do not confuse it with the digit 1.

- VALUES
  - `0` [observed] — ILS localizer only, no glide slope
  - `1` [observed] — ILS localizer / MLS / GLS Category I
  - `2` [observed] — ILS localizer / MLS / GLS Category II
  - `3` [observed] — ILS localizer / MLS / GLS Category III
  - `I` [not in cycle] — IGS (Instrument Guidance System) facility
  - `L` [observed] — LDA facility with glide slope
  - `A` [observed] — LDA facility, no glide slope
  - `S` [not in cycle] — SDF facility with glide slope
  - `F` [not in cycle] — SDF facility, no glide slope
  - ` ` [observed] — No localizer-type facility associated with this runway end

- OBSERVED IN CYCLE 2607
  - ` `, `#`, `A`, `L`

- DETAILS
  - A single character. The table mixes two ideas: the digits give an operating-minimums
  - performance category, while the letters classify the type of localizer-family installation.
  - A category value does not by itself authorise use of the facility to that level.
  - Where it lives (all zero-based):
  - - PG Runway record, offset 85 length 1: Localizer/MLS/GLS Category/Classification, paired
  - with the reference path identifier at offsets 81-84.
  - - PG Runway record, offset 94 length 1: SECOND Localizer/MLS/GLS Category/Classification,
  - paired with the second reference path identifier at offsets 90-93. Used when a runway end
  - is served by two localizer-type facilities.
  - - PI Localizer and Glide Slope record, offset 17 length 1: ILS Category.
  - Measured. PG first category over 16,805 records: blank 15,528, "1" 929, "3" 127, "0" 123,
  - "2" 83, "A" 12, "L" 3. PG second category: blank 16,800, "A" 2, "3" 2, "2" 1. PI ILS
  - category over 1,280 records: "1" 935, "3" 125, "0" 123, "2" 80, "A" 13, "L" 4 - never blank.

- FAA NOTES
  - The FAA includes ILS procedures for Category I only, and does not include CAT II, CAT III,
  - PRM, converging ILS or GLS procedures. Category 2 and 3 values nonetheless appear here
  - because this field describes the FACILITY classification, not the procedures published to it.
  - For LDA approaches that have both LDA and glide slope minima, the FAA codes the procedure to
  - LDA minimums only - which is consistent with "A" (LDA, no glideslope) outnumbering "L"
  - (LDA with glideslope) in the data.

- WATCH OUT
  - 1. The Field Value Examples file masks every digit as '#', so it reports only ' ', '#', 'A'
  - and 'L'. The real file distinguishes 0, 1, 2 and 3, and those distinctions matter.
  - 2. The letter "I" (IGS) and the digit "1" (Category I) are visually confusable and both
  - legal. Compare as characters, never by a numeric parse.
  - 3. Category 3 appears on 127 runway records and 125 localizer records even though the CIFP
  - contains no CAT III procedures.

---

### 5.81 - ATC Indicator

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Flags that the altitudes coded on this procedure leg may be changed by ATC, or will be assigned by ATC.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ATC
  - When blank: The altitudes in this leg are as published and are not flagged as ATC-modifiable or ATC-assigned.

- CONVERTER
  - `CifpFieldConverter.Field581()` returns `string`

- USED ON
  - `HD` — col 83 (ATC Indicator)
  - `HF` — col 83 (ATC Indicator)
  - `PD` — col 83 (ATC Indicator)
  - `PE` — col 83 (ATC Indicator)
  - `PF` — col 83 (ATC Indicator)

- RETURNS
  - The resolved meaning of 'A' or 'S', or null when blank. In the CIFP always null.

- VALUES
  - `A` [not in cycle] — The official source states the coded altitude can be modified or assigned by ATC
  - `S` [not in cycle] — The official source states the altitude will be assigned by ATC, or no altitude is supplied
  - ` ` [observed] — Not flagged; the coded altitudes stand as published

- OBSERVED IN CYCLE 2607
  - ` `

- DETAILS
  - A single alpha character sitting immediately before the two altitude fields, so it qualifies
  - Altitude 1 (offset 84) and Altitude 2 (offset 89) together with Altitude Description (5.29,
  - offset 82).
  - Position: zero-based offset 83, length 1 on PD, PE, PF, HF and the undocumented HD procedure
  - records.
  - Measured: blank on every one of the 34,605 PD, 44,148 PE, 129,064 PF, 24 HF and 15 HD
  - records. The FAA does not use this field.

- WATCH OUT
  - Never populated. Any logic that relies on this field to decide whether an altitude is a hard
  - constraint will get no signal from CIFP data - use Altitude Description (5.29) instead.

---

### 5.82 - Waypoint Usage

- SUMMARY
  - Two columns saying which airway structure a waypoint belongs to: column 1 flags RNAV use, column 2 gives the
    altitude structure (high, low, or both).

- METADATA
  - Length: 2 characters
  - Character type: alpha
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: WPT USAGE
  - When blank: Both columns blank means the waypoint is for terminal use only - it is not part of the enroute
    high or low airway structure.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `EA` — col 29-30 (Waypoint Usage)
  - `HC` — col 29-30 (Waypoint Usage)
  - `PC` — col 29-30 (Waypoint Usage)

- RETURNS
  - Two separate values: a bool IsRnavStructure from column 1, and a resolved altitude-structure enum (Both / High
    / Low / TerminalOnly) from column 2.

- COLUMNS (this field packs several independent values)
  - **RnavUsage** — offset 0, length 1
    - `R` [not in cycle] — Waypoint is used in the RNAV route structure
    - ` ` [observed] — Not flagged for RNAV use
  - **AltitudeStructure** — offset 1, length 1
    - `B` [observed] — Used in both the high and the low altitude structure
    - `H` [observed] — Used in the high altitude structure only
    - `L` [observed] — Used in the low altitude structure only
    - ` ` [observed] — Terminal use only - not part of the enroute structure

- OBSERVED IN CYCLE 2607
  - `  `, ` B`, ` H`, ` L`

- DETAILS
  - Two adjacent but INDEPENDENT single-character columns. ARINC presents them as one table
  - which is easy to misread; the two columns do not form a single two-character code.
  - Column 1 (zero-based offset +0): "R" means the waypoint is used in the RNAV structure;
  - blank otherwise.
  - Column 2 (zero-based offset +1): the altitude structure the waypoint serves.
  - "B" both high and low altitude structures, "H" high altitude only, "L" low altitude only,
  - blank means terminal use only.
  - Position: zero-based offset 29, length 2 on EA (enroute waypoint), PC (airport terminal
  - waypoint) and HC (heliport terminal waypoint) records.
  - Measured. EA over 32,401 records: " " 23,258, " L" 6,265, " B" 1,505, " H" 1,373. PC: all
  - 37,626 records blank. HC: all 9 records blank.

- FAA NOTES
  - ARINC says this field is used on enroute (EA) waypoint records, and that is where the FAA
  - populates it. The terminal waypoint records (PC and HC) carry the field in their layout but
  - the FAA leaves it blank throughout, which is consistent - a terminal waypoint is by
  - definition terminal use only. The FAA also never sets the RNAV column, even for waypoints
  - that sit on Q and T RNAV routes.

- WATCH OUT
  - Column 1 ("R" for RNAV) is NEVER set in the CIFP, not even on waypoints that form Q-routes
  - and T-routes. Do not use this field to detect RNAV waypoints - use the airway's Route Type
  - (5.7 = "R") instead.

---

### 5.90 - ILS/DME Bias

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Offset applied to a co-located ILS or MLS DME so that it reads zero at the runway threshold rather than at the
    antenna.

- METADATA
  - Length: 2 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ILS/DME BIAS
  - When blank: The DME is unbiased. In the CIFP this is always the case.

- CONVERTER
  - `CifpFieldConverter.Field590()` returns `decimal?`

- USED ON
  - `D` — col 85-86 (ILS/DME Bias)

- RETURNS
  - Bias in nautical miles as decimal? (raw digits / 10), or null when blank. In the CIFP always null.

- OBSERVED IN CYCLE 2607
  - `  `

- DETAILS
  - Two digits giving nautical miles and tenths of a nautical mile with the decimal point
  - suppressed: "13" is 1.3 NM, "91" is 9.1 NM. The field is blank for unbiased DMEs.
  - Appears on the D (VHF NAVAID) record at zero-based offset 85, length 2, and applies only
  - when that record describes an ILS/DME or MLS/DME facility.
  - Measured: all 2,083 D records have this field blank. The FAA supplies no DME bias values in
  - the CIFP.

- WATCH OUT
  - Never populated. Note that the field is only two characters wide, so the maximum expressible
  - bias is 9.9 NM.

---

### 5.91 - Continuation Record Application Type

- SUMMARY
  - Says what kind of continuation record this is, and therefore which field layout the rest of the record
    follows.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: APPL
  - When blank: Not applicable - the record is a primary record, not a continuation. The field only exists on
    continuation records.

- CONVERTER
  - `CifpFieldConverter.Field591()` returns `string`

- USED ON
  - `HF~cont` — col 39 (Application Type)
  - `PF~cont` — col 39 (Application Type)
  - `PP~cont` — col 27 (Application Type)
  - `UR~cont` — col 25 (Application Type)

- RETURNS
  - A resolved continuation-application enum used to select the continuation layout. The parser should treat an
    unrecognised value as a hard stop rather than guessing a layout.

- VALUES
  - `A` [not in cycle] — Standard ARINC continuation carrying notes or other formatted data not covered by a defined continuation type
  - `B` [not in cycle] — Combined controlling agency / call sign plus formatted time of operation
  - `C` [observed] — Call sign / controlling agency continuation
  - `E` [observed] — Primary record extension
  - `L` [not in cycle] — VHF navaid limitation continuation
  - `N` [not in cycle] — Sector narrative continuation
  - `P` [not in cycle] — Flight planning application continuation
  - `Q` [not in cycle] — Flight planning application primary data continuation
  - `S` [not in cycle] — Simulation application continuation
  - `T` [not in cycle] — Time of operations continuation, formatted time data
  - `U` [not in cycle] — Time of operations continuation, narrative time data
  - `V` [not in cycle] — Time of operations continuation, start and end dates
  - `W` [observed] — Airport or heliport procedure data continuation carrying SBAS use authorization information (the Level of Service record)

- OBSERVED IN CYCLE 2607
  - ` `, `B`, `C`, `E`, `H`, `L`, `V`, `W`, `X`, `Y`, `Z`

- DETAILS
  - A single alpha character carried on continuation records only. It is the dispatch key: a
  - continuation record's layout from this column onward is defined by the application type, so
  - the parser must read Continuation Record Number (5.16) first to know it has a continuation,
  - then read this field, then choose the layout.
  - Where it lives in the CIFP (all zero-based offsets):
  - - PF and HF Approach Level of Service continuation: Continuation Record Number at offset 38,
  - Application Type at offset 39.
  - - PP Path Point continuation: Continuation Record Number at offset 26, Application Type at
  - offset 27.
  - - UR Restrictive Airspace continuation: Continuation Record Number at offset 24, Application
  - Type at offset 25.
  - Continuation Record Number convention in this file: "0" means the primary record has no
  - continuation, "1" means it is a primary record that is followed by one, and "2" or higher is
  - the continuation record itself. So a record is a continuation when its continuation number is
  - not "0" and not "1".
  - Measured application types on genuine continuation records:
  - - PF: 6,741 continuations, all "W".
  - - HF: 1 continuation, "W".
  - - PP: 4,905 continuations, all "E".
  - - UR: 1,175 continuations, all "C".
  - All three usages are consistent with the ARINC table:
  - - "W" on PF/HF is the Airport Procedure Data Continuation carrying SBAS use authorization -
  - the FAA readme calls these the Level of Service continuation records and says 424-19A
  - applies to them.
  - - "E" on PP is Primary Record Extension, which is exactly what the Path Point continuation
  - is: additional ellipsoid/orthometric heights, approach type identifier, GNSS channel and
  - helicopter procedure course that do not fit in the primary.
  - - "C" on UR is Call Sign / Controlling Agency Continuation, matching the FAA readme
  - statement that continuation records for UR records are included only for controlling
  - agencies (5.140, offset 99 length 24).
  - No mismatch with the ARINC text was found for any of the three.

- FAA NOTES
  - The FAA readme confirms two of the three: it applies ARINC 424 version 19 to the level of
  - service continuation record, and it states that UR continuation records exist only to carry
  - controlling agencies. It says nothing directly about the PP continuation.

- ARINC 424-19A DIFFERENCE
  - 424-19A keeps the same code table and only rewords the "A" entry to "a standard ARINC
  - continuation containing notes or other formatted data not covered by a defined
  - continuation". More importantly, 424-19A changes the LAYOUT that "W" selects: section 4.1.9.5
  - adds up to four pairs of RNP Authorized (5.276) plus RNP Level of Service value at columns
  - 89-104 (zero-based 88-103), where 424-18 had blank spacing. The FAA emits that 424-19A
  - layout - see anomalies.

- WATCH OUT
  - 1. THE FIELD VALUE EXAMPLES FILE FOR 5.91 IS CONTAMINATED. It lists ' ', B, C, E, H, L, V,
  - W, X, Y and Z. Only C, E and W are real application types. The extractor sampled the same
  - column on PRIMARY records, where a different field lives:
  - - PF/HF offset 39 on a primary record is Waypoint Description Code (5.17) character 1,
  - which supplies E, V, G, N and blank.
  - - UR offset 25 on a primary record is Level (5.19), which supplies L, B and H.
  - - PP offset 27 on a primary record is Route Indicator (5.224), which supplies X, Y, Z
  - and blank.
  - Reading this field without first checking the continuation record number produces
  - nonsense. Do not build the switch from that examples file.
  - 2. The CH 4 RECORD LAYOUTS CSV for the PF/HF Level of Service continuation marks zero-based
  - 73 through 117 as one 45-column blank. That is the 424-18 layout. The FAA actually emits
  - the 424-19A layout, which uses zero-based 88-103 for up to four pairs of
  - RNP Authorized (1 char) plus RNP Level of Service value (3 chars). 430 of the 6,741 PF
  - continuations carry data there - every one of them a route type "H" RNAV (RNP) procedure
  - with Route Qualifier 1 "F" (SAAAR/AR). Observed content is always the authorization
  - character "A" followed by a three-character RNP value in the standard 424 two-digit
  - mantissa plus exponent form, e.g. A031 = RNP 0.3, A152 = RNP 0.15, A112 = RNP 0.11,
  - A011 = RNP 0.1, A030 = RNP 3.0.
  - 3. Because of point 2, applying the PRIMARY record layout to a continuation record produces
  - phantom values in Transition Altitude (5.53, offsets 94-98), Speed Limit (5.72, offsets
  - 99-101) and Vertical Angle (5.70, offsets 102-105). This is the source of the "##A##",
  - "#A#" and "## " artefacts visible in those fields' example files.
  - 4. The FAA never emits application types A, B, L, N, P, Q, S, T, U or V, so the parser only
  - needs three layouts today - but it should fail loudly rather than silently on anything
  - else.

---

### 5.107 - ATA/IATA Designator

- SUMMARY
  - A three-character short code for the airport or heliport - internationally the IATA/ATA code, but in the FAA
    CIFP the three-character FAA location identifier.

- METADATA
  - Length: 3 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: ATA/IATA
  - When blank: In the FAA CIFP: the airport ICAO identifier is four characters long, so no separate three-
    character code is carried. In generic ARINC terms: no IATA code is assigned.

- CONVERTER
  - `CifpFieldConverter.Field5107()` returns `string`

- USED ON
  - `HA` — col 13-15 (ATA/IATA Designator)
  - `PA` — col 13-15 (ATA/IATA Designator)

- RETURNS
  - The trimmed three-character code, or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `   `, `AAA`, `##A`, `#A#`, `#AA`, `A##`, `AA#`

- DETAILS
  - Three characters, left justified. ARINC intends the IATA reservations code (DEN, LHR, JFK) and
  - therefore specifies the field as alpha only.
  - The FAA repurposes the column. It publishes the FAA location identifier (LID) here instead, and
  - FAA LIDs are alphanumeric - roughly 4% of the observed values contain a digit (01A, 0A1, 13S,
  - 16K, 7W4 and so on). Treat the column as alphanumeric.
  - The rule for when it is filled is mechanical: if the airport's ICAO identifier field is four
  - characters, this column is left blank; if the identifier is only three characters (which for a
  - US airport means the FAA LID is standing in for a missing ICAO code) the same three characters
  - appear here.

- FAA NOTES
  - "The IATA code field in the Airport Record will contain the FAA Airport Identifier. If the Airport Identifier
    is four characters in length, the field will be left blank." In the 2507 file 8,150 of 13,321 airport records
    and 5,941 of 6,134 heliport records have this field blank.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - ARINC declares this field alpha; the FAA writes alphanumeric FAA LIDs into it. Any validation that rejects
    digits will reject roughly a quarter of the populated values. Also note this is NOT an IATA code in the FAA
    file, so do not join it against IATA reference data.

---

### 5.108 - IFR Capability

- SUMMARY
  - Says whether the airport or heliport has at least one official published instrument approach procedure.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: IFR
  - When blank: Does not occur in the FAA CIFP - every airport and heliport record carries Y or N.

- CONVERTER
  - `CifpFieldConverter.Field5108()` returns `string`

- USED ON
  - `HA` — col 30 (IFR Indicator)
  - `PA` — col 30 (IFR Capability)

- RETURNS
  - true for Y, false for N, null for anything else.

- VALUES
  - `Y` [observed] — An official government instrument approach procedure is published for this airport or heliport
  - `N` [observed] — No published instrument approach procedure

- OBSERVED IN CYCLE 2607
  - `N`, `Y`

- DETAILS
  - One character. Y means an official government instrument approach procedure exists for this
  - airport or heliport; N means none is published.
  - Y is a statement about the real world, not about this file. It does not promise that the
  - procedure is coded in the CIFP - the FAA only publishes a subset of procedures (Cat I ILS/LOC,
  - VOR and NDB families including GPS overlays, GPS, RNAV (GPS), RNAV (RNP), plus GPS and
  - RNAV (GPS) helicopter approaches). Use the presence of PF/HF records, not this flag, to decide
  - whether procedures are available to fly from the data.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Y is set on 3,070 of 13,321 airports and on only 4 of 6,134 heliports. Because Y does not imply coded
    procedures, a consistency check that expects a PF record for every Y airport will report false positives.

---

### 5.109 - Runway Width

- SUMMARY
  - The width of the runway, in whole feet.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: WIDTH
  - When blank: Width unknown or not applicable. Does not occur in the FAA CIFP - every runway record has a value.

- CONVERTER
  - `CifpFieldConverter.Field5109()` returns `int?`

- USED ON
  - `PG` — col 77-79 (Runway Width)

- RETURNS
  - The width in whole feet as an int, or null if the slice is blank or non-numeric.

- OBSERVED IN CYCLE 2607
  - `###`

- DETAILS
  - Three zero-padded digits giving the runway width in feet, resolution one foot, taken from
  - official government source. The maximum value the field can express is 999 feet.
  - Where the runway is not a constant width along its length, the value is the narrowest width
  - encountered.
  - Note the unit: feet, not metres. The commonest values in the FAA file are 075, 100, 150 and
  - 060.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

---

### 5.115 - Directional Restriction

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - On an airway, says whether the route may be flown only in the direction it is coded, only against it, or both
    ways.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: DIR RESTR
  - When blank: On an enroute airway record, no directional restriction - the airway may be flown either way. (On
    preferred route records, which the FAA does not publish, blank has no defined meaning; F or B is expected
    there.)

- USED ON
  - `ER` — col 46 (Direction Restriction)

- RETURNS
  - null in every case against current FAA data. If the field is ever populated, return the raw character and let
    the caller apply the airway-vs-preferred-route interpretation.

- VALUES
  - `F` [not in cycle] — Airway: one-way in the coded direction. Preferred route: uni-directional, initial fix to terminus fix
  - `B` [not in cycle] — Airway: one-way opposite the coded direction. Preferred route: bi-directional
  - ` ` [observed] — Airway: no directional restriction

- OBSERVED IN CYCLE 2607
  - ` `

- DETAILS
  - One character, and its meaning depends on which record carries it.
  - Enroute airway records
  - F one-way, in the direction the airway is coded (forward)
  - B one-way, against the direction the airway is coded (backward)
  - blank no directional restriction
  - Preferred route records (not published by the FAA)
  - F uni-directional, usable only from the initial fix to the terminus fix
  - B bi-directional
  - The same two letters therefore mean different things on the two record types, and B in
  - particular flips from "one way, reversed" to "both ways". Since the FAA publishes no preferred
  - route records, only the airway reading applies here.

- FAA NOTES
  - "ATS Routes will not contain directional restrictions (5.115)." In practice the FAA leaves the column blank on
    all 19,099 airway records, not just on ATS routes - no F or B appears anywhere in the file.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - The B code means opposite things on the two record types it is defined for. Do not build one shared enum whose
    member names assume the airway meaning.

---

### 5.118 - Boundary Via

- SUMMARY
  - Describes the shape of the airspace boundary leaving this vertex - straight line, arc, circle - and flags the
    vertex that closes the boundary.

- METADATA
  - Length: 2 characters
  - Character type: alpha
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: BDRY VIA
  - When blank: Does not occur on a valid airspace primary record; a blank slice means you have read a UR
    continuation record, which has different columns at this offset.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `UC` — col 30-31 (Boundary Via)
  - `UR` — col 30-31 (Boundary Via)

- RETURNS
  - A pair: the path-type character (or a five-member enum) and a bool saying whether E was present. A C in
    position 1 should additionally tell the caller to stop reading vertices and build a circle from the arc origin
    and Arc Distance.

- COLUMNS (this field packs several independent values)
  - **PathType** — offset 0, length 1
    - `C` [observed] — Circle - the entire boundary is a circle about the arc origin given in this record
    - `G` [observed] — Great circle (straight line) to the next point
    - `H` [observed] — Rhumb line (constant bearing) to the next point
    - `L` [observed] — Counter-clockwise arc about the arc origin in this record
    - `R` [observed] — Clockwise arc about the arc origin in this record
  - **IsEndOfDescription** — offset 1, length 1
    - `E` [observed] — Last vertex - close the boundary back to the first point
    - ` ` [observed] — More vertices follow

- OBSERVED IN CYCLE 2607
  - `CE`, `G `, `GE`, `H `, `HE`, `L `, `LE`, `R `, `RE`

- DETAILS
  - Two characters that must be read separately.
  - Position 1 - how the boundary runs from the point in THIS record to the point in the NEXT record:
  - C circle (the whole boundary is one circle centred on the arc origin in this record)
  - G great circle - a straight line on the earth
  - H rhumb line - a line of constant bearing
  - L counter-clockwise arc about the arc origin in this record
  - R clockwise arc about the arc origin in this record
  - Position 2:
  - E this is the last vertex; the boundary closes from here back to the first point
  - blank more vertices follow
  - L and R (and C) are the codes that make the Arc Origin latitude/longitude, Arc Distance (5.119)
  - and Arc Bearing (5.120) columns meaningful; for G and H those four columns are blank.
  - Coding conventions worth knowing when consuming the geometry: boundaries that follow rivers or
  - political lines are approximated by a chain of G segments kept within two nautical miles of the
  - true line; boundaries along a parallel of latitude are coded H; boundaries along a meridian may
  - be coded G or H.

- FAA NOTES
  - The FAA readme does not restate the code table but does warn that positions in UR records which
  - left a gap of more than 0.02 NM between an arc end and the adjoining leg may have been
  - recalculated, so the coordinates can differ slightly from the published legal description while
  - better matching the published arc radius. It also notes that maritime limits are being
  - re-standardised to NOAA source, which can leave a coded point off the nautical boundary.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Fields 5.119 (Arc Distance) and 5.120 (Arc Bearing) both say they are entered "when Boundary
  - Via is A, C, L or R". There is no code A in the 5.118 table, in either -18 or -19A, and no A
  - appears in the FAA file. Treat the A in those two field definitions as a stale reference and key
  - off C, L and R.
  - A CE record is a complete circular airspace on its own: one vertex, path type C, end-of-
  - description E. Geometry code that expects at least two vertices before it can draw anything will
  - drop 510 airspace segments.

---

### 5.119 - Arc Distance

- SUMMARY
  - The radius, in nautical miles, from the arc origin out to the arc or circle that forms this piece of the
    airspace boundary.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: ARC DIST
  - When blank: This boundary segment is not an arc or a circle - Boundary Via is G or H - so there is no radius
    to give.

- CONVERTER
  - `CifpFieldConverter.Field5119()` returns `double?`

- USED ON
  - `UC` — col 70-73 (Arc Distance)
  - `UR` — col 70-73 (Arc Distance)

- RETURNS
  - The radius in nautical miles as a double (raw integer / 10.0), or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `    `, `####`

- DETAILS
  - Four digits, zero padded, holding nautical miles and tenths with the decimal point removed.
  - 0050 is 5.0 NM, 0150 is 15.0 NM, 1000 is 100.0 NM. Divide the parsed integer by 10.
  - The field is populated only when the Boundary Via (5.118) path type is C, L or R; for straight
  - segments (G, H) it is blank. It is read together with the Arc Origin latitude and longitude in
  - the same record and, for arcs, with the Arc Bearing (5.120).

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - The suppressed decimal point is the trap: this field is tenths of a NM while the neighbouring Sector Radius
    (5.145) on MSA records is whole NM. They are not interchangeable.

---

### 5.120 - Arc Bearing

- SUMMARY
  - The true bearing from the arc origin to the point where the arc begins.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: ARC BRG
  - When blank: This boundary segment is not an arc - Boundary Via is G or H, or the segment is a full circle - so
    there is no start bearing.

- CONVERTER
  - `CifpFieldConverter.Field5120()` returns `double?`

- USED ON
  - `UC` — col 74-77 (Arc Bearing)
  - `UR` — col 74-77 (Arc Bearing)

- RETURNS
  - The true bearing in degrees as a double (raw integer / 10.0), or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `    `, `####`

- DETAILS
  - Four digits, zero padded, holding degrees and tenths of a degree with the decimal point
  - removed. 0900 is 90.0 degrees, 1800 is 180.0, 3450 is 345.0. Divide the parsed integer by 10.
  - The bearing is TRUE, not magnetic - unlike most other bearing fields in the file. It is entered
  - only when the Boundary Via (5.118) path type is C, L or R, and is used with the arc origin
  - coordinates and Arc Distance (5.119) to place the start of the arc.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - 0000 is a legitimate bearing of due true north. Do not treat it as missing data. The bearing is true while
    nearly every other bearing in the CIFP is magnetic.

---

### 5.121 - Lower/Upper Limit

- SUMMARY
  - The floor or ceiling of a piece of special use or controlled airspace, expressed as an altitude in feet, a
    flight level, or a reserved word such as GND or UNLTD.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: LOWER/UPPER LIMIT
  - Format: nnnnn (feet) | FLnnn | GND | MSL | UNLTD | NOTSP | NOTAM | blank
  - When blank: Not the first record of this airspace. The limits are carried only on the first record of each
    area; every later vertex record leaves both limit columns blank.

- CONVERTER
  - `CifpFieldConverter.Field5121()` returns `string`

- USED ON
  - `UC` — col 81-85 (Lower Limit); col 87-91 (Upper Limit)
  - `UR` — col 81-85 (Lower Limit); col 87-91 (Upper Limit)

- RETURNS
  - A small value type: the numeric altitude in feet where one exists (FL245 becoming 24500 if you choose to
    normalise, or 245 kept as a level - pick one and document it), a kind discriminator (Feet, FlightLevel,
    Ground, Unlimited, MeanSeaLevel, NotSpecified, ByNotam, NotCoded), and the datum taken from the adjacent Unit
    Indicator.

- VALUES
  - `#####` [observed] — Altitude in feet, zero padded
  - `FL###` [observed] — Flight level, hundreds of feet
  - `GND` [observed] — Ground level
  - `UNLTD` [observed] — Unlimited - no upper bound
  - `MSL` [not in cycle] — Mean sea level
  - `NOTSP` [not in cycle] — Not specified in source
  - `NOTAM` [not in cycle] — Announced by NOTAM (restrictive airspace only)

- OBSERVED IN CYCLE 2607
  - `     `, `#####`, `FL###`, `GND  `, `UNLTD`

- DETAILS
  - Five characters. Four encodings share the column:
  - all digits an altitude, right-justified and zero padded, in feet - 05000 is 5,000 ft
  - FLnnn a flight level: the letters FL followed by hundreds of feet - FL245 is FL245
  - GND ground level
  - UNLTD unlimited (no ceiling)
  - MSL mean sea level
  - NOTSP not specified
  - NOTAM limits announced by NOTAM (restrictive airspace only)
  - Each airspace record has two of these columns side by side - the lower limit then the upper
  - limit - and each is followed immediately by its own Unit Indicator (5.133) telling you whether
  - the number is above mean sea level or above ground level.
  - The pair is written only on the first record of each airspace; the remaining vertex records of
  - the same area leave both columns blank. Any consumer that wants the vertical extent of an
  - airspace has to carry it forward from the area's first record.

- FAA NOTES
  - "Special Use Airspace Altitudes (5.121) are only coded on the first record of each area. Upper
  - altitudes are described as 'to and including'." So the ceiling is inclusive - an upper limit of
  - 17999 means the airspace includes 17,999 ft.
  - Every altitude the FAA describes as GND carries A (AGL) in its Unit Indicator.
  - A volume that is completely excluded from within an airspace is coded with the six characters
  - GND A0000A - lower limit GND with unit A, upper limit 00000 with unit A. That pattern occurs 16
  - times in the 2507 file and marks a hole, not a real 0-to-0 slab.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - The FAA "totally excluded volume" convention (GND A0000A) writes an upper limit of 00000 that
  - is not an altitude of zero feet - it is a marker for a hole punched out of the parent airspace.
  - Sixteen records use it.
  - Because the limits appear only on the first record of an area, roughly 98% of the slices are
  - blank. Code that reads limits per-vertex instead of per-area will conclude that almost all
  - airspace has no vertical extent.

---

### 5.126 - Restrictive Airspace Name

- SUMMARY
  - The plain-language name of a piece of special use airspace, written once per area.

- METADATA
  - Length: 30 characters
  - Character type: alphanumeric
  - Kind: freetext
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: REST AIRSPACE NAME
  - When blank: Either this is not the first record of the area, or the government source assigns no name to it.

- CONVERTER
  - `CifpFieldConverter.Field5126()` returns `string`

- USED ON
  - `UR` — col 93-122 (Restrictive Airspace Name)

- RETURNS
  - The trimmed name, or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `                              `, `A-###                         `, `A-###A                        `, `ABEL BRAVO MOA                `, `ANCHORAGE MERRILL SEGMENT     `, `BEAUFORT # MOA                `, `ISABELLA MOA                  `, `POWDER RIVER # LOW MOA        `, `R-####B                       `

- DETAILS
  - Thirty characters of free text, left justified and blank padded. Embedded blanks, digits and
  - hyphens all occur (ABEL BRAVO MOA, R-2524, ANCHORAGE MERRILL SEGMENT, A-291A).
  - The name is written on the first record of the area only. Every later vertex record of the same
  - airspace leaves the column blank, so the name has to be carried forward from the area's first
  - record when building a per-area object.
  - This is the long form. The short, key-like designator lives in Restrictive Airspace Designation
  - (5.129), which is only ten characters wide.

- FAA NOTES
  - For the Grand Canyon Special Flight Rules Area the FAA puts all the internal boundary names -
  - sectors and flight free zones - and their altitudes into this field. (The readme calls the field
  - 5.216 there, which is the controlled-airspace name; on a UR record the column at index 93 is
  - 5.126.)

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Blank dominates (over 94% of UR primary records) because the name is written once per area rather than once
    per vertex. Do not conclude the airspace is unnamed from a single record.

---

### 5.127 - Maximum Altitude

- SUMMARY
  - The ceiling of an airway segment - the highest altitude at which the segment may be flown.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: MAX ALT
  - Format: nnnnn (feet) | FLnnn | UNLTD | blank
  - When blank: No maximum altitude is published for this airway segment.

- CONVERTER
  - `CifpFieldConverter.Field5127()` returns `int?`

- USED ON
  - `ER` — col 93-97 (Maximum Altitude)

- RETURNS
  - The ceiling in feet as an int. If FLnnn is encountered, either normalise to feet (level x 100) or return a
    discriminated value - document which. UNLTD should map to null-with-a-flag or int.MaxValue, not to 0.

- OBSERVED IN CYCLE 2607
  - `     `, `#####`

- DETAILS
  - Five characters holding the upper limit of the airway, in one of three forms:
  - all digits altitude in feet, zero padded (17999, 08000)
  - FLnnn flight level in hundreds of feet (FL100, FL450)
  - UNLTD unlimited
  - In the FAA CIFP only the all-digit form is used. The values are dominated by three structural
  - ceilings: 17500 (11,927 records - the top of the low-altitude Victor airway structure), 45000
  - (3,581 records - the top of the high-altitude Jet/Q structure) and 60000 (1,140 records).

- FAA NOTES
  - The readme says nothing specific about this field. It does specify that Route Type (5.7) is O for conventional
    and R for RNAV routes and that the Minimum Altitude field carries the point-to-point MEA, which is the
    companion to this ceiling.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Also used on holding pattern and preferred route records in the wider standard; the FAA publishes neither, so
    on this file the field only ever appears on ER records.

---

### 5.128 - Restrictive Airspace Type

- SUMMARY
  - Says what kind of special use airspace the record describes - MOA, restricted, prohibited, warning, alert and
    so on.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: REST TYPE
  - When blank: Does not occur - every UR record carries a type.

- CONVERTER
  - `CifpFieldConverter.Field5128()` returns `string`

- USED ON
  - `UR` — col 8 (Restrictive Type)
  - `UR~cont` — col 8 (Restrictive Type)

- RETURNS
  - A typed enum value. Counts in the 2507 file: M 13,804; R 9,461; W 3,128; U 2,445; A 801; P 355.

- VALUES
  - `A` [observed] — Alert area
  - `C` [not in cycle] — Caution area
  - `D` [not in cycle] — Danger area
  - `M` [observed] — Military operations area (MOA)
  - `N` [not in cycle] — National security area - 424-19A only; the FAA codes these as U instead
  - `P` [observed] — Prohibited area
  - `R` [observed] — Restricted area
  - `T` [not in cycle] — Training area
  - `W` [observed] — Warning area
  - `U` [observed] — Unspecified or unknown. In the FAA CIFP this also carries Part 93 Special Air Traffic Rules Areas and National Security Areas

- OBSERVED IN CYCLE 2607
  - `A`, `M`, `P`, `R`, `U`, `W`

- DETAILS
  - One alpha character. Together with the ICAO code (5.14), the Restrictive Airspace Designation
  - (5.129) and the Multiple Code (5.130) it forms the identity of a special use airspace area;
  - the same designation number can exist under two different types in different regions, so the
  - type is part of the key, not just a label.

- FAA NOTES
  - The FAA uses U for two things the generic table does not cover:
  - Special Air Traffic Rules Areas described under 14 CFR Part 93, whenever their spatial
  - dimensions can be coded, are published as UR records typed U.
  - National Security Areas are also published as UR records typed U.
  - That second one matters: ARINC 424-19A defines a dedicated code N for National Security Area,
  - and the FAA explicitly does not use it. Anyone mapping N to NSA will find no NSAs, and anyone
  - treating U as "unknown" will silently discard every NSA and SATR area in the file.
  - Codes C (Caution), D (Danger) and T (Training) never appear - the FAA publishes no such
  - airspace.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds N for National Security Area to the table. The FAA continues to code National Security Areas as
    U, so the -19A code is not used in this file.

- WATCH OUT
  - U is heavily overloaded in FAA data (2,445 records). It is not a data-quality marker - it is the FAA code for
    SATR areas and National Security Areas. Filtering U out as "unknown" removes the Washington DC SFRA, the Grand
    Canyon SFRA, the New York Hudson/East River SFRA and every NSA.

---

### 5.129 - Restrictive Airspace Designation

- SUMMARY
  - The short designation that identifies a special use airspace area - the number of a restricted or warning
    area, or the name of a MOA or special flight rules area.

- METADATA
  - Length: 10 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: REST DESIG
  - When blank: Does not occur - every UR record carries a designation.

- CONVERTER
  - `CifpFieldConverter.Field5129()` returns `string`

- USED ON
  - `UR` — col 9-18 (Restrictive Airspace Designation)
  - `UR~cont` — col 9-18 (Restrictive Airspace Designation)

- RETURNS
  - The right-trimmed designation string, preserving embedded blanks.

- OBSERVED IN CYCLE 2607
  - `##        `, `## NORTH  `, `#### HIGH `, `####A     `, `###A NORTH`, `GCNPSFRA W`, `KJFK PAB  `, `LAUGHLN1  `, `NY SFRA   `, `OWENS     `

- DETAILS
  - Ten characters, left justified and blank padded. Two styles share the field:
  - numeric the area number with its type letter and region already carried in other columns,
  - so R-2524 is stored as 2524 with type R and ICAO code K2. Suffix letters are kept:
  - 2524A, 5107B.
  - by name the name of the area, up to ten characters, with embedded blanks - OWENS,
  - LAUGHLN1, GCNPSFRA W, NY SFRA, KJFK PAB.
  - ARINC defines an overflow convention: if the name is longer than ten characters, position 10
  - holds an asterisk and the full designation is taken from the Restrictive Airspace Name (5.126).
  - Because the same designation is reused in different regions and for different types, the useful
  - key is the tuple ICAO code (5.14) + type (5.128) + designation (this field) + multiple code
  - (5.130).

- FAA NOTES
  - The readme lists the FAA's named special air traffic rule / special flight rules designations
  - together with the published names they stand for:
  - ANC SATR Anchorage, Alaska Terminal Area
  - KTN SATR Ketchikan International Airport Traffic Rule
  - GCNPSFRA E and GCNPSFRA W Grand Canyon Special Flight Rules, east and west sections
  - LUKE SATR Special Air Traffic Rules near Luke AFB, AZ
  - DC SFRA Washington DC Metropolitan Area SFRA, which includes the DC FRZ
  - NIAGFLSATR Special Air Traffic Rules near Niagara Falls, NY
  - NY SFRA New York Class B Hudson River and East River Exclusion SFRA
  - VALPO SATR Valparaiso, Florida Terminal Area
  - VUO SFRA Special Air Traffic Rules near Portland Intl, OR
  - All of these carry Restrictive Airspace Type U.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Embedded blanks are part of the value: "GCNPSFRA W" and "NY SFRA" are single designations, not
  - two tokens. A converter that calls Trim() plus Replace(" ", "") or that splits on whitespace
  - will merge distinct airspaces.
  - The ten-character asterisk overflow convention described by ARINC is never exercised - there is
  - not one asterisk in the field anywhere in the 2507 file - so do not build the overflow lookup
  - against FAA data expecting it to fire.

---

### 5.130 - Multiple Code

- SUMMARY
  - Distinguishes several areas that share the same designation but differ in lateral or vertical detail - the A,
    B, C of a subdivided MOA, or of an MSA published around the same centre fix.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: MULTI CD
  - When blank: There is only one area or MSA under this designation - no subdivision exists, so no discriminator
    is needed.

- CONVERTER
  - `CifpFieldConverter.Field5130()` returns `string`

- USED ON
  - `HD` — col 111 (Multiple Code or TAA Sector Identifier)
  - `HF` — col 111 (Multiple Code or TAA Sector Identifier)
  - `HS` — col 22 (Multiple Code)
  - `PD` — col 111 (Multiple Code or TAA Sector Identifier)
  - `PE` — col 111 (Multiple Code or TAA Sector Identifier)
  - `PF` — col 111 (Multiple Code or TAA Sector Identifier)
  - `PS` — col 22 (Multiple Code)
  - `UC` — col 19 (Multiple Code)
  - `UR` — col 19 (Multiple Code)
  - `UR~cont` — col 19 (Multiple Code)

- RETURNS
  - The raw character, or null when blank. Do not fold blank into A - they are different keys.

- OBSERVED IN CYCLE 2607
  - ` `, `A`, `B`, `C`, `D`, `E`, `F`, `G`, `H`, `I`, `J`, `K`, `L`, `M`, `N`, `O`, `P`, `Q`, `R`, `S`, `T`, `U`, `V`, `W` … (27 total)

- DETAILS
  - One alpha character used as a tie-breaker in three places:
  - Restrictive and controlled airspace - when the source divides one designation into several
  - areas with different activation times, altitudes or shapes, each area gets its own letter.
  - MSA centre records - when more than one MSA is published around the same centre fix, with
  - different sectorisation or altitudes.
  - SID/STAR/approach records - as the multiple code of the MSA the record points at (the
  - companion to the Center Fix, 5.144).
  - Lettering starts at A for the first area and continues B, C, D as needed. Blank means the
  - designation is not subdivided.
  - For airspace, the full key is ICAO code + type + designation + this letter.

- FAA NOTES
  - The readme adds no rule. In practice the FAA subdivides special use airspace heavily: A through K all occur on
    UR records, with A on 23,311 of them.

- ARINC 424-19A DIFFERENCE
  - No substantive change beyond a spelling correction in the ARINC text.

- WATCH OUT
  - On the procedure records (PD/PE/PF/HF) the column at index 111 is shared: it is the Multiple Code when index
    106-115 point at an MSA or an RF centre fix, and the TAA Sector Identifier (5.272) when they point at a TAA.
    Decide which by whether index 112-115 are blank - blank means TAA.

---

### 5.131 - Time Code

- SUMMARY
  - Says whether the thing described by the record is active continuously or only at certain times, and on
    continuation records says how to read the time-of-operation columns.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TIME CD
  - When blank: In the FAA CIFP: the airspace is part-time. In generic ARINC: active times are announced by NOTAM.
    These are different claims - see the FAA notes.

- CONVERTER
  - `CifpFieldConverter.Field5131()` returns `string`

- USED ON
  - `UC` — col 26 (Time Code)
  - `UR` — col 26 (Time Code)
  - `UR~cont` — col 26 (Time Code)

- RETURNS
  - A typed value distinguishing Continuous, PartTime (FAA blank) and the ARINC codes the FAA does not use. Do not
    return "unknown" for blank - blank is a positive statement in this file.

- VALUES
  - `C` [observed] — Active continuously, including holidays
  - `H` [not in cycle] — Active continuously, excluding holidays
  - `N` [not in cycle] — Primary: active non-continuously, see continuation record. Continuation: times too complex for the standard format, given as a note
  - `T` [not in cycle] — Continuation records only: times in Time of Operation format, holidays included
  - `S` [not in cycle] — Airway restriction records only: times in Time of Operation format, holidays excluded
  - `P` [not in cycle] — 424-19A only: active times announced by NOTAM
  - `U` [not in cycle] — 424-19A only: active times not specified in source
  - ` ` [observed] — FAA meaning: part-time, schedule not carried in the file. Generic ARINC -18 meaning: active times announced by NOTAM

- OBSERVED IN CYCLE 2607
  - ` `, `C`

- DETAILS
  - One alpha character with two different code tables depending on where it sits.
  - On primary records (restrictive airspace, preferred route, communications):
  - C active continuously, holidays included
  - H active continuously, holidays excluded
  - N active non-continuously; the detail is in a continuation record
  - blank active times announced by NOTAM
  - On continuation records (other than airway restriction records):
  - H times are given in Time of Operation format and exclude holidays
  - N the activation pattern is too complex for the Time of Operation format and is given as a note
  - T times are given in Time of Operation format and include holidays
  - On enroute airway restriction records, primary and continuation alike:
  - C active continuously, holidays included
  - H active continuously, holidays excluded
  - S times in Time of Operation format, holidays excluded
  - T times in Time of Operation format, holidays included

- FAA NOTES
  - "Special Use Airspace: Time Code (5.131) uses a C to indicate continuous and is blank to
  - indicate part-time."
  - That redefines blank. Under generic ARINC a blank means "active times announced by NOTAM"; in
  - the FAA CIFP it means "part-time" with no further detail carried. There are no time-of-operation
  - continuation records in the file (UR continuations exist only to carry the controlling agency),
  - so a part-time airspace's actual schedule is simply not in the data.
  - Only 197 UR primary records carry C. Every UR continuation record leaves this column blank, and
  - UC records never populate it at all.

- ARINC 424-19A DIFFERENCE
  - 424-19A rewrites the primary-record table: blank is replaced by explicit codes P (active times announced by
    NOTAM) and U (active times not specified in source), and the field is extended to primary extension
    continuation records. The FAA still uses the -18 shape with a bare blank.

- WATCH OUT
  - Blank means the opposite of what the ARINC text says, and it is the overwhelmingly common value (42,932
    records against 197 C). Implementing the generic table verbatim will label every part-time MOA as "announced
    by NOTAM".

---

### 5.132 - NOTAM

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Flags special use airspace whose activation comes by NOTAM rather than from a published schedule.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: NOTAM
  - When blank: The airspace is not NOTAM-activated - its times, if any, come from the Time Code and any
    continuation records.

- USED ON
  - `UC` — col 27 (NOTAM)
  - `UR` — col 27 (NOTAM)
  - `UR~cont` — col 27 (NOTAM)

- RETURNS
  - false (or null) in every case against current FAA data.

- VALUES
  - `N` [not in cycle] — Primary record: active by NOTAM only. Continuation record: active by NOTAM in addition to the listed times
  - ` ` [observed] — Not NOTAM-activated

- OBSERVED IN CYCLE 2607
  - ` `

- DETAILS
  - One character: N or blank.
  - On a primary record, N means the area is activated only by NOTAM and there will be no
  - continuation record giving times.
  - On a continuation record, N means the area is activated by NOTAM in addition to the published
  - times in that record.
  - Blank means neither applies.

- FAA NOTES
  - The FAA never populates this column - all 43,129 UR and UC records leave it blank. Note that the FAA instead
    signals part-time airspace by leaving Time Code (5.131) blank, and it publishes no time-of-operation
    continuation records at all, so NOTAM-activated airspace is effectively indistinguishable from any other part-
    time airspace in this file.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

---

### 5.133 - Unit Indicator

- SUMMARY
  - Says whether the airspace limit sitting immediately before it is measured above mean sea level or above ground
    level.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: UNIT IND
  - When blank: No altitude is coded in the paired limit column - this is not the first record of the area.

- CONVERTER
  - `CifpFieldConverter.Field5133()` returns `string`

- USED ON
  - `UC` — col 86 (Lower Limit Unit Indicator); col 92 (Upper Limit Unit Indicator)
  - `UR` — col 86 (Unit Indicator); col 92 (Unit Indicator)

- RETURNS
  - A datum enum (Msl, Agl, None). Bind it to the limit it follows, not to the record as a whole.

- VALUES
  - `M` [observed] — The paired limit is above mean sea level
  - `A` [observed] — The paired limit is above ground level
  - ` ` [observed] — No limit coded on this record

- OBSERVED IN CYCLE 2607
  - ` `, `A`, `M`

- DETAILS
  - One character:
  - M the paired limit is above mean sea level (MSL)
  - A the paired limit is above ground level (AGL)
  - blank no limit is coded on this record
  - There are two of these per airspace primary record, one immediately after the lower limit and
  - one immediately after the upper limit, and they are independent - an airspace can run from a
  - height AGL up to an altitude MSL. Always read the pair together; a limit without its unit
  - indicator is meaningless.

- FAA NOTES
  - "Unit Indicator (5.133) for all altitudes described as GND contains an A for AGL." That holds
  - without exception in the data: all 1,308 GND lower limits carry A.
  - The distribution shows the pairing rules clearly. On restrictive airspace: GND with A (589),
  - digits with M (506), digits with A (452), FLnnn with M (36) for lower limits; digits with M
  - (1,232), FLnnn with M (166), UNLTD with M (151), digits with A (34) for upper limits. On
  - controlled airspace: GND with A (719) and digits with M (561) below, digits with M (1,281)
  - above.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - A significant minority of numeric upper limits are AGL (34 records) as well as numeric lower limits (452
    records). Code that assumes "digits means MSL, GND means AGL" will put those airspaces at the wrong height.
    Always read the unit indicator.

---

### 5.134 - Cruise Table Identifier

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Points an airway record at the table of cruising levels that applies to it.

- METADATA
  - Length: 2 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: CRSE TBL IDENT
  - When blank: No cruise table is referenced. In the FAA CIFP this is the only value that occurs.

- USED ON
  - `ER` — col 47-48 (Cruise Table Indicator)

- RETURNS
  - null in every case against current FAA data.

- OBSERVED IN CYCLE 2607
  - `  `

- DETAILS
  - Two characters naming a cruise level table:
  - AA the standard ICAO cruising level table
  - BB - ZZ a modified national table
  - AO an exception to the ICAO table - the airway or a portion of it is flown against the
  - direction the table implies
  - BO - ZO the same exception applied to a modified table
  - The identifier is a pointer to a cruise table record elsewhere in the file.

- FAA NOTES
  - The FAA publishes no cruise table records and leaves this column blank on all 19,099 airway records. There is
    nothing to dereference.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

---

### 5.138 - Time Indicator

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Says whether the times in the Time of Operations columns of the same record are local, daylight-adjusted
    local, or UTC.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: TIME IND
  - When blank: The times in the accompanying Time of Operations columns are UTC.

- USED ON
  - `UR~cont` — col 28 (Time Indicator)

- RETURNS
  - null against current FAA data. If the field is ever populated, return the raw character.

- VALUES
  - `T` [not in cycle] — Times are local time
  - `S` [not in cycle] — Times are local and adjusted for daylight saving
  - ` ` [observed] — Times are UTC

- OBSERVED IN CYCLE 2607
  - ` `

- DETAILS
  - One character qualifying the time-of-operation columns that sit beside it:
  - T the times are local time
  - S the times are local and must be adjusted for daylight saving
  - blank the times are Universal Coordinated Time
  - Blank is a positive statement here, not missing data - it asserts UTC.

- FAA NOTES
  - All 1,175 UR continuation records leave this column blank, and those continuation records carry no time-of-
    operation data anyway (the FAA uses UR continuations only for the controlling agency). There are therefore no
    times in the file for this indicator to qualify.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

---

### 5.140 - Controlling Agency

- SUMMARY
  - Names the ATC facility that may authorise IFR operations inside a joint-use special use airspace when the
    using agency is not working it.

- METADATA
  - Length: 24 characters
  - Character type: alphanumeric
  - Kind: freetext
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: CONT AGENCY
  - When blank: No controlling agency is specified for this joint-use airspace.

- CONVERTER
  - `CifpFieldConverter.Field5140()` returns `string`

- USED ON
  - `UR~cont` — col 99-122 (Controlling Agency)

- RETURNS
  - The trimmed facility name, or null when the slice is blank.

- OBSERVED IN CYCLE 2607
  - `FAA ALBUQUERQUE ARTCC   `, `FAA JACKSONVILLE ARTCC  `, `FAA SALT LAKE CITY ARTCC`, `FAA SOUTHERN CAL TRACON `, `FAA POTOMAC APPROACH    `, `ALBUQUERQUE ARTCC       `, `LUKE RAPCON             `, `MCAS CHERRY PT APP CON  `, `US ARMY FT CAMPBELL ARAC`, `USAF NELLIS AFB NV RATCF`, `WHIDBEY IS NAS APP CON  `, `DESIGNATED ATCT         `, `                        `

- DETAILS
  - Free text naming an air traffic facility - an ARTCC, a TRACON, an approach control, a tower or
  - a military RAPCON. Left justified, blank padded.
  - Only joint-use airspace has one. It is written on the first record of the area, and in the FAA
  - CIFP that record is a continuation record, not a vertex record.
  - Length warning: ARINC Chapter 5 states this field is 25 characters, but the Chapter 4 record
  - layout for the restrictive airspace continuation record gives it 24 columns, at zero-based index
  - 99 through 122 (column 123 onward is the file record number). Twenty-four is what the file
  - actually contains - slice 24.

- FAA NOTES
  - "Continuation Records for UR records are included only for Controlling Agencies (5.140)." That
  - is the whole purpose of the 1,175 UR continuation records in the file: everything else on them
  - (time code, NOTAM, time indicator, time of operations) is blank. Conversely, if you want the
  - controlling agency you must read the continuation records - it is not on the primary record.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - The supplied Field Value Examples file for 5.140 is wrong and must not be used as the value
  - table. It contains 380 entries including fragments such as " A MOA", " HIGH", " NORTH" and
  - " MILE EAST MOA". Those come from slicing index 99-122 out of UR PRIMARY records, where that
  - offset falls in the middle of the 30-character Restrictive Airspace Name (5.126) that starts at
  - index 93. The field only exists on UR CONTINUATION records; filter on continuation number
  - greater than 1 before slicing. The true value set is 83 ATC facility names.
  - ARINC Chapter 5 says the field is 25 characters; the Chapter 4 layout and the actual file say
  - 24. Use 24.
  - The same physical facility appears under several spellings (with and without the FAA prefix,
  - SALT LAKE vs SALT LAKE CITY). Do not treat this string as a normalised facility key.

---

### 5.141 - Starting Latitude

- SUMMARY
  - The latitude of the south-west corner of the first one-degree block in a Grid MORA record.

- METADATA
  - Length: 3 characters
  - Character type: alphanumeric
  - Kind: coordinate
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: START LAT
  - Format: N|S followed by two digits of whole degrees
  - When blank: Does not occur - every Grid MORA record carries a starting latitude.

- CONVERTER
  - `CifpFieldConverter.Field5141()` returns `int?`

- USED ON
  - `AS` — col 13-15 (Starting Latitude)

- RETURNS
  - The signed latitude in whole degrees as an int (S becomes negative), representing the southern edge of the
    block row.

- OBSERVED IN CYCLE 2607
  - `N##`, `S##`

- DETAILS
  - Three characters: N or S followed by two digits of whole degrees.
  - The value is the LOWER LEFT corner of the first of the thirty one-degree blocks that the record
  - carries. Because it is a corner and not a centre, N42 means the block spanning 42 to 43 degrees
  - north.
  - Convert to a signed integer: N is positive, S is negative. Range is 90S to 90N.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - This is the corner of the block, not its centre. A consumer that plots MORA values at the coordinate as given
    will offset the whole grid by half a degree in each direction.

---

### 5.142 - Starting Longitude

- SUMMARY
  - The longitude of the south-west corner of the first one-degree block in a Grid MORA record.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: coordinate
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: START LONG
  - Format: E|W followed by three digits of whole degrees
  - When blank: Does not occur - every Grid MORA record carries a starting longitude.

- CONVERTER
  - `CifpFieldConverter.Field5142()` returns `int?`

- USED ON
  - `AS` — col 16-19 (Starting Longitude)

- RETURNS
  - The signed longitude in whole degrees as an int (W becomes negative), representing the western edge of the
    first block.

- OBSERVED IN CYCLE 2607
  - `E060`, `E090`, `E120`, `E150`, `W060`, `W090`, `W120`, `W150`, `W180`

- DETAILS
  - Four characters: E or W followed by three digits of whole degrees.
  - It is the LOWER LEFT corner of the first of the thirty one-degree blocks in the record. The
  - thirty MORA values that follow occupy this longitude and the twenty-nine one-degree blocks east
  - of it, so a record starting at W120 covers W120 through W091.
  - Convert to a signed integer: E positive, W negative. Range is 180W to 180E.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - Because the values step by thirty degrees, the starting longitude alone does not tell you where a given MORA
    value sits - you must add the ordinal position of the MORA column (0 to 29) to this longitude.

---

### 5.143 - Grid MORA

- SUMMARY
  - The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or UNK where
    no value has been established.

- METADATA
  - Length: 3 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: MORA
  - Format: Three digits of hundreds of feet, or the literal UNK
  - When blank: Does not occur - unsurveyed blocks carry UNK, not blanks.

- CONVERTER
  - `CifpFieldConverter.Field5143()` returns `int?`

- USED ON
  - `AS` — col 30-32 (MORA 1); col 33-35 (MORA 2); col 36-38 (MORA 3); col 39-41 (MORA 4); col 42-44 (MORA 5); col 45-47 (MORA 6); col 48-50 (MORA 7); col 51-53 (MORA 8); col 54-56 (MORA 9); col 57-59 (MORA 10); col 60-62 (MORA 11); col 63-65 (MORA 12); col 66-68 (MORA 13); col 69-71 (MORA 14); col 72-74 (MORA 15); col 75-77 (MORA 16); col 78-80 (MORA 17); col 81-83 (MORA 18); col 84-86 (MORA 19); col 87-89 (MORA 20); col 90-92 (MORA 21); col 93-95 (MORA 22); col 96-98 (MORA 23); col 99-101 (MORA 24); col 102-104 (MORA 25); col 105-107 (MORA 26); col 108-110 (MORA 27); col 111-113 (MORA 28); col 114-116 (MORA 29); col 117-119 (MORA 30)

- RETURNS
  - The altitude in FEET as an int (raw digits x 100), or null when the slice is UNK.

- VALUES
  - `UNK` [observed] — The block has not been surveyed; no off-route altitude is available

- OBSERVED IN CYCLE 2607
  - `###`, `UNK`

- DETAILS
  - Three characters, repeated thirty times across a Grid MORA record, one per one-degree block
  - running east from the record's starting longitude.
  - three digits the altitude in HUNDREDS of feet - 060 is 6,000 ft, 071 is 7,100 ft, 191 is
  - 19,100 ft
  - UNK the block has not been surveyed
  - The altitude clears all terrain and obstructions in the block by 1,000 ft where the highest
  - elevation is 5,000 ft MSL or lower, and by 2,000 ft where the highest elevation is 5,001 ft or
  - higher. It is a grid value, not a route value - it is not the same thing as an MEA or an MOCA.
  - To locate a value, take the record's starting latitude (5.141) and starting longitude (5.142)
  - and add the zero-based column index to the longitude.

- ARINC 424-19A DIFFERENCE
  - No substantive change.

- WATCH OUT
  - UNK is not an error - it is the coded value for an unsurveyed block and it appears 5,426 times.
  - int.Parse will throw on it.
  - The unit is hundreds of feet. Storing the raw three digits as the altitude is the single most
  - likely mistake here.

---

### 5.144 - Center Fix

- SUMMARY
  - Names the fix a minimum safe altitude is drawn around, or - on an RF leg - the fix at the centre of the
    constant-radius turn.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: CENTER FIX
  - When blank: On an MSA record: never blank. On a procedure record: this leg neither points at an MSA/TAA nor is
    an RF leg. Blank is the normal case on procedure records (119,842 of them).

- CONVERTER
  - `CifpFieldConverter.Field5144()` returns `string`

- USED ON
  - `HD` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `HF` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `HS` — col 13-17 (MSA Center)
  - `PD` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `PE` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `PF` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `PS` — col 13-17 (MSA Center)

- RETURNS
  - The trimmed fix identifier or null, together with the qualifier tuple (ICAO code, section, subsection) read
    from the columns that follow, and a discriminator saying whether this occurrence is an MSA pointer, a TAA
    pointer or an RF arc centre.

- OBSERVED IN CYCLE 2607
  - `RW## `, `RW##L`, `RW##R`, `RW##C`, `TTT  `, `MCI  `, `GEP  `, `KORD `, `KATL `, `ARC##`

- DETAILS
  - Up to five left-justified characters holding a fix identifier: a navaid, an enroute or terminal
  - waypoint, a runway threshold expressed as RWnn, or an airport reference point.
  - The field has two quite different jobs.
  - On MSA records (PS, HS) it is the MSA centre - the point the sector radii and sector altitudes
  - are measured from. It is never blank there.
  - On procedure records (PD, PE, PF, HF) the five columns at index 106 are shared:
  - - a pointer to the MSA that applies to the procedure, which is why the FAA writes it on the
  - final approach fix record;
  - - a pointer to a TAA, in which case only index 106-111 are used and 112-115 are blank;
  - - the centre fix of a constant-radius-to-a-fix (RF) leg, in which case the full index 106-115
  - block is used.
  - The RF use takes priority over the MSA pointer when both would land on the same record.
  - Whichever use applies, the identifier is qualified by the ICAO code, section code and subsection
  - code that follow it at index 112, 114 and 115, so resolve the four together.

- FAA NOTES
  - "The MSA Center Fix (5.144) is normally coded on the FAF record. If the FAF record is an RF leg,
  - then the MSA Center Fix is coded on the FACF record. If there is no FACF record, a center fix
  - will not be coded."
  - That rule is visible in the data: of the procedure records carrying a value, 4,458 are TF legs
  - whose waypoint description code has F (final approach fix) in column 43, 2,783 are CF legs with
  - the same F, and 1,434 are RF legs where the value is the arc centre rather than an MSA pointer.
  - The practical consequence is that some approaches have no MSA pointer at all - an RF final
  - approach fix with no FACF record leaves the procedure with no way to reach its MSA.
  - Values on SID records (1,029 of them) are MSA pointers too, and a number of them are four-
  - character airport identifiers (KAKH, KCLT, KDTW), meaning the MSA is drawn around the airport
  - reference point.

- ARINC 424-19A DIFFERENCE
  - 424-19A spells out the three uses that -18 only implies: an MSA pointer written on the FAF record, a TAA
    pointer written on the first record of each approach transition, and the RF turn centre, with the explicit
    precedence rule that the RF centre wins and pushes the MSA pointer onto the FACF record. The FAA follows the
    -19A behaviour even though the file is nominally -18.

- WATCH OUT
  - On procedure records this field shares its columns with the TAA Procedure Turn Indicator
  - (5.271), and the neighbouring column at 111 shares with the TAA Sector Identifier (5.272).
  - Decide which by looking at index 112-115: if they are blank the block is a TAA reference, not an
  - MSA or RF centre.
  - RF legs overload the field with something structurally different - a geometric arc centre rather
  - than a pointer to another record. Reading every populated value as an MSA reference will produce
  - 1,434 broken links on approach records.
  - Because the MSA pointer sits on the FAF (or FACF) record rather than on the procedure header,
  - you cannot find a procedure's MSA without walking its legs.

---

### 5.145 - Radius Limit

- SUMMARY
  - How far out from the MSA centre fix the sector altitude in the same slot provides obstacle clearance, in whole
    nautical miles.

- METADATA
  - Length: 2 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: RADIUS LIMIT
  - When blank: This sector slot is unused. An MSA record has seven bearing/altitude/radius slots and most
    airports use only one.

- CONVERTER
  - `CifpFieldConverter.Field5145()` returns `int?`

- USED ON
  - `HS` — col 51-52 (Sector Radius 1); col 62-63 (Sector Radius 2); col 73-74 (Sector Radius 3); col 84-85 (Sector Radius 4); col 95-96 (Sector Radius 5); col 106-107 (Sector Radius 6); col 117-118 (Sector Radius 7)
  - `PS` — col 51-52 (Sector Radius 1); col 62-63 (Sector Radius 2); col 73-74 (Sector Radius 3); col 84-85 (Sector Radius 4); col 95-96 (Sector Radius 5); col 106-107 (Sector Radius 6); col 117-118 (Sector Radius 7)

- RETURNS
  - The radius in whole nautical miles as an int, or null when the slot is unused.

- OBSERVED IN CYCLE 2607
  - `  `, `##`

- DETAILS
  - Two digits giving a radius in whole nautical miles from the MSA centre fix (5.144). It is the
  - third member of a repeating triple - sector bearing (5.146, 6 columns), sector altitude (5.147,
  - 3 columns), radius limit (this field, 2 columns) - and an MSA record carries seven of those
  - triples back to back.
  - Unused slots are blank in all eleven columns.
  - Whole nautical miles: 25 means 25 NM, not 2.5 NM. This is unlike Arc Distance (5.119), which
  - suppresses a decimal point.

- FAA NOTES
  - The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30
    and a single 37.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds the case of an MSA with multiple radii for the same sector, in which the bearing pair is repeated
    with a second altitude and radius before the next sector begins. The field itself is unchanged.

- WATCH OUT
  - Whole nautical miles here, tenths of a nautical mile in the airspace Arc Distance field (5.119). The two are
    easy to confuse when writing a shared distance converter.

---

### 5.146 - Sector Bearing

- SUMMARY
  - The pair of bearings, measured to the MSA centre fix, that bound one sector of a minimum safe altitude - start
    bearing first, end bearing second, going clockwise.

- METADATA
  - Length: 6 characters
  - Character type: numeric
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: SEC BRG
  - Format: SSSEEE - three digits start bearing, three digits end bearing, clockwise, inclusive
  - When blank: This sector slot is unused.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `HS` — col 42-47 (Sector Bearing 1); col 53-58 (Sector Bearing 2); col 64-69 (Sector Bearing 3); col 75-80 (Sector Bearing 4); col 86-91 (Sector Bearing 5); col 97-102 (Sector Bearing 6); col 108-113 (Sector Bearing 7)
  - `PS` — col 42-47 (Sector Bearing 1); col 53-58 (Sector Bearing 2); col 64-69 (Sector Bearing 3); col 75-80 (Sector Bearing 4); col 86-91 (Sector Bearing 5); col 97-102 (Sector Bearing 6); col 108-113 (Sector Bearing 7)

- RETURNS
  - A pair of ints (start, end), or null when the slot is blank, plus a derived IsFullCircle flag when both are
    180.

- COLUMNS (this field packs several independent values)
  - **StartBearing** — offset 0, length 3
  - **EndBearing** — offset 3, length 3

- OBSERVED IN CYCLE 2607
  - `      `, `######`

- DETAILS
  - Six digits split into two three-digit whole-degree bearings:
  - offset 0-2 bearing at which the sector starts
  - offset 3-5 bearing at which the sector ends
  - The sector runs CLOCKWISE from the start bearing to the end bearing, so 140060 is the sector
  - from 140 degrees clockwise through north to 060 degrees - a 280-degree wedge, not a 80-degree
  - one. Reading it as a numeric range and assuming start < end is wrong.
  - 180180 is the reserved encoding for an unsectorised MSA: a full circle.
  - The bearings are TO the MSA centre fix, and whether they are magnetic or true is stated by the
  - Magnetic/True Indicator (5.165) in the same record.
  - Sectors are listed in clockwise order and share their dividing bearings - the end bearing of one
  - sector is the start bearing of the next, confirmed throughout the FAA data (270360 / 360270;
  - 090180 / 180270 / 270090).

- FAA NOTES
  - The FAA MSA sectors always tile the full circle and always share dividing bearings. 5,329 MSA sector slots are
    the unsectorised 180180 circle and 719 MSA records have more than one sector.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds substantial detail: it states explicitly that for MSA the values are dividing values with the end
    of one sector reused as the start of the next, that sectors are given lowest-first and clockwise, that an MSA
    with several radii for one sector repeats the bearing pair with the extra radius and altitude, and that 180180
    means an un-sectorised circle. It also notes the bearings may be magnetic or true per the Mag/True indicator.
    The FAA data already behaves this way.

- WATCH OUT
  - 360 is used, not 000 - the observed values include 360180, 180360, 270360 and 360090. A
  - converter that normalises 360 to 0 will break the "end of one sector is the start of the next"
  - chain.
  - 180180 is a magic value meaning a full circle, not a zero-width sector. Angular arithmetic that
  - computes end minus start will give 0 degrees for the most common MSA in the file.

---

### 5.147 - Sector Altitude

- SUMMARY
  - The minimum safe altitude for one sector of an MSA, in hundreds of feet.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: SEC ALT
  - When blank: This sector slot is unused.

- CONVERTER
  - `CifpFieldConverter.Field5147()` returns `int?`

- USED ON
  - `HS` — col 48-50 (Sector Altitude 1); col 59-61 (Sector Altitude 2); col 70-72 (Sector Altitude 3); col 81-83 (Sector Altitude 4); col 92-94 (Sector Altitude 5); col 103-105 (Sector Altitude 6); col 114-116 (Sector Altitude 7)
  - `PS` — col 48-50 (Sector Altitude 1); col 59-61 (Sector Altitude 2); col 70-72 (Sector Altitude 3); col 81-83 (Sector Altitude 4); col 92-94 (Sector Altitude 5); col 103-105 (Sector Altitude 6); col 114-116 (Sector Altitude 7)

- RETURNS
  - The altitude in FEET as an int (raw digits x 100), or null when the slot is unused. If 999 is ever seen,
    return null and flag it rather than reporting 99,900 ft.

- OBSERVED IN CYCLE 2607
  - `   `, `###`

- DETAILS
  - Three digits giving an altitude in HUNDREDS of feet: 010 is 1,000 ft, 025 is 2,500 ft, 100 is
  - 10,000 ft.
  - On an MSA record the altitude provides 1,000 ft of obstacle clearance within the sector defined
  - by the bearing pair (5.146) out to the radius (5.145) in the same triple. It is the second
  - member of the repeating bearing/altitude/radius triple, seven of which fit in an MSA record.
  - On TAA records (which the FAA does not publish) the same field is the sector minimum altitude
  - for that TAA area.

- FAA NOTES
  - The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a
    real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds the value 999 to mean "the official source provides no sector altitude for this sector", and adds
    worked examples of how MSA triples are packed. The FAA does not use 999.

- WATCH OUT
  - Hundreds of feet, like Grid MORA (5.143) but unlike almost every other altitude field in the file, which are
    plain feet. Mixing them up puts MSAs at 1/100 of their true height.

---

### 5.149 - Figure of Merit

- SUMMARY
  - Encodes the usable range of a VHF navaid beyond what the Class field gives, and doubles as a flag for navaids
    that are out of service or absent from civil NOTAM coverage.

- METADATA
  - Length: 1 character
  - Character type: numeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: MERIT
  - When blank: Not applicable to this record.

- CONVERTER
  - `CifpFieldConverter.Field5149()` returns `string`

- USED ON
  - `D` — col 84 (Figure of Merit)

- RETURNS
  - A description of the service volume, e.g. "(2) High Altitude Use (within 130NM)", or the status text for 7 and
    9. Unrecognized characters pass through unchanged.

- VALUES
  - `0` [observed] — Terminal use, generally usable within 25 NM
  - `1` [observed] — Low altitude use, generally usable within 40 NM
  - `2` [observed] — High altitude use, generally usable within 130 NM
  - `3` [observed] — Extended high altitude use, generally usable beyond 130 NM
  - `7` [not in cycle] — Navaid is not carried in a civil international NOTAM system
  - `9` [not in cycle] — Navaid is out of service

- OBSERVED IN CYCLE 2607
  - `#`

- DETAILS
  - Applies only to VHF Navaid (D) records. Values are not taken verbatim from government
  - source; they are derived from the facility's class, usage and availability, and may be
  - refined from operator feedback. Codes 0 through 3 describe increasing service volumes;
  - 7 and 9 are status flags rather than ranges, so any consumer treating this field as an
  - ordered range must special-case them.

- FAA NOTES
  - The FAA derives the Figure of Merit from the NAVAID Class. Where the class cannot be
  - determined, the FAA codes the Figure of Merit as '3'.

- WATCH OUT
  - The observed-values file masks every digit as '#', so it cannot confirm which of the six
  - codes actually occur. Read the real column to distinguish; do not assume 7 and 9 are absent.

---

### 5.150 - Frequency Protection Distance

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Distance in nautical miles to the nearest other navaid sharing the same frequency.

- METADATA
  - Length: 3 characters
  - Character type: alphanumeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: FREQ PRD
  - When blank: No frequency protection distance computed for this facility.

- USED ON
  - `D` — col 87-89 (Frequency Protection)

- RETURNS
  - The distance in nautical miles as an integer, or null when blank.

- OBSERVED IN CYCLE 2607
  - `   `

- DETAILS
  - A computed rather than published value, carried only on VHF Navaid records and only for
  - facilities equipped with DME or TACAN. It gives the distance to the next nearest
  - DME/TACAN-equipped facility on the same frequency, capped at a meaningful maximum of
  - 600 NM. A change to this field alone does not trigger a Cycle Date update.

- WATCH OUT
  - Blank on every record in the FAA CIFP. The field is defined but never populated, so a
  - parser must not require a value here.

---

### 5.164 - EU Indicator

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Flags an enroute airway segment that has an associated Airway Restriction record, without saying what the
    restriction is.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: EU IND
  - When blank: No airway restriction record exists for this segment.

- CONVERTER
  - `CifpFieldConverter.Field5164()` returns `string`

- USED ON
  - `ER` — col 49 (EU Indicator)

- RETURNS
  - true when 'Y', otherwise false.

- VALUES
  - `Y` [not in cycle] — An airway restriction record exists for this segment
  - ` ` [observed] — No airway restriction record exists

- OBSERVED IN CYCLE 2607
  - ` `

- DETAILS
  - Carried on Enroute Airway (ER) records only. It is a pointer, not a description: 'Y'
  - means a restriction for this segment exists in the Airway Restriction file (section EU),
  - and blank means none does. To learn the restriction itself you must read the EU records,
  - which the FAA CIFP does not supply.

- FAA NOTES
  - The FAA CIFP does not include Airway Restriction (EU) records at all, and this indicator
  - is blank on every airway record. Treat it as permanently false for this dataset.

- WATCH OUT
  - Never set in the FAA CIFP because the companion EU record type is not published. Any
  - downstream logic keyed on this flag will be dead code against FAA data.

---

### 5.165 - Magnetic/True Indicator

- SUMMARY
  - States whether the courses and bearings in a record are referenced to Magnetic North or True North.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: M/T IND
  - When blank: On Airport and Heliport records, a deliberate signal that the facility carries a MIX of magnetic
    and true data, so each detail record must be read individually. It is not 'unknown'.

- CONVERTER
  - `CifpFieldConverter.Field5165()` returns `string`

- USED ON
  - `HA` — col 91 (Magnetic/True Indicator)
  - `HS` — col 119 (Magnetic/True Indicator)
  - `PA` — col 85 (Magnetic/True Indicator)
  - `PS` — col 119 (Magnetic/True Indicator)

- RETURNS
  - "(M) Magnetic" or "(T) True"; empty string when blank.

- VALUES
  - `M` [observed] — Courses and bearings are magnetic
  - `T` [not in cycle] — Courses and bearings are true
  - ` ` [not in cycle] — Airport/Heliport records only: the facility carries a mix of magnetic and true data

- OBSERVED IN CYCLE 2607
  - `M`

- DETAILS
  - Used two different ways. On MSA and TAA records it qualifies that record's own sector
  - bearings. On Airport and Heliport records it is a blanket statement about every detail
  - and procedure record belonging to that facility. In the airport case the blank value is
  - meaningful rather than empty: it says the facility's data is mixed, and the individual
  - detail records carry their own reference. Consumers that treat blank as "assume magnetic"
  - will silently mis-handle true-referenced facilities.

- WATCH OUT
  - Only 'M' appears anywhere in the FAA CIFP. Alaskan true-referenced procedures would be
  - the expected source of 'T', so its total absence is worth a sanity check against a future
  - cycle rather than an assumption baked into code.

---

### 5.176 - Pad Dimensions

- SUMMARY
  - The size of a helicopter landing pad in feet, packed as two three-digit numbers.

- METADATA
  - Length: 6 characters
  - Character type: numeric
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: PAD DIM
  - Format: AAABBB - three digits then three digits, both whole feet
  - When blank: No pad dimensions published. Does not occur in the FAA file - all 6,134 heliport records are
    populated.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `HA` — col 85-90 (Pad Dimensions)

- RETURNS
  - Two integers in feet plus a shape indicator: rectangle (both sides given) when the second group is non-zero,
    circle (first group is the diameter) when the second group is 000.

- COLUMNS (this field packs several independent values)
  - **PadDimensionA** — offset 0, length 3
  - **PadDimensionB** — offset 3, length 3

- OBSERVED IN CYCLE 2607
  - `######`

- DETAILS
  - Six digits at offset 85 of the heliport (HA) record, read as two three-digit groups, each a
  - whole number of feet with one-foot resolution.
  - If the pad is RECTANGULAR the two groups are the two side lengths - '060120' is a 60 by 120
  - foot pad. If the pad is CIRCULAR the first group is the diameter and the second group is all
  - zeros - '080000' is an 80 foot circle. So the second group being '000' is the shape
  - discriminator, not a missing value.
  - Because the field is fixed six digits, the largest expressible dimension is 999 feet.

- FAA NOTES
  - The readme is silent on this field. Every one of the 6,134 heliport records carries a value,
  - 566 distinct combinations, the most common being 040040, 050050 and 060060. Notably NO record
  - uses the circular form - the second group is never all zeros - so in FAA data every pad is
  - described as a rectangle even when it is physically a circle.

- WATCH OUT
  - The circular-pad convention is never exercised by the FAA, so a parser that only handles the
  - rectangular reading will pass on FAA data and then silently mis-report a diameter as a
  - zero-length side on any other 424 source.

---

### 5.177 - Public/Military Indicator

- SUMMARY
  - Classifies a landing facility as civil/public, military, or private/not open to the public.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: PUB/MIL
  - When blank: Use category not stated. Does not occur in the FAA file - all airport and heliport records are
    populated.

- CONVERTER
  - `CifpFieldConverter.Field5177()` returns `string`

- USED ON
  - `HA` — col 80 (Public Military Indicator)
  - `PA` — col 80 (Public/Military Indicator)

- RETURNS
  - A PublicMilitaryIndicator enum (Civil / Military / Private / JointUse), or null when blank.

- VALUES
  - `C` [observed] — Civil - open to the general public. Joint civil/military fields are coded here in 424-18.
  - `M` [observed] — Military airport or heliport.
  - `P` [observed] — Private - not open to the public.
  - `J` [not in cycle] — Joint civil and military use. Added in 424-19A only; not valid under 424-18 and never emitted by the FAA.

- OBSERVED IN CYCLE 2607
  - `C`, `M`, `P`

- DETAILS
  - A single character at offset 80 of both the airport (PA) and heliport (HA) records. It answers
  - one question - who may use this facility - and drives things like which airports a general
  - aviation flight planner should offer. Joint civil/military fields are shown as civil in
  - 424-18: there is no separate joint-use code at this version.

- FAA NOTES
  - Not discussed in the readme. Distribution in the shipped file: airports 8,143 private, 4,983
  - civil, 195 military; heliports 5,857 private, 216 military, 61 civil. Private facilities
  - dominate the CIFP because of the very large number of private helipads.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds a fourth code, 'J', for a field that is jointly civil and military, and reworks
  - the introduction to describe four categories instead of three. The FAA never emits 'J' - it
  - still folds joint-use fields into 'C'.

---

### 5.178 - Time Zone

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - The airport's or heliport's standard-time offset from UTC, as a zone letter plus an extra minutes correction.

- METADATA
  - Length: 3 characters
  - Character type: alphanumeric
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TIME ZONE
  - Format: Zdd - one zone letter followed by two digits of extra minutes
  - When blank: No time zone published. This is the value in every FAA record.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `HA` — col 81-83 (Time Zone)
  - `PA` — col 81-83 (Time Zone)

- RETURNS
  - A TimeSpan giving the facility's standard offset from UTC (zone hours signed per the letter, plus the minute
    correction), or null when the slice is blank.

- COLUMNS (this field packs several independent values)
  - **TimeZoneLetter** — offset 0, length 1
    - `Z` [not in cycle] — UTC+00:00 (Greenwich).
    - `A` [not in cycle] — UTC-01:00.
    - `B` [not in cycle] — UTC-02:00.
    - `C` [not in cycle] — UTC-03:00.
    - `D` [not in cycle] — UTC-04:00.
    - `E` [not in cycle] — UTC-05:00.
    - `F` [not in cycle] — UTC-06:00.
    - `G` [not in cycle] — UTC-07:00.
    - `H` [not in cycle] — UTC-08:00.
    - `I` [not in cycle] — UTC-09:00.
    - `K` [not in cycle] — UTC-10:00.
    - `L` [not in cycle] — UTC-11:00.
    - `M` [not in cycle] — UTC-12:00.
    - `N` [not in cycle] — UTC+01:00.
    - `O` [not in cycle] — UTC+02:00.
    - `P` [not in cycle] — UTC+03:00.
    - `Q` [not in cycle] — UTC+04:00.
    - `R` [not in cycle] — UTC+05:00.
    - `S` [not in cycle] — UTC+06:00.
    - `T` [not in cycle] — UTC+07:00.
    - `U` [not in cycle] — UTC+08:00.
    - `V` [not in cycle] — UTC+09:00.
    - `W` [not in cycle] — UTC+10:00.
    - `X` [not in cycle] — UTC+11:00.
    - `Y` [not in cycle] — UTC+12:00.
  - **TimeZoneMinutes** — offset 1, length 2

- OBSERVED IN CYCLE 2607
  - `   `

- DETAILS
  - Three characters at offset 81 of the airport (PA) and heliport (HA) records, made of two parts.
  - The FIRST character is a zone letter. 'Z' is UTC. Letters A through M (skipping J) step
  - backwards one hour each: A is -1, B is -2, and so on to M at -12. Letters N through Y step
  - forwards one hour each: N is +1, O is +2, up to Y at +12. Each letter nominally covers a
  - 15-degree band of longitude centred on its meridian.
  - The SECOND AND THIRD characters are a whole number of MINUTES that the locally observed time is
  - offset from the exact hour. India is the standard example: geographically it straddles two
  - zones but observes a single UTC+05:30, coded 'E30'. A country in the M or Y zone that keeps the
  - time of the next zone out shows '60' in those two positions, i.e. a full extra hour.
  - Note the sign convention is the reverse of what a programmer expects: the letters that run A
  - through M are NEGATIVE offsets and N through Y are POSITIVE.

- FAA NOTES
  - The readme does not mention the field and the FAA never populates it: all 13,321 airport and
  - all 6,134 heliport records carry three spaces. Local time for a U.S. facility must come from
  - somewhere other than the CIFP.

- WATCH OUT
  - The letter 'J' is deliberately skipped in the zone sequence - do not compute the offset
  - arithmetically from the character code.

---

### 5.179 - Daylight Time Indicator

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Says whether the facility observes daylight saving / summer time.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: DAY TIME
  - When blank: Not stated. This is the value in every FAA record.

- CONVERTER
  - `CifpFieldConverter.Field5179()` returns `string`

- USED ON
  - `HA` — col 84 (Daylight Indicator)
  - `PA` — col 84 (Daylight Indicator)

- RETURNS
  - true for 'Y', false for 'N', null for blank. Note that false and null are not the same claim - 'N' also covers
    'unknown'.

- VALUES
  - `Y` [not in cycle] — The facility observes daylight or summer time.
  - `N` [not in cycle] — The facility does not observe daylight time, or it is unknown.

- OBSERVED IN CYCLE 2607
  - ` `

- DETAILS
  - One character at offset 84 of the airport (PA) and heliport (HA) records. 'Y' means the
  - facility shifts its clocks when daylight or summer time is in force where it sits; 'N' means
  - it does not, and 'N' is also used when the answer is simply unknown. It is meant to be read
  - together with Time Zone (5.178) to work out local time at the field.

- FAA NOTES
  - Not mentioned in the readme, and never populated: all 13,321 airport and all 6,134 heliport
  - records carry a space. Since Time Zone is blank too, the CIFP gives no local-time information
  - at all for U.S. facilities.

---

### 5.180 - Pad Identifier

- SUMMARY
  - The name of an individual helipad, unique within its heliport, used as part of the record key.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: PAD IDENT
  - When blank: No pad identifier. Does not occur on FAA heliport records - all 6,134 are populated.

- USED ON
  - `HA` — col 16-20 (PAD Identifier)
  - `PP` — col 19-23 (Runway or Helipad Identifier)
  - `PP~cont` — col 19-23 (Runway or Helipad Identifier)

- RETURNS
  - The trimmed pad identifier, or null when the slice is all spaces.

- OBSERVED IN CYCLE 2607
  - `##/##`, `H#   `, `H##  `, `HA   `, `HB   `, `HC   `, `HD   `, `HE   `, `HF   `, `HG   `, `HI   `

- DETAILS
  - Up to five characters, left justified and blank padded, at offset 16 of the heliport (HA)
  - record. Each physical landing pad at a location gets its own heliport record, and this is what
  - tells them apart. Identifiers come from official publications where they exist; where they do
  - not, the data supplier invents one.
  - The same field number is also used on path point records (offset 19) as the alternative to a
  - runway identifier when a procedure serves a helipad or a point in space rather than a runway,
  - and on airport/heliport ILS and MLS records to say which pad a precision aid serves.

- FAA NOTES
  - The readme does not mention the field. In practice the FAA uses a simple 'H' plus sequence
  - number scheme - 'H1' covers 5,638 of the 6,134 heliport records, running up to 'H27', with a
  - small tail of lettered pads 'HA' through 'HI'.

- ARINC 424-19A DIFFERENCE
  - 424-19A extends the list of records the field appears on to include helicopter operations
  - company routes. The content rules are unchanged.

- WATCH OUT
  - Thirteen FAA heliport records carry a RUNWAY-style pad identifier - '18/36', '05/23', '14/32',
  - '12/30', '01/19', '07/25', '09/27', '16/34', '17/35'. These are landing lanes described by
  - their reciprocal headings rather than an 'H' pad number, and they contain a slash. Do not
  - validate this field as alphanumeric-only, and do not assume it starts with 'H'.
  - The lettered series skips 'HH' - the observed letters run HA, HB, HC, HD, HE, HF, HG, HI.

---

### 5.195 - Time of Operation

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - One daily operating window inside a calendar week - which days, what start time and what end time - for a
    facility or an airspace restriction.

- METADATA
  - Length: 10 characters
  - Character type: alphanumeric
  - Kind: composite
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TIME OP
  - Format: DDHHMMHHMM, where either time group may instead be nnnR / nnnS / Rnnn / Snnn
  - When blank: No operating period defined in this slot. Every occurrence in the FAA file is blank.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `UR~cont` — col 29-38 (Time of Operations 1); col 39-48 (Time of Operations 2); col 49-58 (Time of Operations 3); col 59-68 (Time of Operations 4); col 69-78 (Time of Operations 5); col 79-88 (Time of Operations 6); col 89-98 (Time of Operations 7)

- RETURNS
  - A start day, an end day, and two times each carrying either a clock time or a sunrise/sunset relative offset
    with its sign. Null when the slice is blank.

- COLUMNS (this field packs several independent values)
  - **DayRange** — offset 0, length 2
  - **StartTime** — offset 2, length 4
  - **EndTime** — offset 6, length 4

- OBSERVED IN CYCLE 2607
  - `          `

- DETAILS
  - Ten characters describing a single recurring daily period. Seven of these fields sit
  - side by side on a restrictive airspace continuation record (offsets 29, 39, 49, 59, 69, 79 and
  - 89), so a full weekly schedule can need several of them.
  - Layout is 2 + 4 + 4:
  - - Characters 1-2, DAYS. Monday is 1 through Sunday is 7. A single day is that digit twice
  - with a leading zero, so Monday is '01'. A consecutive run is first day then last day, so
  - Monday through Friday is '15'. Non-consecutive days need separate Time of Operation
  - entries - Mon/Wed/Fri is three entries: '0107001700', '0307001700', '0507001700'.
  - - Characters 3-6, START TIME.
  - - Characters 7-10, END TIME.
  - Each time is normally HHMM on a 24-hour clock. But either time can instead be expressed
  - relative to sunrise or sunset, and the position of the letter carries the sign:
  - - '000R' = at sunrise, '000S' = at sunset.
  - - Letter LAST means BEFORE: '030R' is 30 minutes before sunrise, '100S' is one hour before
  - sunset.
  - - Letter FIRST means AFTER: 'R030' is 30 minutes after sunrise, 'S100' is one hour after
  - sunset.
  - - The three digits beside the letter are H, M, M - so 1 hour 30 minutes is '130' and 2 hours
  - 15 minutes is '215'.
  - One trap: when a period runs past midnight, the end time belongs to the NEXT day, so the day
  - field must be extended. Monday to Friday 1700-0300 is coded '16' (Monday through Saturday) with
  - times 1700 and 0300, not '15'.

- FAA NOTES
  - The readme says nothing about times of operation. The FAA does not populate the field at all -
  - every one of the seven slots on all 1,175 restrictive airspace continuation records is ten
  - spaces, and the readme states that UR continuation records are included only to carry the
  - controlling agency (5.140). Class B/C/D airspace records have no continuation records at all.

- WATCH OUT
  - IMPORTANT - the Field Value Examples file for 5.195 is contaminated and must not be trusted.
  - It lists 317 values such as '###MABEL B' and 'LTDMW-###A'. Those come from slicing restrictive
  - airspace PRIMARY records with the CONTINUATION record layout: on a UR primary, offsets 29-99
  - hold coordinates, altitude limits and the Restrictive Airspace Name (5.126), not times. When
  - the continuation records are isolated correctly (application type 'C' at offset 25), every one
  - of the 8,225 time slots is blank.

---

### 5.196 - Name Format Indicator

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Describes how the Waypoint Name/Description field was constructed - whether the name is a published five-
    letter fix, a navaid identifier, a lat/long, an abeam point and so on.

- METADATA
  - Length: 3 characters
  - Character type: alpha
  - Kind: composite
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: NAME IND
  - Format: Three independent single-character codes; position 3 reserved.
  - When blank: The waypoint name format is not described. This is the value in every FAA record.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `EA` — col 95-97 (Name Format Indicator)
  - `HC` — col 95-97 (Name Format Indicator)
  - `PC` — col 95-97 (Name Format Indicator)

- RETURNS
  - Up to three decoded format codes (or an empty result). Null when the slice is blank, which is always the case
    in FAA data.

- VALUES
  - `A` [not in cycle] — Abeam fix - a point abeam something else.
  - `B` [not in cycle] — Bearing and distance fix.
  - `D` [not in cycle] — Airport name used as the fix name.
  - `F` [not in cycle] — FIR fix.
  - `H` [not in cycle] — Phonetic letter name fix.
  - `I` [not in cycle] — Airport identifier used as the fix name.
  - `L` [not in cycle] — Latitude/longitude fix.
  - `M` [not in cycle] — Multiple word name fix; also used for a localizer marker with no officially published five-letter identifier.
  - `N` [not in cycle] — Navaid identifier used as the fix name.
  - `O` [not in cycle] — Localizer marker that does have an officially published five-letter identifier.
  - `P` [not in cycle] — Published five-letter name fix.
  - `Q` [not in cycle] — Published name fix of fewer than five letters.
  - `R` [not in cycle] — Published name fix of more than five letters.
  - `T` [not in cycle] — Airport or runway related fix - a terminal waypoint.
  - `U` [not in cycle] — UIR fix.

- COLUMNS (this field packs several independent values)
  - **NameFormat1** — offset 0, length 1
  - **NameFormat2** — offset 1, length 1
  - **NameFormat3** — offset 2, length 1

- OBSERVED IN CYCLE 2607
  - `   `

- DETAILS
  - Three characters at offset 95 of the enroute waypoint (EA) and terminal waypoint (PC/HC)
  - records. Each position is an independent single-character code drawn from the same list, and
  - the codes may be combined across positions but a code is never repeated. The third position is
  - reserved for future expansion of the concept and is normally blank.
  - The point of the field is to say which naming convention produced the name in field 5.43, so
  - that a display system knows whether it is looking at a real published fix name, a derived
  - bearing/distance construction, a raw coordinate, or an airport-related terminal waypoint.

- FAA NOTES
  - The FAA readme states flatly that the Waypoint Name Format Indicator will not be populated, and
  - the data agrees: all 70,036 enroute and terminal waypoint records carry three spaces.

- ARINC 424-19A DIFFERENCE
  - Not comparable - the 424-19A text extracted for this field number is a supplement change log,
  - not the field definition, so no reliable v19 comparison is available. Treat the 424-18 table as
  - authoritative.

- WATCH OUT
  - The letter 'M' is listed twice in the ARINC table with two different meanings - 'multiple word
  - name fix' and 'localizer marker without an officially published five-letter identifier'. Which
  - one applies has to be inferred from the record type, so any lookup must be context aware.

---

### 5.197 - Datum Code

- SUMMARY
  - Three-letter code naming the local horizontal reference datum that the record's latitude and longitude are
    expressed in.

- METADATA
  - Length: 3 characters
  - Character type: alpha
  - Kind: enum
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: DATUM
  - When blank: No horizontal datum stated for the coordinates in this record.

- USED ON
  - `D` — col 90-92 (Datum Code)
  - `DB` — col 90-92 (Datum Code)
  - `EA` — col 84-86 (Datum Code)
  - `HA` — col 27-29 (Datum Code)
  - `HC` — col 84-86 (Datum Code)
  - `PA` — col 86-88 (Datum Code)
  - `PC` — col 84-86 (Datum Code)
  - `PN` — col 90-92 (Datum Code)

- RETURNS
  - The three-letter datum code as a trimmed string, or null when blank.

- VALUES
  - `NAR` [observed] — North American Datum 1983.
  - `WGE` [observed] — World Geodetic System 1984.

- OBSERVED IN CYCLE 2607
  - `NAR`, `WGE`

- DETAILS
  - Three alphabetic characters identifying the geodetic datum the coordinates belong to. Without
  - it a latitude/longitude pair is ambiguous by up to a few hundred metres. The full code list
  - lives in Attachment 2 of the ARINC specification and is long - hundreds of national and
  - regional datums - so this should be carried as a string, not an enum.
  - Its offset moves with the record type. VHF navaid (D), NDB navaid (DB) and terminal navaid (PN)
  - records carry it at offset 90; enroute and terminal waypoint records (EA, PC, HC) at offset 84;
  - airport (PA) records at offset 86; heliport (HA) records at offset 27.

- FAA NOTES
  - The readme does not mention datums. The FAA uses only two codes. 'NAR' (North American 1983)
  - appears on essentially everything - all 70,036 waypoints, all 2,475 navaids, all 6,134
  - heliports and 13,311 of 13,321 airports. 'WGE' (WGS-84) appears on exactly ten airports, all
  - military: KADW, KDAA, KHST, KLFI, KNBG, KNFW, KNGU, KNIP, KNRB and KNYG. Anything consuming
  - CIFP coordinates should be aware the bulk of the file is NAD 83, not WGS-84, even though the
  - two are close enough for most navigation purposes over CONUS.

- WATCH OUT
  - Ten military airport records use WGE while every other coordinate-bearing record in the file
  - uses NAR. A consumer that assumes a single datum for the whole file will be silently wrong on
  - those ten.

---

### 5.204 - ARC Radius

- SUMMARY
  - The turn radius of a constant-radius arc leg or an RNP holding pattern, in thousandths of a nautical mile.

- METADATA
  - Length: 6 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ARC RAD
  - Format: NNNnnn - three digits of whole nautical miles then three digits of thousandths
  - When blank: The leg is not a constant-radius turn. 199,675 of 201,114 procedure leg primaries are blank - only
    RF legs and RNP holding legs use it.

- CONVERTER
  - `CifpFieldConverter.Field5204()` returns `double?`

- USED ON
  - `HD` — col 56-61 (ARC Radius)
  - `HF` — col 56-61 (ARC Radius)
  - `PD` — col 56-61 (ARC Radius)
  - `PE` — col 56-61 (ARC Radius)
  - `PF` — col 56-61 (ARC Radius)

- RETURNS
  - Radius in decimal nautical miles (raw integer divided by 1000.0), or null when blank.

- OBSERVED IN CYCLE 2607
  - `      `, `######`

- DETAILS
  - Six digits at offset 56 of SID, STAR and approach leg records. The decimal point is suppressed
  - and sits after the third digit, so the value is NNN.NNN nautical miles: '002500' is 2.500 NM
  - and '024700' is 24.700 NM. Thousandth-of-a-mile resolution works out to roughly six feet, which
  - is why the field is this wide.
  - Two uses. On an RF leg (Path and Termination 'RF') it is the radius of the curved path between
  - the arc's start and end fixes, about the centre fix. On RNP holding patterns - which appear as
  - HA, HF and HM legs in SID, STAR and approach records, and on holding pattern records - it is
  - the turn radius from the inbound leg to the outbound leg.

- FAA NOTES
  - Not mentioned in the readme. In the shipped file 1,439 records carry a radius, 278 distinct
  - values, ranging from 001060 (1.060 NM) to 024700 (24.700 NM). The count matches the number of
  - RF legs exactly, so the FAA does not currently code RNP holding radii.

- WATCH OUT
  - The 424-19A text extracted for this field number is a supplement change log rather than the
  - field definition, so no v19 comparison is available; the 424-18 definition is authoritative.

---

### 5.211 - Required Navigation Performance

- SUMMARY
  - The navigation accuracy required on this segment, encoded as two significant digits plus a negative decimal
    exponent.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: RNP
  - Format: MMe - two significant digits then a single-digit negative decimal exponent
  - When blank: No source-published RNP value exists for this segment. It does NOT mean RNP zero and it does not
    mean the segment has no navigation requirement - it means the database carries no specified value. 153,709 of
    201,114 procedure leg primaries are blank.

- CONVERTER
  - `CifpFieldConverter.Field5211()` returns `double?`

- USED ON
  - `ER` — col 56-58 (RNP)
  - `HD` — col 44-46 (RNP)
  - `HF` — col 44-46 (RNP)
  - `PD` — col 44-46 (RNP)
  - `PE` — col 44-46 (RNP)
  - `PF` — col 44-46 (RNP)
  - `UC` — col 78-80 (RNP)

- RETURNS
  - RNP in decimal nautical miles: int(chars 0-1) * Math.Pow(10, -int(char 2)). Null when blank.

- OBSERVED IN CYCLE 2607
  - `   `, `###`

- DETAILS
  - Three characters. The first TWO are the significant digits; the THIRD is the number of places
  - to shift the decimal point to the LEFT. So the value is (first two digits) times ten to the
  - power of minus (third digit):
  - '990' = 99 x 10^0 = 99.0 NM
  - '120' = 12 x 10^0 = 12.0 NM
  - '010' = 01 x 10^0 = 1.0 NM
  - '031' = 03 x 10^-1 = 0.3 NM (the standard RNAV final approach segment)
  - '011' = 01 x 10^-1 = 0.1 NM
  - '152' = 15 x 10^-2 = 0.15 NM (RNP AR)
  - '013' = 01 x 10^-3 = 0.001 NM
  - Offsets differ by record: 44 on SID (PD), STAR (PE) and approach (PF/HF) leg records; 56 on
  - enroute airway (ER) records; 78 on controlled airspace (UC) records.
  - Scope rules: on an airway the value applies INBOUND to the fix when the legs are read in
  - increasing sequence number order, and only to that one leg. On a SID, STAR or approach the
  - value applies to the segment it is coded on, and it is coded on every segment where source
  - specifies one. On a holding pattern it applies to the pattern. There is no vertical RNP in
  - ARINC 424.

- FAA NOTES
  - The readme devotes a whole section to this field. The FAA populates RNP from the NAVSPEC values
  - in FAA Order 8260.58C Table 1-2-1, using five rules:
  - 1. On day-forward procedures, HF and HM (holding) legs are NOT coded with RNP values at all.
  - 2. On amendments and abbreviated amendments, values match FAA Form 8260-3 Terminal Routes.
  - 3. For P-NOTAMs requiring coding changes, values match Form 8260-3 Terminal Routes; where the
  - form documents none, the current NAVSPEC is coded and any RNP on an accompanying Form
  - 8260-10 is ignored.
  - 4. For P-NOTAMs not requiring coding changes, the same rule as (3) but applied as workload
  - permits.
  - 5. Day-back procedures already in the CIFP are updated as workload permits, with an effort to
  - update all procedures at an airport together.
  - Consequence for an implementer: RNP coverage in the CIFP is deliberately INCOMPLETE and
  - inconsistent across procedures of different vintages. A blank RNP is not evidence that the
  - published procedure has no RNP requirement.
  - The record layout also notes that where an RNAV procedure has more than one set of RNP criteria,
  - the primary record carries one consistent set representing the least restrictive operating
  - criteria, without mixing values from different criteria.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds SID/STAR/Approach CONTINUATION records to the list of records the field appears on.
  - The encoding is unchanged.

- WATCH OUT
  - 33 distinct values appear on procedure records. The common ones are '010' (1.0 NM, 34,496
  - records) and '031' (0.3 NM, 11,223 records - final approach). The exponent-2 family ('152',
  - '452', '752', '892' and friends) are RNP AR values between 0.11 and 0.89 NM and are rare, often
  - a single record each; they are exactly the ones a naive integer parse would corrupt most badly.
  - Enroute airways carry RNP on only 42 of 19,099 legs, all '010'. Controlled airspace records
  - never carry it - all 13,135 UC records are blank at offset 78.

---

### 5.212 - Runway Gradient

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - The overall slope of the runway in percent, signed, measured from the start of the take-off roll.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: RWY GRAD
  - Format: sNNNN - sign then four digits, decimal point implied after the first digit
  - When blank: No gradient published for this runway. This is the value on every FAA runway record.

- CONVERTER
  - `CifpFieldConverter.Field5212()` returns `double?`

- USED ON
  - `PG` — col 51-55 (Runway Gradient)

- RETURNS
  - Gradient in percent as a signed double (digits divided by 1000.0, sign applied), or null when blank.

- OBSERVED IN CYCLE 2607
  - `     `

- DETAILS
  - Five characters at offset 51 of the runway (PG) record. Position one is '+' or '-'; positions
  - two through five are four digits with the decimal point suppressed after the first, giving
  - N.NNN percent. '+0450' is an upward gradient of 0.450 percent, '-0300' is a downward gradient
  - of 0.300 percent. The field can express at most plus or minus 9.000 percent.
  - The sign is referenced to the direction of the take-off roll on the runway END named in the
  - record, so the same physical strip has opposite gradients on its two runway records. Positive
  - is uphill in the direction of travel.

- FAA NOTES
  - This field, together with Ellipsoidal Height (5.225), is one of the two additions the FAA calls
  - out on the runway record: the readme says "Runway gradient (5.212) and ellipsoid height (5.225)
  - are included in the runway record when available."
  - In the shipped file that promise is not kept for gradient. All 16,805 runway records carry five
  - spaces at offset 51. Ellipsoid height IS populated on 6,282 of them, so the two are not paired
  - in practice. Parse and model the field, but expect nothing in it.

- WATCH OUT
  - Direct contradiction between the FAA readme and the data: the readme states gradient is included
  - when available, and it never is. Do not build anything that depends on it.

---

### 5.213 - Controlled Airspace Type

- SUMMARY
  - Names the category of controlled airspace the record describes - Class B, Class C, Class D, a control area, a
    TMA or a radar area.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ARSP TYPE
  - When blank: Should not occur. Every controlled airspace record in the FAA file carries a type.

- CONVERTER
  - `CifpFieldConverter.Field5213()` returns `string`

- USED ON
  - `UC` — col 8 (Airspace Type)

- RETURNS
  - A ControlledAirspaceType enum, or null when blank.

- VALUES
  - `A` [observed] — Class C airspace (previously ARSA in the USA).
  - `C` [not in cycle] — Control area - the ICAO CTA designation.
  - `M` [not in cycle] — Terminal control area - the ICAO TMA or TCA designation.
  - `R` [not in cycle] — Radar zone or radar area (previously TRSA in the USA).
  - `T` [observed] — Class B airspace (previously TCA in the USA).
  - `Z` [observed] — Class D airspace in the USA; control zone, the ICAO CTR designation.

- OBSERVED IN CYCLE 2607
  - `A`, `T`, `Z`

- DETAILS
  - One character at offset 8 of the controlled airspace (UC) record, part of the record's key
  - along with the airspace centre and multiple code. The code list mixes U.S. class letters with
  - ICAO airspace terms, and the ARINC table keeps the older U.S. names in parentheses purely as a
  - memory aid - TCA, ARSA and TRSA are no longer published designations.
  - Note the mapping is not intuitive: 'A' is Class C airspace and 'T' is Class B airspace, so the
  - letter does NOT match the class letter. In FAA data the Airspace Classification field (5.215)
  - in the same record carries the actual class letter and correlates one-to-one with this field:
  - T pairs with B, A pairs with C, and Z pairs with D, on every one of the 13,135 records.

- FAA NOTES
  - The readme confirms the CIFP carries Class B, C and D airspace only ("Class B, C, and D
  - Airspace (UC)"). Observed distribution: 'T' Class B on 7,150 records, 'A' Class C on 3,620,
  - 'Z' Class D on 2,365. The three ICAO-flavoured codes never appear.

- WATCH OUT
  - The letter does not match the airspace class letter - 'T' means Class B and 'A' means Class C.
  - An implementer who maps this field straight through to a class letter will label Class B
  - airspace as 'T'. Use field 5.215 for the class letter.

---

### 5.214 - Controlled Airspace Center

- SUMMARY
  - Identifier of the navigation element the controlled airspace is built around - the key that groups all records
    belonging to one airspace.

- METADATA
  - Length: 5 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: ARSP CNTR
  - When blank: No centre identifier. Does not occur in the FAA file.

- USED ON
  - `UC` — col 9-13 (Airspace Center)

- RETURNS
  - The trimmed centre identifier, or null when blank. Pair it with the section/subsection codes at offsets 14-15
    to resolve what it points at.

- OBSERVED IN CYCLE 2607
  - `KJFK `, `KDFW `, `KDEN `, `KTPA `, `KCLT `

- DETAILS
  - Five characters, left justified and blank padded, at offset 9 of the controlled airspace (UC)
  - record. It is the grouping key: every boundary record describing one piece of controlled
  - airspace repeats the same centre identifier, so a parser assembles an airspace by collecting
  - all records sharing airspace type, ICAO code, centre and multiple code.
  - The value can be a navaid, an enroute waypoint or an airport identifier. It is the element the
  - airspace is PREDICATED on, which is not necessarily the geometric centre - New York Class B is
  - the classic example, built around several navaids but keyed on one airport. Where nothing
  - suitable is published, ARINC permits a region identifier from ICAO Document 7910, or a
  - supplier-created centre waypoint.
  - The two characters immediately following (offsets 14 and 15) are the section and subsection
  - codes telling you which file the identifier belongs to, so resolve the reference using those
  - rather than guessing.

- FAA NOTES
  - The readme is explicit: "Airspace Center (5.214) uses the ICAO identifier for the primary
  - airport for the airspace." So in FAA data this is always an airport identifier, never a navaid
  - or waypoint. 696 distinct values across 13,135 records; the busiest are KJFK (844 boundary
  - records), KDFW (800), KDEN (746), KTPA (596) and KCLT (549).

- ARINC 424-19A DIFFERENCE
  - 424-19A adds heliport identifiers to the list of things that may appear here. No effect on FAA
  - data.

---

### 5.215 - Controlled Airspace Classification

- SUMMARY
  - The published ICAO airspace class letter, A through G.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ARSP CLASS
  - When blank: Source does not assign a classification to this airspace. Does not occur in the FAA file.

- CONVERTER
  - `CifpFieldConverter.Field5215()` returns `string`

- USED ON
  - `UC` — col 16 (Airspace Classification)

- RETURNS
  - An AirspaceClass enum (A through G), or null when blank.

- VALUES
  - `A` [not in cycle] — Class A airspace.
  - `B` [observed] — Class B airspace.
  - `C` [observed] — Class C airspace.
  - `D` [observed] — Class D airspace.
  - `E` [not in cycle] — Class E airspace.
  - `F` [not in cycle] — Class F airspace.
  - `G` [not in cycle] — Class G airspace.

- OBSERVED IN CYCLE 2607
  - `B`, `C`, `D`

- DETAILS
  - One character at offset 16 of the controlled airspace (UC) record. Unlike Controlled Airspace
  - Type (5.213), this is the airspace class exactly as published - A through G. Where source does
  - not classify the airspace the field is blank.
  - In FAA data it is fully redundant with 5.213 (T pairs with B, A pairs with C, Z pairs with D on
  - every record), but it is the field to trust when you want the class letter, because 5.213's
  - codes do not match the class letters.

- FAA NOTES
  - The readme does not mention the field. Observed: 'B' on 7,150 records, 'C' on 3,620, 'D' on
  - 2,365 - matching the readme's statement that only Class B, C and D airspace is carried.

---

### 5.216 - Controlled Airspace Name

- SUMMARY
  - The published name of the controlled airspace, carried once on the first record of each airspace.

- METADATA
  - Length: 30 characters
  - Character type: alphanumeric
  - Kind: freetext
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: ARSP NAME
  - When blank: Either this is not the first record of the airspace (the name is carried only once, on the first
    record), or source assigns no name. 11,854 of 13,135 UC records are blank.

- USED ON
  - `UC` — col 93-122 (Controlled Airspace Name)

- RETURNS
  - The trimmed airspace name, or null when the slice is all spaces.

- OBSERVED IN CYCLE 2607
  - `                              `, `SANTA ANA                     `, `PORTLAND INTERNATIONAL        `, `HOUSTON AREA C                `, `NASHVILLE                     `, `RIVERSIDE MARCH FIELD         `

- DETAILS
  - Thirty characters at offset 93 of the controlled airspace (UC) record, left justified and blank
  - padded. The name is deliberately written on the FIRST record of an airspace only - the
  - remaining boundary records for the same airspace leave it blank. So when assembling an airspace
  - from its records, take the name from whichever record carries one rather than expecting it on
  - each.
  - In FAA data the text is upper case and includes punctuation - commas, apostrophes, hyphens and
  - parentheses all occur - so do not validate it as A-Z and digits only. Examples in the file
  - include "MARTHA'S VINEYARD", "LITTLE ROCK, ADAMS FIELD", "FORT WORTH NAS JRB (CARSWELL)" and
  - "DAYTON, COX-DAYTON INTL ARPT". Names run right up to the full 30 characters, so expect
  - truncation of long ones.

- FAA NOTES
  - The readme says "Controlled Airspace Names (5.216) are those found in the legal description" -
  - so the text is the legal-description name, not the common name of the airport.
  - Watch out for a numbering error in the readme: the Special Use Airspace section says all Grand
  - Canyon boundary names and altitudes are "included in the Restrictive Airspace Name Field
  - (5.216)". That is wrong. The restrictive airspace (UR) record's name field is 5.126, also 30
  - characters at offset 93. Field 5.216 lives only on UC records.

- WATCH OUT
  - 982 distinct names appear on only 1,281 of 13,135 records, because the name is written once per
  - airspace. A parser that reads airspace names per-record will report most airspaces as unnamed.

---

### 5.222 - GNSS/FMS Indicator

- SUMMARY
  - Says whether a conventional approach is authorised to be flown as a GNSS or FMS overlay, and for RNAV
    procedures whether SBAS vertical guidance is authorised.

- METADATA
  - Length: 1 character
  - Character type: alphanumeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: GNSS/FMS IND
  - When blank: No overlay or SBAS statement for this procedure. 78,769 of 201,114 procedure leg primaries are
    blank - the field is only meaningful on approach records.

- CONVERTER
  - `CifpFieldConverter.Field5222()` returns `string`

- USED ON
  - `HD` — col 116 (GNSS/FMS Indication)
  - `HF` — col 116 (GNSS/FMS Indication)
  - `PD` — col 116 (GNSS/FMS Indication)
  - `PE` — col 116 (GNSS/FMS Indication)
  - `PF` — col 116 (GNSS/FMS Indication)

- RETURNS
  - A GnssFmsIndicator enum, or null when blank.

- VALUES
  - `0` [observed] — Procedure is not authorised for GNSS or FMS overlay.
  - `1` [not in cycle] — Authorised for GNSS overlay; the underlying navaids are operating and monitored.
  - `2` [not in cycle] — Authorised for GNSS overlay; the underlying navaids are installed but not monitored.
  - `3` [observed] — Authorised for GNSS overlay; the procedure title itself includes GPS or GNSS.
  - `4` [not in cycle] — Authorised for FMS overlay.
  - `5` [not in cycle] — Authorised for FMS and/or GNSS overlay. Removed in 424-19A.
  - `A` [observed] — RNAV (GPS) or RNAV (GNSS) procedure with SBAS use authorised - this is the code that indicates GNSS-based vertical guidance (LPV, LNAV/VNAV). Requires a procedure data continuation record.
  - `B` [observed] — RNAV (GPS) or RNAV (GNSS) procedure with SBAS use NOT authorised - lateral guidance only.
  - `C` [not in cycle] — RNAV (GPS) or RNAV (GNSS) procedure with SBAS use not specified.
  - `P` [observed] — Stand-alone GPS (GNSS) procedure.
  - `U` [not in cycle] — Overlay authorisation not specified. Removed in 424-19A.

- OBSERVED IN CYCLE 2607
  - ` `, `0`, `3`, `A`, `B`, `P`

- DETAILS
  - One character at offset 116 of approach records. It carries two different ideas depending on
  - whether the code is a digit or a letter.
  - DIGITS 0-5 are about OVERLAY authorisation of a conventional ground-based approach: may this
  - VOR/NDB/localizer procedure be flown using a GNSS or FMS sensor as primary navigation, and
  - under what condition.
  - LETTERS A, B and C are about RNAV (GPS) / RNAV (GNSS) procedures and say whether SBAS use -
  - in practice WAAS, which was the only approved SBAS when these codes were introduced - is
  - authorised, not authorised, or unspecified. 'A' is the code that means the procedure supports
  - GNSS-based VERTICAL navigation (LPV, LNAV/VNAV); 'B' means lateral only.
  - 'P' marks a stand-alone GPS procedure and 'U' means the authorisation was simply not stated.
  - Code 'A' requires an accompanying procedure data continuation record (4.1.9.5 for airports,
  - 4.2.3.5 for heliports).

- FAA NOTES
  - The readme does not name the field, but its content is consistent with the FAA's approach
  - inventory: GPS overlays, RNAV (GPS), RNAV (RNP) and stand-alone GPS procedures.
  - Observed on procedure leg primaries: blank 78,769, 'A' 66,097, '0' 37,280, 'B' 18,658, '3' 174,
  - 'P' 136. Codes 1, 2, 4, 5, C and U never appear.

- ARINC 424-19A DIFFERENCE
  - 424-19A REMOVES codes '5' (FMS and/or GNSS overlay) and 'U' (not specified) from the table,
  - rewrites the descriptions of '0', '1' and '2' to talk about whether the authorisation is
  - published, and adds explanatory notes making the 'A'/'B' vertical-guidance meaning explicit
  - ('A' = LPV and LNAV/VNAV authorised, 'B' = LNAV only). It also names EGNOS alongside WAAS as an
  - approved SBAS. The FAA applies 424-18 here, so keep '5' and 'U' in the switch.

- WATCH OUT
  - The single column mixes two unrelated code spaces - digits for conventional-procedure overlay
  - rights, letters for RNAV/SBAS rights - so any 'is this a GPS approach' test must branch on both.

---

### 5.223 - Operation Type

- SUMMARY
  - Classifies the kind of final approach segment a path point record describes.

- METADATA
  - Length: 2 characters
  - Character type: numeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: OPS TYPE
  - When blank: Not applicable. Does not occur - every path point record carries '00'.

- CONVERTER
  - `CifpFieldConverter.Field5223()` returns `string`

- USED ON
  - `PP` — col 24-25 (Operation Type)
  - `PP~cont` — col 24-25 (Operation Type)

- RETURNS
  - The two digits as an int (0-15), or null when blank.

- VALUES
  - `00` [observed] — Straight-in approach procedure.
  - `01` [not in cycle] — Reserved for future definition.
  - `02` [not in cycle] — Reserved for future definition.
  - `03` [not in cycle] — Reserved for future definition.
  - `04` [not in cycle] — Reserved for future definition.
  - `05` [not in cycle] — Reserved for future definition.
  - `06` [not in cycle] — Reserved for future definition.
  - `07` [not in cycle] — Reserved for future definition.
  - `08` [not in cycle] — Reserved for future definition.
  - `09` [not in cycle] — Reserved for future definition.
  - `10` [not in cycle] — Reserved for future definition.
  - `11` [not in cycle] — Reserved for future definition.
  - `12` [not in cycle] — Reserved for future definition.
  - `13` [not in cycle] — Reserved for future definition.
  - `14` [not in cycle] — Reserved for future definition.
  - `15` [not in cycle] — Reserved for future definition.

- OBSERVED IN CYCLE 2607
  - `##`

- DETAILS
  - Two digits at offset 24 of both the path point primary (PP) and path point continuation record.
  - The value range is 00 through 15. Only 00 is defined - a straight-in procedure. Everything from
  - 01 to 15 is reserved for future definition.
  - This field is part of the path point record's identity, so it is read on both primary and
  - continuation records and should match between them.

- FAA NOTES
  - The readme does not mention it. All 4,905 path point primary records carry '00' - every FAA
  - path point describes a straight-in final approach segment.

- ARINC 424-19A DIFFERENCE
  - 424-19A rewrites the definition to say the field distinguishes an approach procedure from an
  - "advanced operation" or a future operation type, and adds commentary listing what advanced
  - operations might be - straight-in approaches followed by a missed approach, precision curved
  - approaches, departure procedures, roll-out and taxiing procedures. The value range and the
  - meaning of 00 are unchanged.

---

### 5.224 - Route Indicator

- SUMMARY
  - A single letter distinguishing between several different final approach segments serving the same runway or
    helipad.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: identifier
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: RTE IND
  - When blank: There is only one final approach segment to this runway, so no letter is needed to tell variants
    apart. 4,432 of 4,905 path point primaries are blank.

- USED ON
  - `PP` — col 27 (Route Indicator)

- RETURNS
  - The single character, or null when blank.

- OBSERVED IN CYCLE 2607
  - ` `, `X`, `Y`, `Z`

- DETAILS
  - One character at offset 27 of the path point PRIMARY record. Legal values are A through Z with
  - I and O omitted, because those two are too easily confused with digits.
  - It exists because a runway can have more than one approach with a coded final segment - for
  - example an RNAV (GPS) Y and an RNAV (GPS) Z to the same runway. The letter here matches the
  - MULTIPLE APPROACH INDICATOR, which is the fifth character of the approach procedure identifier
  - in field 5.10. That correspondence is confirmed in FAA data: the 473 records with a non-blank
  - route indicator all have approach identifiers such as 'R03-Y', 'R17LY' and 'R28RY' whose fifth
  - character is exactly this letter.
  - Note the offset collision - on a path point CONTINUATION record, offset 27 is Application Type
  - (5.91), not Route Indicator. Branch on the continuation record number at offset 26 first.

- FAA NOTES
  - Not mentioned in the readme. Observed on path point primaries: blank 4,432, 'Y' 330, 'Z' 129,
  - 'X' 14. So the FAA uses only the tail end of the alphabet, matching its Y/Z/X approach naming
  - convention.

- ARINC 424-19A DIFFERENCE
  - 424-19A adds the words "contained in the Final Approach Coding" to the definition and points
  - explicitly at Section 5.10 for the multiple approach indicator. No change in content.

- WATCH OUT
  - CRITICAL - there is no Field Value Examples file for 5.224, which would normally mean the FAA
  - never populates the field. That inference is WRONG. The field IS populated on 473 path point
  - records. The examples file is missing because the path point primary record carries continuation
  - record number '1' (not '0') at offset 26, so the tool that generated the examples treated every
  - primary as a continuation and sliced it with the wrong layout. The same mistake removed or
  - corrupted the examples for 5.226, 5.228, 5.229, 5.255, 5.256, 5.257, 5.258, 5.259, 5.263, 5.264,
  - 5.265, 5.266, 5.267 and 5.268, and injected garbage into 5.225, 5.227, 5.244, 5.262 and 5.269.
  - All observed values in this file were re-derived directly from FAACIFP18.

---

### 5.225 - Ellipsoidal Height

- SUMMARY
  - Height of a surveyed point above (or below) the WGS-84 ellipsoid, in tenths of a metre with an explicit sign.

- METADATA
  - Length: 6 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ELLIP HGT
  - Format: sNNNNN - sign then five digits, decimal point implied before the last digit
  - When blank: No ellipsoidal height published for this point. Blank on 10,523 of 16,805 runway records and on
    all 4,905 path point continuation records.

- CONVERTER
  - `CifpFieldConverter.Field5225()` returns `double?`

- USED ON
  - `PG` — col 60-65 ((LTP) Ellipsoid Height)
  - `PP` — col 60-65 ((LTP) Ellipsoid Height)
  - `PP~cont` — col 28-33 ((FPAP) Ellipsoid Height)

- RETURNS
  - Height in metres as a signed double (five digits divided by 10.0, sign applied), or null when blank.

- OBSERVED IN CYCLE 2607
  - `      `, `+#####`, `-#####`

- DETAILS
  - Six characters. Position one is always a sign - '+' for at or above the ellipsoid, '-' for
  - below. Positions two through six are five digits of metres with the decimal point suppressed
  - after the fourth, so the resolution is one tenth of a metre. '+00356' is 35.6 m above the
  - ellipsoid; '-00022' is 2.2 m below.
  - Do not confuse this with elevation above mean sea level. Ellipsoidal height is a purely
  - geometric height above the WGS-84 reference ellipsoid and differs from MSL elevation by the
  - geoid undulation, which over CONUS is roughly -20 to -35 m. That is why so many U.S. threshold
  - values here are negative even though the runway is well above sea level. The MSL counterpart is
  - Orthometric Height (5.227).
  - Three different places in the file use the field:
  - - Runway (PG) record, offset 60: the height of the landing threshold.
  - - Path point primary (PP) record, offset 60: the height of the Landing Threshold Point (LTP).
  - - Path point continuation record, offset 28: the height of the Flight Path Alignment Point
  - (FPAP).

- FAA NOTES
  - The readme names this field explicitly: "Runway gradient (5.212) and ellipsoid height (5.225)
  - are included in the runway record when available." That half of the statement holds - 6,282 of
  - 16,805 runway records carry a value. Gradient never does.
  - On path point records, all 4,905 primaries carry an LTP ellipsoidal height (3,441 distinct
  - values), but the FPAP ellipsoidal height on the continuation record is blank on all 4,905.

- WATCH OUT
  - The Field Value Examples file for 5.225 lists a fourth pattern, '####W#', which is NOT a valid
  - ellipsoidal height. It is an artefact: the example generator sliced path point PRIMARY records
  - using the CONTINUATION layout, so offsets 28-33 of a primary (SBAS provider id + reference path
  - data selector + the first two characters of the reference path identifier, e.g. '0000W1') got
  - captured as if they were an FPAP height. Ignore it.
  - Because the sign character is mandatory, a value can never be all digits - reject a six-digit
  - slice as malformed rather than parsing it.

---

### 5.226 - Glide Path Angle

- SUMMARY
  - The intended descent angle of the final approach path, in hundredths of a degree.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: GPA
  - When blank: No glide path angle. Does not occur - all 4,905 path point primaries are populated, though 180 of
    them carry 0000.

- CONVERTER
  - `CifpFieldConverter.Field5226()` returns `double?`

- USED ON
  - `PP` — col 66-69 (Glide Path Angle)

- RETURNS
  - The angle in decimal degrees (raw integer divided by 100.0), or null when blank. Treat 0.00 as 'no vertical
    guidance' rather than a real angle.

- OBSERVED IN CYCLE 2607
  - `0000`, `0300`, `0350`, `0310`, `0304`, `0320`, `0400`

- DETAILS
  - Four digits at offset 66 of the path point primary (PP) record. The decimal point is suppressed
  - after the first digit, so the value is D.DD degrees: '0300' is 3.00 degrees, '0275' is 2.75
  - degrees, '1015' would be 10.15 degrees.
  - The angle is measured at the Flight Path Control Point and defines the vertical path the
  - aircraft flies on final. Together with the LTP position, the threshold crossing height (5.265)
  - and the FPAP position it fully defines the approach's vertical geometry.

- FAA NOTES
  - Not mentioned in the readme. Observed on all 4,905 path point primaries, 81 distinct values
  - from '0000' to '0570' (0.00 to 5.70 degrees). '0300' - a standard 3.00 degree path - covers
  - 4,229 of them.
  - A value of '0000' appears on 180 records and correlates exactly with LP procedures: every
  - 0000 record has approach type identifier 'LP' on its continuation record and vertical alert
  - limit '000'. So 0000 means "no vertical guidance", not "a zero-degree glide path".

- WATCH OUT
  - CRITICAL - there is no Field Value Examples file for 5.226, which would normally mean the FAA
  - never populates it. That is wrong; the field is populated on every path point record. The
  - examples generator mis-identified path point primaries as continuation records (see 5.224 for
  - the full explanation). Observed values here were taken directly from FAACIFP18.
  - A raw 0000 must not be fed into a descent-angle calculation.

---

### 5.227 - Orthometric Height

- SUMMARY
  - Height of a surveyed point above mean sea level, in tenths of a metre with an explicit sign.

- METADATA
  - Length: 6 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: ORTH HGT
  - Format: sNNNNN - sign then five digits, decimal point implied before the last digit
  - When blank: No orthometric height published for this point.

- CONVERTER
  - `CifpFieldConverter.Field5227()` returns `double?`

- USED ON
  - `PP~cont` — col 34-39 ((FPAP) Orthometric Height); col 40-45 ((LTP) Orthometric Height)

- RETURNS
  - Height above MSL in metres as a signed double (five digits divided by 10.0, sign applied), or null when blank.

- OBSERVED IN CYCLE 2607
  - `+#####`, `-#####`

- DETAILS
  - Six characters, laid out exactly like Ellipsoidal Height (5.225): position one is '+' or '-',
  - positions two through six are five digits of metres with a suppressed decimal point giving one
  - tenth of a metre resolution. '+00356' is 35.6 m above MSL, '-00022' is 2.2 m below.
  - The difference from 5.225 is the reference surface. This one is referenced to MEAN SEA LEVEL
  - (the geoid), so it is the number that matches a published field elevation. Ellipsoidal height
  - is referenced to the WGS-84 ellipsoid. The gap between them is the geoid undulation.
  - It appears twice on the path point CONTINUATION record: offset 34 for the Flight Path Alignment
  - Point and offset 40 for the Landing Threshold Point.

- FAA NOTES
  - Not mentioned in the readme. Both instances are fully populated on all 4,905 path point
  - continuation records - 3,310 distinct FPAP values and 3,308 distinct LTP values, mostly small
  - positive numbers in the tens of metres.

- WATCH OUT
  - The Field Value Examples file for 5.227 lists seven bogus patterns - '######', '#A#N##',
  - '#B#N##', '#C#N##', '#D#N##', '#E#N##' and '#F#N##'. None are orthometric heights. They come
  - from slicing path point PRIMARY records with the continuation layout: offsets 34-39 of a primary
  - are the last two characters of the reference path identifier, the approach performance
  - designator and the first three characters of the LTP latitude, e.g. '8A0N61'. Ignore them; only
  - '+#####' and '-#####' are real.

---

### 5.228 - Course Width At Threshold

- SUMMARY
  - The lateral width of the final approach course at the landing threshold, in hundredths of a metre, which sets
    lateral deviation sensitivity.

- METADATA
  - Length: 5 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: CRS WDTH
  - When blank: No course width. Does not occur - all 4,905 path point primaries are populated.

- CONVERTER
  - `CifpFieldConverter.Field5228()` returns `double?`

- USED ON
  - `PP` — col 93-97 (Course Width at Threshold)

- RETURNS
  - Course width in metres as a double (raw integer divided by 100.0), or null when blank.

- OBSERVED IN CYCLE 2607
  - `10675`, `10650`, `11500`, `11575`, `14375`, `11175`, `08000`

- DETAILS
  - Five digits at offset 93 of the path point primary (PP) record. The layout is hundreds, tens,
  - units, tenths, hundredths of a metre with the decimal point suppressed, so '10675' is 106.75 m
  - and '03800' is 38.00 m.
  - Together with the position of the Flight Path Alignment Point it defines how sensitive lateral
  - deviation indications are along the approach: the width at the threshold anchors the splay of
  - the course. Source values are quoted to a 0.25 m resolution, so the last two digits are always
  - 00, 25, 50 or 75 - a cheap validation check. For a procedure to a helicopter alighting point the
  - standard value is 38 metres.
  - When the runway number in the path point record is 00 (a helipad procedure), the record layout
  - notes say the course width field is ignored.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primaries are populated; 47 distinct values
  - ranging from '08000' (80.00 m) to '14375' (143.75 m), with '10675' (106.75 m) on 4,804 of them.
  - Every value ends in 00, 25, 50 or 75 as required. The 38.00 m helicopter value never appears,
  - because there are no runway-00 path point records in the file.

- WATCH OUT
  - CRITICAL - there is no Field Value Examples file for 5.228, which would normally mean the field
  - is never populated. That is wrong; it is populated on every path point record. See 5.224 for
  - why the examples generator missed the whole path point primary layout. Observed values here came
  - straight from FAACIFP18.

---

### 5.229 - Final Approach Segment Data CRC Remainder

- SUMMARY
  - Eight-character hexadecimal representation of the 32-bit CRC that protects the final approach segment data
    block.

- METADATA
  - Length: 8 characters
  - Character type: alphanumeric
  - Kind: pattern
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: FAS CRC
  - Format: Eight uppercase hexadecimal digits (0-9, A-F)
  - When blank: No CRC supplied. Does not occur - all 4,905 path point primaries carry one.

- CONVERTER
  - `CifpFieldConverter.Field5229()` returns `uint?`

- USED ON
  - `PP` — col 115-122 (SBAS FAS Data CRC Remainder)

- RETURNS
  - The 32-bit value as a uint (parsed base 16), plus the original eight characters retained verbatim. Null when
    blank.

- OBSERVED IN CYCLE 2607
  - `FDCE99BD`, `AF9E33F0`, `51158D24`, `4E6B17AA`

- DETAILS
  - Eight characters at offset 115 of the path point primary (PP) record - the last field before the
  - file record number. It is the 32-bit cyclic redundancy check computed by the data source over
  - the aeronautical data fields that make up the Final Approach Segment data block, written as
  - uppercase hexadecimal: '243BC649', 'A6934B72'.
  - This is a safety-of-life integrity check, not a checksum for the record as stored. Avionics
  - recompute the CRC over the decoded FAS data and compare; a mismatch means the approach data
  - must not be used. The algorithm is specified in Chapter 6 of ARINC 424. Because the CRC covers
  - the source values, fields inside the wrap - including the TCH Units Indicator (5.266) - must be
  - preserved exactly as received rather than normalised.
  - A parser should keep the original eight characters as well as the parsed value, so that the
  - exact bytes are available for verification.

- FAA NOTES
  - The readme does not discuss the FAS CRC specifically, but it does state the whole CIFP file is
  - wrapped with a separate 32-bit CRC calculated per ARINC Report 665. Observed: all 4,905 path
  - point primaries carry a CRC and all 4,905 values are distinct, as expected.

- WATCH OUT
  - CRITICAL - there is no Field Value Examples file for 5.229. That would normally mean never
  - populated; it is in fact populated on every path point record, with a unique value per record.
  - See 5.224 for the cause. Observed values here were read directly from FAACIFP18.
  - Do not normalise, re-case or reformat this field. It is an integrity artefact.

---

### 5.244 - GLS Channel / GNSS Channel Number

- SUMMARY
  - Five-digit channel number that identifies which augmentation system and reference path the procedure uses.

- METADATA
  - Length: 5 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: GLS CHNL
  - When blank: No channel assigned to this procedure.

- CONVERTER
  - `CifpFieldConverter.Field5244()` returns `int?`

- USED ON
  - `PP~cont` — col 56-60 (GNSS Channel Number)

- RETURNS
  - The channel number as an int, plus an augmentation-system classification derived from the band. Null when
    blank.

- OBSERVED IN CYCLE 2607
  - `#####`

- DETAILS
  - Five digits at offset 56 of the path point continuation record (and on GLS records). The value
  - range is 20001 to 99999 - numbers below 20000 are reserved for ILS and MLS and never appear
  - here. The band tells you what kind of system the channel refers to:
  - - 20001 to 39999: GBAS (ground based augmentation), and SBAS where applicable.
  - - 40000 to 99999: SBAS (satellite based augmentation - WAAS in the United States).
  - The channel is what an avionics box tunes to pull the approach's reference path definition, so
  - it is effectively the machine-readable key for the procedure.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point continuation records carry a channel, 4,904 of
  - them distinct, ranging from 40000 to 99747. Every single one falls in the SBAS band - the FAA
  - publishes no GBAS/GLS procedures in the CIFP, which matches the readme's statement that GLS
  - procedures are not included.

- WATCH OUT
  - The Field Value Examples file for 5.244 lists two impossible patterns, '####+' and '####-'. A
  - channel number cannot contain a sign. They are artefacts of slicing path point PRIMARY records
  - with the continuation layout: offsets 56-60 of a primary are the tail of the LTP longitude plus
  - the leading sign of the LTP ellipsoidal height, e.g. '3005+'. Ignore them.
  - One duplicate channel ('56234') appears on two records; do not treat the channel as a unique
  - key without checking.

---

### 5.249 - Longest Runway Surface Code

- SUMMARY
  - Says what the longest runway at the airport is surfaced with - hard, soft, water, or unknown.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: LRSC
  - When blank: Surface type not stated. Does not occur in the FAA file - all 13,321 airport records are
    populated.

- CONVERTER
  - `CifpFieldConverter.Field5249()` returns `string`

- USED ON
  - `PA` — col 31 (Longest Runway Surface Code)

- RETURNS
  - A RunwaySurfaceCode enum (Hard / Soft / Water / Undefined), or null when blank.

- VALUES
  - `H` [observed] — Hard surface - asphalt, concrete or similar.
  - `S` [observed] — Soft surface - gravel, grass, soil or similar.
  - `W` [observed] — Water runway.
  - `U` [not in cycle] — Undefined - source did not state the surface material.

- OBSERVED IN CYCLE 2607
  - `H`, `S`, `W`

- DETAILS
  - One character at offset 31 of the airport (PA) record. It qualifies the Longest Runway field
  - (5.54) that sits beside it: the length figure alone does not tell you whether an aircraft can
  - actually use it, so this says whether the surface is paved, unpaved, water, or simply not
  - reported by source.

- FAA NOTES
  - The readme warns that "The Longest Runway (5.54) field may not always represent the longest
  - hard-surface runway at the airport" - so the length and this surface code must be read together,
  - and neither should be used alone to decide whether a paved runway of a given length exists.
  - Observed: 'S' soft on 7,735 airports, 'H' hard on 5,000, 'W' water on 586. 'U' never appears -
  - the FAA always states a surface. The dominance of 'S' reflects the very large number of small
  - private strips in the CIFP.

- ARINC 424-19A DIFFERENCE
  - Identical code table; 424-19A just formats it one code per row.

---

### 5.254 - Fixed Radius Transition Indicator

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - The required turn radius, in tenths of a nautical mile, when the controlling authority mandates a fixed radius
    transition between airway legs.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: FIXED RAD IND
  - When blank: No fixed radius transition is required at this point. This is the value on every FAA airway
    record.

- CONVERTER
  - `CifpFieldConverter.Field5254()` returns `double?`

- USED ON
  - `ER` — col 98-100 (Fix Radius Transition Indicator)

- RETURNS
  - Turn radius in decimal nautical miles (raw integer divided by 10.0), or null when blank - null meaning 'no
    fixed radius transition required'.

- OBSERVED IN CYCLE 2607
  - `   `

- DETAILS
  - Three digits at offset 98 of the enroute airway (ER) record. The decimal point is suppressed
  - before the last digit, so '225' is 22.5 NM and '150' is 15.0 NM.
  - Its meaning is a constraint, not a measurement: it says the controlling agency requires the turn
  - from the inbound course onto the outbound course at this fix to be flown at that specific
  - radius, rather than left to the flight management system to fly a normal turn. A blank field is
  - the normal case and explicitly means no fixed radius transition applies - do not model blank as
  - a radius of zero.

- FAA NOTES
  - The readme does not mention the field, and the FAA does not use it: all 19,099 enroute airway
  - primary records carry three spaces at offset 98.

---

### 5.255 - SBAS Service Provider Identifier

- SUMMARY
  - Two-digit code tying the approach to a particular satellite based augmentation system service provider.

- METADATA
  - Length: 2 characters
  - Character type: numeric
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: SBAS ID
  - When blank: No SBAS service provider identified for this procedure. Does not occur - all 4,905 path point
    primaries carry '00'.

- CONVERTER
  - `CifpFieldConverter.Field5255()` returns `int?`

- USED ON
  - `PP` — col 28-29 (SBAS Service Provider Identifier)

- RETURNS
  - The two digits as an int in the range 0-15, or null when blank.

- OBSERVED IN CYCLE 2607
  - `00`

- DETAILS
  - Two digits at offset 28 of the path point primary (PP) record, immediately after the route
  - indicator. The value range is 00 to 15. ARINC 424-18 does not define what each number means -
  - the assignments were left to the ICAO SBAS SARPS working groups - so the specification supplies
  - the field and the range but not the code table.
  - In practice the number identifies which regional SBAS provides the corrections the approach
  - depends on. The neighbouring Reference Path Data Selector (5.256) and Reference Path Identifier
  - (5.257) complete the tuning triple.

- FAA NOTES
  - The readme does not mention the field. All 4,905 path point primary records carry '00', which
  - is consistent with a single U.S. provider (WAAS) for the whole dataset.

- WATCH OUT
  - CRITICAL - the absence of a Field Value Examples file for 5.255 does NOT mean the field is
  - unpopulated. It is populated on every path point record with '00'. The examples generator failed
  - to read path point primary records at all; see 5.224 for the explanation. This value was read
  - directly from FAACIFP18.
  - ARINC 424-18 gives no code table for this field, so any mapping from number to provider name
  - must come from an external source and should be kept configurable.

---

### 5.256 - Reference Path Data Selector

- SUMMARY
  - Two-digit selector that lets GBAS avionics tune the correct approach data block automatically.

- METADATA
  - Length: 2 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: REF PDS
  - When blank: No data selector. Does not occur - all 4,905 path point primaries carry '00'.

- CONVERTER
  - `CifpFieldConverter.Field5256()` returns `int?`

- USED ON
  - `PP` — col 30-31 (Reference Path Data Selector)

- RETURNS
  - The two digits as an int in the range 0-48, or null when blank.

- OBSERVED IN CYCLE 2607
  - `00`

- DETAILS
  - Two digits at offset 30 of the path point primary (PP) record. The value range is 00 to 48.
  - Its purpose is automatic tuning: a GBAS ground station broadcasts several approach data blocks
  - and this number selects which one belongs to this procedure. As with the SBAS provider
  - identifier, ARINC 424-18 defines only the range and leaves the detailed semantics to the ICAO
  - GBAS SARPS working groups.
  - It works with the SBAS Service Provider Identifier (5.255) immediately before it and the
  - Reference Path Identifier (5.257) immediately after it.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primary records carry '00'. That is expected -
  - the FAA publishes no GBAS/GLS procedures in the CIFP, so there is no data block to select.

- WATCH OUT
  - CRITICAL - there is no Field Value Examples file for 5.256, but the field IS populated (with
  - '00') on every path point record. See 5.224 for why the examples generator missed the path point
  - primary layout entirely. This value was read directly from FAACIFP18.

---

### 5.257 - Reference Path Identifier

- SUMMARY
  - Four-character identifier a crew can use to confirm the avionics tuned the intended approach - the augmented-
    approach equivalent of an ILS Morse ident.

- METADATA
  - Length: 4 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: REF ID
  - When blank: No reference path identifier. Does not occur - all 4,905 path point primaries carry one.

- USED ON
  - `PP` — col 32-35 (Reference Path Identifier)

- RETURNS
  - The trimmed identifier, or null when blank.

- OBSERVED IN CYCLE 2607
  - `W18A`, `W36A`, `W35A`, `W17A`, `W13A`, `W31A`

- DETAILS
  - Four characters at offset 32 of the path point primary (PP) record. It is deliberately analogous
  - to the Morse identifier on an ILS: a short human-checkable string that confirms the box has
  - selected the right approach. Where an ILS crew listens for the ident, an SBAS/GBAS crew reads
  - this string off the display and matches it to the chart.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primaries carry a value, 95 distinct. The FAA
  - uses a systematic scheme rather than free text: a leading 'W' (for WAAS), then the two-digit
  - runway number, then a letter - 'W18A', 'W36A', 'W35A', 'W13A', 'W27A'. The trailing letter
  - distinguishes multiple reference paths to the same runway number.

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.257, but the field is populated on every
  - path point record. See 5.224. Observed values were read directly from FAACIFP18.
  - The FAA's 'W' + runway + letter scheme is a convention, not a rule from the specification - do
  - not parse the runway number out of it as if it were guaranteed.

---

### 5.258 - Approach Performance Designator

- SUMMARY
  - Single digit stating the type or category of approach the path point record supports.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: APD
  - When blank: No performance designator. Does not occur - all 4,905 path point primaries carry '0'.

- CONVERTER
  - `CifpFieldConverter.Field5258()` returns `int?`

- USED ON
  - `PP` — col 36 (Approach Performance Designator)

- RETURNS
  - The digit as an int in the range 0-7, or null when blank.

- OBSERVED IN CYCLE 2607
  - `0`

- DETAILS
  - One character at offset 36 of the path point primary (PP) record, between the reference path
  - identifier and the LTP latitude. The value range is 0 through 7. ARINC 424-18 states that the
  - complete assignment of numbers to approach categories was to be supplied by the ICAO GBAS SARPS
  - working groups and gives only one example - '1' meaning a Category I approach.
  - ARINC types the field as Alpha even though its content is a digit, so do not let a strict
  - character-class validator reject it.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primary records carry '0'. Combined with the
  - approach type identifiers on the continuation records (LPV and LP only), '0' evidently
  - corresponds to the non-precision-approach-category SBAS approaches the FAA publishes.

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.258, but the field is populated with '0' on
  - every path point record. See 5.224.
  - ARINC 424-18 declares the character type as Alpha while the content is numeric, and it publishes
  - no complete code table. Any mapping from number to approach category must come from outside the
  - specification.

---

### 5.259 - Length Offset

- SUMMARY
  - Distance in metres from the stop end of the runway to the Flight Path Alignment Point, marking where lateral
    sensitivity switches to missed approach sensitivity.

- METADATA
  - Length: 4 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: OFFSET
  - When blank: No offset stated. Does not occur - all 4,905 path point primaries carry a value, including 565
    explicit zeros.

- CONVERTER
  - `CifpFieldConverter.Field5259()` returns `int?`

- USED ON
  - `PP` — col 98-101 (Length Offset)

- RETURNS
  - The offset in whole metres as an int, or null when blank. Zero means the FPAP is at the opposite runway end,
    not that the value is missing.

- OBSERVED IN CYCLE 2607
  - `0000`, `1224`, `1528`, `1072`, `0920`, `0768`

- DETAILS
  - Four digits at offset 98 of the path point primary (PP) record, expressed in whole metres with
  - no suppressed decimal point - '0432' is 432 metres.
  - The Flight Path Alignment Point sits beyond the far end of the runway and, with the course width
  - at threshold (5.228), defines the splay of the lateral course. This field says how far past the
  - designated stop end the FPAP is. Where the FPAP coincides with the centre of the opposite runway
  - end the distance is zero, and '0000' is a real, meaningful value rather than a missing one.
  - Source resolution is 8 metres, so populated values are always multiples of 8.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primaries carry a value, 239 distinct, ranging
  - from 0000 to 2016 metres, and every single one is an exact multiple of 8 - a useful validation
  - check. The most common are 1224 m (597 records) and 0000 (565 records).

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.259, but the field is populated on every
  - path point record. See 5.224. Observed values were read directly from FAACIFP18.
  - Do not conflate '0000' with blank; they mean different things here.

---

### 5.261 - Speed Limit Description

- SUMMARY
  - Qualifies the speed restriction at a fix as at, at-or-above, or at-or-below the value in the Speed Limit
    field.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: SLD
  - When blank: Mandatory speed - cross the fix AT the speed given in the Speed Limit field. Blank is NOT 'no
    value'; it is the 'at' qualifier. If the Speed Limit field itself is empty there is simply no speed
    restriction.

- CONVERTER
  - `CifpFieldConverter.Field5261()` returns `string`

- USED ON
  - `HD` — col 117 (Speed Limit Description)
  - `HF` — col 117 (Speed Limit Description)
  - `PD` — col 117 (Speed Limit Description)
  - `PE` — col 117 (Speed Limit Description)
  - `PF` — col 117 (Speed Limit Description)

- RETURNS
  - A SpeedLimitDescription enum (At / AtOrAbove / AtOrBelow). Return At for a blank - never null - and let the
    caller decide there is no restriction by checking the Speed Limit field.

- VALUES
  - ` ` [observed] — Mandatory speed - cross the fix AT the speed in the Speed Limit field. (Shown as '@' in the ARINC table; the actual character is a space.)
  - `+` [observed] — Minimum speed - cross the fix AT OR ABOVE the speed in the Speed Limit field.
  - `-` [observed] — Maximum speed - cross the fix AT OR BELOW the speed in the Speed Limit field.

- OBSERVED IN CYCLE 2607
  - ` `, `+`, `-`

- DETAILS
  - One character at offset 117 of SID, STAR and approach leg records. It works exactly like the
  - altitude description field does for altitudes: the number lives elsewhere and this character
  - says which side of it you must be on.
  - The trap is that the 'at' case is encoded as a SPACE. ARINC writes it as '@' in the table but
  - the actual field content is blank. So a blank here plus a populated Speed Limit means a
  - mandatory crossing speed, while a blank here plus a blank Speed Limit means no restriction at
  - all. The two must be read together.

- FAA NOTES
  - Not mentioned in the readme. Observed on procedure leg primaries: blank 197,008, '-' 4,102, '+'
  - 4. The FAA overwhelmingly publishes maximum speeds; minimum speeds are essentially unused.

- WATCH OUT
  - ARINC's own table writes the mandatory code as '@' with '(blank)' beside it. The file contains a
  - space, not an at-sign. Do not code a '@' case.
  - Because blank is a meaningful value, this is one of the few single-character fields where
  - mapping blank to null loses information.

---

### 5.262 - Approach Type Identifier

- SUMMARY
  - The literal name of a vertically guided approach type that requires path point data, such as LPV or LP.

- METADATA
  - Length: 10 characters
  - Character type: alphanumeric
  - Kind: identifier
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: ATI
  - When blank: No approach type named on this continuation record.

- USED ON
  - `PP~cont` — col 46-55 (Approach Type Identifier)

- RETURNS
  - The trimmed approach type name, or null when the slice is all spaces.

- OBSERVED IN CYCLE 2607
  - `LP        `, `LPV       `

- DETAILS
  - Ten characters at offset 46 of the path point CONTINUATION record, left justified and blank
  - padded. It names the approach type in words as published - the specification's own examples are
  - 'GLS', 'LPV' and 'APV-II'. The field exists so a reader can tell which minima line the path
  - point data belongs to, and it is coded alongside the horizontal and vertical alert limits
  - (5.263, 5.264) that go with that service level.

- FAA NOTES
  - Not mentioned in the readme by name, but the CIFP's approach inventory constrains it. Only two
  - values appear across all 4,905 path point continuation records: 'LPV' (4,187) and 'LP' (718).
  - The correlation with the alert limits is exact - every LPV record has vertical alert limit 500
  - (50.0 m) or 350 (35.0 m), and every LP record has 000, because LP is a lateral-only service.
  - GLS never appears, consistent with the readme's statement that GLS procedures are not in the
  - CIFP.

- ARINC 424-19A DIFFERENCE
  - Identical in 424-19A.

- WATCH OUT
  - The Field Value Examples file lists a third pattern, '##W#######', which is not an approach type.
  - It comes from slicing path point PRIMARY records with the continuation layout: offsets 46-55 of
  - a primary are the tail of the LTP latitude plus the start of the LTP longitude, e.g.
  - '50W1490602'. Ignore it - only LP and LPV are real.

---

### 5.263 - Horizontal Alert Limit

- SUMMARY
  - The radius of the horizontal containment circle the navigation solution must stay inside, in tenths of a
    metre.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: HAL
  - When blank: No horizontal alert limit stated. Does not occur - all 4,905 path point primaries carry a value.

- CONVERTER
  - `CifpFieldConverter.Field5263()` returns `double?`

- USED ON
  - `PP` — col 109-111 (HAL)

- RETURNS
  - The limit in metres as a double (raw integer divided by 10.0), or null when blank.

- OBSERVED IN CYCLE 2607
  - `400`

- DETAILS
  - Three digits at offset 109 of the path point primary (PP) record, expressed in metres to a
  - resolution of one tenth with the decimal point suppressed. '400' is 40.0 metres, not 400.
  - Conceptually it is an integrity threshold: a circle in the horizontal plane, centred on the
  - aircraft's true position, that the indicated position must lie within with the required
  - probability for the navigation mode in use. If the system's computed horizontal protection
  - level exceeds this limit, the approach service is unavailable and the crew must be alerted. It
  - is paired with the Vertical Alert Limit (5.264) immediately after it.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primaries carry '400' - 40.0 metres, the
  - standard LPV/LP horizontal alert limit. There is no variation in the dataset.

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.263, but the field is populated on every
  - path point record. See 5.224 for why the examples generator missed the path point primary
  - layout. Read directly from FAACIFP18.
  - The suppressed decimal is easy to miss on a three-digit field. 40.0 m is the correct reading of
  - '400'.

---

### 5.264 - Vertical Alert Limit

- SUMMARY
  - Half the height of the vertical containment segment the navigation solution must stay inside, in tenths of a
    metre.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: VAL
  - When blank: No vertical alert limit stated. Does not occur - all 4,905 path point primaries carry a value,
    though 718 of them are '000'.

- CONVERTER
  - `CifpFieldConverter.Field5264()` returns `double?`

- USED ON
  - `PP` — col 112-114 (VAL)

- RETURNS
  - The limit in metres as a double (raw integer divided by 10.0), or null when blank. Treat 0.0 as 'no vertical
    guidance' - it pairs with approach type LP and with glide path angle 0000.

- OBSERVED IN CYCLE 2607
  - `000`, `350`, `500`

- DETAILS
  - Three digits at offset 112 of the path point primary (PP) record, in metres to a resolution of
  - one tenth with the decimal point suppressed. '500' is 50.0 metres, '350' is 35.0 metres.
  - It is the vertical counterpart of the Horizontal Alert Limit: half the length of a segment on
  - the vertical axis, centred on the aircraft's true position, that the indicated vertical position
  - must lie within with the required probability. If the computed vertical protection level exceeds
  - it, vertical guidance is not available.

- FAA NOTES
  - Not mentioned in the readme, but the observed values map exactly onto the FAA's SBAS service
  - levels, cross-checked against the approach type identifier (5.262) on the matching continuation
  - record:
  - '500' (50.0 m) on 2,985 records - all LPV, the standard LPV vertical alert limit.
  - '350' (35.0 m) on 1,202 records - all LPV, the tighter LPV-200 limit.
  - '000' on 718 records - all LP, which is a lateral-only service with no vertical guidance.
  - So '000' means "no vertical service", not "a zero-metre limit". The correlation with 5.262 is
  - 100 percent in the shipped file.

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.264; the field is nevertheless populated on
  - every path point record. See 5.224.
  - '000' is a sentinel, not a measurement. A consumer that feeds it into a vertical containment
  - check as zero metres will conclude every LP approach is out of tolerance.

---

### 5.265 - Path Point TCH

- SUMMARY
  - The height of the approach path above the landing threshold or helicopter alighting point, at higher
    resolution than the ordinary TCH field.

- METADATA
  - Length: 6 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: PP TCH
  - Format: Six digits; decimal point implied one place from the right when units are feet, two places when units are metres.
  - When blank: No threshold crossing height stated. Does not occur - all 4,905 path point primaries carry a
    value, including 177 explicit zeros.

- CONVERTER
  - `CifpFieldConverter.Field5265()` returns `double?`

- USED ON
  - `PP` — col 102-107 (Path Point TCH)

- RETURNS
  - The crossing height as a double, together with its unit. Divide by 10.0 when 5.266 is 'F', by 100.0 when it is
    'M'. Null when blank.

- OBSERVED IN CYCLE 2607
  - `000400`, `000450`, `000500`, `000550`, `000000`

- DETAILS
  - Six digits at offset 102 of the path point primary (PP) record. It is the same physical quantity
  - as the ordinary Threshold Crossing Height (5.67), but carried at far greater precision because
  - the path point data has to support precision-like vertical guidance.
  - The scaling is NOT fixed. It depends on the TCH Units Indicator (5.266) in the very next column:
  - - Units 'F': the value is FEET to a resolution of one tenth. '000400' is 40.0 ft.
  - - Units 'M': the value is METRES to a resolution of one hundredth. '000400' would be 4.00 m.
  - So the six digits alone are meaningless; the pair must be decoded together. Because the units
  - indicator is inside the FAS CRC wrap, a metric source value must not be silently converted to
  - feet.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primaries carry a value with units 'F', 287
  - distinct, from '000000' to '000680' - so 0.0 to 68.0 feet. The common ones are 000400 (40.0 ft,
  - 1,221 records), 000450 (45.0 ft) and 000500 (50.0 ft), which are typical published TCH values.
  - 177 records carry 000000; those pair with the LP procedures that have no vertical guidance.

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.265, but the field is populated on every
  - path point record. See 5.224.
  - This is the only path point measurement whose decimal scaling is decided by a separate field.
  - Hard-coding a divide-by-ten will silently produce a ten-times error on any metric source.

---

### 5.266 - TCH Units Indicator

- SUMMARY
  - Says whether the Path Point TCH beside it is expressed in feet or in metres.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: TCH UNIT
  - When blank: Units not stated, which makes the Path Point TCH unusable. Does not occur - all 4,905 path point
    primaries carry 'F'.

- CONVERTER
  - `CifpFieldConverter.Field5266()` returns `string`

- USED ON
  - `PP` — col 108 (TCH Units Indicator)

- RETURNS
  - A TchUnits enum (Feet / Metres), or null when blank. The Path Point TCH converter must consume this value.

- VALUES
  - `F` [observed] — Path Point TCH is in feet, resolution one tenth of a foot.
  - `M` [not in cycle] — Path Point TCH is in metres, resolution one hundredth of a metre.

- OBSERVED IN CYCLE 2607
  - `F`

- DETAILS
  - One character at offset 108 of the path point primary (PP) record, immediately after the Path
  - Point TCH (5.265). 'F' means the TCH is in feet to a resolution of one tenth; 'M' means it is in
  - metres to a resolution of one hundredth.
  - This field exists specifically so that a metric source value never has to be converted to feet
  - before storage. It is included inside the Final Approach Segment CRC wrap, which means the
  - stored value must round-trip exactly - a parser that normalises everything to feet and discards
  - the indicator breaks the integrity check.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primary records carry 'F'; the FAA publishes
  - threshold crossing heights in feet throughout.

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.266, but the field is populated with 'F' on
  - every path point record. See 5.224.
  - Because the indicator is inside the FAS CRC wrap, do not convert the TCH and drop the unit. Keep
  - both.

---

### 5.267 - High Precision Latitude

- SUMMARY
  - Latitude of a path point feature at 0.0001 arc-second resolution - the high precision extension of the
    ordinary latitude field.

- METADATA
  - Length: 11 characters
  - Character type: alphanumeric
  - Kind: coordinate
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: HPLAT
  - Format: H DD MM SS ssss - hemisphere letter then 2+2+2+4 digits
  - When blank: No high precision latitude. Does not occur - both instances on every path point primary are
    populated.

- CONVERTER
  - `CifpFieldConverter.Field5267()` returns `double?`

- USED ON
  - `PP` — col 37-47 (Landing Threshold Point Latitude); col 70-80 (Flight Path Alignment Point Latitude)

- RETURNS
  - Signed decimal degrees as a double, positive north, negative south. Null when blank. Keep the raw 11
    characters too, because the value is inside the FAS CRC wrap.

- OBSERVED IN CYCLE 2607
  - `N5938250525`, `N4200067055`, `N3812287175`, `N4222256945`, `N3458453445`

- DETAILS
  - Eleven characters. Position one is the hemisphere, 'N' or 'S'. The remaining ten are packed
  - sexagesimal with no separators:
  - positions 2-3 two digits of DEGREES (00-90)
  - positions 4-5 two digits of MINUTES (00-59)
  - positions 6-7 two digits of SECONDS (00-59)
  - positions 8-11 four digits of DECIMAL SECONDS
  - So 'N3028422400' is N 30 degrees 28 minutes 42.2400 seconds. Decimal degrees =
  - deg + min/60 + (sec + frac/10000)/3600, negated when the hemisphere letter is 'S'.
  - This is the same idea as the ordinary Latitude field (5.36) but with four decimal places of
  - seconds instead of two, giving a stated resolution of 0.0005 arc seconds - roughly 1.5
  - centimetres. That precision is needed because path point coordinates define the geometry of a
  - vertically guided approach and are protected by the FAS CRC.
  - It appears twice on the path point primary (PP) record: offset 37 for the Landing Threshold
  - Point and offset 70 for the Flight Path Alignment Point.

- FAA NOTES
  - Not mentioned in the readme. All 4,905 path point primaries carry both latitudes; 4,881 distinct
  - LTP values, so a handful of thresholds are shared between procedures.

- WATCH OUT
  - CRITICAL - no Field Value Examples file exists for 5.267, yet the field is populated on every
  - path point record. See 5.224.
  - Do not reuse the 9-character latitude converter (5.36) here. The layouts differ in the number of
  - fractional-second digits and a shared routine will silently mis-scale by a factor of 100.

---

### 5.268 - High Precision Longitude

- SUMMARY
  - Longitude carried at the extra precision the FAS data block needs, used for the landing threshold and flight
    path alignment points on Path Point records.

- METADATA
  - Length: 12 characters
  - Character type: alphanumeric
  - Kind: coordinate
  - Trimmed: N
  - Converted: Y
  - ARINC abbreviation: HPLONG
  - Format: E|W followed by DDDMMSSssss
  - When blank: Position not provided.

- CONVERTER
  - `CifpFieldConverter.Field5268()` returns `double?`

- USED ON
  - `PP` — col 48-59 (Landing Threshold Point Longitude); col 81-92 (Flight Path Alignment Point Longitude)

- RETURNS
  - Signed decimal degrees as a double, negative for western longitudes; null when blank.

- OBSERVED IN CYCLE 2607
  - `W###########`, `E###########`

- DETAILS
  - An extended form of the ordinary Longitude field (5.37). Layout is a hemisphere letter
  - E or W followed by eleven digits: three for degrees, two for minutes, two for seconds,
  - then four fractional digits carrying tenths, hundredths, thousandths and ten-thousandths
  - of a second. That yields a resolution of 0.0005 arc seconds, roughly 15 mm, which is what
  - the SBAS Final Approach Segment data block requires. Decimal degrees are
  - (deg + min/60 + sec/3600), negated for W.
  - Appears twice on the Path Point primary record: the Landing Threshold Point at zero-based
  - index 48 and the Flight Path Alignment Point at index 81.

- WATCH OUT
  - The Field Value Examples folder has no file for 5.268, and the file for its latitude twin
  - 5.267 is empty. Both are wrong: the real Path Point records clearly populate these columns
  - (e.g. 'W14906023005'). The sampler that produced those example files evidently missed this
  - field, so do NOT conclude from the examples folder that these are unpopulated.

---

### 5.269 - Helicopter Procedure Course

- SUMMARY
  - Final approach course, in whole degrees, for helicopter procedures flown to a helipad or to a point in space.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: numeric
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: HPC
  - Format: DDD, zero-padded whole degrees
  - When blank: Not a helicopter procedure to a helipad or point in space.

- USED ON
  - `PP~cont` — col 71-73 (Helicopter Procedure Course)

- RETURNS
  - The course in whole degrees as an integer, or null when blank.

- OBSERVED IN CYCLE 2607
  - `   `, `###`

- DETAILS
  - Carried on Path Point Continuation records. Helicopter procedures to a pad or a point in
  - space have no runway to key on: the primary record codes runway number 00 with a blank
  - runway letter, so the pad identifier and this final approach course are what make the
  - procedure uniquely identifiable. Read it together with the Approach Procedure Identifier
  - and the Runway/Helipad Identifier from the primary record. Values are zero-padded whole
  - degrees, 001 through 360.

- WATCH OUT
  - Blank on the overwhelming majority of Path Point continuations, since almost all of them
  - are fixed-wing. Only helicopter procedures to pads or points in space populate it.

---

### 5.270 - TCH Value Indicator

- SUMMARY
  - Single character saying where the Threshold Crossing Height in the runway record came from - the glide slope,
    an RNAV procedure, the visual glide slope indicator, or a default.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: TCHVI
  - Format: One character from the four-code table.
  - When blank: No TCH source declared. Does not occur in the FAA CIFP - every runway record carries one of the
    four codes.

- USED ON
  - `PG` — col 80 (TCH Value Indicator)

- RETURNS
  - The raw character or a four-member TchSource enum. Pair it with the Threshold Crossing Height value so callers
    can tell a surveyed height from a default.

- VALUES
  - `I` [observed] — The TCH in the runway record is that of the ILS or MLS glide slope.
  - `R` [observed] — The TCH in the runway record is that of an RNAV procedure to the runway.
  - `V` [observed] — The TCH in the runway record is that of the visual glide slope indicator (VGSI) for the runway.
  - `D` [observed] — The TCH in the runway record is the default value - 50 feet under 424-18, 40 or 50 feet under 424-19A.

- OBSERVED IN CYCLE 2607
  - `D`, `I`, `R`, `V`

- DETAILS
  - One character at offset 80 of the Runway (PG) record. It qualifies the Threshold
  - Crossing Height (5.67) in the same record: two runways can both show a TCH of 50 ft
  - and mean entirely different things, so this code must be carried on the model
  - alongside the height rather than discarded.
  - The four codes name the source in descending order of authority: an electronic glide
  - slope, an RNAV procedure's published TCH, the VGSI (VASI/PAPI) setting, or the
  - fallback default when nothing is published.
  - A consumer computing a vertical path should treat 'D' as 'no published TCH' rather
  - than as a surveyed value.

- ARINC 424-19A DIFFERENCE
  - 424-19A changes the meaning of 'D' from a flat default of 50 feet to 'the default
  - value of 40 or 50 feet', cross-referencing Section 5.67. So under v19 a 'D' record
  - does not by itself tell you whether the assumed TCH is 40 or 50 ft. The FAA applies
  - v18 for this field, but the associated procedure-coding rules it does take from v19
  - (Attachment 5) use the 40-or-50 wording, so do not hard-code 50.

- WATCH OUT
  - All four codes occur and 'D' is the commonest: 9,261 runways declare a default TCH,
  - 4,922 an RNAV TCH, 1,359 a VGSI TCH and 1,263 a glide slope TCH. That means over half
  - the runway records carry an assumed rather than a published crossing height - a fact
  - worth surfacing in any derived vertical-path calculation.

---

### 5.271 - Procedure Turn

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - TAA field indicating whether a course reversal must be flown when arriving within a particular terminal
    arrival area sector.

- METADATA
  - Length: 4 characters
  - Character type: alpha
  - Kind: enum
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: PROC TURN
  - Format: 424-18 - the literal 'NOPT' or four blanks. 424-19A - a single 'N' or 'Y'.
  - When blank: Under 424-18, blank means a course reversal IS expected. Blank is therefore a meaningful code, not
    missing data - although this never matters in the FAA CIFP because the field never appears.

- CONVERTER
  - Decoded per column; see the composite columns below.

- USED ON
  - `HD` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `HF` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `PD` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `PE` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)
  - `PF` — col 106-110 (Center Fix or TAA Procedure Turn Indicator)

- RETURNS
  - A bool? ProcedureTurnRequired - false for 'NOPT' or 'N', true for blank (v18) or 'Y' (v19), null when the
    field is not applicable to the record. In an FAA-only parser this property should simply not exist on any
    model.

- VALUES
  - `NOPT` [not in cycle] — 424-18 - no procedure turn (course reversal) is required in this TAA area.
  - `    ` [not in cycle] — 424-18 - a course reversal is expected.
  - `N` [not in cycle] — 424-19A - course reversal not necessary.
  - `Y` [not in cycle] — 424-19A - course reversal necessary.

- DETAILS
  - Under 424-18 this is a four-character field on the Airport or Heliport TAA Primary
  - Record (subsections PK and HK). Government source publishes 'NOPT' when no procedure
  - turn is required; ARINC copies that literally into the field and leaves the field
  - blank when a course reversal IS required. The indication is given once per TAA
  - Sector Identifier (5.272).
  - Where does it live in the FAA CIFP? Nowhere. The FAA publishes no TAA records. The
  - project's record-layout CSVs label offsets 106-110 of the SID, STAR and Approach
  - records as '5.144 or 5.271' - Center Fix or TAA Procedure Turn Indicator - because
  - ARINC overloads those columns. In the FAA CIFP those columns are always the Center
  - Fix (5.144), never the TAA procedure turn. See anomalies for the evidence.

- FAA NOTES
  - The FAA CIFP readme lists the record types the file contains; TAA records (PK, HK)
  - are not among them. The readme says nothing about 5.271.

- ARINC 424-19A DIFFERENCE
  - 424-19A changes this field substantially. It becomes ONE character rather than four,
  - and the coding inverts from 'text or blank' to an explicit pair: 'N' when the course
  - reversal is not necessary and 'Y' when it is necessary. 424-19A also changes the
  - granularity - the indication is given for each sector on a particular TAA initial
  - approach fix rather than once for a group of sectors. If the FAA ever adds TAA
  - records it will presumably follow v19, so build the converter to accept 'NOPT',
  - blank, 'N' and 'Y'.

- WATCH OUT
  - The field is completely absent from the FAA CIFP. Two independent confirmations:
  - - There is no Field Value Examples file for 5.271 at all, which the brief defines
  - as meaning the FAA never populates it.
  - - Scanning offsets 106-111 of all 122,323 Approach records yields only blanks,
  - runway identifiers (RW09, RW09L, ...) and fix identifiers - the Center Fix
  - (5.144) content. The literal 'NOPT' appears just twice in the entire 396,430-line
  - file, and both occurrences are the five-letter waypoint identifier 'NOPTE' at
  - KCPR, not this field.
  - Implementation guidance: do not add a TaaProcedureTurn property to the SID, STAR or
  - Approach models. Offsets 106-110 there are unambiguously the Center Fix. Keep this
  - spec only so that the overloaded-columns note in the layout CSVs is explained.

---

### 5.272 - TAA Sector Identifier

> **Never populated by the FAA.** Defined by ARINC 424 and reserved in the layout, but blank on every record in cycle 2607.

- SUMMARY
  - Single character naming which terminal arrival area sector - straight-in/centre, left base or right base - a
    TAA record describes.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: N
  - ARINC abbreviation: TAA SECTOR
  - Format: One character - 'C', 'L' or 'T'.
  - When blank: The record does not carry a TAA sector reference.

- USED ON
  - `HD` — col 111 (Multiple Code or TAA Sector Identifier)
  - `HF` — col 111 (Multiple Code or TAA Sector Identifier)
  - `PD` — col 111 (Multiple Code or TAA Sector Identifier)
  - `PE` — col 111 (Multiple Code or TAA Sector Identifier)
  - `PF` — col 111 (Multiple Code or TAA Sector Identifier)

- RETURNS
  - A three-member TaaSector enum, or null. In an FAA-only parser this property should not exist on any model.

- VALUES
  - `C` [not in cycle] — Straight-in area, or centre sector (on the final approach course).
  - `L` [not in cycle] — Left base area (left of the final approach course).
  - `T` [not in cycle] — Right base area (right of the final approach course). Note the letter is 'T', not 'R'.

- DETAILS
  - One character on the Airport or Heliport TAA Primary Record. Terminal arrival
  - altitudes are published for each initial approach fix of an RNAV or GPS approach, and
  - this code says which of the three sectors around that fix the record's altitude
  - applies to.
  - 'Left' and 'right' are relative to the final approach course, not to any compass
  - direction: left of final, right of final, or straight in. Note the deliberately
  - counter-intuitive letter choice - the right base area is coded 'T', not 'R'.
  - Where does it live in the FAA CIFP? Nowhere. The FAA publishes no TAA records. The
  - project's record-layout CSVs label offset 111 of the SID, STAR and Approach records
  - as '5.130 or 5.272' - Multiple Code or TAA Sector Identifier - because ARINC
  - overloads that column. In the FAA CIFP that column is always the Multiple Code
  - (5.130), never a TAA sector.

- FAA NOTES
  - The FAA CIFP readme's record-type list contains no TAA (PK, HK) records, and says
  - nothing about 5.272.

- ARINC 424-19A DIFFERENCE
  - 424-19A keeps the same three letters but reframes the field as a 'TAA Fix Position
  - Indicator': when it appears on an Airport or Heliport Approach Procedure record it
  - acts as a pointer to the specific PK/HK TAA record holding that fix's data. The
  - descriptions are also clarified - centre means on the final approach course, left and
  - right mean left and right of it, which can equally be read as the direction of turn
  - onto final from that base leg.

- WATCH OUT
  - Completely absent from the FAA CIFP - there is no Field Value Examples file for
  - 5.272, and offset 111 of the SID, STAR and Approach records carries the Multiple Code
  - (5.130) in every populated case.
  - Trap for the implementer: the letter for the right base area is 'T'. Anyone
  - hand-writing the enum from memory will write 'R' and produce a silently wrong mapping
  - if the FAA ever starts publishing TAA records.

---

### 5.275 - Level of Service Name

- SUMMARY
  - The published operating-minima name for an approach level of service authorized for SBAS, such as LPV or
    LNAV/VNAV.

- METADATA
  - Length: 10 characters
  - Character type: alpha
  - Kind: enum
  - Trimmed: Y
  - Converted: N
  - ARINC abbreviation: LSN
  - When blank: The paired Level of Service Authorized field (5.276) is 'N', so no name applies.

- USED ON
  - `HF~cont` — col 41-50 (FAS Block Provided Level of Service Name); col 52-61 (LNAV/VNAV Level of Service Name); col 63-72 (LNAV Level of Service Name)
  - `PF~cont` — col 41-50 (FAS Block Provided Level of Service Name); col 52-61 (LNAV/VNAV Level of Service Name); col 63-72 (LNAV Level of Service Name)

- RETURNS
  - The trimmed minima name, or an empty string when the service is not authorized.

- VALUES
  - `LPV` [observed] — Localizer Performance with Vertical guidance
  - `LP` [observed] — Localizer Performance, lateral guidance only
  - `LNAV/VNAV` [observed] — Lateral Navigation with Vertical Navigation
  - `LNAV` [observed] — Lateral Navigation only

- OBSERVED IN CYCLE 2607
  - `LPV       `, `LNAV/VNAV `, `LNAV      `, `LP        `, `          `

- DETAILS
  - Left justified and blank filled to ten characters. It appears three times on an approach
  - Level of Service continuation record, each occurrence paired with its own Level of Service
  - Authorized flag (5.276) immediately preceding it: the FAS-block-provided service, then
  - LNAV/VNAV, then LNAV. When the paired authorization flag is 'N', the whole ten-character
  - name field is blank by design.
  - Zero-based positions on the continuation record are 41-50, 52-61 and 63-72.

- FAA NOTES
  - The FAA applies ARINC 424 version 19 to the level of service continuation record. Version
  - 19 renumbers the RNP variant of this concept as 5.297 and adds RNP Level of Service values
  - in columns that version 18 shows as blank spacing (see anomalies).

- ARINC 424-19A DIFFERENCE
  - Version 19 splits the concept: 5.275 continues to carry the SBAS minima names, while a new
  - field 5.297 carries three-digit RNP level of service values formatted per 5.211.

- WATCH OUT
  - Two traps here.
  - First, the Field Value Examples file for 5.275 is contaminated. It lists strings such as
  - ' F IF ', ' FL###RF ' and 'RFL###RF ' which are not level of service names at all;
  - they are Path and Termination and RNP data read from the same columns on PRIMARY approach
  - records. Always test the continuation record number before slicing these columns. Sampling
  - only genuine continuations gives exactly four names plus blank.
  - Second, the CH 4 layout CSV marks zero-based 73-117 as one blank run. It is not. Verified
  - against the real file: 430 of the 6,742 PF/HF continuations carry RNP level of service data
  - starting at zero-based index 88, laid out per ARINC 424-19A section 4.1.9.5 as four
  - repetitions of a 1-character RNP Authorized flag followed by a 3-character RNP value
  - (indices 88-91, 92-95, 96-99, 100-103). Observed values look like 'A031', 'A152', 'A112',
  - 'A011', 'A021' — an 'A' authorization flag plus an RNP value encoded per 5.211, so A031
  - means RNP 0.30. Every record carrying this block is route type H with Qualifier 1 F, i.e.
  - an RNAV (RNP) approach. The v19 layout is authoritative here because the FAA states it
  - applies version 19 to this record.

---

### 5.276 - Level of Service Authorized

- SUMMARY
  - Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.

- METADATA
  - Length: 1 character
  - Character type: alpha
  - Kind: enum
  - Trimmed: N
  - Converted: Y
  - When blank: The level of service is not addressed on this record. On the 430 RNAV (RNP) continuations the SBAS
    flags are blank because the record carries RNP data instead.

- CONVERTER
  - `CifpFieldConverter.Field5276()` returns `string`

- USED ON
  - `HF~cont` — col 40 (FAS Block Provided); col 51 (LNAV/VNAV Authorized for SBAS); col 62 (LNAV Authorized for SBAS); col 88 (RNP Authorized 1); col 92 (RNP Authorized 2); col 96 (RNP Authorized 3); col 100 (RNP Authorized 4)
  - `PF~cont` — col 40 (FAS Block Provided); col 51 (LNAV/VNAV Authorized for SBAS); col 62 (LNAV Authorized for SBAS); col 88 (RNP Authorized 1); col 92 (RNP Authorized 2); col 96 (RNP Authorized 3); col 100 (RNP Authorized 4)

- RETURNS
  - true for 'A', false for 'N', null when blank.

- VALUES
  - `A` [observed] — The designated level of service is authorized for the procedure
  - `N` [observed] — The designated level of service is not authorized for the procedure
  - ` ` [observed] — Not addressed on this record

- OBSERVED IN CYCLE 2607
  - `A`, `N`, ` `

- DETAILS
  - Always read as a pair with the Level of Service Name that follows it. Three pairs appear
  - on an approach Level of Service continuation record, at zero-based indices 40, 51 and 62,
  - covering the FAS-block-provided service, LNAV/VNAV, and LNAV respectively. When the flag
  - is 'N' the paired ten-character name field is blank.
  - Under ARINC 424-19A the same field type also gates each RNP level of service value on the
  - same record, at zero-based indices 88, 92, 96 and 100.

- FAA NOTES
  - The FAA applies ARINC 424 version 19 to the level of service continuation record.

- WATCH OUT
  - The Field Value Examples file for 5.276 lists ' ', '#', 'A', 'N' and 'Y'. The '#' and 'Y'
  - entries are contamination from primary approach records, where other fields occupy these
  - columns. Measured against genuine continuations only, the field takes exactly A, N or blank.
  - Real distribution across the 6,742 PF/HF continuations: FAS block provided A=4,903 N=1,409
  - blank=430; LNAV/VNAV A=4,077 N=2,235 blank=430; LNAV A=6,263 N=46 blank=433. The blanks
  - line up with the RNAV (RNP) records that carry RNP data in place of SBAS minima.

---

### 5.297 - RNP Level of Service

- SUMMARY
  - An RNP value published as an additional level of service for an RNAV (RNP) approach, encoded the same way as
    the RNP field 5.211.

- METADATA
  - Length: 3 characters
  - Character type: numeric
  - Kind: pattern
  - Trimmed: Y
  - Converted: Y
  - ARINC abbreviation: LSN
  - Format: Two significant digits followed by a single-digit negative power of ten
  - When blank: No further RNP level of service at this position.

- CONVERTER
  - `CifpFieldConverter.Field5297()` returns `double?`

- USED ON
  - `HF~cont` — col 89-91 (RNP Level of Service Value 1); col 93-95 (RNP Level of Service Value 2); col 97-99 (RNP Level of Service Value 3); col 101-103 (RNP Level of Service Value 4)
  - `PF~cont` — col 89-91 (RNP Level of Service Value 1); col 93-95 (RNP Level of Service Value 2); col 97-99 (RNP Level of Service Value 3); col 101-103 (RNP Level of Service Value 4)

- RETURNS
  - The decoded RNP value as a double, e.g. 0.30 for "031"; null when blank.

- OBSERVED IN CYCLE 2607
  - `031`, `152`, `112`, `011`, `021`, `   `

- DETAILS
  - Introduced in ARINC 424-19A and carried only on approach Level of Service continuation
  - records, in up to four slots, each preceded by its own Level of Service Authorized flag
  - (5.276). Values are listed beginning with the least restrictive.
  - Encoding follows 5.211: the first two characters are the significant digits and the third
  - is a negative power-of-ten exponent, so "031" is 3 x 10^-1 = RNP 0.30 and "112" is
  - 11 x 10^-2 = RNP 0.11. Note the least restrictive value for each individual leg still lives
  - in the primary record's RNP field; this continuation carries the additional published values.

- FAA NOTES
  - The FAA states it applies ARINC 424 version 19 to the level of service continuation record.
  - Verified in FAACIFP18: 430 of the 6,742 PF/HF continuation records carry this block, and
  - every one of them is an RNAV (RNP) approach (route type H with Approach Route Qualifier 1 F).

- ARINC 424-19A DIFFERENCE
  - Does not exist in ARINC 424-18. The version 18 layout marks these columns as blank spacing,
  - which is why the CH 4 layout CSV for this record shows one long blank run across them.

- WATCH OUT
  - Present in real data at zero-based indices 89-91, 93-95, 97-99 and 101-103, inside the range
  - the version 18 CH 4 layout CSV describes as a single blank run. Any parser built only from
  - the v18 layout silently discards it.

---
