using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {

    public event EventHandler onCorrectAnswer;
    public event EventHandler onWrongAnswer;

    public static QuizManager Instance { get; private set; }

    private ComputerTable currentComputerTable;

    [SerializeField] private Transform quizBackground;
    [SerializeField] private Button firstButton;

    public List<Question> programmingQuestions;
    public List<Question> dataQuestions;
    public List<Question> mathQuestions;
    public List<Question> questions;

    public GameObject[] options;

    public int currentQuestion;

    public Text QuestionText;

    public bool currentlyInQuestion = false;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        questions.RemoveAt(currentQuestion);
        quizBackground.gameObject.SetActive(false);
    }

    public void correct() {
        onCorrectAnswer?.Invoke(this, EventArgs.Empty);
        currentComputerTable.beginPrinting();
        currentlyInQuestion = false;
        quizBackground.gameObject.SetActive(false);
    }

    public void wrong() {
        onWrongAnswer?.Invoke(this, EventArgs.Empty);
        currentlyInQuestion = false;
        quizBackground.gameObject.SetActive(false);
    }

    private void generateQuestions() {
        pickUpObject book = currentComputerTable.GetClassroomObject().getPickUpObject();

        if (book.questionSet == 1) {
            currentQuestion = UnityEngine.Random.Range(0, programmingQuestions.Count);

            QuestionText.text = programmingQuestions[currentQuestion].Questions;

            setAnswers(1);
        } else if (book.questionSet == 2) {
            currentQuestion = UnityEngine.Random.Range(0, dataQuestions.Count);

            QuestionText.text = dataQuestions[currentQuestion].Questions;

            setAnswers(2);
        } else if (book.questionSet == 3) {
            currentQuestion = UnityEngine.Random.Range(0, mathQuestions.Count);

            QuestionText.text = mathQuestions[currentQuestion].Questions;

            setAnswers(3);
        } else {
            currentQuestion = UnityEngine.Random.Range(0, questions.Count);

            QuestionText.text = questions[currentQuestion].Questions;

            setAnswers(4);
        }

    }

    public void askQuestions(ComputerTable computerTable) {
        currentlyInQuestion = true;
        this.currentComputerTable = computerTable;
        generateQuestions();
        firstButton.Select();
        quizBackground.gameObject.SetActive(true);
    }

    private void setAnswers(int questionSet) {
        if (questionSet == 1) {
            for (int i = 0; i < options.Length; i++) {
                options[i].GetComponent<Answer>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = programmingQuestions[currentQuestion].Answers[i];

                if (programmingQuestions[currentQuestion].CorrectAnswers == i + 1) {
                    options[i].GetComponent<Answer>().isCorrect = true;
                }
            }
        } else if (questionSet == 2) {
            for (int i = 0; i < options.Length; i++) {
                options[i].GetComponent<Answer>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = dataQuestions[currentQuestion].Answers[i];

                if (dataQuestions[currentQuestion].CorrectAnswers == i + 1) {
                    options[i].GetComponent<Answer>().isCorrect = true;
                }
            }
        } else if (questionSet == 3) {
            for (int i = 0; i < options.Length; i++) {
                options[i].GetComponent<Answer>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = mathQuestions[currentQuestion].Answers[i];

                if (mathQuestions[currentQuestion].CorrectAnswers == i + 1) {
                    options[i].GetComponent<Answer>().isCorrect = true;
                }
            }
        } else {
            for (int i = 0; i < options.Length; i++) {
                options[i].GetComponent<Answer>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = questions[currentQuestion].Answers[i];

                if (questions[currentQuestion].CorrectAnswers == i + 1) {
                    options[i].GetComponent<Answer>().isCorrect = true;
                }
            }
        }

        
    }

    public void Hide() {
        quizBackground.gameObject.SetActive(false);
    }

    public void Show() {
        quizBackground.gameObject.SetActive(true);
        firstButton.Select();
    }
}
