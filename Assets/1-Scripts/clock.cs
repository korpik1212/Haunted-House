//using System.Diagnostics;
using UnityEngine;

public class clock : MonoBehaviour
{
    public TimeAndEventHandler timeAndEventHandler;
    //private float rotation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Holen der aktuellen Zeit
        System.DateTime currentTime = TimeAndEventHandler.getInstance().getCurrentTime();
        
        // Berechne die Rotation basierend auf Stunden (für Stundenzeiger)
        // 30° pro Stunde, plus 0.5° pro Minute für kontinuierliche Bewegung
        //float totalHours = (currentTime.Hour % 12) + (float)currentTime.Minute / 60f;
        float totalTime = currentTime.Hour + (float)currentTime.Minute / 60f;
        float rotationAngle = -30f *totalTime - 100f; // Negativ für gegen den Uhrzeigersinn
        
        // Setze die Rotation relativ zur Initialrotation
        transform.localEulerAngles = new Vector3(0, rotationAngle, 0);
        Debug.Log(rotationAngle);
        
        // Optional: Debug-Ausgabe entfernen oder anpassen
        Debug.Log("Time: " + currentTime.ToString("HH:mm:ss") + "totaltime: " + totalTime);
    }
}
