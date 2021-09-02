using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler {
    //TODO: Add transformation stuff

    [HideInInspector] public DraggableGridManager.DraggableGrid homeGrid;
    public int gridIndex;
    public collection_type type;
    public int ID = 0;

    [System.Serializable]
    public enum collection_type { Cats, Plants, Relics };
    
    public void OnPointerDown(PointerEventData e)
    {
        GameStateManager.Instance.gridManager.GrabItem(this);
    }
}
