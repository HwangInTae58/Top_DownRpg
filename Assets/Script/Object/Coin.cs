using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    UnityAction<Coin> OnCollecterCoin;
    
    private void CollecterCoin()
    {
        OnCollecterCoin.Invoke(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollecterCoin();
        Destroy(gameObject);
    }
}
