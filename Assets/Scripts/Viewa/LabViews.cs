using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabViews : MonoBehaviour
{

    public ToolView[] allTools;
    public WaterQualityReport report;
    public GameObject panel;
    public GameObject summaryPanel;
     int good;
     int bad;
     public TMP_Text resultText;
     public TMP_Text myDecText;
    public TMP_Text[] summaryData;
    private int currentTool;
    public void SelectTool(int index)
    {
        for (int i = 0; i < allTools.Length; i++)
        {
            allTools[i].HidePanel();
        }
        
        allTools[index].ShowPanel(index,report);
        currentTool = index;
    }

    public void StartExamine(WaterQualityReport wq)
    {
        panel.SetActive(true);
        report = wq;
        
        SelectTool(0);
    }
    public void OnGood()
    {
        good++;
        GoNext();
    }

    public void OnBad()
    {
        bad++;
        GoNext();
    }

    void GoNext()
    {
        currentTool++;
        if (currentTool == 4)
            currentTool = 0;
        
        SelectTool(currentTool);

    }

    public void OnSummarize()
    {
        panel.SetActive(false);
        summaryPanel.SetActive(true);
        bool isGood = good >= bad;

        resultText.text = report.isGoodWater ? "Final Result: Good Water" : "Final Result: Bad Water";
        myDecText.color = isGood && report.isGoodWater ? new Color32(23,177,75,255) :new Color32(255,49,48,255);

        myDecText.text = isGood ? "Your Decision: Good Water" : "Your Decision: Bad Water";
        
        
        summaryData[0].text = report.pHLevel.ToString("F1");                // pH Level
        summaryData[1].text = report.dissolvedOxygen.ToString("F1") + " mg/L"; // Dissolved Oxygen
        summaryData[2].text = report.turbidity.ToString("F1") + " NTU";     // Turbidity
        summaryData[3].text = report.temperature.ToString("F1") + " °C";    // Temperature
        summaryData[4].text = report.depth.ToString("F1") + " meters";      // Water Depth
        summaryData[5].text = report.alkalinity.ToString("F1") + " mg/L CaCO3"; // Alkalinity
        summaryData[6].text = report.density.ToString("F1") + " kg/m³";     // Density
        summaryData[7].text = report.isStagnant ? "Yes" : "No";             // Stagnant
        summaryData[8].text = report.nearVegetation ? "Yes" : "No";

        good = 0;
        bad = 0;
    }
}
