using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowInfoClick : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject pointPanel;

    void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false); // hide the panel at start
            

        UnityEngine.Debug.Log("ShowInfoClick script is running!");
    }

    // clicked (select event)
    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        UnityEngine.Debug.Log("Sphere clicked!");
        TogglePanels();
    }

    // activated (grip/secondary button pressed)
    public void OnActivate(ActivateEventArgs args)
    {
        UnityEngine.Debug.Log("Sphere activated!");
        TogglePanels();
    }

    // toggle info and point canvas
    private void TogglePanels()
    {
        if (infoPanel != null) infoPanel.SetActive(!infoPanel.activeSelf);
        if (pointPanel != null) pointPanel.SetActive(!infoPanel.activeSelf);
    }




}
