using UnityEngine;
using System.Collections;

public class ApartmentState : MonoBehaviour, IGUIState {

    /// <summary>
    /// The collection draggableGrid
    /// The score display, and recalculating whenever collection grid changes
    /// Buttons: Box, bed, computer/phone
    /// Chat display for radio announcements (do we just trigger that if you click radio or at end/beginning of day?)
    /// Stretch: non-chat display for the note slipped under the door. 
    /// </summary>

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.apartment;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}
