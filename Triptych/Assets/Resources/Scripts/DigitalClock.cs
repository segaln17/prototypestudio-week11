using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{
    private TimeManager tm;

    public bool is24hour = true;

    public TextMeshProUGUI display;
    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is24hour)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                
                if (((tm.currentTime * 24 / tm.dayDuration) >= 3f && (tm.currentTime * 24 / tm.dayDuration) <= 6f) || (tm.currentTime * 24 / tm.dayDuration) >= 15f && (tm.currentTime * 24 / tm.dayDuration) <= 21f)
                {
                    display.text = "BUS?";
                    Debug.Log("BUS");
                }
                else
                {
                    //display.text = tm.Clock24Hour();
                    display.text = "no bus...";
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //display.text = tm.BackwardsClock24Hour();
                display.text = "-bus";
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //display.text = "bus...";
                if (tm.GetHour()==4f)
                {
                    display.text = "BUS?";
                }

                if (tm.GetHour()>=3f && tm.GetHour()<=6f)
                {
                    display.text = "another hour of waiting";
                }
                
                if (tm.GetHour()>=6f && tm.GetHour()<=9f)
                {
                    display.text = "lots of minutes of waiting";
                }
                
                if (tm.GetHour()>=9f && tm.GetHour()<=12f)
                {
                    display.text = "you've been here a long time";
                }
                
                if (tm.GetHour()>=12f && tm.GetHour()<=15f)
                {
                    display.text = "a really long time";
                }
                
                if (tm.GetHour()>=15f && tm.GetHour()<=18f)
                {
                    display.text = "the asphalt shines";
                }
                
                if (tm.GetHour()>=18f && tm.GetHour()<=21f)
                {
                    display.text = "all you can hear is the road";
                }
                
                if (tm.GetHour()>=21f && tm.GetHour()<=24f)
                {
                    display.text = "still no bus...";
                }
                
                /*
                if (tm.GetHour()==2f)
                {
                    display.text = "2 hours of waiting";
                }
                */
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                display.text = "time keeps going";
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (tm.GetMinutes()==4f)
                {
                    display.text = "BUS?";
                }
                else
                {
                    display.text = tm.Clock12Hour();
                }
            }
        }
        
    }
}
