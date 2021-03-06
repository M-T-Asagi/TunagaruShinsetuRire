﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterManager : MonoBehaviour
{
    public class CharacterChangedEventArgs : System.EventArgs
    {
        public GameObject newCharacterObject;

        public CharacterChangedEventArgs(GameObject _newCharacter)
        {
            newCharacterObject = _newCharacter;
        }
    }

    [SerializeField]
    ClickToMove clickToMove = null;

    [SerializeField]
    ScoreManager scoreManager = null;

    [SerializeField]
    TimeManager timeManager = null;

    [SerializeField]
    ItemCharacterArranger itemCharacterArranger = null;

    [SerializeField]
    ClickedItemManager clickedItemManager = null;

    [SerializeField]
    ClickedCharacterManager clickedCharacterManager = null;

    [SerializeField]
    float canGetItemDistance = 0.3f;

    [SerializeField]
    List<GameObject> characterList = null;

    public System.EventHandler<CharacterChangedEventArgs> characterChanged;

    bool haveItem = false;
    public bool HaveItem { get { return haveItem; } }

    int itemID = -1;
    public int ItemID { get { return itemID; } set { itemID = value; haveItem = true; } }
    
    // Start is called before the first frame update
    void Start()
    {
        SetNewPlayerCharacter(Random.Range(0, characterList.Count - 1), transform.position, Quaternion.identity);
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
            itemCharacterArranger.ReleaseBox(clickedItemManager.clickedItem.transform.parent);
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
        if (!timeManager.Gaming || !haveItem || itemID != clickedCharacterManager.clickedCharacter.WantObjectID)
            return;

        haveItem = false;
        itemID = -1;

        int gotScore = transform.GetChild(0).GetComponent<CharacterSettings>().GettingScore;
        Debug.Log("Get score: " + gotScore);
        scoreManager.Score += gotScore;

        CharacterChange(clickedCharacterManager.clickedCharacter.CharacterID);
        clickedCharacterManager.clickedCharacter.RemoveCharacter();
        itemCharacterArranger.ReleaseBox(clickedCharacterManager.clickedCharacter.transform.parent);
        clickedCharacterManager.clickedCharacter = null;
    }

    void CharacterChange(int characterID)
    {
        Transform nowCharacter = transform.GetChild(0);
        SetNewPlayerCharacter(characterID, nowCharacter.position, Quaternion.LookRotation(-nowCharacter.forward, Vector3.up));
        Destroy(nowCharacter.gameObject);
        itemCharacterArranger.AddItemAndCharacter();
    }

    void SetNewPlayerCharacter(int characterID, Vector3 position, Quaternion rotation)
    {
        GameObject newCharacter = Instantiate(characterList[characterID], position, rotation, transform);

        clickToMove.SetNavMeshAgent(newCharacter.GetComponent<UnityEngine.AI.NavMeshAgent>());
        characterChanged?.Invoke(this, new CharacterChangedEventArgs(newCharacter));
    }
}
