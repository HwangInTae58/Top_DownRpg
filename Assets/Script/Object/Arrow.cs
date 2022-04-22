using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject pickUpWeapone;

    Arrow arrow;
    Collider2D collider;
    Rigidbody2D rigid;

    private void Awake()
    {
        arrow = GetComponent<Arrow>();
        collider = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
    }

}
