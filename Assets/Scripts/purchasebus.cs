using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class purchasebus : MonoBehaviour
{
    [SerializeField] private double busCost;
    [SerializeField] private double busUpkeep;
    [SerializeField] private double numberbuses;
    private GameObject bus;

    [SerializeField] Timer timer;
    [SerializeField] TramWayGame gameManager;

    private bool Extrabus = false;

    public void Update()
    {
        if (Extrabus == true)
        {
            timer.timeRemaining -= 1;
            gameManager.initialbudget -= busUpkeep;
        }

        else if (gameManager.initialbudget < busCost)
        {
            Extrabus = false;
            
        }
           

    }

    public void BusToggle()
    {
        if (gameManager.initialbudget >= busCost)
        {
            gameManager.initialbudget -= busCost;
            Extrabus = true;
        }

        
    }


}
