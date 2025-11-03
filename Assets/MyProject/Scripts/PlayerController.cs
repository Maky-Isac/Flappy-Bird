using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // --- Serialized ---
    [Header("Movement System")]
    [SerializeField] private float moveSpeed = 1f;

    [Header("Fly System")]
    [SerializeField] private float flyForce = 100f;
    [SerializeField] private float rotFactor = 3f;
    [SerializeField] private float maxFallAngle = -90f;

    // --- Components ---
    private Rigidbody2D rb2d;

    // --- Flags ---
    private bool shouldFly = false;



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            shouldFly = true;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);

        if (shouldFly)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            rb2d.AddForce(Vector2.up * flyForce);
            shouldFly = false;
        }

        if (rb2d.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float fallFactor = Mathf.Clamp01(- rb2d.velocity.y / rotFactor);
            float angle = Mathf.Lerp(0, maxFallAngle, fallFactor);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
