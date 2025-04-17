using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    //scores
    public ItemData[] allItems;
    public int score = 0;
    //timer
    private TextMeshProUGUI timer;
    [SerializeField] private float firstTime;
    private float remainingTime;
    public bool isGameOver = false;
    private bool isEndingTriggered = false;

    public static GameManager Instance { get; private set; }


    void Awake()
    {
        remainingTime = firstTime;
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


    private void Update()
    {
        if (timer == null)
        {
            timer = GameObject.Find("Countdown").GetComponent<TextMeshProUGUI>();
        }
        if (!isGameOver)
        {
            Timer();
        }
        else if (!isEndingTriggered)
        {
            EndScene();
        }

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
        isEndingTriggered = false;

    }

    private void Timer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (remainingTime <= 0)
        {
            Debug.Log("Game Over");
            timer.text = "00:00";
            isGameOver = true;
            remainingTime = firstTime;
        }
    }

    private void EndScene()
    {
        isEndingTriggered = true; // sadece bir kez tetiklenir
        FadeManager.Instance.FadeToScene("EndGame");
    }
}





