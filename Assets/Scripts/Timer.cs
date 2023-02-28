using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TramWayGame gameManager;

    //Timer
    [SerializeField] public float timeRemaining;
    [SerializeField] private float TimerMax;
    [SerializeField] private float TimerMaxDefault;
    [SerializeField] private Slider Timerslider;
    [SerializeField] Text TimerText;
    [SerializeField] Timer timer;
        //Route for timer
    [SerializeField] private Button RouteBeginButton;
    public bool running = false;

    //Manager
    [SerializeField] private Button managerButton;
    public bool manager = false;

    //Purchase Buses
    [SerializeField] private double busCost;
    [SerializeField] private double busCostDefault;
    [SerializeField] private double busUpkeep;
    [SerializeField] private double busUpkeepDefault;
    [SerializeField] private float numberbuses;
    [SerializeField] private Slider BusNumslider;
    float previousvalue;

    private bool Extrabus = false;
    


    //Money or Income
    public Text BudgetText;
    [SerializeField] double money;            //income
    [SerializeField] double moneyformanager;  //once off purchase
    [SerializeField] double moneyfordriver;   //Manager Upkeep

    //Ongoing Bools
    
    


    public void Start()
    {
        TimerMaxDefault = TimerMax;
        busCostDefault = busCost;
        busUpkeepDefault = busUpkeep;
        previousvalue = BusNumslider.value;
        numberbuses = Timerslider.value;
        timeRemaining = TimerMax;
    }
    public void Update()
    {
        //timer
        Timerslider.value = CalculateSliderValue();
        
        //Time countdown 

        int minutes = (int)timeRemaining / 60;
        int seconds = (int)timeRemaining % 60;

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        TimerText.text = timeString;
        //Debug.Log(timeString);

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
            RouteBeginButton.interactable = false; 
        }

        if (running == false)
        {
            RouteBeginButton.interactable = true;
        }

        if (BusNumslider.value == 1)
        {
            numberbuses = (BusNumslider.value);
            TimerMax = TimerMaxDefault;
            busCost = busCostDefault;
            
        }
    }


    //Route Begin
    public void RouteClick()
    {
        running = true;
        //Bus Route
        if (Extrabus == true)
        {
            //timer.TimerMax --;
            gameManager.initialbudget -= busUpkeep;

        }

        else if (gameManager.initialbudget < busUpkeep)
        {
            Extrabus = false;
            BusNumslider.value = 1;
        }
          
    }

    //timer slider value
    float CalculateSliderValue()
    {
        return (timeRemaining / TimerMax);
    }

    //manager button click
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
            managerButton.interactable = false;
            RouteClick();

        }

    }

    //Buses Slider Values
    public void BusSlider()
    {
        if (previousvalue < BusNumslider.value && BusNumslider.value != 1)
        {
            if (gameManager.initialbudget >= busCost)
            {
                TimerMax += (previousvalue - BusNumslider.value);
                numberbuses = (BusNumslider.value);
                busUpkeep *= numberbuses;
                gameManager.initialbudget -= busCost;
                Extrabus = true;
            }


            else if (gameManager.initialbudget < busCost)
            {
                Extrabus = false;
            }
        }




            if (previousvalue > BusNumslider.value && BusNumslider.value != 1)
            {
                if (gameManager.initialbudget >= busCost)
                {
                
                    TimerMax += (previousvalue - BusNumslider.value);
                    numberbuses = (BusNumslider.value);
                    busCost /= numberbuses;
                    gameManager.initialbudget -= busCost;
                    Extrabus = true;
                    
                }

                else if (gameManager.initialbudget < busUpkeep)
                {
                    Extrabus = false;
                    busUpkeep = busUpkeepDefault;
                    BusNumslider.value = 1;
                }
            }
            
            previousvalue = BusNumslider.value;
        

    }
}
