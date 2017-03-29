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

        timeline.Add(new EventDev.Events(2f, "Phone", "this is and event", "Mr. Phone",new string[] { " is " }, 0f));
        timeline.Add(new EventDev.Events(3f, "Radio", "this is and event2", "Mr. Radio", new string[] { " and " }, 0f));
        timeline.Add(new EventDev.Events(4f, "Tweet", "this is and event3", "Mr. Tweet", new string[] { " event " }, 0f, images[0]));
        timeline.Add(new EventDev.Events(6f, "Phone", "phone 2", "Mr. Phone", new string[] { " is " }, 0f));
        timeline.Add(new EventDev.Events(7f, "Radio", "radio 2", "Mr. Radio", new string[] { " and " }, 0f));
        timeline.Add(new EventDev.Events(8f, "Tweet", "tweet 2", "Mr. Tweet", new string[] { " event " }, 0f, images[0]));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
