using UnityEngine;
using System.Collections;

public interface IGUIState {

    GameStateManager.stateType GetID();

    void OnEnter();

    void OnExit();
}
