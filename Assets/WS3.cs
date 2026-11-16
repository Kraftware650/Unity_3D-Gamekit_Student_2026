using System;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.Events;

public class WS3 : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    [SerializeField] private bool singleUse;
    [SerializeField] EventReference eventReference;
    [SerializeField] private bool play;
    [SerializeField] private bool stop;
    
    [Header("Parameter settings")]
    [SerializeField] private bool setParameter;
    [SerializeField] private string parameterName;
    [SerializeField] private float parameterValue;
    private EventInstance eventInstance;
     
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstance.start();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (play)
        {
            eventInstance.start();
        }

        if (stop)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if (setParameter)
        {
            eventInstance.setParameterByName(parameterName, parameterValue);
        }
    }

    public void Play()
    {
        eventInstance.start();
    }
}
