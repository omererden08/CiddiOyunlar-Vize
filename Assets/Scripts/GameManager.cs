using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    
    public ItemData[] allItems; // Array of ItemData references
    public int score = 0;

    public static GameManager Instance { get; private set; }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetCounters();

        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
    }

    

    void OnEnable()
    {
        EventManager.StartListening("ItemCollected", OnItemCollected);
    }

    void OnDisable()
    {
        EventManager.StopListening("ItemCollected", OnItemCollected);
    }

    private void OnItemCollected(object data)
    {
        if (data is ItemData item)
        {
            score += item.itemPoints;
        }
    }

   
    public void ResetCounters()
    {
        foreach (var item in allItems)
        {
            item.counter = 0;
        }
        score = 0;
    }

    
}





