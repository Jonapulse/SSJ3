using UnityEngine;
using System.Collections;

public class PhoneScavengeState : MonoBehaviour, IGUIState
{
    /// <summary>
    /// A map (that I need to draw) which has places you can scavenge that will affect what you find. 
    /// Popup that says what you get and maybe has some messages. Could ping Lily for them.
    /// Also back button.
    /// </summary>

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneScavenge;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}
