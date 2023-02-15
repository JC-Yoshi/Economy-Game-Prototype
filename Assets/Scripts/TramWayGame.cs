using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TramWayGame : MonoBehaviour
{
    public Text budgetText;
    public double budget;

    
    public void Start()
    {
        budget = 100;
    }

    public void Update()
    {
        //bugdet text
        budgetText.text = "Budget: " + budget;

        
    }



    
}