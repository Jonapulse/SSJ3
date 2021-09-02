using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

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
    public ItemManager possibleItems;
    public RawImage nightCover;
    public GameObject uiAnchorToAppearAbove;
    private IGUIState[] stateList;
    private IGUIState currentState;
    public enum stateType {phoneTrade, phoneScavenge, phoneHomescreen, phoneChat, apartment};
    private int actionsLeft;
    public int actionsPerDay;
    public int day = 1;

    private void Start()
    {
        stateList = stateReference.GetComponents<IGUIState>();
        currentState = FindState(stateType.apartment);
        actionsLeft = actionsPerDay;
        nightCover.gameObject.SetActive(false);
    }

    public void ChangeState(stateType type)
    {
        currentState.OnExit(type);
        stateType currentType = currentState.GetID();
        currentState = FindState(type);
        currentState.OnEnter(currentType);
    }

    IGUIState FindState(stateType type)
    {
        for (int i = 0; i < stateList.Length; i++)
            if (stateList[i].GetID().Equals(type))
                return stateList[i];

        Debug.LogError("FindState couldn't find " + type);
        return null;
    }

    public void ScavengeItem()
    {
        possibleItems.GrantRandomItem();

    }

    public void NextDay()
    {
        nightCover.gameObject.SetActive(true);
        nightCover.color = Color.clear;
        nightCover.DOFade(1, 0.75f).OnComplete(FinishDayTransition);

        //TODO: Special interrupt for end of game
    }

    void FinishDayTransition()
    {
        nightCover.DOFade(0, 0.75f).OnComplete(TurnOffNightCover);
        day++;
        actionsLeft = actionsPerDay;
        DraggableGridManager.DraggableGrid box = gridManager.grids[1];
        for (int i = 0; i < box.items.Count; i++)
            Destroy(box.items[i].gameObject);
        box.items = new List<DraggableItem>();
    }

    void TurnOffNightCover()
    {
        nightCover.gameObject.SetActive(false);
    }

    public void DeductAction()
    {
        actionsLeft--;
    }

    private void Update()
    {
    }
}
