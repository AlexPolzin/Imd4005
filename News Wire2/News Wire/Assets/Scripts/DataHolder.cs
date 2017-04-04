using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour {

    public List<EventDev.Events> Answers;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void NewEvent(EventDev.Events c)
    {
        Answers.Add(c);
    }
}
