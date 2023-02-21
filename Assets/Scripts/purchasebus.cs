using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class purchasebus : MonoBehaviour
{
    [SerializeField] private double busCost;
    [SerializeField] private double busUpkeep;
    [SerializeField] private float numberbuses;
    [SerializeField] private double numberbusesmax;
    [SerializeField] private Slider slider;
    //private GameObject bus;

    [SerializeField] Timer timer;
    [SerializeField] TramWayGame gameManager;

    private bool Extrabus = false;

    public void Start()
    {
        numberbuses = slider.value; 
    }

    public void Update()
    {
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

    public void BusSlider()
    {
        if (gameManager.initialbudget >= busCost)
        {
            busCost *= numberbuses;
            gameManager.initialbudget -= busCost;
            Extrabus = true;
        }

        else if (gameManager.initialbudget < busCost)
        {
            Extrabus = false;
        }
    }

   /* float CalcSliderValue()
    {
         
    } */


}
