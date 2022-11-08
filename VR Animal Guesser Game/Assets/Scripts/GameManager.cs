using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StreetViewImageLoader initalSkybox;
    public GameObject grassFloor, grassFloorInvis;
    public TextMeshProUGUI scoreText, hintOneText, hintTwoText, hintThreeText, currentHeldText, justPerformedText, currentMapPoint;

    public int scoreNum, hintsUsed;
    public bool isHoldingSomething = false, isFloorInvis = false;

    public Pickables currentlyHeld;
    public MapPoint[] allMapPoints = new MapPoint[15];
    public int numberOfGuesses = 0, maxGuesses = 15;

    //GameFinished variables
    public GameObject gameFinishedPanel, gameSessionPanel;
    public TextMeshProUGUI finalScoreText, finalHintsUsedText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameSessionPanel.SetActive(true);
        gameFinishedPanel.SetActive(false);
        initalSkybox.CreateStreetView();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreNum.ToString();
        if (!isHoldingSomething)
        {
            currentHeldText.text = "Nothing Held Yet!";
            currentMapPoint.text = "Nothing Held Yet!";
        }
        else 
        {
            currentHeldText.text = currentlyHeld.name;
            currentMapPoint.text = currentlyHeld.currentlyInMapPoint.name;
        }
    }

    public void UseHint()
    {
        currentlyHeld.numHintsUsed++;
        if (currentlyHeld.numHintsUsed > 3)
        {
            currentlyHeld.numHintsUsed = 3;
            return;
        }

        switch (currentlyHeld.numHintsUsed)
        {
            case 1:
                hintOneText.text = currentlyHeld.hintOne;
                hintsUsed++;
                break;
            case 2:
                hintTwoText.text = currentlyHeld.hintTwo;
                hintsUsed++;
                break;
            case 3:
                hintThreeText.text = currentlyHeld.hintThree;
                hintsUsed++;
                break;
        }
    }

    public void CheckForGameOver()
    {
        numberOfGuesses++;
        if (numberOfGuesses >= maxGuesses)
        {
            FinishGame();
        }
    }

    public void CalculateScore()
    {
        switch (currentlyHeld.numHintsUsed)
        {
            case 0:
                scoreNum += 100;
                justPerformedText.text = "No hints were used and 100 points were awarded!";
                break;
            case 1:
                scoreNum += 80;
                justPerformedText.text = "1 hint was used and 80 points were awarded!";
                break;
            case 2:
                scoreNum += 60;
                justPerformedText.text = "2 hints were used and 60 points were awarded!";
                break;
            case 3:
                scoreNum += 40;
                justPerformedText.text = "3 hints were used and 40 points were awarded!";
                break;
        }
    }

    public void MakeFloorTransparent()
    {
        if (isFloorInvis)
        {
            grassFloorInvis.gameObject.SetActive(false);
            grassFloor.gameObject.SetActive(true);
            isFloorInvis = false;
            
        }
        else if (!isFloorInvis)
        {
            grassFloorInvis.gameObject.SetActive(true);
            grassFloor.gameObject.SetActive(false);
            isFloorInvis = true;
        }
    }

    public void FinishGame()
    {
        gameSessionPanel.SetActive(false);
        gameFinishedPanel.SetActive(true);

        finalScoreText.text = scoreNum + "/1500";
        finalHintsUsedText.text = hintsUsed + "/45";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
