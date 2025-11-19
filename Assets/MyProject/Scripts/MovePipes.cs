using UnityEngine;

public class MovePipes : MonoBehaviour
{
    [SerializeField] private float spacing = 1f;
    private static int nextPositionIndex = 6;

    [SerializeField] private float minY = -0.5f;
    [SerializeField] private float maxY = -1f;

    private GameObject[] pipes;

    private GameObject[] walls;
    
    private void Start()
    {
        pipes = GameObject.FindGameObjectsWithTag("Pipes");

        foreach (GameObject pipe in pipes)
        {
            Vector3 _newPosition = pipe.transform.position;
            _newPosition.y = Random.Range(minY, maxY);
            pipe.transform.position = _newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipes"))
        {
            Vector3 _newPosition = other.transform.position;
            _newPosition.x = nextPositionIndex * spacing;
            _newPosition.y = Random.Range(minY, maxY);

            other.transform.position = _newPosition;

            walls = GameObject.FindGameObjectsWithTag("BreakableWall");
            
            foreach (GameObject wall in walls)
            {
                wall.SetActive(true);
            }

            nextPositionIndex++;
        }
        
    }
}
