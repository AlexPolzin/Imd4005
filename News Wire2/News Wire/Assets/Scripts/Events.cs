using UnityEngine;
using System.Collections;
using System;

namespace EventDev
{
    [Serializable]
    public class Events
    {
        public int id;
        public float time = 100000000000f;
        public string words = "";
        public string function = "";
        public float score = 0f;
        public string name = "";
        public string[] keywords;
        public Sprite img;
        public int missing;
        public Events(int idf, float aTime, string aF, string aText, string nf, string[] kf, float sf,Sprite imgf)
        {
            id = idf;
            time = aTime;
            words = aText;
            keywords = kf;
            function = aF;
            score = sf;
            name = nf;
            img = imgf;
        }
        public Events(int idf, float aTime, string aF, string aText, string nf, string[] kf, float sf)
        {
            id = idf;
            time = aTime;
            words = aText;
            keywords = kf;
            function = aF;
            score = sf;
            name = nf;
        }
        public Events(int idf, float aTime, string aF, string aText, string nf, string[] kf, float sf, int mf)
        {
            id = idf;
            time = aTime;
            words = aText;
            keywords = kf;
            function = aF;
            score = sf;
            name = nf;
            missing = mf;
        }
        public Events(int idf, float aTime, string aF, string aText, string nf, string[] kf, float sf, int mf, Sprite imgf)
        {
            id = idf;
            time = aTime;
            words = aText;
            keywords = kf;
            function = aF;
            score = sf;
            name = nf;
            missing = mf;
            img = imgf;
        }



    }
}
