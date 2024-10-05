using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabTable : Interactable_Comp
{

   public GameObject examinationSummary;
   public TMP_Text reportSummary;
   public TMP_Text standardValue;

   public LabViews lab;
   public override void Interact() {
      if (Controller.instance.LabController.HasSamples())
      {
         Controller.instance.InteractionController.StartInteracting(() =>
         {
            standardValue.text = Controller.instance.LabController.GetStandardValue();
            WaterQualityReport report = Controller.instance.LabController.ExamineSample();
            lab.StartExamine(report);
         });
         
      }
      else
      {
         Controller.instance.NotificationController.ShowNotification("No Samples!!","Please collect samples to examine",3f);
      }

   }
}
