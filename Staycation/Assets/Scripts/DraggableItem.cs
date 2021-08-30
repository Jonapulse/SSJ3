using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler {
    //TODO: Add transformation stuff

    public DraggableGrid homeGrid;
    public int gridIndex;

    
    public void OnPointerDown(PointerEventData e)
    {
        Debug.Log("you just clicked " + this.name);
        //TODO: initiate a dragEvent with homeGrid if homeGrid is active. HomeGrid handles it from here.
    }
}
