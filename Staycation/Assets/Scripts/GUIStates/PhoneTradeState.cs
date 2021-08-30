using UnityEngine;
using System.Collections;

public class PhoneTradeState : MonoBehaviour, IGUIState
{
    /// <summary>
    /// This needs in on the apartment and box state shared, interacting grids. Also need 'canTransfer' rules. Probably we grab those grids from GUIStateManager and use our own rules.
    /// Also calculates the happiness of neighbor with trade and displays it
    /// </summary>

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneTrade;
    }

    public void OnEnter()
    {
        //TODO: Flip phone to proper orientation for trade. What they're offering on the right. Then you can select up to 3 of what you want and have 9 grids for what you offer. Area for player response and return to home.
    }

    public void OnExit()
    {

    }
}
