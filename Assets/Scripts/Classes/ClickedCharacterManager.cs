using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedCharacterManager : MonoBehaviour
{
    public CitytCharacterManager clickedCharacter { get; set; }

    private void Start()
    {
        clickedCharacter = null;
    }

    public void UnClick()
    {
        clickedCharacter = null;
    }
}
