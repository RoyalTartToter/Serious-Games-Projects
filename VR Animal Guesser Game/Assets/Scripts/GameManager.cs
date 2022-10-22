using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText, hintOneText, hintTwoText, hintThreeText;
    public int scoreNum;
    public Pickables currentlyHeld;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreNum.ToString();
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
                break;
            case 2:
                hintTwoText.text = currentlyHeld.hintTwo;
                break;
            case 3:
                hintThreeText.text = currentlyHeld.hintThree;
                break;
        }
    }

    public void CalculateScore()
    {
        switch (currentlyHeld.numHintsUsed)
        {
            case 0:
                scoreNum += 100;
                Debug.Log("No hints were used and 100 points were awarded");
                break;
            case 1:
                scoreNum += 80;
                Debug.Log("1 hint was used and 80 points were awarded");
                break;
            case 2:
                scoreNum += 60;
                Debug.Log("2 hint was used and 80 points were awarded");
                break;
            case 3:
                scoreNum += 40;
                Debug.Log("3 hint was used and 80 points were awarded");
                break;
        }
    }
}
