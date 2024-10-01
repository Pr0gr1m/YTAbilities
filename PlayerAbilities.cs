using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AYellowpaper.SerializedCollections;

public class PlayerAbilities : MonoBehaviour
{
    [SerializedDictionary("Ability","Level")]
    public SerializedDictionary<AbilityEnum, int> AbilityLevelsDictonary = new SerializedDictionary<AbilityEnum, int>();
    public List<AbilityEnum> RegisteredAbilityEnums;

    public int Experience;
    public Text ExperienceText;

    private void Awake()
    {
        AbilityLevelsDictonary.Clear();

        foreach(AbilityEnum ability in RegisteredAbilityEnums)
        {
            AbilityLevelsDictonary.Add(ability, 0);
        }
    }

    private void Update()
    {
        ExperienceText.text = Experience.ToString();   
    }

    public void UpdradeAbility(AbilityEnum ability, int experience)
    {
        int lvl = AbilityLevelsDictonary[ability];
        AbilityLevelsDictonary.Remove(ability);
        AbilityLevelsDictonary.Add(ability, lvl + 1);

        Experience -= experience;
    }
}

public enum AbilityEnum
{
    Speed, AttackDmg, AttackSpeed, Luck
}
