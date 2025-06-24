# FAA_DATA_HANDLER

**FAA_DATA_HANDLER** is a C# library designed to parse and manage a variety of FAA-provided aeronautical data formats. Built with performance, clarity, and future extensibility in mind, this tool focuses on converting raw federal datasets into structured, usable data models for integration into larger systems such as **FE-Buddy v3.0**.

---

## Supported Data Formats

This handler will support the following FAA data sources:

- **NASR CSV Files** – Standard FAA National Airspace System Resources CSV exports.
- **NASR AXIM Files** – Support for both AXIM 5.0 and 5.1 specifications.
- **NASR SHAPE Files** – Geographic data provided in ESRI shapefile format.
- **CIFP** – Coded Instrument Flight Procedures datasets.
- **d-TPP MetaFile** – Terminal Procedures Publication metadata used for chart integration.

---

## Status

> This repository is in active development. Code and Structure are subject to change.

---

## Roadmap

- [ ] NASR CSV parsing complete and tested
- [ ] AXIM v5.0 / v5.1 schema support
- [ ] SHAPE file extraction and geometry modeling
- [ ] CIFP section decoding
- [ ] d-TPP MetaFile indexing
- [ ] Transfer project to FE-Buddy v3.0 development repo
