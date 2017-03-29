using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextRe : MonoBehaviour, IPointerDownHandler
{

    //public Text text;
    //public string key;
    public GameObject prefab;
	// Use this for initialization
	void Start () {
        //text.supportRichText = true;
        //text.text = text.text.Replace(key, "<color=blue>"+ key+ "</color>");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Drag start");
        GameObject s = Instantiate(prefab);
        s.GetComponent<Text>().supportRichText = GetComponent<Text>().supportRichText;
        s.GetComponent<Text>().text = GetComponent<Text>().text;
        s.GetComponent<Text>().fontSize = GetComponent<Text>().fontSize;
        s.GetComponent<Text>().color = new Color(s.GetComponent<Text>().color.r, s.GetComponent<Text>().color.g, s.GetComponent<Text>().color.b, s.GetComponent<Text>().color.a *0.5f);
        s.transform.parent = transform.parent;
    }
}
