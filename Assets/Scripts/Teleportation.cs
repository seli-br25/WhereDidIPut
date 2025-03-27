using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform player;
    public DementiaManager dementiaManager; 
    private System.Random random = new System.Random();

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "13":
                TeleportTo(2.49f, 1.76f, 0.22f);
                break;
            case "31":
                TeleportTo(2.49f, -5.39f, 0.22f);
                break;
            case "15":
                TeleportTo(4.81f, 1.76f, 0.99f);
                break;
            case "51":
                TeleportTo(4.81f, -12.54f, 0.99f);
                break;
            case "23":
                TeleportTo(3.75f, -1.81f, -1.93f);
                break;
            case "32":
                TeleportTo(3.75f, -5.41f, -1.93f);
                break;
            case "24":
                TeleportTo(4.03f, -1.81f, 4.37f);
                break;
            case "42":
                TeleportTo(4.03f, -8.99f, 4.37f);
                break;
            case "45":
                TeleportTo(3.75f, -8.98f, -1.93f);
                break;
            case "54":
                TeleportTo(3.75f, -12.56f, -1.93f);
                break;
        }
    }

    private bool ShouldTeleport()
    {
        if (dementiaManager == null) return false;
        float teleportChance = dementiaManager.dementiaValue / 300f; 
        return random.NextDouble() < teleportChance;
    }

    private void TeleportTo(float x, float y, float z)
    {
        player.transform.position = new Vector3(x, y, z);
    }
}
