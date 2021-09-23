using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    int hour_ = 0;
    int minute_ = 0;
    int seconde_ = 0;

    private Text textClock;
    private float delta_time;
    private bool stop_clock_ = false;

    public static Clock instance;

    private void Awake()
    {
        if(instance)
            Destroy(instance);

        instance = this;
        textClock = GetComponent<Text>();
        delta_time = PlayerPrefs.GetFloat("Chrono", 1);      
    }
    // Start is called before the first frame update
    void Start()
    {
        stop_clock_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop_clock_ == false)
        {
            delta_time += Time.deltaTime;
            PlayerPrefs.SetFloat("Chrono", delta_time);
            TimeSpan span = TimeSpan.FromSeconds(delta_time);

            string hour = LeadingZero(span.Hours);
            string minute = LeadingZero(span.Minutes);
            string seconds = LeadingZero(span.Seconds);

            textClock.text = hour + ":" + minute + ":" + seconds;
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

    public void OnGameOver()
    {
        stop_clock_ = true;
        PlayerPrefs.SetFloat("Chrono", 0);
    }

    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
    }

    public Text GetCurrentTimeText()
    {
        return textClock;
    }
}
