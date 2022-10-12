using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel, aboutPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Play Scene");
    }

    public void ChangePanel()
    {
        if (mainMenuPanel.activeSelf)
        {
            mainMenuPanel.SetActive(false);
            aboutPanel.SetActive(true);
        }        
        else if (aboutPanel.activeSelf)
        {
            aboutPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }
}
