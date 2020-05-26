using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;
using UnityEngine.UI;


public class CharacterCreator : MonoBehaviour
{

    private DynamicCharacterAvatar characterAvatar;
    private Dictionary<string, DnaSetter> DNA;
    [SerializeField]
    private Slider heightSlider, muscleSlider, weightSlider;

    // Start is called before the first frame update
    void Start()
    {
        characterAvatar = GetComponent<DynamicCharacterAvatar>();
        // This is gonna fire off when there is a value change
        characterAvatar.CharacterUpdated.AddListener(OnCharacterUpdated);

        // Get access to all DNA values, that we will access via code (slider) to modify
        characterAvatar.CharacterCreated.AddListener(OnCharacterCreated);

        // Connect height slider with DNA attribute to change
        heightSlider.onValueChanged.AddListener(OnHeightChange);

        // Connect muscle slider with DNA attribute to change
        muscleSlider.onValueChanged.AddListener(OnMuscleChange);

        // Connect weight slider with DNA attribute to change
        weightSlider.onValueChanged.AddListener(OnWeightChange);

    }

    void OnCharacterCreated(UMAData data)
    {
        DNA = characterAvatar.GetDNA();
    }

    void OnCharacterUpdated(UMAData data)
    {

    }

    void OnHeightChange(float height)
    {
        // Set the height based on given values from the slider
        DNA["height"].Set(height);
        // Build avatar to see changes
        characterAvatar.BuildCharacter();
    }

    void OnMuscleChange(float muscle)
    {
        // Lower muscle, feel free to change with another variable, in this case is the same
        DNA["lowerMuscle"].Set(muscle); // Lower muscle
        // Upper muscle, feel free to change with another variable, in this case is the same
        DNA["upperMuscle"].Set(muscle); // Upper muscle, feel free to change with another variable
        // Build avatar to see changes
        characterAvatar.BuildCharacter();
    }

    void OnWeightChange(float weight)
    {
        // Lower weight, feel free to change with another variable, in this case is the same
        DNA["lowerWeight"].Set(weight);
        // Upper weight, feel free to change with another variable, in this case is the same
        DNA["upperWeight"].Set(weight);
        // Build avatar to see changes
        characterAvatar.BuildCharacter();
    }

}
