using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeRemaining;
    [SerializeField] private float TimerMax;
    [SerializeField] private float TimerMaxDefault;
    [SerializeField] private Slider slider;
    [SerializeField] private Button managerButton;
    [SerializeField] private double busCost;
    [SerializeField] private double busCostDefault;
    [SerializeField] private double busUpkeep;
    [SerializeField] private float numberbuses;
    

    [SerializeField] private Slider BusNumslider;
    float previousvalue;
    //private GameObject bus;

    [SerializeField] Timer timer;
    [SerializeField] TramWayGame gameManager;

    private bool Extrabus = false;
    //private State timerComplete;



    public Text BudgetText;
    [SerializeField] double money;
    [SerializeField] double moneyformanager;
    [SerializeField] double moneyfordriver;
    public bool running = false;
    public bool manager = false;


    public void Start()
    {
        TimerMaxDefault = TimerMax;
        busCostDefault = busCost;
        previousvalue = BusNumslider.value;
        numberbuses = slider.value;
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

        if (BusNumslider.value == 1)
        {
            numberbuses = (BusNumslider.value);
            TimerMax = TimerMaxDefault;
            busCost = busCostDefault;
            Debug.Log("TimerMax = Default");
        }
    }

    public void RouteClick()
    {
        running = true;
        //Bus Route
        if (Extrabus == true)
        {
            //timer.TimerMax --;
            gameManager.initialbudget -= busUpkeep;

        }

        else if (gameManager.initialbudget < busCost)
        {
            Extrabus = false;

        }


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
            managerButton.interactable = false;
            RouteClick();


        }


    }
    public void BusSlider()
    {
        if (previousvalue < BusNumslider.value && BusNumslider.value != 0)
        {
            if (gameManager.initialbudget >= busCost)
            {
                TimerMax += (previousvalue - BusNumslider.value);
                numberbuses = (BusNumslider.value);
                busCost *= numberbuses;
                gameManager.initialbudget -= busCost;
                Extrabus = true;
            }


            else if (gameManager.initialbudget < busCost)
            {
                Extrabus = false;
            }
        }




            if (previousvalue > BusNumslider.value && BusNumslider.value != 0)
            {
                if (gameManager.initialbudget >= busCost)
                {
                Debug.Log("previous value > BusSliderValue");
                    TimerMax += (previousvalue - BusNumslider.value);
                    numberbuses = (BusNumslider.value);
                    busCost /= numberbuses;
                    gameManager.initialbudget -= busCost;
                    Extrabus = true;
                    
                }

                else if (gameManager.initialbudget < busCost)
                {
                    Extrabus = false;
                }
            }
            
            previousvalue = BusNumslider.value;
        

    }
}
