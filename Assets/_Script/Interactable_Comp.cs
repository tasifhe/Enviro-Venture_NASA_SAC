using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Comp : MonoBehaviour
{

    public virtual void Interact()
    {
        isInteracting = true;
        Debug.Log("Interact on base!");
    }


    public bool isInteracting;
    public InteractableType type;
    

    public void OnInteract()
    {
        Debug.Log(this.gameObject.name);
        isInteracting = true;
        OnInteractReset();
    }

    void OnInteractReset()
    {
        if (isInteracting)
        {
            Invoke("SetIsInteractingStateFalse", 0.5f);
        }
    }
   
    public void SetIsInteractingStateFalse()
    {
        isInteracting = false;
    }

}

public enum InteractableType
{
    FloodWater,
    StagnantWater,
    PaddyField,
    Laboratory,
    
}
