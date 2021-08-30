using UnityEngine;
using System.Collections.Generic;

public class GUIStateManager : MonoBehaviour {
    /// <summary>
    /// Controls toggling between states, triggering Enter and Exit behavior
    /// Have the lists for collection and box (for box and trade states that deal with multiple grids).
    /// Also any interactables that are in all states.
    /// TODO: Store phone battery info? Use this as a game manager, essentially?
    /// </summary>

    //////////////////////
    //SINGLETON STUFF
    protected GUIStateManager() { }
    private static GUIStateManager _instance = null;
    public static GUIStateManager Instance {
        get { return GUIStateManager._instance; }
    }
    private void Awake() {
        if (_instance != this && _instance != null) {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    //
    /////////////////////

    public List<IGUIState> gameStates;
    private IGUIState currentState;
    public enum stateType {phoneTrade, phoneScavenge, phoneHomescreen, phoneChat, boxOrganization, apartment};

    public void ChangeState(stateType type)
    {
        currentState.OnExit();

        for(int i = 0; i < gameStates.Count; i++)
        {
            if(gameStates[i].GetID().Equals(type))
            {
                currentState = gameStates[i];
                break;
            }
            if (i == gameStates.Count - 1) Debug.LogError("ChangeState could not find type: " + type);
        }

        currentState.OnEnter();
    }
}
