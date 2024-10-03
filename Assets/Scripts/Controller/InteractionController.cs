using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public CharacterInteractionCore cic;
    public Button interactButton;
    public Image interactingIndicator;
    
    private void Update()
    {
        if (cic.currentInteractable)
        {
            Debug.Log("Can interact with " + cic.currentInteractable.name);

            if (!interactButton.IsActive())
            {
                interactButton.GetComponentInChildren<TMP_Text>().text =
                    DetermineButtonText(cic.currentInteractable.type);
                interactButton.gameObject.SetActive(true);
                
                interactButton.onClick.AddListener(delegate
                {
                    // interactButton.interactable = false;
                    interactButton.GetComponentInChildren<TMP_Text>().text =
                        DetermineInteractingText(cic.currentInteractable.type);

                    cic.currentInteractable.isInteracting = true;
                    interactingIndicator.DOFillAmount(1, 2f).SetEase(Ease.InOutQuad).OnComplete(() =>
                    {
                        cic.currentInteractable.isInteracting = false;
                        interactButton.GetComponentInChildren<TMP_Text>().text =
                            DetermineButtonText(cic.currentInteractable.type);
                        interactingIndicator.fillAmount = 0;
                        cic.currentInteractable.Interact();

                    });
                    
                });
            }
         
        }   
        else
        {
            if (interactButton.IsActive())
            {
                interactButton.gameObject.SetActive(false);
                interactButton.onClick.RemoveAllListeners();
            }
        }
    }

    string DetermineButtonText(InteractableType type)
    {
        switch (type)
        {
            case InteractableType.Laboratory:
                return "EXAMINE";
                break;
            case InteractableType.FloodWater:
            case InteractableType.StagnantWater:
                return "COLLECT SAMPLE";
                break;
            default:
                return "INTERACT";
                break;
        }
    }
    
    string DetermineInteractingText(InteractableType type)
    {
        switch (type)
        {
            case InteractableType.Laboratory:
                return "EXAMINING";
                break;
            case InteractableType.FloodWater:
            case InteractableType.StagnantWater:
                return "COLLECTING";
                break;
            default:
                return "INTERACTING";
                break;
        }
    }
}
