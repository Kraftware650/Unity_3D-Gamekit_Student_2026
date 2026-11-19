using System;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.Events;

[System.Serializable]
public struct AudioTriggerStruct
{
    public string eventName;
    public string parameterName;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
}
public class AudioTrigger : MonoBehaviour
{
    [Header("The trigger can either be used in an existing unityEvent...")]
    [Tooltip("Destroys the trigger after use")]
    [SerializeField] private bool singleUse;
    [Header("...or by connecting it to a trigger and using the built in unityEvents below")]
    [SerializeField] AudioTriggerStruct[] audioTriggers;
    private AudioManager audioManager;

    private void Awake()
    {
        GameObject audioManagerGO = GameObject.FindWithTag("AudioManager");
        audioManager = audioManagerGO.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (AudioTriggerStruct audioTrigger in audioTriggers)
        {
            audioManager.eventName = audioTrigger.eventName;
            audioManager.parameterName = audioTrigger.eventName;
            audioTrigger.onTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (AudioTriggerStruct audioTrigger in audioTriggers)
        {
            audioTrigger.onTriggerExit.Invoke();
        }
        if (singleUse)
        {
            Destroy(this);
        }
    }
    
    public void Play()
    {
        audioManager.Play();
    }

    public void Stop()
    {
        audioManager.allowFadeOut = true;
        audioManager.Stop();
    }

    public void StopImmediate()
    {
        audioManager.allowFadeOut = false;
        audioManager.Stop();
    }

    public void SetParameterValue(float value)
    {
        audioManager.parameterValue = value;
        audioManager.SetParameter(audioManager.eventName, audioManager.parameterName, audioManager.parameterValue);
    }
    
    public void CombatEnter()
    {
        audioManager.CombatEnter();
    }

    public void CombatExit()
    {
        audioManager.CombatExit();
    }
}
