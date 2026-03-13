using System;
using UnityEngine;


public class TimeController : MonoBehaviour
{
    private DateTime goalTime;
    public int nightDurationInMinutes = 480;
    public int tickSpeedInSeconds = 60;

    public TMPro.TMP_Text timeText;
    public TMPro.TMP_Text nightsLeftText;

    public void onClick()
    {
        startMovingThroughNight();
    }

    public void Start()
    {
        syncGoalTimeToCurrentTime();
    }

    public void Update()
    {
        if (TimeAndEventHandler.getInstance().getCurrentTime() < goalTime)
        {
            TimeAndEventHandler.getInstance().advanceTime(TimeSpan.FromSeconds(tickSpeedInSeconds));
        }

        
        if (TimeAndEventHandler.getInstance().getCurrentTime() == calculateDayTime())
        {
            timeText.text = "Daytime :)";
        }
        else
        {
            timeText.text = TimeAndEventHandler.getInstance().getCurrentTime().ToShortDateString() + " " +
                            TimeAndEventHandler.getInstance().getCurrentTime().ToShortTimeString();
        }
        
        nightsLeftText.text = "You have " + (GameManager.getInstance().gameStateManager.maxNights - GameManager.getInstance().gameStateManager.getCurrentNight()) + " nights left \n to scare out the family!";
        
    }

    public DateTime calculateDayTime()
    {
        DateTime startTime = TimeAndEventHandler.getInstance().initialStartTime;
        DateTime dayTime = new DateTime(startTime.Year, startTime.Month, startTime.Day,
            TimeAndEventHandler.getInstance().startOfNightHour, 0, 0, 0);
        dayTime = dayTime.AddMinutes(nightDurationInMinutes).AddDays(GameManager.getInstance().gameStateManager.getCurrentNight() - 1);
        return dayTime;
    }

    public void startMovingThroughNight()
    {
        
        GameManager.getInstance().house.resetHumans();
        GameManager.getInstance().house.resetDoors();
        
        DateTime currentTime = TimeAndEventHandler.getInstance().getCurrentTime();
        DateTime startOfNightTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day,
            TimeAndEventHandler.getInstance().startOfNightHour, 0, 0, 0);
        TimeAndEventHandler.getInstance().hardSetCurrentTime(startOfNightTime);
        syncGoalTimeToCurrentTime();
        goalTime += TimeSpan.FromMinutes(nightDurationInMinutes);
    }

    public void syncGoalTimeToCurrentTime()
    {
        goalTime = TimeAndEventHandler.getInstance().getCurrentTime();
    }
}