using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PhoneHomescreenState : MonoBehaviour, IGUIState
{
    public GameObject phone;
    public GameObject homeScreenStuff;
    private float tweenTime = 0.5f;

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneHomescreen;
    }

    public void OnEnter(GameStateManager.stateType comingFrom)
    {
        if(comingFrom == GameStateManager.stateType.apartment || comingFrom == GameStateManager.stateType.phoneTrade)
        {
            phone.transform.DOMove(new Vector3(Screen.width/2, Screen.height/2), 0.5f);
            phone.transform.DORotate(Vector3.zero, 0.5f);
        }
        

        homeScreenStuff.SetActive(true);
    }

    public void OnExit(GameStateManager.stateType goingTo)
    {
        if(goingTo == GameStateManager.stateType.apartment)
        {
            phone.transform.DOMove(new Vector3(Screen.width/2, -1200f), 0.5f).SetEase(Ease.InQuad);
        }

        homeScreenStuff.SetActive(false);
    }

    public void ClickChat()
    {
        if (GameStateManager.Instance.GetActionsLeft() == 0)
        {
            //TODO: I could play a tired noise or send a message
            return;
        }
        GameStateManager.Instance.DeductAction();
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.phoneChat);
    }

    public void ClickScavenge()
    {
        if(GameStateManager.Instance.GetActionsLeft() == 0)
        {
            //TODO: I could play a tired noise or send a message
            return;
        }
        GameStateManager.Instance.DeductAction();
        GameStateManager.Instance.ScavengeItem();
    }

    public void ClickExit()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.apartment);
    }
}
