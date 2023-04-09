using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("correct answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong answer");
            quizManager.correct();
        }
    }
}
