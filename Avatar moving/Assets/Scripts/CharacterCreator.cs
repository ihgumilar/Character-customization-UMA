using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class CharacterCreator : MonoBehaviour
{

    private DynamicCharacterAvatar characterAvatar;
    private Dictionary<string, DnaSetter> DNA;
    
    // Start is called before the first frame update
    void Start()
    {
        characterAvatar = GetComponent<DynamicCharacterAvatar>();
        // This is gonna fire off when there is a value change
        characterAvatar.CharacterUpdated.AddListener(OnCharacterUpdated);
        // Get access to all DNA values, that we will access via code (slider) to modify
        characterAvatar.CharacterCreated.AddListener(OnCharacterCreated);

    }

    void OnCharacterCreated(UMAData data)
    {
        DNA = characterAvatar.GetDNA();
    }

    void OnCharacterUpdated(UMAData data)
    {

    }

}
