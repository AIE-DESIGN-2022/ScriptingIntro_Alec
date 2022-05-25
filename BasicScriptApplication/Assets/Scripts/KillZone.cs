using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Vector3 checkpoint;
    public GameObject player;

    private Color colourAtCheckpoint;

    private void Start()
    {
        checkpoint = player.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkpoint != null)
        {
            other.transform.position = checkpoint;
            player.GetComponent<Renderer>().material.color = colourAtCheckpoint;
        }
    }

    public void UpdateCheckpointPosition(Vector3 newPosition, Color playerColour)
    {
        checkpoint = newPosition;
        colourAtCheckpoint = playerColour;
    }
}
