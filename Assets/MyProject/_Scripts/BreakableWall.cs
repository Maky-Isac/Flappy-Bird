using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projects"))
        {
            Debug.Log("Parede destruída!");
            gameObject.SetActive(false);
        }
    }

}
