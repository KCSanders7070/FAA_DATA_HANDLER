import csv
from pathlib import Path


OUTPUT_FILE = "out.txt"


def main() -> None:
    csv_files = sorted(
        Path.cwd().glob("*.csv"),
        key=lambda path: path.name.lower(),
    )

    if not csv_files:
        print("No .csv files were found in the current directory.")
        return

    field_ids: list[str] = []

    for csv_path in csv_files:
        try:
            with csv_path.open(
                "r",
                encoding="utf-8-sig",
                newline="",
            ) as csv_file:
                reader = csv.DictReader(csv_file)

                if not reader.fieldnames or "FieldId" not in reader.fieldnames:
                    print(
                        f'Skipping "{csv_path.name}": '
                        'missing the "FieldId" column.'
                    )
                    continue

                for row in reader:
                    # FieldId remains a string. Duplicate values are retained.
                    field_id = (row.get("FieldId") or "").strip()

                    if not field_id:
                        continue

                    field_ids.append(field_id)

        except (OSError, UnicodeError, csv.Error) as error:
            print(f'Could not read "{csv_path.name}": {error}')

    output_path = Path.cwd() / OUTPUT_FILE

    with output_path.open(
        "w",
        encoding="utf-8",
        newline="\n",
    ) as output_file:
        for field_id in field_ids:
            output_file.write(field_id + "\n")

    print(
        f'Wrote {len(field_ids)} FieldId values '
        f'to "{OUTPUT_FILE}".'
    )


if __name__ == "__main__":
    main()