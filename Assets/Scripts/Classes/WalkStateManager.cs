using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStateManager : MonoBehaviour
{
    [SerializeField]
    ClickToMove clickToMove = null;

    [SerializeField]
    CharacterManager characterManager = null;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        clickToMove.WalkingStateChanged += (object sender, ClickToMove.WalkingStateChangedEventArgs args) =>
        {
            if (animator != null)
            {
                animator.SetBool("Walking", args.newState);
            }
        };

        characterManager.characterChanged += (object sender, CharacterManager.CharacterChangedEventArgs args) => {
            animator = args.newCharacterObject.transform.GetChild(0).GetComponent<Animator>();
        };

        animator = characterManager.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
