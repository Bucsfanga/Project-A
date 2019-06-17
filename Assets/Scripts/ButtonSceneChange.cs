using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Blockout");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
