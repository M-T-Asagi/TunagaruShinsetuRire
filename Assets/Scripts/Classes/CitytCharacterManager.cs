using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitytCharacterManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int characterID = 0;
    public int CharacterID { get { return characterID; } }

    [SerializeField]
    int wantObjectID = 0;
    public int WantObjectID { get { return wantObjectID; } }

    [SerializeField]
    string characterControllerTagName = "CharacterController";

    [SerializeField]
    LayerMask layerMask = new LayerMask();

    ClickToMove clickToMove;

    private void Start()
    {
        clickToMove = GameObject.FindGameObjectWithTag(characterControllerTagName).GetComponent<ClickToMove>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.GetComponent<ClickedCharacterManager>().clickedCharacter = this;

        RaycastHit raycastHit = new RaycastHit();
        if (Physics.Raycast(((PointerEventData)eventData).pointerCurrentRaycast.worldPosition, Vector3.down, out raycastHit, 1))
        {
            clickToMove.SetNavigateTo(raycastHit.point);
        }
        else
        {
            clickToMove.SetNavigateTo(((PointerEventData)eventData).pointerCurrentRaycast.worldPosition);
        }
    }

    public void RemoveCharacter()
    {
        Destroy(gameObject);
    }
}
