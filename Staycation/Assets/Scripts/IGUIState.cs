using UnityEngine;
using System.Collections;

public interface IGUIState {

    GUIStateManager.stateType GetID();

    void OnEnter();

    void OnExit();
}
