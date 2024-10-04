using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterView : MonoBehaviour
{
    public float pHLevel;
    public float dissolvedOxygen;
    public float turbidity;
    public bool isStagnant;
    public float temperature;
    public float depth;
    public bool nearVegetation;
    public float alkalinity;  // New attribute for alkalinity in mg/L CaCO3

    private void Start()
    {
        pHLevel = Mathf.Round(Random.Range(6.0f, 8.5f) * 10f) / 10f;  // realistic pH range for natural waters
        dissolvedOxygen = Mathf.Round(Random.Range(5.0f, 12.0f) * 10f) / 10f;  // adequate DO for aquatic life
        turbidity = Mathf.Round(Random.Range(0.0f, 30.0f) * 10f) / 10f;  // realistic turbidity for good/bad water
        isStagnant = Random.value > 0.6f;
        temperature = Mathf.Round(Random.Range(15.0f, 30.0f) * 10f) / 10f;  // water temp in Celsius
        depth = Mathf.Round(Random.Range(0.5f, 2.5f) * 10f) / 10f;  // depth in meters
        nearVegetation = Random.value > 0.5f;
        alkalinity = Mathf.Round(Random.Range(50.0f, 150.0f) * 10f) / 10f;  // realistic alkalinity in mg/L
        
        Debug.Log(StandardForDrinking());
        Debug.Log(StandardForAgriculture());
        Debug.Log(StandardForMosquitoHabitat());
    }

    // Analyze whether the water is safe for drinking
    public bool IsWaterSafeForDrinking()
    {
        return pHLevel >= 6.5f && pHLevel <= 8.5f &&
               dissolvedOxygen >= 5.0f &&
               turbidity <= 5.0f &&
               !isStagnant &&
               temperature >= 10.0f && temperature <= 25.0f &&
               !nearVegetation &&
               alkalinity >= 40.0f && alkalinity <= 120.0f;  // New alkalinity range for drinking
    }

    public string PurifyWaterForDrinking()
    {
        string purificationSteps = "Purification Steps for Drinking Water: \n";

        if (pHLevel < 6.5f)
        {
            pHLevel = 6.5f;
            purificationSteps += "- pH level increased to 6.5\n";
        }
        else if (pHLevel > 8.5f)
        {
            pHLevel = 8.5f;
            purificationSteps += "- pH level decreased to 8.5\n";
        }

        if (dissolvedOxygen < 5.0f)
        {
            dissolvedOxygen = 5.0f;
            purificationSteps += "- Dissolved oxygen increased to 5 mg/L\n";
        }

        if (turbidity > 5.0f)
        {
            turbidity = 5.0f;
            purificationSteps += "- Turbidity reduced to 5 NTU\n";
        }

        if (isStagnant)
        {
            isStagnant = false;
            purificationSteps += "- Stagnant water treated\n";
        }

        if (nearVegetation)
        {
            nearVegetation = false;
            purificationSteps += "- Nearby vegetation cleared\n";
        }

        if (alkalinity < 40.0f)
        {
            alkalinity = 40.0f;
            purificationSteps += "- Alkalinity increased to 40 mg/L CaCO3\n";
        }
        else if (alkalinity > 120.0f)
        {
            alkalinity = 120.0f;
            purificationSteps += "- Alkalinity decreased to 120 mg/L CaCO3\n";
        }

        if (IsWaterSafeForDrinking())
        {
            purificationSteps += "Water is now safe for drinking.";
        }
        else
        {
            purificationSteps += "Water could not be fully purified for drinking.";
        }

        return purificationSteps;
    }

    // Analyze whether the water is safe for agricultural use
    public bool IsWaterSafeForAgriculture()
    {
        return pHLevel >= 5.5f && pHLevel <= 7.5f &&
               dissolvedOxygen >= 2.0f &&
               turbidity <= 10.0f &&
               (isStagnant ? depth > 0.5f : true) &&
               temperature >= 15.0f && temperature <= 30.0f &&
               nearVegetation &&
               alkalinity >= 75.0f && alkalinity <= 200.0f;  // Alkalinity range for agriculture
    }

    public string PurifyWaterForAgriculture()
    {
        string purificationSteps = "Purification Steps for Agriculture: \n";

        if (pHLevel < 5.5f)
        {
            pHLevel = 5.5f;
            purificationSteps += "- pH level adjusted to 5.5\n";
        }
        else if (pHLevel > 7.5f)
        {
            pHLevel = 7.5f;
            purificationSteps += "- pH level adjusted to 7.5\n";
        }

        if (turbidity > 10.0f)
        {
            turbidity = 10.0f;
            purificationSteps += "- Turbidity reduced to 10 NTU\n";
        }

        if (dissolvedOxygen < 2.0f)
        {
            dissolvedOxygen = 2.0f;
            purificationSteps += "- Dissolved oxygen increased to 2 mg/L\n";
        }

        if (isStagnant && depth <= 0.5f)
        {
            depth = 0.6f;
            purificationSteps += "- Increased depth to over 0.5m\n";
        }

        if (alkalinity < 75.0f)
        {
            alkalinity = 75.0f;
            purificationSteps += "- Alkalinity increased to 75 mg/L CaCO3\n";
        }
        else if (alkalinity > 200.0f)
        {
            alkalinity = 200.0f;
            purificationSteps += "- Alkalinity reduced to 200 mg/L CaCO3\n";
        }

        if (IsWaterSafeForAgriculture())
        {
            purificationSteps += "Water is now safe for agricultural use.";
        }
        else
        {
            purificationSteps += "Water could not be fully purified for agricultural use.";
        }

        return purificationSteps;
    }

    // Examine and report water quality, including alkalinity
    public string ExamineWater()
    {
        string waterReport = "<b>Water Examination Report:</b>\n";
        waterReport += $"- pH Level: {pHLevel:F1}\n";
        waterReport += $"- Dissolved Oxygen: {dissolvedOxygen:F1} mg/L\n";
        waterReport += $"- Turbidity: {turbidity:F1} NTU\n";
        waterReport += $"- Temperature: {temperature:F1} °C\n";
        waterReport += $"- Water Depth: {depth:F1} meters\n";
        waterReport += $"- Alkalinity: {alkalinity:F1} mg/L CaCO3\n";  // Added alkalinity to report
        waterReport += $"- Stagnant: {(isStagnant ? "Yes" : "No")}\n";
        waterReport += $"- Near Vegetation: {(nearVegetation ? "Yes" : "No")}\n\n";

        return waterReport;
    }

    // Reference values for safe drinking water
    public string StandardForDrinking()
    {
        return "<b>Safe Drinking Water Standards:</b>\n" +
               "- pH Level: 6.5 - 8.5\n" +
               "- Dissolved Oxygen: ≥ 5 mg/L\n" +
               "- Turbidity: ≤ 5 NTU\n" +
               "- Temperature: 10°C - 25°C\n" +
               "- Alkalinity: 40 - 120 mg/L CaCO3\n" +
               "- No stagnant water\n" +
               "- No nearby vegetation";
    }

    // Reference values for agricultural water
    public string StandardForAgriculture()
    {
        return "<b>Agricultural Water Standards:</b>\n" +
               "- pH Level: 5.5 - 7.5\n" +
               "- Dissolved Oxygen: ≥ 2 mg/L\n" +
               "- Turbidity: ≤ 10 NTU\n" +
               "- Temperature: 15°C - 30°C\n" +
               "- Alkalinity: 75 - 200 mg/L CaCO3\n" +
               "- If stagnant, depth > 0.5 meters\n" +
               "- Vegetation nearby is beneficial";
    }

    // Reference values for mosquito habitat identification
    public string StandardForMosquitoHabitat()
    {
        return "<b>Mosquito Habitat Identification:</b>\n" +
               "- Stagnant water present\n" +
               "- Temperature: 15°C - 30°C\n" +
               "- Vegetation nearby";
    }
}
