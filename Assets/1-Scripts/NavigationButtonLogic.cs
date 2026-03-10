using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationButtonLogic : MonoBehaviour
{
    public static void returnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public static void enterLevelSelection()
    {
        SceneManager.LoadSceneAsync("LevelSelect");
    }
    public static void enterSettingsMenu()
    {
        SceneManager.LoadSceneAsync("Settings");
    }

    public static void exitGame()
    {
        Application.Quit();
    }
}
