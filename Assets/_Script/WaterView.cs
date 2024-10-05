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
    public float alkalinity;
    public float density;  // New attribute for water density in kg/m³
    private bool isGoodWater = false;
    private void Start()
    {
        // Determine if the water is good (50% chance)
         isGoodWater = Random.value > 0.5f;

        if (isGoodWater)
        {
            // Generate good water parameters
            pHLevel = Mathf.Round(Random.Range(6.5f, 8.5f) * 10f) / 10f;  
            dissolvedOxygen = Mathf.Round(Random.Range(5.0f, 12.0f) * 10f) / 10f;  
            turbidity = Mathf.Round(Random.Range(0.0f, 5.0f) * 10f) / 10f;  // Ensure turbidity is low
            isStagnant = Random.value > 0.6f;
            temperature = Mathf.Round(Random.Range(10.0f, 25.0f) * 10f) / 10f;  
            depth = Mathf.Round(Random.Range(0.5f, 2.5f) * 10f) / 10f;  
            nearVegetation = Random.value < 0.5f; // 50% chance for vegetation
            alkalinity = Mathf.Round(Random.Range(40.0f, 120.0f) * 10f) / 10f;  
            density = Mathf.Round(Random.Range(997.0f, 1003.0f) * 10f) / 10f;  // Normal density range
        }
        else
        {
            // Generate bad water parameters (out of acceptable ranges)
            pHLevel = Mathf.Round(Random.Range(5.0f, 6.4f) * 10f) / 10f;  // Too low for drinking
            dissolvedOxygen = Mathf.Round(Random.Range(0.0f, 4.9f) * 10f) / 10f;  // Too low
            turbidity = Mathf.Round(Random.Range(10.0f, 30.0f) * 10f) / 10f;  // Too high
            isStagnant = true;  // Bad water is stagnant
            temperature = Mathf.Round(Random.Range(26.0f, 35.0f) * 10f) / 10f;  // Too hot
            depth = Mathf.Round(Random.Range(0.1f, 0.4f) * 10f) / 10f;  // Too shallow
            nearVegetation = Random.value < 0.8f; // High chance for vegetation
            alkalinity = Mathf.Round(Random.Range(0.0f, 39.9f) * 10f) / 10f;  // Too low
            density = Mathf.Round(Random.Range(990.0f, 996.9f) * 10f) / 10f;  // Out of normal range
        }

        // Log the standards for reference
        Debug.Log(StandardForDrinking());
        Debug.Log(StandardForAgriculture());
        Debug.Log(StandardForMosquitoHabitat());
    }

    public bool IsWaterSafeForDrinking()
    {
        return pHLevel >= 6.5f && pHLevel <= 8.5f &&
               dissolvedOxygen >= 5.0f &&
               turbidity <= 5.0f &&
               !isStagnant &&
               temperature >= 10.0f && temperature <= 25.0f &&
               !nearVegetation &&
               alkalinity >= 40.0f && alkalinity <= 120.0f &&
               density >= 997.0f && density <= 1003.0f;  // Density within standard range
    }

    public bool IsWaterSafeForAgriculture()
    {
        return pHLevel >= 5.5f && pHLevel <= 7.5f &&
               dissolvedOxygen >= 2.0f &&
               turbidity <= 10.0f &&
               (isStagnant ? depth > 0.5f : true) &&
               temperature >= 15.0f && temperature <= 30.0f &&
               nearVegetation &&
               alkalinity >= 75.0f && alkalinity <= 200.0f &&
               density >= 995.0f && density <= 1025.0f;  // Density range for agriculture
    }

    public bool IsSuitableForMosquitoHabitat()
    {
        return pHLevel >= 6.0f && pHLevel <= 8.0f &&
               dissolvedOxygen >= 3.0f &&
               turbidity >= 10.0f && turbidity <= 30.0f &&
               temperature >= 20.0f && temperature <= 32.0f &&
               isStagnant &&
               alkalinity >= 50.0f && alkalinity <= 150.0f &&
               density >= 995.0f && density <= 1020.0f;  // Suitable density for mosquito habitat
    }

    public string StandardForDrinking()
    {
        string report = "Water standards for drinking:\n";
        report += "- pH Level: 6.5 to 8.5\n";
        report += "- Dissolved Oxygen: ≥ 5 mg/L\n";
        report += "- Turbidity: ≤ 5 NTU\n";
        report += "- Temperature: 10 to 25°C\n";
        report += "- Alkalinity: 40 to 120 mg/L CaCO3\n";
        report += "- Density: 997 to 1003 kg/m³\n";  // Density standard for drinking water
        return report;
    }

    public string StandardForAgriculture()
    {
        string report = "Water standards for agriculture:\n";
        report += "- pH Level: 5.5 to 7.5\n";
        report += "- Dissolved Oxygen: ≥ 2 mg/L\n";
        report += "- Turbidity: ≤ 10 NTU\n";
        report += "- Temperature: 15 to 30°C\n";
        report += "- Alkalinity: 75 to 200 mg/L CaCO3\n";
        report += "- Density: 995 to 1025 kg/m³\n";  // Density standard for agriculture
        return report;
    }

    public string StandardForMosquitoHabitat()
    {
        string report = "Water standards for mosquito habitat:\n";
        report += "- pH Level: 6.0 to 8.0\n";
        report += "- Dissolved Oxygen: ≥ 3 mg/L\n";
        report += "- Turbidity: 10 to 30 NTU\n";
        report += "- Temperature: 20 to 32°C\n";
        report += "- Alkalinity: 50 to 150 mg/L CaCO3\n";
        report += "- Density: 995 to 1020 kg/m³\n";  // Density suitable for mosquito habitat
        return report;
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

        if (density < 997.0f)
        {
            density = 997.0f;
            purificationSteps += "- Density increased to 997 kg/m³\n";
        }
        else if (density > 1003.0f)
        {
            density = 1003.0f;
            purificationSteps += "- Density decreased to 1003 kg/m³\n";
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

    public WaterQualityReport ExamineWater()
    {
        WaterQualityReport report = new WaterQualityReport(
            pHLevel,
            dissolvedOxygen,
            turbidity,
            temperature,
            depth,
            alkalinity,
            density,
            isStagnant,
            nearVegetation,
            isGoodWater
        );

        return report;
    }
}

[System.Serializable]
public class WaterQualityReport
{
    public float pHLevel;
    public float dissolvedOxygen;
    public float turbidity;
    public float temperature;
    public float depth;
    public float alkalinity;
    public float density;
    public bool isStagnant;
    public bool nearVegetation;
    public bool isGoodWater;
    public WaterQualityReport()
    {
        
    }
    public WaterQualityReport(float pH, float DO, float turbidity, float temp, float depth, float alkalinity, float density, bool stagnant, bool vegetation, bool isGoodWater)
    {
        this.pHLevel = pH;
        this.dissolvedOxygen = DO;
        this.turbidity = turbidity;
        this.temperature = temp;
        this.depth = depth;
        this.alkalinity = alkalinity;
        this.density = density;
        this.isStagnant = stagnant;
        this.nearVegetation = vegetation;
        this.isGoodWater = isGoodWater;
    }
}
