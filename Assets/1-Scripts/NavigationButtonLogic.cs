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
        SceneManager.LoadSceneAsync("LevelSelection");
    }
    public static void enterSettingsMenu()
    {
        SceneManager.LoadSceneAsync("SettingsMenu");
    }

    public static void exitGame()
    {
        Application.Quit();
    }
}
