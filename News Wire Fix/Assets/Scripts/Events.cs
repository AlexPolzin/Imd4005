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
        public string function = "";
        public float score = 0f;
        public Events(float aTime, string aText, string aF, float sf)
        {
            time = aTime;
            words = aText;
            function = aF;
            score = sf;
        }
        
        
    }
}
