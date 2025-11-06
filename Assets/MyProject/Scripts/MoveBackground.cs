using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float boxSize;
    [SerializeField] private int quantity;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Background"))
        {
            Vector3 _newPosition = _other.transform.position;
            _newPosition.x += boxSize * quantity;
            _other.transform.position = _newPosition;
        }
    }
}

