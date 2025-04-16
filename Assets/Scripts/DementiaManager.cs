using UnityEngine;
using UnityEngine.UI;
using Oculus.Interaction.HandGrab;
using UnityEngine.UI;

public class DementiaManager : MonoBehaviour
{
    public Slider dementiaSlider; // Reference to the UI bar
    public float dementiaValue = 0f; // Ranges from 0 to 100
    public float timeToMax = 180f; // Time in seconds to reach 100 (3 minutes)
    public float holdingBoost = -10f; // How much holding the picture reduces the bar (negative = decrease)
    public HandGrabInteractable grabInteractable;
    public Transform playerCamera;

    public AudioSource over70AudioSource;
    public AudioSource over90AudioSource;
    private bool over70AudioPlayed = false;
    private bool over90AudioPlayed = false;
    private float timeOver90 = 0f;

    public bool IsGrabbed = false;

    public RawImage blurOverlay;

    void Update()
    {
        bool isHoldingPicture = IsPictureInHand();

        float delta = (100f / timeToMax) * Time.deltaTime;

        if (isHoldingPicture)
            dementiaValue += delta * (holdingBoost / (100f / timeToMax)); // reduce bar while holding picture
        else
            dementiaValue += delta;

        dementiaValue = Mathf.Clamp(dementiaValue, 0f, 100f);

        if (dementiaSlider != null)
            dementiaSlider.value = dementiaValue;


        if (dementiaValue > 90f)
        {
            timeOver90 += Time.deltaTime;
            if (!over90AudioPlayed)
            {
                over90AudioSource.Play();
                over90AudioPlayed = true;
            }

            if (timeOver90 >= 40f && over90AudioPlayed)
            {
                over90AudioPlayed = false;
                timeOver90 = 0f;
            }
            // TODO: teleportation
        } else
        {
            timeOver90 = 0f;
            over90AudioPlayed = false; 
        }

        if (dementiaValue > 70f)
        {
            if (!over70AudioPlayed)
            {
                over70AudioSource.Play();
                over70AudioPlayed = true;
            }
            
            // TODO: teleportation
        } else
        {
            over70AudioPlayed = false;
        }

        if (dementiaValue > 40f)
        {
            // TODO: teleportation
        }
        UpdateBlurAlpha();
    }

    bool IsPictureInHand()
    {
        return grabInteractable != null && grabInteractable.Interactors.Count > 0;
    }

    void UpdateBlurAlpha()
    {
        if (blurOverlay != null)
        {
            float alpha = 0f;

            if (dementiaValue >= 60f && dementiaValue < 70f)
            {
                // alpha from 0 to 80
                float t = (dementiaValue - 60f) / 10f;
                alpha = Mathf.Lerp(0f, 80f / 255f, t);
            }
            else if (dementiaValue >= 70f && dementiaValue < 80f)
            {
                alpha = 80f / 255f;
            }
            else if (dementiaValue >= 80f && dementiaValue <= 90f)
            {
                // alpha from 80 to 180
                float t = (dementiaValue - 80f) / 10f;
                alpha = Mathf.Lerp(80f / 255f, 180f / 255f, t);
            }
            else if (dementiaValue > 90f)
            {
                // maximum Blur
                alpha = 180f / 255f;
            }

            Color color = blurOverlay.color;
            color.a = alpha;
            blurOverlay.color = color;
        }
    }


}
