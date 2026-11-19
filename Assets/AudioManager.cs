using System;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using NUnit.Framework;

public enum AudioType
{
    music,
    sound
}

[System.Serializable]
public struct AudioEvents
{
    public string eventName;
    public AudioType audioType;
    public EventReference eventReference;
}

[System.Serializable]
public struct EventInstances
{
    public string eventName;
    public EventInstance eventInstance;
}

public class AudioManager : MonoBehaviour
{
    [HideInInspector] public string eventName;
    [HideInInspector] public bool allowFadeOut;
    [HideInInspector] public string parameterName;
    [HideInInspector] public float parameterValue;

    [HideInInspector] public int enemiesTargetingPlayer = 0;
    
    [SerializeField] private AudioEvents[] audioEvents;
    private List<EventInstances> activeEvents = new List<EventInstances>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play()
    {
        foreach (EventInstances activeEvent in activeEvents)
        {
            if (activeEvent.eventName == eventName)
            {
                return;
            }
        }
        
        foreach (AudioEvents audioEvent in audioEvents)
        {
            if (audioEvent.eventName == eventName)
            {
                EventInstance eventInstance = RuntimeManager.CreateInstance(audioEvent.eventReference);
                eventInstance.start();
                if (audioEvent.audioType == AudioType.sound)
                {
                    eventInstance.release();
                }
                var ei = new EventInstances();
                ei.eventName = audioEvent.eventName;
                ei.eventInstance = eventInstance;
                activeEvents.Add(ei);
                
            } 
        }
    }

    public void Stop()
    {
        foreach (EventInstances activeEvent in activeEvents)
        {
            if (activeEvent.eventName == eventName)
            {
                if (allowFadeOut)
                {
                    activeEvent.eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
                else
                {
                    activeEvent.eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                }
                activeEvent.eventInstance.release();
            }
        }
    }

    public void SetParameter(string eventName,string parameterName, float value)
    {
        foreach (EventInstances activeEvent in activeEvents) 
        {
            if (activeEvent.eventName == eventName)
            {
                activeEvent.eventInstance.setParameterByName(parameterName, value);
            }
        }
    }

    public void CombatEnter()
    {
        RuntimeManager.StudioSystem.setParameterByName("Combat", 1);
    }

    public void CombatExit()
    {
        if (enemiesTargetingPlayer < 1)
        {
            RuntimeManager.StudioSystem.setParameterByName("Combat", 0);
        }
    }
    
}
