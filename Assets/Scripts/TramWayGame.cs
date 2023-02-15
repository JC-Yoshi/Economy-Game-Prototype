using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TramWayGame : MonoBehaviour
{
    public Text budgetText;
    public double budget;


    private float timeRemaining;
    private float timerMax;
    public Slider slider;

    public void Start()
    {
        budget = 100;
    }

    public void Update()
    {
        //bugdet text
        budgetText.text = "Budget: " + budget;

        //timer
        slider.value = CalculateSliderValue();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }

        else if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);
    }

    public void Click()
    {
        if (timeRemaining < 0)
        {
            timerMax = 5f;
        }
    }
}
    