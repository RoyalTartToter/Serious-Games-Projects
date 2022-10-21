using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditScore : MonoBehaviour
{
    private TextMeshProUGUI Score;
    private int scoreNum;


    void Start()
    {
         Score = GetComponent<TextMeshProUGUI>();

    }


    public void noHintsUsed()
    {
        scoreNum += 1000;
        Score.text = scoreNum.ToString();
        Debug.Log("NoHintsUsed script ran :(");
        
    }

        public void oneHintUsed()
    {
        scoreNum += 800;
        Score.text = scoreNum.ToString();
        
    }

        public void twoHintsUsed()
    {
        scoreNum += 600;
        Score.text = scoreNum.ToString();

        
    }

        public void threeHintsUsed()
    {
        scoreNum += 400;
        Score.text = scoreNum.ToString();
        
    }

    
}
