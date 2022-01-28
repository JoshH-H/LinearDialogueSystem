using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    [SerializeField] public bool isCorrect = false;
    [SerializeField] QuestionManager questionManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] int scoreCorrectValue;
    [SerializeField] int scoreWrongValue;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("That's right");
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            scoreManager.playerScore += scoreCorrectValue;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SetScore();
        }
        else
        {
            Debug.Log("That's wrong");
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            scoreManager.playerScore -= scoreWrongValue;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SetScore();
        }
    }
}
