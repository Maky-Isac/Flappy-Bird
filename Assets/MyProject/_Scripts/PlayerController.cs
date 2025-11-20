using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Flags")]
    public bool isDead = false;
    [SerializeField] private bool canFly;

    [Header("Component References")]
    public Animator animator;
    public Rigidbody2D rb2d;

    [Header("Movement System")]
    [SerializeField] private float moveSpeed = 1f;

    [Header("Fly System")]
    [SerializeField] private float flyForce = 100f;
    [SerializeField] private float maxFallAngle = -90f;
    [SerializeField] private float rotFactor = 3f;

    [Header("Shoot System")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float flyPenalty = 5f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInputs();

        if (Input.GetKeyDown(KeyCode.Return) && isDead)
            SceneManager.LoadScene("Game");
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Move();
        Fly();
        Fall();
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (isDead) return;

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator.SetTrigger("Dead");
        isDead = true;
        FindObjectOfType<GameManager>().GameOver();
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
    }

    private void Fly()
    {
        if (canFly)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            flyForce = 70f;
            rb2d.AddForce(Vector2.up * flyForce);
            animator.SetTrigger("Fly");
            canFly = false;
        }
    }

    private void Fall()
    {
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

    public void Shoot()
    {
        if (isDead) return;

        GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rbProj = proj.GetComponent<Rigidbody2D>();
        rbProj.velocity = new Vector2(projectileSpeed, 0f);

        flyForce = Mathf.Max(20f, flyForce - flyPenalty);
    }

    private void CheckInputs()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            canFly = true;

        if (Input.GetMouseButtonDown(1)) 
            Shoot();
    }
}
