using UnityEngine;
using System.Collections;

public class BoxOrganizationState : MonoBehaviour, IGUIState
{
    /// <summary>
    /// Have a box popup. If possible, make it big enough to fit all items without scroll, and then to also have room for collection and phone trade display.
    /// </summary>

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.boxOrganization;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}
