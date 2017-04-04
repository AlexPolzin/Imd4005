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
    public GameObject UITextBox;
    public GameObject notificationBox;
    public GameObject prefab;

    private GameObject playerGO;
    private bool activeEvent;
    private GameObject UIGO;
    private int evType;
    public GameObject[] textOBJList;

    [HideInInspector]
    public List<EventDev.Events> currentEvent;
    public List<GameObject> winy;

    private Vector3 sScale;
    private bool triggered = false;
    private Vector3 notice;
    private float timeL = 2f;

    
    string name;
    string info;

    //public Text[] textBox;
    void Start () {
        notice = test.transform.position;
        sScale = test.transform.localScale;
        test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        playerGO = GameObject.FindGameObjectWithTag("Player");
        activeEvent = false;
        UITextBox.SetActive(false);
        UIGO = GameObject.FindGameObjectWithTag("UIElement");
        notificationBox.SetActive(false);

        if (this.gameObject.tag == "Phone")
            evType = 1;

        if (this.gameObject.tag == "Tweet")
            evType = 2;

        if (this.gameObject.tag == "Radio")
            evType = 3;

        for (int i = 0; i < textOBJList.Length; i++)
            textOBJList[i].SetActive(false);
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
        else
            currentEvent.Insert(0, c);

        triggered = true;
        test.transform.position = notice;
        test.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        timeL = timer;
        notificationBox.SetActive(true);

        name = c.name;
        info = c.words;
    }
    public void display()
    {
        UITextBox.SetActive(true);
        //playerGO.GetComponent<PlayerMovment>().PlayerMove = false;
        activeEvent = true;
        UIGO.GetComponent<timer>().timerEnb = false;
        notificationBox.SetActive(false);

        winy.Add(place());
    }
    GameObject place()
    {
        GameObject s = Instantiate(prefab);
        s.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        s.GetComponent<Notepad>().AddNote(currentEvent[currentEvent.Count - 1]);
        return s;
    }
    public void end()
    {
        Debug.Log("asdf");
        foreach(GameObject i in winy)
        {
            
            Destroy(i);
        }
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && triggered)
        {
            other.GetComponent<PlayerMovment>().Touch(this);
            
            /*for (int i = 0; i < textOBJList.Length; i++)
                textOBJList[i].SetActive(true);

            if(evType == 1)
            {
                textOBJList[0].GetComponent<Text>().text = name;
                textOBJList[1].GetComponent<Text>().text = info;
            }*/
            
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
