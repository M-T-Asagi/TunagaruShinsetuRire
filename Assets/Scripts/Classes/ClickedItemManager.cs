using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedItemManager : MonoBehaviour
{
    public ItemManager clickedItem { get; set; }

    private void Start()
    {
        clickedItem = null;
    }

    public void UnClick()
    {
        clickedItem = null;
    }

    public void Destroying()
    {
        clickedItem = null;
    }

    private void OnDestroy()
    {
        Destroying();
    }
}
