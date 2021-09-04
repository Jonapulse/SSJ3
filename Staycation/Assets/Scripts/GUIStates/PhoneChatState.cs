using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneChatState : MonoBehaviour, IGUIState
{
    public GameObject chatScreen;
    public GameObject select;
    public GameObject chat;
    public GameObject[] disableCovers;
    public GameObject[] neighborPortraits; //0 is penny, 1 is shae, 2 is gabe, 3 is ezra, 4 is group

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneChat;
    }

    public void OnEnter(GameStateManager.stateType comingFrom)
    {
        chatScreen.SetActive(true);
        select.SetActive(true);

        if(GameStateManager.Instance.day > 0)
        {
            for (int i = 0; i < disableCovers.Length; i++)
                disableCovers[i].SetActive(PlayerPrefs.GetInt("day" + (GameStateManager.Instance.day - 1) + ":" + i, 0) == 1 || PlayerPrefs.GetInt("day" + (GameStateManager.Instance.day) + ":" + i, 0) == 1);
        }
    }

    public void OnExit(GameStateManager.stateType goingTo)
    {
        chat.SetActive(false);
        chatScreen.SetActive(false);
    }

    public void ChooseChat(int neighborID) //0 is penny, 1 is shae, 2 is gabe, 3 is ezra
    {
        select.SetActive(false);
        chat.SetActive(true);

        PlayerPrefs.SetInt("day" + GameStateManager.Instance.day + ":" + neighborID, 1);

        for (int i = 0; i < neighborPortraits.Length; i++)
            neighborPortraits[i].SetActive(false);
        neighborPortraits[neighborID].SetActive(true);

        int talkProgress = PlayerPrefs.GetInt("talk" + neighborID, 0);
        PlayerPrefs.SetInt("talk" + neighborID, talkProgress + 1);

        DialogueInfo.singleDialogue.neighborID ID = DialogueInfo.singleDialogue.neighborID.Penny; //Default
        switch (neighborID)
        {
            case (1):
                ID = DialogueInfo.singleDialogue.neighborID.Shae;
                break;
            case (2):
                ID = DialogueInfo.singleDialogue.neighborID.Gabe;
                break;
            case (3):
                ID = DialogueInfo.singleDialogue.neighborID.Ezra;
                break;
        }

        GameStateManager.Instance.chat.StartChat(ID, talkProgress, true);
    }
}
