using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class Player : MonoBehaviour
{
    public DynamicCharacterAvatar characterAvatar;

    // Start is called before the first frame update
    void Start()
    {
        characterAvatar = GetComponent<DynamicCharacterAvatar>();
        //characterAvatar.CharacterCreated.AddListener(OnCharacterCreated);
        characterAvatar.LoadFromRecipeString(PlayerPrefs.GetString("CharacterData"));
        characterAvatar.BuildCharacter();
    }

    //void OnCharacterCreated(UMAData data)
    //{
    //    characterAvatar.LoadFromRecipeString(PlayerPrefs.GetString("CharacterData"));
    //    characterAvatar.BuildCharacter();
    //    Debug.Log("The function is called");
    //}

}

