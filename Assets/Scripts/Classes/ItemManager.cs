using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int id = 0;
    public int ID { get { return id; } }

    [SerializeField]
    ClickToMove clickToMove = null;

    [SerializeField]
    LayerMask layerMask = new LayerMask();

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.GetComponent<ClickedItemManager>().clickedItem = this;
        RaycastHit raycastHit = new RaycastHit();
        if(Physics.Raycast(((PointerEventData)eventData).pointerCurrentRaycast.worldPosition, Vector3.down, out raycastHit, 1))
        {
            clickToMove.SetNavigateTo(raycastHit.point);
        } else
        {
            clickToMove.SetNavigateTo(((PointerEventData)eventData).pointerCurrentRaycast.worldPosition);
        }
    }

    public void RemoveItem()
    {
        Destroy(gameObject);
    }
}
