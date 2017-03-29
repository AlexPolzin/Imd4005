using UnityEngine;
using System.Collections;
using EventDev;
public class TriggerObj : MonoBehaviour {

    public GameObject test;
    public float speed = 0.5f;
    public bool shake = true;
    public float timer = 3f;

    [HideInInspector]
    public EventDev.Events currentEvent;


    private Vector3 sScale;
    private bool triggered = false;
    private Vector3 notice;
    private float timeL = 2f;
    void Start () {
        notice = test.transform.position;
        sScale = test.transform.localScale;
        test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (triggered == true && currentEvent!= null)
        {
            activated();
        }
        else
        {
            test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        timeL -= Time.deltaTime;
        if (timeL <= 0)
            triggered = false;
	}
    void activated()
    {
        test.transform.position = new Vector3(test.transform.position.x, test.transform.position.y + speed * Time.deltaTime, test.transform.position.z);
        if (timeL <= timer / 2)
        {
            test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, test.GetComponent<SpriteRenderer>().color.a - Time.deltaTime);
        }
        if (shake == true)
        {
            test.transform.rotation = new Quaternion(0, 0, Mathf.Sin(Time.time * 16) / 4, test.transform.rotation.w);
        }
        else
        {
            test.transform.localScale = new Vector3(sScale.x + Mathf.Sin(Time.time * 16) / 16, sScale.x + Mathf.Sin(Time.time * 16) / 16, sScale.z);
        }
        
    }
    public void NewEvent(EventDev.Events c)
    {
        currentEvent = c;
        triggered = true;
        test.transform.position = notice;
        test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        timeL = timer;
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
