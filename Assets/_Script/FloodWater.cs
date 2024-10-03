using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloodWater : Interactable_Comp
{
    public override void Interact() {
        
        if (Controller.instance.LabController.HasSample(Controller.instance.InteractionController.cic.currentInteractable.sampleID))
        {
            Controller.instance.NotificationController.ShowNotification("Duplicate Sample","You have already collected the sample",2f);
            return;
        }
        
        isInteracting = true;

        Controller.instance.InteractionController.StartInteracting(() =>
        {
            Controller.instance.LabController.AddSample(this);
            isInteracting = false;
        });
       
    }
}
