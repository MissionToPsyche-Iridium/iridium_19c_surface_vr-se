using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scripts purpose is to find an GameObject named "PlayTimerUI" which has a PlayTimer script attached to it.
/// Then it calls the StartTimer function on it.
/// This implementation was chosen because as the PlayTimer script changes scenes the button invoking PlayTimer.StartTimer()
///    loses references to the GameObject. 
/// </summary>
public class FindPlayTimer : MonoBehaviour
{

    public void TryToFindAndActivatePlayTimer()
    {
        GameObject temp = GameObject.Find("PlayTimerUI");
        if (temp != null)
        {
            PlayTimer playTimer = temp.GetComponent<PlayTimer>();
            if (playTimer != null)
            {
                playTimer.StartTimer();
            }
            else
            {
                Debug.LogWarning("FindPlayTimer: Couldn't Find Script PlayTimer");
            }
        }
        else
        {
            Debug.LogWarning("FindPlayTimer: Couldn't Find GameObject PlayTimerUI");
        }
        
    }
}
