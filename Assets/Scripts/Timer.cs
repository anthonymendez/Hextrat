using System;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Stopwatch stopWatch = new Stopwatch();
    [SerializeField] private Text timerText;

    void Start() {
        timerText = GetComponent<Text>();
        startWatch();
    }

    void Update() {
        if (stopWatch.IsRunning) {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format(
                "{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            timerText.text = elapsedTime;
        }
    }

    public void startWatch() {
        stopWatch.Start();
    }

    public void restartWatch() {
        stopWatch.Restart();
    }

    public void endWatch() {
        stopWatch.Stop();
    }
}
