using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public string itemToUnlock;
    public int costOfItem;
    private CurrencyManager _currencyManager;
    private bool _isInTrigger;
    private bool _canPurchaseItem;

    private InventoryManager _inventoryManager;
    public Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        _currencyManager = FindObjectOfType<CurrencyManager>();
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Update()
    {
        if(_isInTrigger == true && _canPurchaseItem && Input.GetKeyDown(KeyCode.E))
        {
            //Reduce cost of item from currency manager
            _currencyManager.RemoveCurrency(costOfItem);

            //Add the item to the inventory
            _inventoryManager.AssignInventoryItem(itemToUnlock);

            //Check currency amount in comparison to cost of item
            _canPurchaseItem = CheckPlayerCurrency();
        }
    }

    private bool CheckPlayerCurrency()
    {
        if(_currencyManager.currentCurrencyAmount >= costOfItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            infoText.text = "Purchase " + itemToUnlock + " for " + costOfItem + " gold?";
            _isInTrigger = true;

            _canPurchaseItem = CheckPlayerCurrency();          
        }
    }

    private void OnTriggerExit(Collider other)
    {
     if (other.gameObject.tag == "Player")
        {
            _isInTrigger = false;
            infoText.text = "";
        }   
    }
}
