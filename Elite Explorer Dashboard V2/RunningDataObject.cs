﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    public class runningDataObject
    {
        public string? CurrentEvent { get; set; }
        public string? CurrentSystem { get; set; }
        public string? TargetSystem { get; set; }
        public string? CruiseMode { get; set; }
        public string? LastSystem { get; set; }
        public string? CurrentBody { get; set; }
        public string? LastBody { get; set; }
        public int FuelLevel { get; set; }
        public double FuelScooped { get; set; }
        public double FuelScoopedTotal { get; set; }
        public string? CommanderName { get; set; }
        public string? ShipName { get; set; }
        public string? ShipType { get; set; }
        public string? ShipIdent { get; set; }
        public int CurrentLogLineNumber { get; set; }
        public string? CurrentLogFile { get; set; }
        public string? LastLogTimestamp { get; set; }
        public double FuelUsed { get; set; }
        public double TotalJumped { get; set; }
        public double TotalFuelUsed { get; set; }
        public double TotalScooped { get; set; }
        public dynamic? hugeFont { get; set; }
        public dynamic? largeFont { get; set; }
        public dynamic? mediumFont { get; set; }
        public dynamic? smallFont { get; set; }
        public bool Realtime { get; set; }

        public Dictionary<int?,string?> bodyIDToName = new Dictionary<int?,string?>();
        public Dictionary<string, int> usedParents = new Dictionary<string,int>();
        public Dictionary<string, int> materialCount = new Dictionary<string,int>();
        public Dictionary<string, int> usedBodies = new Dictionary<string, int>();

        public Dictionary<string, ScanObjectBodyDetailed> bodyDictionary = new Dictionary<string, ScanObjectBodyDetailed>();

        public Dictionary<string, string> atmosphereConversion = new Dictionary<string, string>();
        public Dictionary<string, string> materialConversion = new Dictionary<string, string>();

        public Dictionary<string, string> bodyConversion = new Dictionary<string, string>();
        public Dictionary<string, int> bodyCount = new Dictionary<string, int>();
        public Dictionary<string, int> starCount = new Dictionary<string, int>();

        public Dictionary<string, int> collectedMaterialsCount = new Dictionary<string, int>();



    }

}
