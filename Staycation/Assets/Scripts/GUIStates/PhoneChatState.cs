using UnityEngine;
using System.Collections;

public class PhoneChatState : MonoBehaviour, IGUIState
{
    /// <summary>
    /// Display the four neighbors, with grayed out 'gone scavengin'' wanrings for the ones who are doing that. Clicking runs a chat .
    /// Play the chat (with settings for phone + portrait) and show trade button at the end.. So it has chat-scroll. But I don't think I'll implement scroll back. Too rarely useful.
    /// Also back button
    /// </summary>

    public GUIStateManager.stateType GetID()
    {
        return GUIStateManager.stateType.phoneChat;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}
