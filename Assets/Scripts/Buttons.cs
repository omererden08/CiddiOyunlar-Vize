using UnityEngine;

public class Buttons : MonoBehaviour
{
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void StartGame()
    {
        audioSource.Play();
        FadeManager.Instance.FadeToScene("Gameplay");
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
