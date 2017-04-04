using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{


    public GameObject sunDisplay;
    public GameObject monDisplay;
    public GameObject timeDot;
    public GameObject nightGO;

    public float daySpeed;
    public float startDarkAt;

    public float curTimer;
    private float startDark;

    public bool timerEnb;

    private Vector3 sunPos;
    private Vector3 moonPos;
    private Vector3 timerPos;

    private Vector3 totalChange;
    private Vector3 rateChange;

    private Color darkCol;

    private float DRateofChange;
    private float darkTimer;

    // Use this for initialization
    void Start()
    {
        curTimer = 0.0f;
        timerEnb = true;

        sunPos = sunDisplay.transform.position;
        moonPos = monDisplay.transform.position;
        timerPos = timeDot.transform.position;

        totalChange = moonPos - sunPos;

        rateChange = new Vector3(Time.deltaTime / daySpeed * totalChange[0], Time.deltaTime / daySpeed * totalChange[1], Time.deltaTime / daySpeed * totalChange[2]);

        startDark = daySpeed * startDarkAt;
        darkTimer = daySpeed - startDark;


        DRateofChange = Time.deltaTime / darkTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //print(rateChange);
        if (timerEnb)
        {
            timerPos += (rateChange);
            timeDot.transform.position = timerPos;

            if (curTimer >= startDark)
            {
                nightGO.GetComponent<SpriteRenderer>().color += new Color(0.0f, 0.0f, 0.0f, DRateofChange);
            }
            curTimer += Time.deltaTime;

            if (curTimer > daySpeed)
            {
                timerEnb = false;
            }
        }



    }
}
