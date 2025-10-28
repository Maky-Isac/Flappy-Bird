using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Components
    private Rigidbody2D rb2d;

    // Variables
    [Header("Movement System")]
    [SerializeField] private float moveSpeed = 1f;

    [Header("Fly System")]
    [SerializeField] private float flyForce = 100f;
    [SerializeField] private bool canFly = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            canFly = true;
        }
    }

    private void FixedUpdate()
    {
        // Move o pássaro para frente

        //---Método 1: Mais legível---
        //Vector2 vel = rb2d.velocity;
        //vel.x = moveSpeed;
        //rb2d.velocity = vel;

        //---Método 2: Mais utilizado---
        rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);

        if (canFly)
        {
            rb2d.AddForce(Vector2.up * flyForce);
            canFly = false;
        }
    }
}
