using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeRemaining;
    [SerializeField] private float TimerMax;
    [SerializeField] private Slider slider;
    //private State timerComplete;

    [SerializeField] TramWayGame gameManager;

    public Text BudgetText;
    [SerializeField] double money;
    [SerializeField] double moneyformanager;
    [SerializeField] double moneyfordriver;
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
            
            gameManager.initialbudget += money;
            running = false;
            timeRemaining = TimerMax;
            if (manager == true)
            {
                gameManager.initialbudget -= moneyfordriver;
                if (gameManager.initialbudget >= 0)
                {
                    RouteClick();
                }
            }
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

    public void RouteClick()
    {
        running = true;
        
        
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / TimerMax);
    }

    public void OnManagerClick()
    {
        if (gameManager.initialbudget < moneyformanager)
        {
            manager = false;
        }

        if (gameManager.initialbudget > moneyformanager)
        {
            manager = true;
            gameManager.initialbudget -= moneyformanager;
           
            RouteClick();
            

        }
        

    }

}
