using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    public GameObject Panel;
    public Text Name, Description, Cost;
    public Button Buy, Cancel;

    private AbilityButton button;
    private bool isOn = true;


    private void Update()
    {
        Panel.SetActive(isOn);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Tab))
        {
            if(Buy.interactable)
            {
                if(button)
                {
                    OnBuyClick();
                }
            }
        }
    }

    public void SetAbility(AbilityButton button)
    {
        isOn = true;

        this.button = button;
        Name.text = button.nameText.text;
        Cost.text = button.costText.text;

        Color imgColor = button.NotAvaibleButton;

        Buy.interactable = false;
        if (button.isBought)
        {
            imgColor = button.BoughtColor;
        } else
        {
            if (button.prevButton)
            {
                if (button.prevButton.isBought)
                {
                    Buy.interactable = true;
                    imgColor = button.AvaibleColor;
                }
            }

            if(button.isFirstInList)
            {
                Buy.interactable = true;
                imgColor = button.AvaibleColor;
            }
        }

        Buy.gameObject.GetComponent<Image>().color = imgColor;
    }

    public void OnBuyClick()
    {
        int exp = button.abilities.Experience;

        if (exp >= button.ExperienceNeeded)
        {
            button.isBought = true;

            button.abilities.UpdradeAbility(button.abilityType, button.ExperienceNeeded);
        
            button.image.color = button.BoughtColor;

            Buy.image.color = button.BoughtColor;
            Buy.interactable = false;

            if (button.nextButton)
            {
                button.connectionImage.color = button.AvaibleColor;
                button.nextButton.TriggerAvaibleColor();
            }

            if (button.prevButton)
            {
                button.prevButton.connectionImage.color = button.BoughtColor;
            }
        }
        else
        {
            print("NOT ENOUGH");
        }
    }

    public void OnCancelClick()
    {
        isOn = false;
    }
}
