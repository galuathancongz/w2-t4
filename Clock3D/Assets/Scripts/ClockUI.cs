using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour {

    public bool tickMode;

    private Transform hourHandTransform;
    private Transform minuteHandTransform;
    private Transform secondHandTransform;

    private float hour;
    private float minute;
    private float second;
    private float tick;
    private DateTime timeCheck;

    private void Awake() {
        hourHandTransform = transform .Find("HourHand");
        minuteHandTransform = transform.Find("MinuteHand");
        secondHandTransform = transform.Find("SecondHand");
    }


    // Start is called before the first frame update
    void Start() {
        timeCheck = DateTime.Now;
        tick = timeCheck.Ticks;
        second = timeCheck.Second;
        minute = timeCheck.Minute;
        hour = timeCheck.Hour % 12;
        secondHandTransform.eulerAngles = new Vector3(0, 0, -(second / 60) * 360f);
        minuteHandTransform.eulerAngles = new Vector3(0, 0, -(minute / 60) * 360f);
        hourHandTransform.eulerAngles = new Vector3(0, 0, -(hour / 12 + minute / 720) * 360f);
    }

    // Update is called once per frame
    void Update() {
        timeCheck = DateTime.Now;
        tick = timeCheck.Ticks;
        if (tickMode) {
            if (second != timeCheck.Second) {
                second = timeCheck.Second;
                secondHandTransform.eulerAngles = new Vector3(0, 0, -(second / 60) * 360f);
                if (minute != timeCheck.Minute) {
                    minute = timeCheck.Minute;
                    minuteHandTransform.eulerAngles = new Vector3(0, 0, -(minute / 60) * 360f);
                    hourHandTransform.eulerAngles = new Vector3(0, 0, -(hour / 12 + minute / 720) * 360f);
                }
            }
        }
        else {
            if (tick != timeCheck.Ticks) {
                secondHandTransform.eulerAngles = new Vector3(0, 0, -(second / 60 + tick / 6000) * 360f);
                if (second != timeCheck.Second) {
                    minuteHandTransform.eulerAngles = new Vector3(0, 0, -(minute / 60) * 360f);
                    if (minute != timeCheck.Minute) {
                        hourHandTransform.eulerAngles = new Vector3(0, 0, -(hour / 12 + minute / 720) * 360f);
                    }
                }
            }
            
        }

    }
}
