using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using NUnit.Framework;

[System.Serializable]
public struct MusicEvents
{
    public string eventName;
    public EventReference eventReference;
}

[System.Serializable]
public struct SoundEvents
{
    public string eventName;
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
    [SerializeField] private string eventName;
    [SerializeField] private MusicEvents[] musicEvents;
    [SerializeField] private SoundEvents[] soundEvents;
    List<EventInstances> activeEvents = new List<EventInstances>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        Play();
        DontDestroyOnLoad(this);
    }

    private void Play()
    {
        foreach (MusicEvents musicEvent in musicEvents)
        {
            if (musicEvent.eventName == eventName)
            {
                EventInstance eventInstance = RuntimeManager.CreateInstance(musicEvent.eventReference);
                var ei = new EventInstances();
                ei.eventName = musicEvent.eventName;
                ei.eventInstance = eventInstance;
                activeEvents.Add(ei);
                eventInstance.start();
                eventInstance.release();
            } 
        }
    }

    private void Stop()
    {
        foreach (EventInstances activeEvent in activeEvents)
        {
            if (activeEvent.eventName == eventName)
            {
                activeEvent.eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                activeEvent.eventInstance.release();
            }
        }
    }

    private void SetParameter(string eventName,string parameterName, float value)
    {
        
    }
    
    
}
