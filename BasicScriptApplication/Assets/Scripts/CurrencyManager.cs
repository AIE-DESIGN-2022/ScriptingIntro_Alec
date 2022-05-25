using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public int currentCurrencyAmount;
    public Text currencyAmountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrencyText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCurrencyText()
    {
        currencyAmountText.text = currentCurrencyAmount.ToString();
    }

    public void AddCurrency(int _currencyToAdd)
    {
        //Add the currency amount from the pickup item to the total currency count
        currentCurrencyAmount += _currencyToAdd;

        //Call the function to update the text to match the current currency amount
        UpdateCurrencyText();
    }

    public void RemoveCurrency(int _currencyToRemove)
    {
        //Remove the currency amount from the pickup item from the total currency count
        currentCurrencyAmount -= _currencyToRemove;

        //Call the function to update the text to match the current currency amount
        UpdateCurrencyText();
    }
}
