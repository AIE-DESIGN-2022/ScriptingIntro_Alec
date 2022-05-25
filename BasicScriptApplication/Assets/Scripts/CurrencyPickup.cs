using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickup : MonoBehaviour
{
    public int currencyValue;
    private CurrencyManager _currencyManager;

    // Start is called before the first frame update
    void Start()
    {
        _currencyManager = FindObjectOfType<CurrencyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _currencyManager.AddCurrency(currencyValue);
            Destroy(gameObject);
        }
    }
}
