using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class LabController : MonoBehaviour
{
    public List<Sample> samples = new List<Sample>();
    public List<WaterView> views = new List<WaterView>();
    public void AddSample(Interactable_Comp _samp)
    {
        if (!HasSample(_samp.sampleID))
        {
            Sample _sample = new Sample();
            _sample.sampleType = _samp.type;
            _sample.sampleID = _samp.sampleID;
            _sample.examined = false;
            _sample.collectionTime = DateTime.Now;
            
            samples.Add(_sample);

            if (_samp.type == InteractableType.FloodWater || _samp.type == InteractableType.StagnantWater)
            {
                views.Add(_samp.GetComponent<WaterView>());
            }
            
            Controller.instance.NotificationController.ShowNotification($"Sample Collected",$"You have just collected {SampleName()} sample",2f);
        }

    }

    public string ExamineSample()
    {
        int index = samples.FindIndex(_sample => _sample.examined == false);

        if (index != -1)
        {
            Controller.instance.NotificationController.ShowNotification($"Examined!!",$"You have just examined the {SampleName()}",3f);
            samples[index].examined = true;

            if (samples[index].sampleType == InteractableType.FloodWater ||
                samples[index].sampleType == InteractableType.StagnantWater)
            {
                return views[index].ExamineWater();
            }
            else
            {
                return "";
            }
            
        }
        else
        {
            Debug.LogError("No Sample");
            return "";
        }
    }

    public string GetStandardValue()
    {
        int index = samples.FindIndex(_sample => _sample.examined == false);

        if (index != -1)
        {

            if (samples[index].sampleType == InteractableType.FloodWater ||
                samples[index].sampleType == InteractableType.StagnantWater)
            {
                return views[index].StandardForDrinking() + "\n\n" + views[index].StandardForAgriculture()+ "\n\n" + views[index].StandardForMosquitoHabitat();
            }
            else
            {
                return "";
            }
            
        }
        else
        {
            Debug.LogError("No Sample");
            return "";
        }
    }

    
    public bool HasSample(int id)
    {
        int index =samples.FindIndex(_sample => _sample.sampleID == id);

        if (index != -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasSamples()
    {
        int index = samples.FindIndex(_sam => _sam.examined == false);
        return samples.Count >= 1 && index != -1;
    }

    public string SampleName()
    {
        if (HasSamples())
        {
            int index = samples.FindIndex(_sam => _sam.examined == false);
            string sampleTypeName = samples[index].sampleType.ToString();

            // Use Regex to add space before each capital letter (except the first one)
            string formattedName = Regex.Replace(sampleTypeName, "(?<!^)([A-Z])", " $1");

            return formattedName;
        }
        else
        {
            return "";
        }
    }
    public void CompareSampleTimes(int id)
    {
        int index = samples.FindIndex(_sample => _sample.sampleID == id);

        if (index != -1)
        {
            Sample foundSample = samples[index];

            DateTime now = DateTime.Now;
            TimeSpan timeSinceCollection = now - foundSample.collectionTime;

            // Example: If more than an hour has passed since collection
            if (timeSinceCollection.TotalHours > 1)
            {
                Console.WriteLine("More than 1 hour has passed since the sample was collected.");
            }
            else
            {
                Console.WriteLine("Less than 1 hour has passed since the sample was collected." + timeSinceCollection.TotalHours);
            }
        }
    }
}

[Serializable]
public class Sample
{
    public int sampleID;
    public InteractableType sampleType;
    public bool examined;
    public DateTime collectionTime;
    public Interactable_Comp _sample;
    public Sample()
    {
        
    }
}
