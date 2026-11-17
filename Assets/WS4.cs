using Mono.Cecil;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using EventReference = Mono.Cecil.EventReference;


public enum ElementalPower
{
    None,
    Fire,
    Ice,
    Lightning,
    Earth
}

[System.Serializable]
public struct CharacterInformation
{
    public string name;
    public ElementalPower power;
    public float speed;
    public int health;
    public bool canFly;
    public int damagePower;
}



public class WS4 : MonoBehaviour
{
    [SerializeField] private int[] highScores;
    [SerializeField] private ElementalPower elementKraft;
    [SerializeField] private CharacterInformation[] characterInformation;
    
    public EventReference eventRef;
    public EventInstance  eventInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Debug.Log(elementKraft);

        /*for (int i = 0; i < highScores.Length; i++)
        {
            Debug.Log(highScores[i]);
        }*/

        foreach (CharacterInformation character in characterInformation)
        {
            Debug.Log(character.name);
        }

        switch (elementKraft)
        {
            case ElementalPower.Earth:
                Debug.Log("Earth");
                break;
            case ElementalPower.Ice:
                Debug.Log("Ice");
                break;
            case ElementalPower.Lightning:
                Debug.Log("Lightning");
                break;
            case ElementalPower.Fire:
                Debug.Log("Fire");
                break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
