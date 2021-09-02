using UnityEngine;
using System.Collections;

public interface IGUIState {

    GameStateManager.stateType GetID();

    void OnEnter(GameStateManager.stateType comingFrom);

    void OnExit(GameStateManager.stateType goingTo);
}
