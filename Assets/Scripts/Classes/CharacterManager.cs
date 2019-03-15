using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    ClickToMove clickToMove = null;

    [SerializeField]
    ScoreManager scoreManager = null;

    [SerializeField]
    ClickedItemManager clickedItemManager = null;

    [SerializeField]
    ClickedCharacterManager clickedCharacterManager = null;

    [SerializeField]
    float canGetItemDistance = 0.3f;

    [SerializeField]
    List<GameObject> characterList = null;

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

        if (clickedCharacterManager.clickedCharacter != null)
        {
            PassItem();
        }
    }

    void PassItem()
    {
        if (!haveItem)
            return;

        if (itemID != clickedCharacterManager.clickedCharacter.WantObjectID)
            return;

        haveItem = false;
        itemID = -1;

        int gotScore = transform.GetChild(0).GetComponent<CharacterSettings>().GettingScore;
        Debug.Log("Get score: " + gotScore);
        scoreManager.Score += gotScore;

        CharacterChange(clickedCharacterManager.clickedCharacter.CharacterID);
        clickedCharacterManager.clickedCharacter.RemoveCharacter();
        clickedCharacterManager.clickedCharacter = null;
    }

    void CharacterChange(int characterID)
    {
        Transform nowCharacter = transform.GetChild(0);
        GameObject newCharacter = Instantiate(characterList[characterID], nowCharacter.position, nowCharacter.rotation, transform);
        Destroy(nowCharacter.gameObject);
        clickToMove.SetNavMeshAgent(newCharacter.GetComponent<UnityEngine.AI.NavMeshAgent>());
    }
}
