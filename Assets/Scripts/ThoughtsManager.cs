using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;

public class ThoughtsManager : MonoBehaviour
{
    private AudioSource startAudioSource;
    private AudioSource trashAudioSource;
    public HandGrabInteractable grabInteractable;

    private bool grabAudioPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name.Equals("Player"))
        {
            startAudioSource = GetComponent<AudioSource>();
            if (startAudioSource != null)
            {
                Invoke("PlayDelayedAudio", 5f);
            }
        }
        else if (gameObject.name.Equals("TrashRespawned"))
        {
            trashAudioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabAudioPlayed && grabInteractable != null && grabInteractable.Interactors.Count > 0 && this.gameObject.name.Equals("TrashRespawned"))
        {
            trashAudioSource?.Play();
            grabAudioPlayed = true;
        }
    }

    void PlayDelayedAudio()
    {
        startAudioSource.Play();
    }
}
