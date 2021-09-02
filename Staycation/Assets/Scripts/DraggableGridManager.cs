using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class DraggableGridManager : MonoBehaviour {

    /// <summary>
    /// Can be turned active or inactive. Do that with a function, so we can toggle highlighting spaces (mostly for collection)
    /// handles highlight behavior
    /// handles drag, highlight-during-drag-to-show-target, and release behaviour. Can be exclusionary.
    /// performs the item snap. Also will swap items if appropriately placed. Also or swaps item places
    /// handles update after a release (or doesn't update if you're too far to snap, just goes back to place. )
    /// Also keeps a list of gridItems it contains (principally for the collection scoring)
    /// </summary>

    public DraggableGrid[] grids; 

    [System.Serializable]
    public class DraggableGrid
    {
        public bool active;
        public Image[] spaces;
        public List<DraggableItem> items;
        public Transform itemFolder;
    }

    public class NewSpaceData
    {
        public Vector3 position;
        public DraggableGrid newGrid;
        public int index;
    }

    public int distanceForSpaceSnap = 100; //pixels
    public float tweenTime = 0.125f;
    public Color highlightColor = Color.gray;
    private bool dragging = false;
    private bool tweening = false;
    private DraggableItem heldItem;
    private Vector3 originalPosition;
    private Image oldHighlightedSpace = null;

    public void GrabItem(DraggableItem newheldItem)
    {
        heldItem = newheldItem;
        originalPosition = heldItem.transform.position;
        heldItem.transform.SetParent(GameStateManager.Instance.uiAnchorToAppearAbove.transform);
        dragging = true;
    }
	
	void Update () {

        NewSpaceData closestSpace = GetClosestGridSpace();
        Image newHighlightedSpace = closestSpace.newGrid.spaces[closestSpace.index];

        if (oldHighlightedSpace)
            oldHighlightedSpace.color = Color.white;

        // Handle highlighting
        if (!dragging)
        {
            Rect testRect = new Rect(newHighlightedSpace.rectTransform.rect);
            testRect.x += newHighlightedSpace.transform.position.x;
            testRect.y += newHighlightedSpace.transform.position.y;
            if(testRect.Contains(Input.mousePosition))
            {
                newHighlightedSpace.color = highlightColor;
                oldHighlightedSpace = newHighlightedSpace;
            }

        }
        else if (!tweening)
        {
            bool inRange = (Input.mousePosition - closestSpace.position).magnitude < distanceForSpaceSnap;
            if(inRange)
            {
                newHighlightedSpace.color = highlightColor;
                oldHighlightedSpace = newHighlightedSpace;
            }

            //And handle dragging
            heldItem.transform.position = Input.mousePosition;

            if(Input.GetMouseButtonUp(0))
            {
                tweening = true;

                if (inRange)
                {
                    //TODO: Disallowing inactive grids?

                    heldItem.transform.DOMove(closestSpace.position, tweenTime).OnComplete(EndTween);

                    //Check for swapping items
                    DraggableItem itemInSpaceAlready = null;
                    foreach(DraggableItem item in closestSpace.newGrid.items) 
                    {
                        if(item.gridIndex == closestSpace.index && item.gridIndex != heldItem.gridIndex)
                        {
                            itemInSpaceAlready = item;
                            itemInSpaceAlready.homeGrid.items.Remove(heldItem);
                            heldItem.homeGrid.items.Add(heldItem);
                            itemInSpaceAlready.homeGrid = heldItem.homeGrid;
                            itemInSpaceAlready.gridIndex = heldItem.gridIndex;
                            itemInSpaceAlready.transform.DOMove(originalPosition, tweenTime).OnComplete(EndTween);                                
                        }
                    }

                    heldItem.homeGrid.items.Remove(heldItem);
                    closestSpace.newGrid.items.Add(heldItem);
                    heldItem.homeGrid = closestSpace.newGrid;
                    heldItem.gridIndex = closestSpace.index;

                    GameStateManager.Instance.score.RecalculateScore();
                }
                else //tween back
                {
                    heldItem.transform.DOMove(originalPosition, tweenTime).OnComplete(EndTween);
                }

                heldItem.transform.SetParent(heldItem.homeGrid.itemFolder);

                if(GameStateManager.Instance.GetCurrentState() == GameStateManager.stateType.phoneTrade)
                    GameStateManager.Instance.trade.CalculateTradeScore();
            }
        }
	}

    void EndTween() {
        tweening = false;
        dragging = false;
    }

    //relative to mouse position
    NewSpaceData GetClosestGridSpace()
    {
        float minDistance = float.PositiveInfinity;
        NewSpaceData closestGridSpace = new NewSpaceData();
        for(int i = 0; i < grids.Length; i++)
        {
            if(grids[i].active)
            {
                for(int j = 0; j < grids[i].spaces.Length; j++)
                {
                    float distance = (Input.mousePosition - grids[i].spaces[j].transform.position).magnitude;
                    if(distance < minDistance)
                    {
                        closestGridSpace.position = grids[i].spaces[j].transform.position;
                        closestGridSpace.newGrid = grids[i];
                        closestGridSpace.index = j;
                        minDistance = distance;
                    }
                }
            }
        }
        return closestGridSpace;
    }

    public List<DraggableItem> GetCollection()
    {
        return grids[0].items;
    }
}
