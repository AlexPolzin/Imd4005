using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using EventDev;

public class Plan : MonoBehaviour {

    //[Serializable]
    public List<EventDev.Events> timeline;

    public float filler = 0f;

	// Use this for initialization
	void Start () {

        timeline.Add(new EventDev.Events(2f, "this is and event", "Phone",0f));
        timeline.Add(new EventDev.Events(3f, "this is and event2", "Radio", 0f));
        timeline.Add(new EventDev.Events(4f, "this is and event3", "Tweet", 0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
