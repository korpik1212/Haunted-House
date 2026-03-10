using UnityEngine;
using UnityEngine.UI;

public class LevelButtonGridLayoutResizer : MonoBehaviour
{
    public GridLayoutGroup levelGrid;
    public float levelButtonDefaultHeight;
    public float levelButtonDefaultWidth;
    public float levelNameDefaultOffset;
    [Range(0f, 1000f)] public float borderOffset;

    private Vector2 levelButtonSize;

    // Update is called once per frame
    void Update()
    {
        if (levelButtonSize.x != levelButtonDefaultWidth || levelButtonSize.y != levelButtonDefaultHeight)
            levelButtonSize = new Vector2(levelButtonDefaultWidth, levelButtonDefaultHeight);
        if (areElementsUnalligned())
            resizeElements();
    }

    private void resizeElements()
    {
        levelGrid.cellSize = new Vector2(levelButtonSize.x, levelButtonSize.y+levelNameDefaultOffset);
        levelGrid.transform.localPosition = new Vector2(levelGrid.transform.localPosition.x + borderOffset,
            levelGrid.transform.localPosition.y + borderOffset);
    }

    private bool areElementsUnalligned()
    {
        if (
            !levelGrid.cellSize.Equals(new Vector2(levelButtonSize.x, levelButtonSize.y+levelNameDefaultOffset))||
            !levelGrid.transform.localPosition.Equals(new Vector2(levelGrid.transform.localPosition.x + borderOffset,
                levelGrid.transform.localPosition.y + borderOffset))
        )
        {
            return true;
        }

        return false;
    }
}