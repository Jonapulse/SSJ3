using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    public GameObject[] powerBars;
    void Update()
    {
        for (int i = 0; i < powerBars.Length; i++)
            powerBars[i].SetActive(GameStateManager.Instance.GetActionsLeft() - 1 >= i);
    }
}
