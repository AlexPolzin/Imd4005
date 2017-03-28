using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EventDev;
public class EventManager : MonoBehaviour {
    public TriggerObj phone;
    //public TriggerObj radio;
    //public TriggerObj computer;
    //public TriggerObj twitter;
    public Plan plan;


    private float timerStart;
    void Start () {
        timerStart = Time.time;
        if ((plan == null) && (GetComponent<Plan>() != null))
        {
            plan = GetComponent<Plan>();
        }
        else
        {
            Debug.LogWarning("Missing Plan component. Please add one");
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Debug.Log(plan.filler);
        List<int> arr = new List<int>();
        for (int i = 0; i < plan.timeline.Count; i++)
        { 
            if (Time.time - timerStart > plan.timeline[i].time)
            {
                phone.NewEvent(plan.timeline[i]);
                arr.Add(i);
            }
        }   
        foreach(int k in arr)
        {
            plan.timeline.RemoveAt(k);
        }
	}
}
