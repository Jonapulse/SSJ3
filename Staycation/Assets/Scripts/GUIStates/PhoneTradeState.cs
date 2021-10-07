using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;

public class PhoneTradeState : MonoBehaviour, IGUIState
{
    public GameObject phone;
    public GameObject tradeScreen;
    public TradeItem[] trades;
    int tradeValue = 0;
    public TextMeshProUGUI scoreText;
    public GameObject[] scoreMoticons;

    private float referencePixelWidth = 1920;

    public GameStateManager.stateType GetID()
    {
        return GameStateManager.stateType.phoneTrade;
    }

    public void OnEnter(GameStateManager.stateType comingFrom)
    {
        float screenAdjust = Screen.width / referencePixelWidth;
        print(screenAdjust);

        phone.transform.DOMove(new Vector3(Screen.width / 2 + 376 * screenAdjust, Screen.height / 2 - 214 * screenAdjust), 0.5f);
        phone.transform.DORotate(new Vector3(0, 0, 90), 0.5f);
        tradeScreen.SetActive(true);

        for (int i = 0; i < trades.Length; i++)
            trades[i].GenerateItem();

        CalculateTradeScore();
    }

    public void OnExit(GameStateManager.stateType goingTo)
    {
        tradeScreen.SetActive(false);
    }

    public void CalculateTradeScore()
    {
        int tradeScore = GameStateManager.Instance.gridManager.grids[2].items.Count;
        int selectedScore = 0;
        for (int i = 0; i < trades.Length; i++)
            if (trades[i].selected)
                selectedScore += 1;

        tradeValue = tradeScore - selectedScore + 1; //An even trade is valued at 1
        scoreText.text = tradeValue.ToString();

        scoreMoticons[0].SetActive(tradeValue < 1 ? true : false);
        scoreMoticons[1].SetActive(tradeValue >= 1 ? true : false);
    }

    public void ClickTrade()
    {
        if (tradeValue < 1)
            return;

        bool nothingSelected = true;
        for (int i = 0; i < trades.Length; i++)
            if (trades[i].selected)
                nothingSelected = false;
        if (nothingSelected)
            return;

        ClearTradeGrid();

        List<DraggableItem> tradeGet = new List<DraggableItem>();
        for (int i = 0; i < trades.Length; i++)
            if (trades[i].selected)
                tradeGet.Add(trades[i].TakeItem());

        DraggableGridManager.DraggableGrid tradeGrid = GameStateManager.Instance.gridManager.grids[2];
        for(int i = 0; i < tradeGet.Count; i++)
        {
            DraggableItem tradedItem = tradeGet[i];
            tradeGrid.items.Add(tradedItem);
            tradedItem.transform.SetParent(tradeGrid.itemFolder);
            tradedItem.homeGrid = tradeGrid;
            tradedItem.gridIndex = i;

            tradedItem.transform.DOMove(tradeGrid.spaces[i].transform.position, 0.45f);
        }
    }

    public void ClickExit()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.phoneHomescreen);
        for (int i = 0; i < trades.Length; i++)
            trades[i].ClearItem();

        ClearTradeGrid();
    }

    void ClearTradeGrid()
    {
        DraggableGridManager.DraggableGrid tradeGrid = GameStateManager.Instance.gridManager.grids[2];

        for (int i = 0; i < tradeGrid.items.Count; i++)
            Destroy(tradeGrid.items[i].gameObject);
        tradeGrid.items = new List<DraggableItem>();

    }
}
