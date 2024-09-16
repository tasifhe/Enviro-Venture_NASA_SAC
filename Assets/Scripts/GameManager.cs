using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int platformCount = 0;
    public TextMeshProUGUI platformCountText; // Reference to a UI text element to display the platform count

    public void IncrementPlatformCount()
    {
        platformCount++;
        UpdatePlatformCountText();
    }

    private void UpdatePlatformCountText()
    {
        if (platformCountText != null)
        {
            platformCountText.text = " " + platformCount;
        }
    }
}
