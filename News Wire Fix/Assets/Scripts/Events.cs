using UnityEngine;
using System.Collections;
using System;

namespace EventDev
{
    [Serializable]
    public class Events
    {
        public float time = 100000000000f;
        public string words = "";
        public float function = -1f;
        public Events(float aTime, string aText, float aF)
        {
            time = aTime;
            words = aText;
            function = aF;
        }
        
        
    }
}
