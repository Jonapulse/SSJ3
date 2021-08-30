using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DraggableGrid : MonoBehaviour {

    /// <summary>
    /// Can be turned active or inactive. Do that with a function, so we can toggle highlighting spaces (mostly for collection)
    /// handles highlight behavior
    /// handles drag, highlight-during-drag-to-show-target, and release behaviour. Can be exclusionary.
    /// performs the item snap. Also will swap items if appropriately placed. Also or swaps item places
    /// handles update after a release (or doesn't update if you're too far to snap, just goes back to place. )
    /// Also keeps a list of gridItems it contains (principally for the collection scoring)
    /// </summary>

    public Image[] gridSpaces; //TODO: Make, place, and add to object these highlightable spaces

    public int distanceForSpaceSnap = 100; //pixels
    public bool dragging = false;
	
	void Update () {
	
      //  List<>

        // Handle highlighting
        if (!dragging)
        {

        }
        else
        {

        }
            //if not dragging than just inside
            //else 
	}
}
