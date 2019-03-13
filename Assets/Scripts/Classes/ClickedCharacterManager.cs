using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedCharacterManager : MonoBehaviour
{
    public CitytCharacterManager clickedCharacter { get; set; }

    public void UnClick()
    {
        clickedCharacter = null;
    }
}
