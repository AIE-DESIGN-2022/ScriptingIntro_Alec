using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColourTeleporter : MonoBehaviour 
{

	public GameObject teleportOutLocation;

	public float red;
	public float green;
	public float blue;

	// Use this for initialization
	void Start () 
	{
		//Check if Teleport out location has been set.
		if (teleportOutLocation == null) 
		{
			Debug.LogWarning("No Teleporter Out Location has been set for " + transform.name + ", Please set it and restart");
		}
		
		//Checks to see if you have set the collider on this object to a trigger 
		if (!GetComponent<Collider> ().isTrigger)
		{
			Debug.LogWarning("Collider on " + transform.name + " is not set to \"Is Trigger\", please update and restart");
		}
	}
	
	// This function is called then any collider touches the collider on this object.
	void OnTriggerEnter(Collider collidedObject) 
	{
		//Teleport GameObject that was collided with to the teleportOutLocation
		if (collidedObject.gameObject.tag == "Player") 
		{
			if (collidedObject.GetComponent<Renderer>().material.color == new Color(red, green, blue))
			{ 
				Debug.Log("Player Teleported");
				collidedObject.transform.position = teleportOutLocation.transform.position;
			}
		}
	}

	//This section Draws a line from the teleporter in to the teleporter out within the editor
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position,teleportOutLocation.transform.position);
	}
}
