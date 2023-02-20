using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TramWayGame : MonoBehaviour
{
    public Text BudgetText;
    public double initialbudget = 140;
   // public double currentbudget;

    
    public void Start()
    {
        
    }

    public void Update()
    {
        BudgetText.text = "Budget: " + initialbudget.ToString();

    }



    
}