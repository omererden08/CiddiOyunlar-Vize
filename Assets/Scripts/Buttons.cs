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
        FadeManager.Instance.FadeToScene("Gameplay");
    } 
    public void Quit()
    {
        FadeManager.Instance.Quit();
    }    
}
