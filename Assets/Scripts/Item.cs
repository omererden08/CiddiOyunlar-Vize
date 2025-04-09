using UnityEngine;

public class Item : MonoBehaviour
{
    private Spawner spawner;
    private int spawnIndex;
    [SerializeField] private float destroyTime; // Destroy time in seconds

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    public void Init(Spawner spawnerRef, int index)
    {
        spawner = spawnerRef;
        spawnIndex = index;
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.MarkAsFree(spawnIndex);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && CompareTag("Correct"))
        {
            Debug.Log("Correct");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && CompareTag("Wrong"))
        {
            Debug.Log("Wrong");
            Destroy(gameObject);

        }
    }
}
