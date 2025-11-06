using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffect : MonoBehaviour
{
    public Rigidbody2D player;
    [SerializeField] float scrollSpeed = 0.75f; 

    private void FixedUpdate()
    {
        float _velocity = player.velocity.x * scrollSpeed;
        transform.position = transform.position + Vector3.right * _velocity * Time.deltaTime;
    }
}