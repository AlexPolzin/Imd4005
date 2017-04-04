using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EventDev;
using UnityEngine.UI;
public class TriggerObj : MonoBehaviour {

    public GameObject test;
    public float speed = 0.5f;
    public bool shake = true;
    public float timer = 3f;
    public bool multi = false;
    public GameObject notificationBox;
    public GameObject prefab;
    
    private bool activeEvent;
    private GameObject UIGO;
    private GameObject Bonus;
    private int evType;

    [HideInInspector]
    public List<EventDev.Events> currentEvent;
    public List<GameObject> winy;

    private Vector3 sScale;
    private bool triggered = false;
    private Vector3 notice;
    private float timeL = 2f;


    //public Text[] textBox;
    void Start()
    {
        notice = test.transform.position;
        sScale = test.transform.localScale;
        test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        activeEvent = false;
        UIGO = GameObject.FindGameObjectWithTag("UIElement");
        if (GameObject.FindGameObjectWithTag("TB") && multi) 
        {
            Bonus = GameObject.FindGameObjectWithTag("TB");
            Bonus.SetActive(false);
        }
        notificationBox.SetActive(false);
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
        
        if (multi)
            currentEvent.Add(c);
        else {
            if (currentEvent.Count > 0)
                currentEvent[0] = c;
            else
                currentEvent.Insert(0, c); 
        }

        triggered = true;
        test.transform.position = notice;
        test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        timeL = timer;
        notificationBox.SetActive(true);
    }
    public void display()
    {
        //playerGO.GetComponent<PlayerMovment>().PlayerMove = false;
        activeEvent = true;
        UIGO.GetComponent<timer>().timerEnb = false;
        notificationBox.SetActive(false);
        if (currentEvent.Count > 0)
        {
            if (multi)
            {
                Bonus.SetActive(true);
                int j = 0;
                Debug.Log(currentEvent.Count - 1 + " " + (currentEvent.Count - 1 >= currentEvent.Count - 6 && currentEvent.Count - 1 >= 0));
                for (int i = currentEvent.Count - 1; i >= currentEvent.Count - 6 && i >= 0; i--)
                {

                    GameObject s = Instantiate(prefab);
                    s.transform.SetParent(Bonus.transform, false);
                    s.transform.position = new Vector3(s.transform.position.x, s.transform.position.y - 140 * j);
                    s.GetComponent<Notepad>().AddNote(currentEvent[i]);
                    winy.Add(s);
                    j++;
                }
            }
            else
            {

                GameObject s = Instantiate(prefab);
                s.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                s.GetComponent<Notepad>().AddNote(currentEvent[0]);
                winy.Add(s);
            }
        }
    


        
    }
    public void end()
    {
        Debug.Log("asdf");
        foreach(GameObject i in winy)
        {
            
            Destroy(i);
        }
        if (multi)
            Bonus.SetActive(false);
        else
            currentEvent.Clear();
        UIGO.GetComponent<timer>().timerEnb = true;
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (currentEvent.Count >= 0)
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
