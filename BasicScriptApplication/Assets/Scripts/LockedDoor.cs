using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public string keyName;
    private InventoryManager _inventoryManager;
    public Text infoText;
    private bool _canOpenDoor;
    private bool _inTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //An IF statement that's checking for 3 conditions to be true using the syntax "&&"
        if(_canOpenDoor == true && Input.GetKeyDown(KeyCode.E) == true && _inTrigger == true)
        {
            infoText.text = "";

            //Remove item from inventory
            _inventoryManager.UseItem(keyName);

            //Setting the parent gameObject inactive
            transform.parent.gameObject.SetActive(false);                      
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Set bool _inTrigger to true
            _inTrigger = true;

            //Asking the Inventory manager if the player has the correct item.
            //i.e. there is an item in their inventory that has the same name as the public string "keyName"
            if (_inventoryManager.CheckInventoryForItem(keyName))
            {
                //Tell the player that they can open the door
                infoText.text = "Open door 'E'";
                //Set a bool to allow the player to open the door, that we will check in Update()
                _canOpenDoor = true;
            }

            else
            {
                //Tell the player they need to find X key
                infoText.text = "Door is locked, find the " + keyName;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Check if the player leaves the trigger, and if so, set inTrigger to false and the text to blank
        if(other.gameObject.tag == "Player")
        {
            _inTrigger = false;
            infoText.text = "";
        }
    }
}
