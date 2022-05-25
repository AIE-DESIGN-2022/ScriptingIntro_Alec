using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private KillZone killzone;

    private void Start()
    {
        killzone = FindObjectOfType<KillZone>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Color playerColour = other.gameObject.GetComponent<Renderer>().material.color;
            Debug.Log("Checkpoint reached");
            killzone.UpdateCheckpointPosition(this.transform.position, playerColour);
        }
    }
}
