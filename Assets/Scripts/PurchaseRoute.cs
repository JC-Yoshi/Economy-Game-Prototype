using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseRoute : MonoBehaviour
{
    public Text BudgetText;
    [SerializeField] double money;
    [SerializeField] TramWayGame gameManager;
    [SerializeField] GameObject RouteBegin;
    [SerializeField] GameObject Manager;
    [SerializeField] GameObject Slider;
    [SerializeField] GameObject PurchaseRouteButton;

    public bool Purchased = false;
    




    void Start()
    {
        Manager.SetActive(false);
        Slider.SetActive(false); 
        RouteBegin.SetActive(false);
    }

    void Update()
    {
        
        if (Purchased == true)
        {
            RouteBegin.SetActive(true);
            Manager.SetActive(true);
            Slider.SetActive(true);
            PurchaseRouteButton.SetActive(false);

        }

        if (Purchased == false)
        {
            RouteBegin.SetActive(false);
            Manager.SetActive(false);
            Slider.SetActive(false);
        }
    }

    public void purchaseRoute()
    {
        Purchased = true;
        gameManager.initialbudget -= money;
    }


}
