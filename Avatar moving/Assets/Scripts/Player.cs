using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class Player : MonoBehaviour
{
    public DynamicCharacterAvatar characterAvatar;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        characterAvatar = GetComponent<DynamicCharacterAvatar>();
        //characterAvatar.CharacterCreated.AddListener(OnCharacterCreated);

        // If I put the following two lines into a function and called from the line that was commented above,
        // it doesn't load the SAVED avatar. With this current structure, it can load the avatar (without calling function).
        characterAvatar.LoadFromRecipeString(PlayerPrefs.GetString("CharacterData"));
        characterAvatar.BuildCharacter();

        animator = GetComponent<Animator>();    
        
    }

    private void Update()
    {
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        animator.SetFloat("Direction", Input.GetAxis("Horizontal"));
    }

    //void OnCharacterCreated(UMAData data)
    //{
    //    characterAvatar.LoadFromRecipeString(PlayerPrefs.GetString("CharacterData"));
    //    characterAvatar.BuildCharacter();
    //    Debug.Log("The function is called");
    //}

}

