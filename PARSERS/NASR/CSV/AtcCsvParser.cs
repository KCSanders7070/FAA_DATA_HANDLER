﻿using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.AtcDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class AtcCsvParser
    {
        public AtcDataCollection ParseAtcAtis(string filePath)
        {
            var result = new AtcDataCollection();

            result.AtcAtis = FebCsvHelper.ProcessLines(
                filePath,
                fields => new AtcAtis
                {
                    EffDate = fields["EFF_DATE"],
                    SiteNo = fields["SITE_NO"],
                    SiteTypeCode = fields["SITE_TYPE_CODE"],
                    FacilityType = fields["FACILITY_TYPE"],
                    StateCode = fields["STATE_CODE"],
                    FacilityId = fields["FACILITY_ID"],
                    City = fields["CITY"],
                    CountryCode = fields["COUNTRY_CODE"],
                    AtisNo = FebCsvHelper.ParseInt(fields["ATIS_NO"]),
                    Description = fields["DESCRIPTION"],
                    AtisHrs = fields["ATIS_HRS"],
                    AtisPhoneNo = fields["ATIS_PHONE_NO"],
                });

            return result;
        }

        public AtcDataCollection ParseAtcBase(string filePath)
        {
            var result = new AtcDataCollection();

            result.AtcBase = FebCsvHelper.ProcessLines(
                filePath,
                fields => new AtcBase
                {
                    EffDate = fields["EFF_DATE"],
                    SiteNo = fields["SITE_NO"],
                    SiteTypeCode = fields["SITE_TYPE_CODE"],
                    FacilityType = fields["FACILITY_TYPE"],
                    StateCode = fields["STATE_CODE"],
                    FacilityId = fields["FACILITY_ID"],
                    City = fields["CITY"],
                    CountryCode = fields["COUNTRY_CODE"],
                    IcaoId = fields["ICAO_ID"],
                    FacilityName = fields["FACILITY_NAME"],
                    RegionCode = fields["REGION_CODE"],
                    TwrOperatorCode = fields["TWR_OPERATOR_CODE"],
                    TwrCall = fields["TWR_CALL"],
                    TwrHrs = fields["TWR_HRS"],
                    PrimaryApchRadioCall = fields["PRIMARY_APCH_RADIO_CALL"],
                    ApchPProvider = fields["APCH_P_PROVIDER"],
                    ApchPProvTypeCd = fields["APCH_P_PROV_TYPE_CD"],
                    SecondaryApchRadioCall = fields["SECONDARY_APCH_RADIO_CALL"],
                    ApchSProvider = fields["APCH_S_PROVIDER"],
                    ApchSProvTypeCd = fields["APCH_S_PROV_TYPE_CD"],
                    PrimaryDepRadioCall = fields["PRIMARY_DEP_RADIO_CALL"],
                    DepPProvider = fields["DEP_P_PROVIDER"],
                    DepPProvTypeCd = fields["DEP_P_PROV_TYPE_CD"],
                    SecondaryDepRadioCall = fields["SECONDARY_DEP_RADIO_CALL"],
                    DepSProvider = fields["DEP_S_PROVIDER"],
                    DepSProvTypeCd = fields["DEP_S_PROV_TYPE_CD"],
                    CtlFacApchDepCalls = fields["CTL_FAC_APCH_DEP_CALLS"],
                    ApchDepOperCode = fields["APCH_DEP_OPER_CODE"],
                    CtlPrvdingHrs = fields["CTL_PRVDING_HRS"],
                    SecondaryCtlPrvdingHrs = fields["SECONDARY_CTL_PRVDING_HRS"],
                });

            return result;
        }

        public AtcDataCollection ParseAtcRmk(string filePath)
        {
            var result = new AtcDataCollection();

            result.AtcRmk = FebCsvHelper.ProcessLines(
                filePath,
                fields => new AtcRmk
                {
                    EffDate = fields["EFF_DATE"],
                    SiteNo = fields["SITE_NO"],
                    SiteTypeCode = fields["SITE_TYPE_CODE"],
                    FacilityType = fields["FACILITY_TYPE"],
                    StateCode = fields["STATE_CODE"],
                    FacilityId = fields["FACILITY_ID"],
                    City = fields["CITY"],
                    CountryCode = fields["COUNTRY_CODE"],
                    LegacyElementNumber = fields["LEGACY_ELEMENT_NUMBER"],
                    TabName = fields["TAB_NAME"],
                    RefColName = fields["REF_COL_NAME"],
                    RemarkNo = FebCsvHelper.ParseInt(fields["REMARK_NO"]),
                    Remark = fields["REMARK"],
                });

            return result;
        }

        public AtcDataCollection ParseAtcSvc(string filePath)
        {
            var result = new AtcDataCollection();

            result.AtcSvc = FebCsvHelper.ProcessLines(
                filePath,
                fields => new AtcSvc
                {
                    EffDate = fields["EFF_DATE"],
                    SiteNo = fields["SITE_NO"],
                    SiteTypeCode = fields["SITE_TYPE_CODE"],
                    FacilityType = fields["FACILITY_TYPE"],
                    StateCode = fields["STATE_CODE"],
                    FacilityId = fields["FACILITY_ID"],
                    City = fields["CITY"],
                    CountryCode = fields["COUNTRY_CODE"],
                    CtlSvc = fields["CTL_SVC"],
                });

            return result;
        }

    }

    public class AtcDataCollection
    {
        public List<AtcAtis> AtcAtis { get; set; } = new();
        public List<AtcBase> AtcBase { get; set; } = new();
        public List<AtcRmk> AtcRmk { get; set; } = new();
        public List<AtcSvc> AtcSvc { get; set; } = new();
    }
}