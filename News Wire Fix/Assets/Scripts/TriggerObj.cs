using UnityEngine;
using System.Collections;
using EventDev;
public class TriggerObj : MonoBehaviour {

    public GameObject test;
    [HideInInspector]
    public EventDev.Events currentEvent;
    private bool triggered = false;
    private Vector3 notice;
    void Start () {
        notice = test.transform.position;
        test.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (triggered == true)
        {
            
            activated();
        }
        else
        {
            test.GetComponent<SpriteRenderer>().enabled = false;
        }
	}
    void activated()
    {
        test.GetComponent<SpriteRenderer>().enabled = true;
        test.transform.position = new Vector3(test.transform.position.x, test.transform.position.y + 0.5f, test.transform.position.z);
    }
    public void NewEvent(EventDev.Events c)
    {
        currentEvent = c;
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovment>().Touch(this);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovment>().Leave();
        }
    }
}
