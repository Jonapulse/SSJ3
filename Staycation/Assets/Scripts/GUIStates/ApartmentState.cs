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
        Debug.Log("You clicked a bed!");
        //TODO: Sleep thing (and update a text day rating that is x/7 or do that in the radio)
    }
}
