using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnRoute : MonoBehaviour
{
   // public Text budgetText;
    public GameObject RouteManager;
    public GameObject RouteCard;


    /*public void PurchaseRoute()
    {
        GameObject tmpObj = Instantiate(RouteCard);
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        RouteCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

    }
  */

    public void Click()
    {

        Instantiate(RouteCard, RouteManager.transform);


        /* GameObject Routecard = Instantiate(RouteCard, new Vector2 ( 0, 0), Quaternion.identity) as GameObject;
        RouteCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        Debug.Log("Spawned RouteCard");
        */
    }
  
}