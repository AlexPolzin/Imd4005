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
        public string name = "";
        public string[] keywords;
        public Sprite img;
        public Events(float aTime, string aF, string aText, string nf, string[] kf, float sf,Sprite imgf)
        {
            time = aTime;
            words = aText;
            keywords = kf;
            function = aF;
            score = sf;
            name = nf;
            img = imgf;
        }
        public Events(float aTime, string aF, string aText, string nf, string[] kf, float sf)
        {
            time = aTime;
            words = aText;
            keywords = kf;
            function = aF;
            score = sf;
            name = nf;
        }


    }
}
