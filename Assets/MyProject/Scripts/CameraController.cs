using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float distance;

    void Start()
    {
        distance = transform.position.x - player.position.x;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 _position = transform.position;
        _position.x = player.position.x + distance;
        transform.position = _position;
    }
}
