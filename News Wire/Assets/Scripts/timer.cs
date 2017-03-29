using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {


    public Slider timerSlider;
    public GameObject startOB;
    public GameObject stopOB;

    public float daySpeed;

    private bool startBool;
    private bool endBool;

    // Use this for initialization
    void Start () {
        startOB.SetActive(true);
        stopOB.SetActive(false);

        startBool = endBool = false;

    }
	
	// Update is called once per frame
	void Update () {

        if(!startBool)
        {
            if (Input.anyKey)
            {
                startOB.SetActive(false);
                startBool = true;
            }
        }

        if (startBool && !endBool)
        {
            if (timerSlider.value < 1)
            {
                timerSlider.value += daySpeed;
            }
            else
            {
                endBool = true;
                stopOB.SetActive(true);
            }
        }

        

    }
}
