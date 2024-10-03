using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterView : MonoBehaviour
{
    
    public float pHLevel;
    public float dissolvedOxygen;
    public float turbidity;
    public bool isStagnant;  // New attribute to indicate if the water is stagnant
    public float temperature;  // New attribute for water temperature (in degrees Celsius)
    public float depth;  // Water depth in meters
    public bool nearVegetation;
    
    private void Start()
    {
        pHLevel = Random.Range(5.0f, 9.0f);
        dissolvedOxygen = Random.Range(3.0f, 12.0f);
        turbidity = Random.Range(0.0f, 50.0f);
        isStagnant = Random.value > 0.7f;
        temperature = Random.Range(10.0f, 35.0f);
        depth = Random.Range(0.1f, 2.0f);
        nearVegetation = Random.value > 0.7f;

        
        
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
               !isStagnant &&  // Water should not be stagnant
               temperature >= 10.0f && temperature <= 25.0f &&  // Temperature range for drinking safety
               !nearVegetation;  // Should not be near vegetation
    }
    
    public string PurifyWaterForDrinking()
    {
        string purificationSteps = "Purification Steps for Drinking Water: \n";

        // Adjust pH level
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

        // Increase dissolved oxygen
        if (dissolvedOxygen < 5.0f)
        {
            dissolvedOxygen = 5.0f;
            purificationSteps += "- Dissolved oxygen increased to 5 mg/L\n";
        }

        // Reduce turbidity
        if (turbidity > 5.0f)
        {
            turbidity = 5.0f;
            purificationSteps += "- Turbidity reduced to 5 NTU\n";
        }

        // Treat stagnant water
        if (isStagnant)
        {
            isStagnant = false;  // Simulate draining or treating the stagnant water
            purificationSteps += "- Stagnant water treated\n";
        }

        // Clear nearby vegetation
        if (nearVegetation)
        {
            nearVegetation = false;  // Simulate clearing the vegetation near the water
            purificationSteps += "- Nearby vegetation cleared\n";
        }

        // After purification, return the summary
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
               (isStagnant ? depth > 0.5f : true) &&  // If stagnant, ensure water depth is more than 0.5m for irrigation
               temperature >= 15.0f && temperature <= 30.0f &&  // Slightly broader temperature range
               nearVegetation;  // Vegetation nearby can help agricultural use
    }
    
    public string PurifyWaterForAgriculture()
    {
        string purificationSteps = "Purification Steps for Agriculture: \n";

        // Adjust pH level
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

        // Reduce turbidity
        if (turbidity > 10.0f)
        {
            turbidity = 10.0f;
            purificationSteps += "- Turbidity reduced to 10 NTU\n";
        }

        // Increase dissolved oxygen
        if (dissolvedOxygen < 2.0f)
        {
            dissolvedOxygen = 2.0f;
            purificationSteps += "- Dissolved oxygen increased to 2 mg/L\n";
        }

        // Ensure adequate depth for stagnant water
        if (isStagnant && depth <= 0.5f)
        {
            depth = 0.6f;  // Artificially increase depth to make it suitable for agriculture
            purificationSteps += "- Increased depth to over 0.5m\n";
        }

        // After purification, return the summary
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
    
    // Check if the environment is a potential mosquito habitat
    public bool IsMosquitoHabitat()
    {
        return isStagnant && nearVegetation && temperature >= 15.0f && temperature <= 30.0f;
    }

    // Remove mosquito habitat by addressing stagnant water and vegetation
    public string RemoveMosquitoHabitat()
    {
        string removalSteps = "Mosquito Habitat Removal Steps: \n";

        // Treat stagnant water
        if (isStagnant)
        {
            isStagnant = false;  // Drain or apply treatment to stagnant water
            removalSteps += "- Stagnant water treated\n";
        }

        // Address nearby vegetation
        if (nearVegetation)
        {
            nearVegetation = false;  // Simulate cutting down or clearing vegetation
            removalSteps += "- Vegetation near water removed\n";
        }

        // After removal, return the summary
        if (!IsMosquitoHabitat())
        {
            removalSteps += "Mosquito habitat successfully eliminated.";
        }
        else
        {
            removalSteps += "Could not fully remove mosquito habitat.";
        }

        return removalSteps;
    }
    
    // Reference values for safe drinking water
    public string StandardForDrinking()
    {
        return "<b>Safe Drinking Water Standards:</b>\n" +
               "- pH Level: 6.5 - 8.5\n" +
               "- Dissolved Oxygen: ≥ 5 mg/L\n" +
               "- Turbidity: ≤ 5 NTU\n" +
               "- Temperature: 10°C - 25°C\n" +
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
    
    public string ExamineWater()
    {
        string waterReport = "<b>Water Examination Report:</b>\n";
        waterReport += $"- pH Level: {pHLevel:F1}\n";
        waterReport += $"- Dissolved Oxygen: {dissolvedOxygen:F1} mg/L\n";
        waterReport += $"- Turbidity: {turbidity:F1} NTU\n";
        waterReport += $"- Temperature: {temperature:F1} °C\n";
        waterReport += $"- Water Depth: {depth:F1} meters\n";
        waterReport += $"- Stagnant: {(isStagnant ? "Yes" : "No")}\n";
        waterReport += $"- Near Vegetation: {(nearVegetation ? "Yes" : "No")}\n\n";

        // waterReport += "<b>Safety Analysis:</b>\n";
        //
        // if (IsWaterSafeForDrinking())
        // {
        //     waterReport += "- The water is safe for drinking.\n";
        // }
        // else
        // {
        //     waterReport += "- The water is NOT safe for drinking.\n";
        // }
        //
        // if (IsWaterSafeForAgriculture())
        // {
        //     waterReport += "- The water is suitable for agricultural use.\n";
        // }
        // else
        // {
        //     waterReport += "- The water is NOT suitable for agricultural use.\n";
        // }
        //
        // if (IsMosquitoHabitat())
        // {
        //     waterReport += "- This environment is a potential mosquito habitat.\n";
        // }
        // else
        // {
        //     waterReport += "- This environment is NOT a potential mosquito habitat.\n";
        // }

        return waterReport;
    }
}
