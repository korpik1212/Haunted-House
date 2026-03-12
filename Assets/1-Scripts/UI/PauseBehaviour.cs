using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBehaviour : MonoBehaviour
{
    //[SerializeField] private Animator animMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private Image pauseMenuPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonOnClick ()
    {
        //animMenu.SetBool("isPaused", true);
        pauseButton.SetActive(false);
        continueButton.SetActive(true);
        menuButton.SetActive(true);
        pauseMenuPanel.enabled = true;
        Time.timeScale = 0;

        FindObjectOfType<SoundManager>().Play("UI_Sounds_Click");
    }

    public void ContinueButtonOnClick()
    {
        //animMenu.SetBool("isPaused", false);
        pauseButton.SetActive(true);
        continueButton.SetActive(false);
        menuButton.SetActive(false);
        pauseMenuPanel.enabled = false;
        Time.timeScale = 1;

        FindObjectOfType<SoundManager>().Play("UI_Sounds_Click");
    }

    public void MenuButtonOnClick()
    {
        SceneManager.LoadScene(0);

        FindObjectOfType<SoundManager>().Play("UI_Sounds_Click");
    }
}
