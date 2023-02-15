using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeRemaining;
    private float timerMax = 5f;
    public Slider slider;
    public State timerComplete;


    public void Update()
    {
        //timer

        slider.value = CalculateSliderValue();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            //State timercomplete = true;
            
            
        }

        if (timeRemaining < 0)
        {
            timerMax = 5f;
        }

        else if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void Click()
    {
        timeRemaining = timerMax;
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);
    }

}
