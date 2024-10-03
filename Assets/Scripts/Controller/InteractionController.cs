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
            if (!interactButton.IsActive())
            {
                interactButton.GetComponentInChildren<TMP_Text>().text =
                    DetermineButtonText(cic.currentInteractable.type);
                interactButton.gameObject.SetActive(true);
                
                interactButton.onClick.AddListener(delegate
                {
                    cic.currentInteractable.Interact();
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

    public void StartInteracting(Action ac)
    {
        interactButton.GetComponentInChildren<TMP_Text>().text =
            DetermineInteractingText(cic.currentInteractable.type);

        interactingIndicator.DOFillAmount(1, 2f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            cic.currentInteractable.isInteracting = false;
            interactButton.GetComponentInChildren<TMP_Text>().text =
                DetermineButtonText(cic.currentInteractable.type);
            interactingIndicator.fillAmount = 0;
            ac?.Invoke();
        });
    }

    string DetermineButtonText(InteractableType type)
    {
        switch (type)
        {
            case InteractableType.Laboratory:
                return $"EXAMINE-{Controller.instance.LabController.SampleName()}";
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
