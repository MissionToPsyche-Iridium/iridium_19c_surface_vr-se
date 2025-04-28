using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")] public GameObject mainMenu;

    public GameObject options;
    public GameObject about;

    [Header("Main Menu Buttons")] public Button startButton;

    public Button optionButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    private void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (Button item in returnButtons) item.onClick.AddListener(EnableMainMenu);
    }

    private static void QuitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        HideAll();
        SceneTransitionManager.Singleton.GoToSceneAsync(1);
    }

    private void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    private void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }

    private void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
    }

    private void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }
}