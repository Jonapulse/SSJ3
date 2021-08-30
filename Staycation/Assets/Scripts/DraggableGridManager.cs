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
    }

    public class NewSpaceData
    {
        public Vector3 position;
        public DraggableGrid newGrid;
        public int index;
    }

    public int distanceForSpaceSnap = 100; //pixels
    public float tweenTime = 0.75f;
    private bool dragging = false;
    private bool tweening = false;
    private DraggableItem heldItem;

    public void GrabItem(DraggableItem newheldItem)
    {
        heldItem = newheldItem;
        dragging = true;
    }
	
	void Update () {

        NewSpaceData closestSpace = GetClosestGridSpace();

        // Handle highlighting
        if (!dragging)
        {
            //if within an object, highlight it
        }
        else if (!tweening)
        {


            //And handle dragging
            heldItem.transform.position = Input.mousePosition;

            if(Input.GetMouseButtonUp(0))
            {
                dragging = false;
                tweening = true;

                if ((Input.mousePosition - closestSpace.position).magnitude < distanceForSpaceSnap)
                {
                    heldItem.transform.DOMove(closestSpace.position, tweenTime).OnComplete(EndTween);
                    heldItem.homeGrid = closestSpace.newGrid;
                    heldItem.gridIndex = closestSpace.index;

                    //TODO: swap, child grids appropriately and handle grid changes
                }
                else //tween back
                {
                    //shit, and find the position of your old place
                }
            }
        }
	}

    void EndTween() { tweening = false; }

    //relative to mouse position
    NewSpaceData GetClosestGridSpace()
    {
        float minDistance = float.PositiveInfinity;
        NewSpaceData closestGridSpace = new NewSpaceData();
        for(int i = 0; i < grids.Length; i++)
        {
            if(grids[i].active)
            {
                for(int j = 0; j < grids.Length; j++)
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
}
