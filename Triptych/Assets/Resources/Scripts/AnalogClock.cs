using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    private TimeManager tm;

    public RectTransform minuteHand;
    public RectTransform hourHand;

    private const float hoursToDegrees = 360 / 12;
    private const float minutesToDegrees = 360 / 60;
    
    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            hourHand.rotation = Quaternion.Euler(0,0,-tm.GetHour()*hoursToDegrees);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            minuteHand.rotation = Quaternion.Euler(0,0, -tm.GetMinutes()*minutesToDegrees);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            minuteHand.rotation = Quaternion.Euler(0,0,tm.GetMinutes()*minutesToDegrees);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            hourHand.rotation = Quaternion.Euler(0,0,tm.GetHour()*hoursToDegrees);
        }
    }
}
