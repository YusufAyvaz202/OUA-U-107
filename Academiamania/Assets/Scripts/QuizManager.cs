using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System;
public class QuizManager : MonoBehaviour
{
   public List<QuestionsAndAnswers> QnA;
   public GameObject[] options;
   public int currentQuestion;
   public Text QuestionTxt;
   private void Start()
   {
      generateQuestion();
   }
   public void correct()
   {
      QnA.RemoveAt(currentQuestion);
      generateQuestion();
   }
   void SetAnswers()
   {
      for (int i = 0; i < options.Length; i++)
      {
         options[i].GetComponent<AnswersScript>().isCorrect = false;
         options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
         if (QnA[currentQuestion].CorrectAnswers == i + 1)
         {
            options[i].GetComponent<AnswersScript>().isCorrect = true;
         }
      }
   }
   void generateQuestion()
   {
      
      currentQuestion = Random.Range(0, QnA.Count);
      QuestionTxt.text = QnA[currentQuestion].Question;
      SetAnswers();
      
   }
}
