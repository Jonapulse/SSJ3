using UnityEngine;
using System.Collections;

public class PhoneHomescreenState : MonoBehaviour, IGUIState
{
    /// <summary>
    /// Has Exit button, Chat button, and Scavenge button
    /// </summary>

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneHomescreen;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}
