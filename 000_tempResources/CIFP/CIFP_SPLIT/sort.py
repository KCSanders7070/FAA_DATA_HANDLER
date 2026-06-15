def classify_line(line):
    # Ensure line is long enough
    line = line.rstrip('\n') + ' ' * (13 - len(line))

    # Specific index checks
    idx0_2 = line[0:3]
    idx4 = line[4]
    idx5 = line[5]
    idx12 = line[12]

    # New rules first
    if idx0_2 == 'HDR':
        return 'HeaderInfo'
    elif idx4 == 'H' and idx12 == 'D':
        return 'HeliportStandardInstrumentDepartures'

    # Existing rules
    elif idx4 == 'P' and idx12 == 'A':
        return 'Airports'
    elif idx4 == 'H' and idx12 == 'A':
        return 'Heliports'
    elif idx4 == 'P' and idx12 == 'G':
        return 'Runways'
    elif idx4 == 'D' and idx5 == ' ':
        return 'VhfNavaids'
    elif idx4 == 'D' and idx5 == 'B':
        return 'NnbNavaids'
    elif idx4 == 'P' and idx5 == 'N':
        return 'TerminalNavaids'
    elif idx4 == 'P' and idx12 == 'I':
        return 'LocalizerAndGlideSlope'
    elif idx4 == 'P' and idx12 == 'P':
        return 'PathPoint'
    elif idx4 == 'P' and idx12 == 'S':
        return 'AirportMinimumSectorAltitude'
    elif idx4 == 'H' and idx12 == 'S':
        return 'HeliportMinimumSectorAltitude'
    elif idx4 == 'E' and idx5 == 'A':
        return 'EnrouteWaypoints'
    elif idx4 == 'P' and idx12 == 'C':
        return 'AirportTerminalWaypoints'
    elif idx4 == 'H' and idx12 == 'C':
        return 'HeliportTerminalWaypoints'
    elif idx4 == 'P' and idx12 == 'D':
        return 'StandardInstrumentDepartures'
    elif idx4 == 'P' and idx12 == 'E':
        return 'StandardTerminalArrivalRoutes'
    elif idx4 == 'P' and idx12 == 'F':
        return 'AirportApproachProcedures'
    elif idx4 == 'H' and idx12 == 'F':
        return 'HeliportApproachProcedures'
    elif idx4 == 'E' and idx5 == 'R':
        return 'Airways'
    elif idx4 == 'U' and idx5 == 'C':
        return 'ControlledClassAirspaceBCD'
    elif idx4 == 'U' and idx5 == 'R':
        return 'SpecialUseRestrictive'
    elif idx4 == 'A' and idx5 == 'S':
        return 'GridMora'
    else:
        return 'ignored'


def main():
    input_filename = 'FAACIFP18.txt'
    output_files = {}

    try:
        with open(input_filename, 'r') as infile:
            for line in infile:
                data_type = classify_line(line)
                if data_type not in output_files:
                    output_files[data_type] = open(f'{data_type}.txt', 'w')
                output_files[data_type].write(line)
    finally:
        for f in output_files.values():
            f.close()


if __name__ == '__main__':
    main()
