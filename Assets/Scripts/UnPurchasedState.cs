using UnityEngine;


public class UnPurchasedState : RouteBaseState
{
    public override void EnterState(RouteStateManager route)
    {
        Debug.Log("Hello from the Unpurchased State");
        
    }

    public override void UpdateState(RouteStateManager route)
    {

    }
    public override void OnCollision (RouteStateManager route)
    {

    }
   


}
