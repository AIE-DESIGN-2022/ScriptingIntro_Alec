using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<string> inventoryItemNames;
    public Text inventoryListText;
    public GameObject inventoryPanel;

    private void Start()
    {
        //turn off the inventory panel on start
        inventoryPanel.SetActive(false);

        //Clear the text
        inventoryListText.text = "";
    }
    private void Update()
    {
        //Checking every frame to see if we pressed Tab
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //Sets the inventory panel active or inactive depending on its current state
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
        }
    }
    public void AssignInventoryItem(string _itemPickedUp)
    {
        //Add the item that was picked up the list
        inventoryItemNames.Add(_itemPickedUp);
        UpdateInventoryText();
    }

    private void UpdateInventoryText()
    {
        //Clear the text
        inventoryListText.text = "";
        
        //Foreach loop will run through each item in the list and execute the code
        foreach(string _inventoryItem in inventoryItemNames)
        {
            //Add the item name to the text then create a new line
            inventoryListText.text += _inventoryItem + "\n";
        }
    }

    public bool CheckInventoryForItem(string _itemToCheck)
    {
        //Run through each item in the inventory list to check if the name passed in (-itemToCheck)
        //matches an item in the inventory
        foreach (string _inventoryItem in inventoryItemNames)
        {
            //Check if the inventory item that we are up to has the same name
            if(_inventoryItem == _itemToCheck)
            {            
                //Return a true boolean to whatever has called the function
                return true;
            }
        }

        return false;
    }

    public void UseItem(string _itemToCheck)
    {
        bool _foundItem = false;

        //Run through each item in the inventory list to check if the name passed in (-itemToCheck) matches an item in the inventory
        foreach (string _inventoryItem in inventoryItemNames)
        {
            //Check if the inventory item that we are up to has the same name
            if (_inventoryItem == _itemToCheck)
            {
                _foundItem = true;               
            }
        }
        //After loop has finished, we then remove the item from inventory
        if(_foundItem == true)
        {
            //Remove the item from the inventory
            inventoryItemNames.Remove(_itemToCheck);

            //Update the text for the inventory
            UpdateInventoryText();
        }
    }
}
