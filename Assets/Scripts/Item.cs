using UnityEngine;

public class Item : MonoBehaviour
{
    private Spawner spawner;
    private int spawnIndex;
    public ItemData itemData; // ItemData referans� (ScriptableObject)
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
        if (other.CompareTag("Player"))
        {
            EventManager.TriggerEvent("ItemCollected", itemData);
            itemData.counter++;
            Destroy(gameObject);
        }
        
    }
}
