using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemManager : MonoBehaviour
{
    public List<DraggableItem> itemCandidates;

    public void GrantRandomItem()
    {
        DraggableItem newItem = GameObject.Instantiate(itemCandidates[Random.Range(0,itemCandidates.Count - 1)]);
        newItem.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        newItem.transform.localScale = Vector3.zero;

        DraggableGridManager.DraggableGrid box = GameStateManager.Instance.gridManager.grids[1];
        int targetSpace;
        for (targetSpace = 0; targetSpace < box.spaces.Length; targetSpace++)
        {
            bool spaceOccupied = false;
            for (int i = 0; i < box.items.Count; i++)
            {
                if (box.items[i].gridIndex == targetSpace)
                {
                    spaceOccupied = true;
                    break;
                }
            }
            if (!spaceOccupied)
                break;
        }

        box.items.Add(newItem);
        newItem.transform.SetParent(GameStateManager.Instance.uiAnchorToAppearAbove.transform);
        newItem.homeGrid = box;
        newItem.gridIndex = targetSpace;

        Sequence seq = DOTween.Sequence();
        seq.Insert(0, newItem.transform.DOScale(Vector3.one * 1.75f, 0.5f));
        seq.Insert(0.5f, newItem.transform.DOMove(box.spaces[targetSpace].transform.position, 0.4f));
        seq.Insert(0.5f, newItem.transform.DOScale(Vector3.one, 0.4f));

        seq.Play();

        StartCoroutine(SetItemToBoxParent(0.9f, newItem.transform, box.itemFolder));

        GameStateManager.Instance.DeductAction();
    }

    IEnumerator SetItemToBoxParent(float delay, Transform newT, Transform newParent)
    {
        yield return new WaitForSeconds(delay);
        newT.SetParent(newParent);
    }
}
