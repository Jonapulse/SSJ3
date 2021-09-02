using UnityEngine;
using System.Collections;

public class ApartmentState : MonoBehaviour, IGUIState {

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.apartment;
    }

    public void OnEnter(GameStateManager.stateType comingFrom)
    {

    }

    public void OnExit(GameStateManager.stateType goingTo)
    {

    }

    public void ClickComputer()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.phoneHomescreen);
    }

    public void ClickBed()
    {
        GameStateManager.Instance.NextDay();
    }
}
