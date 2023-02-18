using UnityEngine;

public abstract class RouteBaseState
{
    public abstract void EnterState(RouteStateManager route);

    public abstract void UpdateState(RouteStateManager route);

    public abstract void OnCollision(RouteStateManager route);

   
}
