using UnityEngine;
using UnityEngine.UI;
using Oculus.Interaction.HandGrab;

public class DementiaManager : MonoBehaviour
{
    public Slider dementiaSlider; // Reference to the UI bar
    public float dementiaValue = 0f; // Ranges from 0 to 100
    public float timeToMax = 180f; // Time in seconds to reach 100 (3 minutes)
    public float holdingBoost = -10f; // How much holding the picture reduces the bar (negative = decrease)
    public HandGrabInteractable grabInteractable;
    public Transform playerCamera;

    public bool IsGrabbed = false;


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
            // TODO: teleportation + strong blurriness
        } else if (dementiaValue > 70f)
        {
            // TODO: teleportation + light blurriness
        } else if (dementiaValue > 40f)
        {
            // TODO: teleportation
        }

    }

    bool IsPictureInHand()
    {
        return grabInteractable != null && grabInteractable.Interactors.Count > 0;
    }
}
