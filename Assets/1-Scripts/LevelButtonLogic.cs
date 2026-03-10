using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class LevelButtonLogic : MonoBehaviour
{
    public String levelToLoad;
    public Image levelThumbnail;
    public TextMeshProUGUI levelName;
    public Button levelButton;
    [Range(0f, 50f)] public float levelNameOffset;

    public void Start()
    {
        resizeElements();
    }

    public void Update()
    {
     if(areElementsUnalligned()) resizeElements();   
    }

    private bool areElementsUnalligned()
    {
        if (levelButton.transform.localScale !=
            new Vector3(levelThumbnail.sprite.rect.width, levelThumbnail.sprite.rect.height, 1) ||
            levelName.transform.localPosition.Equals(new Vector2(levelName.transform.localPosition.x,
                -(levelNameOffset + levelThumbnail.sprite.rect.height / 2)))) 
        {
            return true;
        }
        return false;
    }

    public void resizeElements()
    {
        levelButton.transform.localScale =
            new Vector3(levelThumbnail.sprite.rect.width, levelThumbnail.sprite.rect.height, 1);
        levelName.transform.localPosition = new Vector2(levelName.transform.localPosition.x,
            -(levelNameOffset + levelThumbnail.sprite.rect.height / 2));
    }

    public void onCLick()
    {
        SceneManager.LoadSceneAsync(levelToLoad);
    }
}