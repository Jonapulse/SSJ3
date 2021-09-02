using UnityEngine;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {
    /// <summary>
    /// Controls toggling between states, triggering Enter and Exit behavior
    /// Have the lists for collection and box (for box and trade states that deal with multiple grids).
    /// Also any interactables that are in all states.
    /// TODO: Store phone battery info? Use this as a game manager, essentially?
    /// </summary>

    //////////////////////
    //SINGLETON STUFF
    protected GameStateManager() { }
    private static GameStateManager _instance = null;
    public static GameStateManager Instance {
        get { return GameStateManager._instance; }
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
    public DraggableGridManager gridManager;
    public DialogueInfo dialogueInfo;
    public GameObject stateReference;
    public ScoreManager score;
    private IGUIState[] stateList;
    private IGUIState currentState;
    public enum stateType {phoneTrade, phoneScavenge, phoneHomescreen, phoneChat, boxOrganization, apartment};

    private void Start()
    {
        stateList = stateReference.GetComponents<IGUIState>();
        currentState = FindState(stateType.apartment);
    }

    public void ChangeState(stateType type)
    {
        currentState.OnExit();

        currentState = FindState(type);

        currentState.OnEnter();
    }

    IGUIState FindState(stateType type)
    {
        for (int i = 0; i < stateList.Length; i++)
            if (stateList[i].GetID().Equals(type))
                return stateList[i];

        Debug.LogError("FindState couldn't find " + type);
        return null;
    }

    private void Update()
    {
    }
}
