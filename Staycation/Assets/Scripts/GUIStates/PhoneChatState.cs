using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneChatState : MonoBehaviour, IGUIState
{
    public GameObject chatScreen;
    public GameObject select;
    public GameObject chat;
    public GameObject[] neighborPortraits; //0 is penny, 1 is shae, 2 is gabe, 3 is ezra, 4 is group

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneChat;
    }

    public void OnEnter(GameStateManager.stateType comingFrom)
    {
        //enable right stuff
        //disable + overlay for people who were chosen last time
    }

    public void OnExit(GameStateManager.stateType goingTo)
    {

    }

    public void ChooseChat(int neighborID) //0 is penny, 1 is shae, 2 is gabe, 3 is ezra
    {

    }
}
