using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolView : MonoBehaviour
{
    public int price;
    public GameObject indicator;
    public string id;
    public GameObject lockedIcon;
    public GameObject mainPanel;
    public TMP_Text resultText;
    public bool isLocked;

    public void Start()
    {
        if (PlayerPrefs.HasKey(id) && price > 0)
        {
            if (PlayerPrefs.GetInt(id, 0) == 1)
                isLocked = false;
            else
                isLocked = true;
        }
        else
            isLocked = true;
        
        if(lockedIcon)
            lockedIcon.SetActive(false);

    }

    public void ShowPanel(int id, WaterQualityReport wq)
    {
        
        indicator.SetActive(true);
        mainPanel.SetActive(true);
        resultText.text = "--";
        if (id == 0)
        {
            resultText.text = wq.pHLevel.ToString("F1");
        }
        else if (id == 1)
        {
            resultText.text = wq.alkalinity.ToString("F1");
        }
        else if (id == 2)
        {
            resultText.text = wq.temperature.ToString("F1");
        }
        else if (id == 3)
        {
            resultText.text = wq.density.ToString("F1");
        }
        
        // if (isLocked)
        // {
        //     Debug.Log("Locked!!!");
        //     return;
        // }
        // else
        // {
        //     indicator.SetActive(true);
        //     mainPanel.SetActive(true);
        // }
    }

    public void HidePanel()
    {
        indicator.SetActive(false);
        mainPanel.SetActive(false);
    }
    
}
