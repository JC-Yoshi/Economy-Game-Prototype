using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RouteStateManager : MonoBehaviour
{
    RouteBaseState currentState;
    public UnPurchasedState UnPurchasedState = new UnPurchasedState();
    public PurchasedState PurchasedState = new PurchasedState();
    public InStationState InStationState = new InStationState();
    public InTransitState InTransitState = new InTransitState();
   



    // Start is called before the first frame update
    void Start()
    {
        currentState = UnPurchasedState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(RouteBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

}
