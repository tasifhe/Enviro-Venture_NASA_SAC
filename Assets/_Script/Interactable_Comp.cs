using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interactable_Comp : MonoBehaviour
{

    public virtual void Interact()
    {
      
    }


    public bool isInteracting;
    public InteractableType type;
    public int sampleID;

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
    
    
    
    
    
    // Called when script properties are changed in the Inspector
    // private void OnValidate()
    // {
    //     // Check for duplicate sampleID
    //     bool isUnique = SampleController.IsSampleIDUnique(this.gameObject, sampleID);
    //
    //     if (!isUnique)
    //     {
    //         // Log the error in the console and show in Inspector
    //         Debug.LogError($"Duplicate sampleID {sampleID} found in object '{this.gameObject.name}'.");
    //
    //         // Show a popup dialog in the Editor
    //         EditorUtility.DisplayDialog(
    //             "Duplicate Sample ID", 
    //             $"Sample ID {sampleID} is already assigned to another object!", 
    //             "OK"
    //         );
    //     }
    // }

}

public enum InteractableType
{
    FloodWater,
    StagnantWater,
    PaddyField,
    Laboratory,
    
}
