using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private float remainingTime;
    private bool isGameOver = false;
    private bool isEndingTriggered = false;

    private void Start()
    {
        //timer.text = "02:00"; // baþlangýçta zamanlayýcýyý sýfýrla
    }

    private void Update()
    {
        if (!isGameOver)
        {
            Timer();
        }
        else if (!isEndingTriggered)
        {
            EndScene();
        }
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
        }
    }

    private void EndScene()
    {
        isEndingTriggered = true; // sadece bir kez tetiklenir
        FadeManager.Instance.FadeToScene("EndGame");
    }
}
