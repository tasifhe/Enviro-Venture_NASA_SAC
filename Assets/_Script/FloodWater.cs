using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodWater : Interactable_Comp
{
    public override void Interact() {
        if (!isInteracting)
        {
            Controller.instance.NotificationController.ShowNotification("Sample Collected","You just collected flood water sample",3f);
        }

    }
}
