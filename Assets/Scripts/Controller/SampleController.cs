using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    // Static dictionary to track assigned sample IDs globally
    public static Dictionary<int, GameObject> assignedSamples = new Dictionary<int, GameObject>();

    // Check if the sampleID is unique
    public static bool IsSampleIDUnique(GameObject obj, int sampleID)
    {
        // Check if the sampleID is already assigned to another object
        if (assignedSamples.ContainsKey(sampleID))
        {
            GameObject existingObj = assignedSamples[sampleID];
            if (existingObj != obj)
            {
                return false; // sampleID is already assigned to another object
            }
        }

        // If unique or updating the same object, update the dictionary
        assignedSamples[sampleID] = obj;
        return true; // sampleID is unique
    }
}
