using UnityEngine;
using Oculus.Interaction.HandGrab;

public class PhoneGrabBehavior : MonoBehaviour
{
    public HandGrabInteractable grabInteractable;

    private Vector3 startPosition;
    private Quaternion startRotation;
    public AudioSource phoneCall;

    private bool wasGrabbed = false;
    private bool isPlaying = false;
    private bool taskCompleted = false;

    public AudioSource success;
    public GameObject phoneTick;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        bool isGrabbed = grabInteractable.Interactors.Count > 0;

        // Grab started
        if (isGrabbed && !wasGrabbed)
        {
            PlayAudio();
        }

        // Released early
        if (!isGrabbed && wasGrabbed)
        {
            StopAudioAndReset();
        }

        // Audio finished naturally
        if (isPlaying && !phoneCall.isPlaying && !taskCompleted)
        {
            Debug.Log("task done");
            taskCompleted = true;
            isPlaying = false;
            success.Play();
            phoneTick.SetActive(true);
        }

        wasGrabbed = isGrabbed;
    }

    private void PlayAudio()
    {
        if (phoneCall != null && !phoneCall.isPlaying)
        {
            phoneCall.Play();
            isPlaying = true;
            taskCompleted = false;
        }
    }

    private void StopAudioAndReset()
    {
        if (phoneCall != null && phoneCall.isPlaying)
        {
            phoneCall.Stop();
            isPlaying = false;
        }

        transform.position = startPosition;
        transform.rotation = startRotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
