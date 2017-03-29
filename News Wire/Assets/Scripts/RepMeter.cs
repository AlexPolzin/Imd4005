using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RepMeter : MonoBehaviour {
    public float filled;
    
	// Use this for initialization
	void Start () {
	
	}
	
	
	void Update () {
        filled = Mathf.Sin(Time.time) / 2 + 0.5f;
        GetComponent<Image>().fillAmount = filled;
	}
}
