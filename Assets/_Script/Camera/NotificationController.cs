using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
   public TMP_Text title;
   public TMP_Text notificationText;

   public RectTransform notificationBar;
   
   public void ShowNotification(string _title, string msg, float dur)
   {
      // Move the notification bar into view

      title.text = _title;
      notificationText.text = msg;
      notificationBar.DOAnchorPosY(-50f, 1f, false).SetEase(Ease.InOutQuad)
         // Once the tween is complete, wait for 'dur' seconds and move the notification back
         .OnComplete(() => {
            // Wait for the duration, then close the notification (you can also set a new tween here)
            DOVirtual.DelayedCall(dur, () => {
               // Move the notification bar back out of view
               notificationBar.DOAnchorPosY(200f, 1f, false).SetEase(Ease.InOutQuad);
            });
         });
   }

}
