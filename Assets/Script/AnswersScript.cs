using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswersScript : MonoBehaviour
{
    public QuizManager quizManager;
    public bool isCorrect = false;
    public Color startColor;
    
    public void Start()
    {
        //warna awal sesuai dengan yang ditentukan diunity
        startColor = GetComponent<Image>().color;
    }
    public void Answer()
    {
        //jika jawaban benar
        if(isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Jawaban Anda benar");
            quizManager.correct();
        }
        else//jika jawaban salah
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Jawaban Anda Salah");
            quizManager.wrong();
        }
    }   
}