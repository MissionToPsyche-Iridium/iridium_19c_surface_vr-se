using System.Diagnostics;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject infoCanvas; // canvas with info point info
    public GameObject infoPanel; // canvas with Psyche facts

    void Start()
    {
        if (infoCanvas != null)
        {
            infoCanvas.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Trigger Entered by: " + other.gameObject.name);
        if (other.CompareTag("Player")) // check if player entered
        {
            UnityEngine.Debug.Log("Player entered trigger."); // debug
            if (infoPanel == null || !infoPanel.activeSelf) // check if info is shown
            {
                UnityEngine.Debug.Log("Showing infoCanvas.");
                infoCanvas.SetActive(true); // show canvas
            }
             
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player exited trigger, showing UI."); //debug
            infoCanvas.SetActive(false); // hide canvas
            infoPanel.SetActive(false);
        }
    }
}