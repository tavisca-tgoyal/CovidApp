using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{

    public class DataModel
    {
        public Raw_Data[] raw_data { get; set; }
    }

    public class Raw_Data
    {
        public string agebracket { get; set; }
        public string backupnotes { get; set; }
        public string contractedfromwhichpatientsuspected { get; set; }
        public string currentstatus { get; set; }
        public string dateannounced { get; set; }
        public string detectedcity { get; set; }
        public string detecteddistrict { get; set; }
        public string detectedstate { get; set; }
        public string estimatedonsetdate { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public string notes { get; set; }
        public string patientnumber { get; set; }
        public string source1 { get; set; }
        public string source2 { get; set; }
        public string source3 { get; set; }
        public string statecode { get; set; }
        public string statepatientnumber { get; set; }
        public string statuschangedate { get; set; }
        public string typeoftransmission { get; set; }
    }

}
