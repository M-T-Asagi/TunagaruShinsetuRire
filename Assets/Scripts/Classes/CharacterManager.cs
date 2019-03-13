using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    ClickToMove clickToMove = null;

    [SerializeField]
    ClickedItemManager clickedItemManager;

    [SerializeField]
    float canGetItemDistance = 0.3f;

    bool haveItem = false;
    public bool HaveItem { get { return haveItem; } }

    int itemID = -1;
    public int ItemID { get { return itemID; } set { itemID = value; haveItem = true; } }

    // Start is called before the first frame update
    void Start()
    {
        clickToMove.WalkingStop += OnCharacterMoveStop;
    }

    public void OnCharacterMoveStop(object sender, ClickToMove.WalkingStopEventArgs args)
    {
        Debug.Log("Stop character");
        if(clickedItemManager.clickedItem != null)
        {
            haveItem = true;
            itemID = clickedItemManager.clickedItem.ID;
            clickedItemManager.clickedItem.RemoveItem();
            clickedItemManager.clickedItem = null;

            Debug.Log("got an item " + itemID);
        }
    }
}
