using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const int hoursInADay = 24;

    public const int minutesInAnHour = 60;

    //seconds of real life time
    public float dayDuration = 30f;
    
    //all time that has passed since this script starts
    public float totalTime = 0;

    //keeps track of time that has passed in the current day in game
    public float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime = totalTime + Time.deltaTime;
        currentTime = totalTime % dayDuration;
    }

    public float GetHour()
    {
        //gets current hour as a float
        return currentTime * hoursInADay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInADay * minutesInAnHour / dayDuration)%minutesInAnHour;
    }

    public string Clock24Hour()
    {
        //00:00
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public string BackwardsClock24Hour()
    {
        return Mathf.FloorToInt(GetHour() - currentTime).ToString("00") + ":" +
               Mathf.FloorToInt(GetMinutes() - currentTime % minutesInAnHour).ToString("00");
        //return Mathf.FloorToInt(GetHour()-totalTime).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(GetHour());
        string abbreviation = "AM";

        if (hour >= 12)
        {
            abbreviation = "PM";
            hour -= 12;
        }

        if (hour == 0)
        {
            hour = 12;
        }

        return hour.ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + " " + abbreviation;
    }
}
