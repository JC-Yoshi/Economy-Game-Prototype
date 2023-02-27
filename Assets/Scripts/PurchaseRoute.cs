using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseRoute : MonoBehaviour
{
    public Text BudgetText;
    //[SerializeField] double routemoney;
    [SerializeField] double routecost;
    [SerializeField] TramWayGame gameManager;
    [SerializeField] GameObject RouteBegin;
    [SerializeField] GameObject Manager;
    [SerializeField] GameObject TimerSlider;
    [SerializeField] GameObject PurchaseRouteButton;
    [SerializeField] GameObject Buses;
    [SerializeField] GameObject TimerText;

    public bool Purchased = false;
    




    void Start()
    {
        Manager.SetActive(false);
        TimerSlider.SetActive(false); 
        RouteBegin.SetActive(false);
        Buses.SetActive(false);
        TimerText.SetActive(false);
    }

    void Update()
    {
        
        if (Purchased == true)
        {
            RouteBegin.SetActive(true);
            Manager.SetActive(true);
            TimerSlider.SetActive(true);
            Buses.SetActive(true);
            TimerText.SetActive(true);
            PurchaseRouteButton.SetActive(false);
            
        }

        if (Purchased == false)
        {
            RouteBegin.SetActive(false);
            Manager.SetActive(false);
            TimerSlider.SetActive(false);
            Buses.SetActive(false);
            TimerText.SetActive(false);
        }
    }

    public void purchaseRoute()
    {
        if (gameManager.initialbudget >= routecost)
        {
            Purchased = true;
            gameManager.initialbudget -= routecost;
        }

        else if (gameManager.initialbudget < routecost)
        {
            Purchased = false;
        }
        
    }


}
