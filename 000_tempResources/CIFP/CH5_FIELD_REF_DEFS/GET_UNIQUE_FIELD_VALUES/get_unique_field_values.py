import csv
import glob
import os
import re


INPUT_FILENAME = r"C:\Users\ksand\Downloads\FAACIFP18.txt"

CSV_DIRECTORY = r"C:\Users\ksand\Documents\VisualStudioProjects\FAA_DATA_HANDLER\000_tempResources\CIFP\CH4_RECORD_LAYOUTS"


# Records where the subsection code is checked at index 12.
SUBSECTION_AT_INDEX_12 = {
    ("H", "D"),
    ("P", "A"),
    ("H", "A"),
    ("P", "G"),
    ("P", "I"),
    ("P", "P"),
    ("P", "S"),
    ("H", "S"),
    ("P", "C"),
    ("H", "C"),
    ("P", "D"),
    ("P", "E"),
    ("P", "F"),
    ("H", "F"),
}

# Records where the subsection code is checked at index 5.
SUBSECTION_AT_INDEX_5 = {
    ("D", " "),
    ("D", "B"),
    ("P", "N"),
    ("E", "A"),
    ("E", "R"),
    ("U", "C"),
    ("U", "R"),
    ("A", "S"),
}


def get_section_codes_from_filename(filename):
    """
    Gets the section/subsection code from the CSV filename.

    Example:
    4.1.10.1 Runway (Runways-PG).csv

    Returns:
    SectionCode = P
    SubSectionCode = G
    """

    basename = os.path.basename(filename)

    match = re.search(r"\(([^()]*)\)\.csv$", basename, re.IGNORECASE)

    if not match:
        return None

    parenthesis_text = match.group(1)

    if "-" not in parenthesis_text:
        return None

    code = parenthesis_text.rsplit("-", 1)[1].strip()

    if len(code) < 1 or len(code) > 2:
        return None

    section_code = code[0]
    subsection_code = code[1] if len(code) == 2 else " "

    return section_code, subsection_code


def get_subsection_index(section_code, subsection_code):
    key = (section_code, subsection_code)

    if key in SUBSECTION_AT_INDEX_12:
        return 12

    if key in SUBSECTION_AT_INDEX_5:
        return 5

    if section_code in ("P", "H"):
        return 12

    return 5


def line_matches_section(line, section_code, subsection_code):
    # Same line padding style as your current working script.
    line = line.rstrip("\n") + " " * (13 - len(line))

    idx4 = line[4]

    if idx4 != section_code:
        return False

    subsection_index = get_subsection_index(section_code, subsection_code)

    return line[subsection_index] == subsection_code


def get_csv_field_specs(user_defined_field_id):
    field_specs = []

    csv_search_path = os.path.join(CSV_DIRECTORY, "*.csv")

    for csv_filename in glob.glob(csv_search_path):
        section_codes = get_section_codes_from_filename(csv_filename)

        if section_codes is None:
            continue

        section_code, subsection_code = section_codes

        with open(csv_filename, "r", newline="", encoding="utf-8-sig") as csvfile:
            reader = csv.DictReader(csvfile)

            for row in reader:
                field_id = row.get("FieldId", "").strip()

                if field_id == user_defined_field_id:
                    start_index = int(row["StartIndex"])
                    field_length = int(row["FieldLength"])

                    field_specs.append({
                        "CsvFile": csv_filename,
                        "SectionCode": section_code,
                        "SubSectionCode": subsection_code,
                        "StartIndex": start_index,
                        "FieldLength": field_length,
                    })

    return field_specs


def main():
    user_defined_field_id = input("Enter FieldId: ").strip()

    field_specs = get_csv_field_specs(user_defined_field_id)

    if not field_specs:
        print()
        print(f"No CSV rows found for FieldId: {user_defined_field_id}")
        return

    unique_values = []
    seen_values = set()

    with open(INPUT_FILENAME, "r") as infile:
        for line in infile:
            for spec in field_specs:
                section_code = spec["SectionCode"]
                subsection_code = spec["SubSectionCode"]

                if not line_matches_section(line, section_code, subsection_code):
                    continue

                start_index = spec["StartIndex"]
                field_length = spec["FieldLength"]
                end_index = start_index + field_length

                working_line = line.rstrip("\n")

                if len(working_line) < end_index:
                    working_line = working_line + " " * (end_index - len(working_line))

                value = working_line[start_index:end_index]

                # Replace every digit with # before checking uniqueness.
                value = re.sub(r"\d", "#", value)

                if value not in seen_values:
                    seen_values.add(value)
                    unique_values.append(value)

    print()
    print("Matched CSV definitions:")
    for value in unique_values:
        print(f"\t`{value}`")


if __name__ == "__main__":
    main()