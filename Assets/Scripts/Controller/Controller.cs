using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;

    public InteractionController InteractionController;
    public NotificationController NotificationController;
    public LabController LabController;
    public SampleController SampleController;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
}
