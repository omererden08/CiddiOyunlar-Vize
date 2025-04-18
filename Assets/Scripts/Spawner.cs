using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    private List<bool> isOccupied = new List<bool>(); // spawn noktalar�n�n dolu olup olmad���n� kontrol etmek i�in
    [SerializeField] private GameObject[] spawnableObjects;
    [SerializeField] private float spawnInterval;
    private float timer = 0f;
    [SerializeField] private AudioSource spawnSound;

    private void Start()
    {
        spawnSound = GetComponent<AudioSource>();
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
            isOccupied.Add(false); // ba�lang��ta t�m spawn noktalar� bo�
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (GameManager.Instance.isGameOver)
        {
            return; // Oyun bitti�inde spawn yapma
        }


        if (timer >= spawnInterval)
        {
            Spawn();
            spawnSound.Play();
            timer = 0f; 
        }
    }

    private void Spawn()
    {
        int spawnPointIndex = GetRandomFreeSpawnPointIndex();

        if (spawnPointIndex == -1)
        {
            Debug.Log("T�m spawn noktalar� dolu.");
            return;
        }

        int objectIndex = Random.Range(0, spawnableObjects.Length);
        Transform spawnPoint = spawnPoints[spawnPointIndex];

        GameObject spawned = Instantiate(
            spawnableObjects[objectIndex],
            spawnPoint.position,
            spawnPoint.rotation
        );

        isOccupied[spawnPointIndex] = true;

        // Spawnlanan objeye Spawner referans�n� ve index bilgisini g�nder
        Item spawnedScript = spawned.GetComponent<Item>();
        if (spawnedScript != null)
        {
            spawnedScript.Init(this, spawnPointIndex);
        }
    }

    private int GetRandomFreeSpawnPointIndex()
    {
        List<int> freeIndices = new List<int>();

        for (int i = 0; i < isOccupied.Count; i++)
        {
            if (!isOccupied[i])
                freeIndices.Add(i);
        }

        if (freeIndices.Count == 0)
            return -1;

        return freeIndices[Random.Range(0, freeIndices.Count)];
    }

    public void MarkAsFree(int index)
    {
        if (index >= 0 && index < isOccupied.Count)
        {
            isOccupied[index] = false;
        }
    }

}
