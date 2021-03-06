using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    [Header("Customize Questions")]
    [SerializeField] public List<QnA> QuestionsNAnswers;
    [SerializeField] public GameObject[] options;
    [SerializeField] public int currentQuestion;

    [Header("Link Question Text")]
    [SerializeField] public Text QuestionTxt;

    [Header("Question Help")]
    [SerializeField] GameObject notification;

    [Header("Pannel UI")]
    [SerializeField] GameObject pannelUI;
    [SerializeField] Text countdownText;
    public float countdownTime = 15f;
    [SerializeField] AnswerScript[] answerScript;
    private Coroutine currentRoutine;
    public GameObject answerPannelsTL;
    public GameObject answerPannelsTR;
    public GameObject answerPannelsBL;
    public GameObject answerPannelsBR;

    [Header("Other Script Connections")]
    [SerializeField] ScoreManager scoreManager;


    private void Start()
    {
        generateQuestion();
        //notification.SetActive(false);
        //currentRoutine = StartCoroutine(CountdownStart());
        answerPannelsTL.SetActive(false);
        answerPannelsTR.SetActive(false);
        answerPannelsBL.SetActive(false);
        answerPannelsBR.SetActive(false);
    }

    public void correct()
    {
        QuestionsNAnswers.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void SetAnswers()
    {
        answerPannelsTL.SetActive(true);
        answerPannelsTR.SetActive(true);
        answerPannelsBL.SetActive(true);
        answerPannelsBR.SetActive(true);
        currentRoutine = StartCoroutine(CountdownStart());
        for (int i = 0; i< options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QuestionsNAnswers[currentQuestion].Answers[i];

            if(QuestionsNAnswers[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        StartCoroutine(newAlert());
        Invoke("SetAnswers", 4);
        
        if (QuestionsNAnswers.Count > 0) 
        {
            if (currentRoutine != null)
            {
                StopCoroutine(currentRoutine);
            }

            //currentQuestion =Random.Range (0, QuestionsNAnswers.Count);

            QuestionTxt.text = QuestionsNAnswers[currentQuestion].Question;
            //SetAnswers();
        }
        else
        {
            Debug.Log("Complete");
            scoreManager.progressReport();
            pannelUI.SetActive(false);
            if (currentRoutine != null)
            {
                StopCoroutine(currentRoutine);
            }
        }

    }

    IEnumerator newAlert()
    {
        notification.SetActive(true);

        Debug.Log("Works");

        yield return new WaitForSeconds(3);

        notification.SetActive(false);
    }

    IEnumerator CountdownStart()
    {
        countdownTime = 15f;

        while (countdownTime >= 0)
        {
            countdownText.text = countdownTime.ToString("0");
            countdownTime -= Time.deltaTime;
            yield return null;
        }

        correct();
        
    }
}
