using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCharacterArranger : MonoBehaviour
{
    [System.Serializable]
    public class ItemCharacterPair
    {
        public GameObject Character;
        public GameObject Item;
    }

    [SerializeField]
    List<ItemCharacterPair> itemCharacterPairList = null;

    List<Transform> children;
    List<int> reamingBoxIndexes;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>();
        reamingBoxIndexes = new List<int>();
        foreach (Transform child in transform)
        {
            children.Add(child);
            reamingBoxIndexes.Add(reamingBoxIndexes.Count);
        }
        
        for(int i = 0; i < 4; i++)
        {
            int characterItemIndex = Random.Range(0, itemCharacterPairList.Count - 1);
            
            int indexBuff = Random.Range(0, reamingBoxIndexes.Count - 1);
            Instantiate(itemCharacterPairList[characterItemIndex].Character, children[reamingBoxIndexes[indexBuff]]);
            reamingBoxIndexes.RemoveAt(indexBuff);

            indexBuff = Random.Range(0, reamingBoxIndexes.Count - 1);
            Instantiate(itemCharacterPairList[characterItemIndex].Item, children[reamingBoxIndexes[indexBuff]]);
            reamingBoxIndexes.RemoveAt(indexBuff);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
