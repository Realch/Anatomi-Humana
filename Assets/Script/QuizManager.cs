using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManager : MonoBehaviour
{

    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject Quizpanel;
    public GameObject ScorePanel;
    public Text QuestionTxt;
    public Text ScoreTxt;
    int totalQuestions = 0;
    public int score;

    private void Start()
    {  
        totalQuestions = QnA.Count;
        ScorePanel.SetActive(false);
	    generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        ScorePanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        //jika jawaban benar maka score + 1 
        score +=1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void wrong()
    {  
        //jika jawaban salah maka score tidak bertambah
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

      IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void SetAnswers() //untuk mengatur banyaknya jawaban di pilihan ganda
    {
	    for(int i=0; i< options.Length; i++)
	    {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswersScript>().startColor;
            options[i].GetComponent<AnswersScript>().isCorrect = false;
		    options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswers == i+1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
		}
        Debug.Log(QnA.Count);
        Debug.Log(currentQuestion);
	}

    void generateQuestion() //untuk merandom pertanyaan
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Pertanyaan Habis");
            GameOver();
        }
    }
}