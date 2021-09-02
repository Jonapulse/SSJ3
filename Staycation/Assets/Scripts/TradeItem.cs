using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeItem : MonoBehaviour, IPointerDownHandler
{
    public bool selected = false;
    public GameObject checkMark;
    public GameObject checkBox;
    public DraggableItem item;

    public void OnPointerDown(PointerEventData e)
    {
        ToggleSelection();
    }

    private void ToggleSelection()
    {
        if (item == null)
            return;

        selected = !selected;
        checkMark.SetActive(selected);
    }

    public void TakeItem()
    {
        checkMark.SetActive(false);
        checkBox.SetActive(false);
        selected = false;

        //TODO: remove item and send it to the trade grid
    }

    public void GenerateItem()
    {
        checkMark.SetActive(false);
        checkBox.SetActive(true);
        selected = false;

        item = GameObject.Instantiate(GameStateManager.Instance.possibleItems.itemCandidates[Random.Range(0, GameStateManager.Instance.possibleItems.itemCandidates.Count)], this.transform);
        item.transform.SetAsFirstSibling();
    }
}
