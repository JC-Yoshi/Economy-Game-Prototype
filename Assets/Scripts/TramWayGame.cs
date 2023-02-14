using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TramWayGame : MonoBehaviour
{
    public TMP_Text budgetText;
    public double budget;

    public void Start()
    {
        budget = 100;
    }

    public void Update()
    {
        budgetText.text = "Budget: " + budget;
    }
}
    