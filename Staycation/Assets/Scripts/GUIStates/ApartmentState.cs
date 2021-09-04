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
        if(GameStateManager.Instance.GetCurrentState() == GameStateManager.stateType.apartment)
            GameStateManager.Instance.ChangeState(GameStateManager.stateType.phoneHomescreen);
    }

    public void ClickBed()
    {
        if (GameStateManager.Instance.GetCurrentState() == GameStateManager.stateType.apartment)
        {
            GameStateManager.Instance.NextDay();
            SoundManager.Instance.PlaySFX(SoundManager.Instance.screenToBlack);
        }
    }
}
