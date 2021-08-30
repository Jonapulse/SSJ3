using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler {
    //TODO: Add transformation stuff

    public DraggableGridManager.DraggableGrid homeGrid;
    public int gridIndex;

    
    public void OnPointerDown(PointerEventData e)
    {
        GameStateManager.Instance.gridManager.GrabItem(this);
    }
}
