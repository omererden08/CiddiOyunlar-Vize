using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void StartGame()
    {
        FadeManager.Instance.FadeToScene("Gameplay");
    }
    public void ReturnMenu()
    {
        FadeManager.Instance.FadeToScene("MainMenu");
    } 
    public void Restart()
    {
        GameManager.Instance.isGameOver = false;
        GameManager.Instance.ResetCounters();
        FadeManager.Instance.FadeToScene("Gameplay");
    } 
    public void Quit()
    {
        FadeManager.Instance.Quit();
    }    
}
