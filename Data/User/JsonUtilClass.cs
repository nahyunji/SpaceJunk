using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe.SaveJson
{
    public class PlayerData
    {
        public int r { get; set; }
        public int l { get; set; }
        public float e { get; set; }
        public int cP{ get; set; }
        public int sS { get; set; }
        public float vB { get; set; }
        public float vS { get; set; }
        public List<int> oP { get; set; }
        public List<BuffInfo> bIs { get; set; }
        public List<DailyData> dD { get; set; }
        
        public DateTime adD;
        public int adO;

    }

    [Serializable]
    public class BuffInfo
    {
         public bool a { get; set; }
         public EZodiac z { get; set; }
         public DateTime sT { get; set; }
         public int c { get; set; }
    }

    [Serializable]
    public class DailyData
    {
         public int d { get; set; }
         public bool g { get; set; }
         public DateTime gD { get; set; }
    }


}
