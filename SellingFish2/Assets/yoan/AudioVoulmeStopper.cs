using UnityEngine;
using UnityEngine.Audio;

public class AudioVoulmeStopper : MonoBehaviour
{
    public AudioSource audioSource;
    public RectTransform minigameUI;
    
    public float mutedVolume = 0f;
    public float normalVolume = 1f;


    // Volume when inactive


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


       //argetAudio.volume = 1.0f;
       

    }

    void Update()
    {

        if (audioSource != null && minigameUI != null)
        {
            audioSource.volume = minigameUI.gameObject.activeSelf ? mutedVolume : normalVolume;
        }

    }
}
// Update is called once per frame
