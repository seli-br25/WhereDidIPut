using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;
using UnityEngine.Video;

public class ThoughtsManager : MonoBehaviour
{
    public AudioSource startAudioSource;
    public AudioSource endAudioSource;
    public AudioSource trashAudioSource;
    public HandGrabInteractable grabInteractable;

    public GameObject task1;
    public GameObject task2;
    public GameObject task3;

    private bool grabAudioPlayed = false;
    private bool endAudioPlayed = false;

    public VideoPlayer endVideo;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name.Equals("Player"))
        {
            if (startAudioSource != null)
            {
                Invoke("PlayDelayedAudio", 3f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabAudioPlayed && grabInteractable != null && grabInteractable.Interactors.Count > 0 && this.gameObject.name.Equals("TrashRespawned"))
        {
            trashAudioSource.Play();
            grabAudioPlayed = true;
        }

        if (!endAudioPlayed && task1.activeSelf && task2.activeSelf && task3.activeSelf && this.gameObject.name.Equals("Player"))
        {
            endAudioSource.Play();
            endAudioPlayed = true;
        }
    }

    void PlayDelayedAudio()
    {
        startAudioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && endAudioPlayed)
        {
            endVideo.Play();
        }
    }
}
