using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class LevelButtonLogic : MonoBehaviour
{
    public String levelToLoad;
    public Image levelThumbnail;
    public TextMeshProUGUI levelName;
    public RectTransform levelButton;
    [Range(0f, 200f)] public float levelNameOffset;

    public void Start()
    {
        resizeElements();
    }

    public void Update()
    {
        if (areElementsUnalligned())
            resizeElements(); //note to self: null ref exc happens because of levelThumbnail being null
    }

    private bool areElementsUnalligned()
    {
        if (levelButton.sizeDelta !=
            levelThumbnail.rectTransform.sizeDelta || !(levelName.transform.localPosition.Equals(new Vector2(levelThumbnail.transform.localPosition.x,
                levelThumbnail.transform.localPosition.y - levelNameOffset))))
        {
            return true;
        }

        return false;
    }

    public void resizeElements()
    {
        Debug.Log("resizeElements");
        levelButton.transform.localPosition=
            levelThumbnail.transform.localPosition;
        levelButton.sizeDelta=
            levelThumbnail.rectTransform.sizeDelta;
        levelName.transform.localPosition = new Vector2(levelThumbnail.transform.localPosition.x,
            levelThumbnail.transform.localPosition.y - levelNameOffset);
    }

    public void onCLick()
    {
        SceneManager.LoadSceneAsync(levelToLoad);
    }
}