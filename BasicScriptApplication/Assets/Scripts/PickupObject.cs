using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    public Transform pickupPoint;
    public Text infoText;
    private InventoryManager _inventoryManager;
    void Start()
    {
        //Clear the Info text box
        infoText.text = "";
        //Looking through all the objects in the scene to find the one with the InventoryManager script
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            infoText.text = "Pick up 'E'";

            if (Input.GetKey(KeyCode.E))
            {
                //turn the pickup collider off
                    //other.GetComponent<Collider>().enabled = false;
                //move the object to our pickup point
                    //other.transform.position = pickupPoint.position;
                //make pickup object a child of the player
                    //other.transform.parent = this.transform;
                
                //clear the text
                infoText.text = "";

                //Calling into the function on the InventoryManager to add this pickup item to the inventory list,
                //passing the collider object.gameObject to it
                _inventoryManager.AssignInventoryItem(other.gameObject.name);

                //Destorying the pickup object
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            //clear the text
            infoText.text = "";
        }
    }
}
