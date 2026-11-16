using System;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private EventReference eventRef;
    [SerializeField] private bool singleUse;

    private EventInstance eventInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventInstance = RuntimeManager.CreateInstance("eventInstance");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }

    void Play()
    {
        eventInstance.start();
    }

    void Stop()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    void StopImmediate()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
