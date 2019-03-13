using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitytCharacterManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int wantObjectID = 0;
    public int WantObjectID { get { return wantObjectID; } }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.GetComponent<ClickedCharacterManager>().clickedCharacter = this;
    }

    public void RemoveCharacter()
    {
        Destroy(gameObject);
    }
}
