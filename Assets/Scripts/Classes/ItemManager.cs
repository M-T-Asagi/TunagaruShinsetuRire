using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int id = 0;
    public int ID { get { return id; } }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.GetComponent<ClickedItemManager>().clickedItem = this;
    }

    public void RemoveItem()
    {
        Destroy(gameObject);
    }
}
