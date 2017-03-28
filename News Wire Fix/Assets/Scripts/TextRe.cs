using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRe : MonoBehaviour {

    public Text text;
    public string key;
	// Use this for initialization
	void Start () {
        text.supportRichText = true;
        text.text = text.text.Replace(key, "<color=blue>"+ key+ "</color>");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
