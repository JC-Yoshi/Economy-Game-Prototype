using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining;
    [SerializeField] private float TimerMax;
    [SerializeField] private Slider slider;
    private State timerComplete;

    [SerializeField] TramWayGame gameManager;

    public Text BudgetText;
    public double money;
    public bool running = false;

    public bool manager = false;

    public void Start()
    {
        timeRemaining = TimerMax;
    }
    public void Update()
    {
        //timer
        slider.value = CalculateSliderValue();

        if (timeRemaining <= 0)
        {
            money = 20;
            gameManager.initialbudget += money;
            running = false;
            timeRemaining = TimerMax;
        }
              
        if (timeRemaining < 0)
        {
            timeRemaining = TimerMax;
           
        }

       if (running == true)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void Click()
    {
             
        running = true;
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / TimerMax);
    }

    public void Manager()
    {

        if(manager = true)
        {
            Click();
        }
        
    }

}
