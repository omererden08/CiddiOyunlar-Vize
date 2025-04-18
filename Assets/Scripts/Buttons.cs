using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private AudioSource audioSource;
    private Image howtoPlay;
    private bool isOpened = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        howtoPlay = GameObject.Find("HowToPlay").GetComponent<Image>();
        howtoPlay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (howtoPlay == null)
        {
            howtoPlay = GameObject.Find("HowToPlay").GetComponent<Image>();
            howtoPlay.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        audioSource.Play();
        if (isOpened)
        {
            howtoPlay.gameObject.SetActive(false);
            isOpened = false;
        }

        FadeManager.Instance.FadeToScene("Gameplay");
    }

    public void HowtoPlay()
    {
        audioSource.Play();
        if (isOpened)
        {
            howtoPlay.gameObject.SetActive(false);
            isOpened = false;
        }
        else
        {
            howtoPlay.gameObject.SetActive(true);
            isOpened = true;
        }
    }

    public void ReturnMenu()
    {
        audioSource.Play();
        GameManager.Instance.isGameOver = false;
        GameManager.Instance.ResetCounters();
        FadeManager.Instance.FadeToScene("MainMenu");
    }
    public void Restart()
    {
        audioSource.Play();
        GameManager.Instance.isGameOver = false;
        GameManager.Instance.ResetCounters();
        FadeManager.Instance.FadeToScene("Gameplay");
    }
    public void Quit()
    {
        audioSource.Play();
        FadeManager.Instance.Quit();
    }
}
