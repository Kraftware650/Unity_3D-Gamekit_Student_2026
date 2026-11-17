using System;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.Events;

public class AudioTrigger : MonoBehaviour
{
    [Header("The trigger can either be used in an existing unityEvent...")]
    [Tooltip("Destroys the trigger after use")]
    [SerializeField] private bool singleUse;
    [Header("...or by connecting it to a trigger and using the built in unityEvents below")]
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    private EventInstance eventInstance;
    
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
        if (singleUse && onTriggerEnter != null)
        {
            Destroy(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
        if (singleUse && onTriggerExit != null)
        {
            Destroy(this);
        }
    }

    public void EventToImpact(string eventName)
    {
        
    }

    public void Play()
    {

    }

    public void Stop()
    {
        
    }

    public void StopImmediate()
    {
        
    }
    
    public void ParameterToImpact(string parameterName)
    {
        
    }

    public void SetParameterValue(float value)
    {
        
    }
}
