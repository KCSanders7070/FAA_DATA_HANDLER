# FAA_DATA_HANDLER

**FAA_DATA_HANDLER** is a C# library designed to parse and manage a variety of FAA-provided aeronautical data formats. Built with performance, clarity, and future extensibility in mind, this tool focuses on converting raw federal datasets into structured, usable data models for integration into larger systems such as **FE-Buddy v3.0**.

---

## Supported Data Formats

This handler will support the following FAA data sources:

- **NASR CSV Files** – Standard FAA National Airspace System Resources CSV exports.
- **NASR SHAPE Files** – Geographic data provided in ESRI shapefile format.
- **CIFP** – Coded Instrument Flight Procedures datasets.
- **d-TPP MetaFile** – Terminal Procedures Publication metadata used for chart integration.

---

## Status

> This repository is in active development. Code and Structure are subject to change.

---

## Roadmap

- [x] NASR CSV parsing complete and tested
- [ ] SHAPE file extraction and geometry modeling
- [x] CIFP section decoding
- [ ] d-TPP MetaFile indexing
