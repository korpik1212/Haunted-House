using UnityEngine;

public class MusicPlayerMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Soundtrack_DaySong");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
