using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {

    public List<Question> questions;

    public GameObject[] options;

    public int currentQuestion;

    public Text QuestionText;

    private void Start() {
        questions.RemoveAt(currentQuestion);
        generateQuestions();
    }

    public void correct() {
        generateQuestions();
    }
    private void generateQuestions() {
        currentQuestion = Random.Range(0, questions.Count);

        QuestionText.text = questions[currentQuestion].Questions;

        setAnswers();
    }

    private void setAnswers() {
        for (int i = 0; i < options.Length; i++) {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questions[currentQuestion].Answers[i];

            if (questions[currentQuestion].CorrectAnswers == i + 1) {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }
}
