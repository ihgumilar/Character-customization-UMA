using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;
using UnityEngine.UI;
using System;

public class CharacterCreator : MonoBehaviour
{

    private DynamicCharacterAvatar characterAvatar;
    private Dictionary<string, DnaSetter> DNA;
    [SerializeField]
    private Slider heightSlider, muscleSlider, weightSlider;

    [SerializeField]
    private UMAWardrobeRecipe[] maleHair, femaleHair;

    [SerializeField]
    private Color[] skinColors;

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

    private void OnDisable()
    {
        {
            // if it is not used, then we disable all listeners. To prevent memory leak issues
            characterAvatar.CharacterUpdated.RemoveListener(OnCharacterUpdated);
            characterAvatar.CharacterCreated.RemoveListener(OnCharacterCreated);
            heightSlider.onValueChanged.RemoveListener(OnHeightChange);
            weightSlider.onValueChanged.RemoveListener(OnWeightChange);
            muscleSlider.onValueChanged.RemoveListener(OnMuscleChange);
        }
    }

    public void SaveCharacter()
    {
        PlayerPrefs.SetString("CharacterData", characterAvatar.GetCurrentRecipe());
    }

    public void ChangeSex(int sex)
    {
        characterAvatar.ChangeRace(sex == 0 ? "HumanFemaleDCS" : "HumanMaleDCS");
        characterAvatar.BuildCharacter();
    }

    public void ChangeHair(int hair)
    {
        if(characterAvatar.activeRace.name == "HumanMaleDCS")
        {
            characterAvatar.SetSlot(maleHair[hair]);
        }
        if(characterAvatar.activeRace.name == "HumanFemaleDCS")
        {
            characterAvatar.SetSlot(femaleHair[hair]);
        }
        characterAvatar.BuildCharacter();
    }

    public void ChangeSkinColor(int skinColor)
    {
        characterAvatar.SetColor("Skin", skinColors[skinColor]);
        characterAvatar.UpdateColors(true);
    }

    void OnCharacterCreated(UMAData data)
    {
        DNA = characterAvatar.GetDNA();
    }

    void OnCharacterUpdated(UMAData data)
    {
        DNA = characterAvatar.GetDNA();
        UpdateSliders();
    }

    void UpdateSliders()
    {
        heightSlider.value = DNA["height"].Get();
        weightSlider.value = DNA["upperWeight"].Get();
        muscleSlider.value = DNA["upperMuscle"].Get();
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
