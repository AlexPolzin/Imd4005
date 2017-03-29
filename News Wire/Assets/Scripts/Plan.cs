using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using EventDev;

public class Plan : MonoBehaviour {

    //[Serializable]
    public List<Sprite> images;
    public List<EventDev.Events> timeline;

    public float filler = 0f;

	// Use this for initialization
	void Start () {
        // evnet id || time of event|| event machine || message || name of message sender || key words || score affector || ( bonus ) linked event / images 
        timeline.Add(new EventDev.Events(1,2f, "Phone", "this is and event", "Mr. Phone",new string[] { " is " }, 0f));
        timeline.Add(new EventDev.Events(2,3f, "Radio", "this is and event2", "Mr. Radio", new string[] { " and " }, 0f));
        timeline.Add(new EventDev.Events(3,4f, "Tweet", "this is and event3", "Mr. Tweet", new string[] { " event " }, 0f, images[0]));
        timeline.Add(new EventDev.Events(4,6f, "Phone", "phone 2", "Mr. Phone", new string[] { " is " }, 0f));
        timeline.Add(new EventDev.Events(5,7f, "Radio", "radio 2", "Mr. Radio", new string[] { " and " }, 0f));
        timeline.Add(new EventDev.Events(6,8f, "Tweet", "tweet 2", "Mr. Tweet", new string[] { " event " }, 0f, images[0]));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
