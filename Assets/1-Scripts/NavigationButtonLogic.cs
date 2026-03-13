using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationButtonLogic : MonoBehaviour
{
    public static void returnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");

        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("UI_Sounds_Click");
    }
    public static void enterLevelSelection()
    {
        SceneManager.LoadSceneAsync("LevelSelect");

        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("UI_Sounds_Click");
    }
    public static void enterSettingsMenu()
    {
        SceneManager.LoadSceneAsync("Settings");

        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("UI_Sounds_Click");
    }

    public static void exitGame()
    {
        Application.Quit();
    }
}
