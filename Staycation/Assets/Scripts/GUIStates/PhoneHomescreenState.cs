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
        if(comingFrom == GameStateManager.stateType.apartment)
        {
            phone.transform.DOMove(new Vector3(Screen.width/2, Screen.height/2), 0.5f);
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
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.phoneChat);
    }

    public void ClickScavenge()
    {
        GameStateManager.Instance.ScavengeItem();
    }

    public void ClickExit()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.apartment);
    }
}
