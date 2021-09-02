using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PhoneTradeState : MonoBehaviour, IGUIState
{
    public GameObject tradeScreen;
    public TradeItem[] trades;

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneTrade;
    }

    public void OnEnter(GameStateManager.stateType comingFrom)
    {
        Debug.Log("Hello?");
        tradeScreen.transform.parent.DOMove(new Vector3(Screen.width / 2 + 376, Screen.height / 2 - 214), 0.5f);
        tradeScreen.transform.parent.DORotate(new Vector3(0, 0, 90), 0.5f);
        tradeScreen.SetActive(true);

        for (int i = 0; i < trades.Length; i++)
            trades[i].GenerateItem();
    }

    public void OnExit(GameStateManager.stateType goingTo)
    {
        tradeScreen.SetActive(false);
    }

    public void ClickTrade()
    {
        //swap the selected item or items into the trade boxes
        //...actually you can only trade once, then you'll get the button but will be prompted to clear your tray before exiting... or at least warned that anything not cleared will be lost.
        //But yeah acutally I do like the single trade
    }

    public void ClickExit()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.phoneHomescreen);
    }
}
