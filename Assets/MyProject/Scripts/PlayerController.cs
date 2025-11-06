using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // INSERIR
public class PlayerController : MonoBehaviour
{
    [Header("Movement System")] // AJUSTAR
    public Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed = 1f;

    [Header("Fly System")] // AJUSTAR
    [SerializeField] private float flyForce = 100f;
    [SerializeField] private float maxFallAngle = -90f;
    [SerializeField] private float rotFactor = 3f;
    [SerializeField] private bool canFly;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            canFly = true;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        if (canFly)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            rb2d.AddForce(Vector2.up * flyForce);
            canFly = false;
        }

        if (rb2d.velocity.y > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float _angle = Mathf.Lerp(0, maxFallAngle, -rb2d.velocity.y / rotFactor);
            transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
    }
}
