using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {

    public static QuizManager Instance { get; private set; }

    private ComputerTable currentComputerTable;

    [SerializeField] private Transform quizBackground;

    public List<Question> questions;

    public GameObject[] options;

    public int currentQuestion;

    public Text QuestionText;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        questions.RemoveAt(currentQuestion);
        generateQuestions();
        quizBackground.gameObject.SetActive(false);
    }

    public void correct() {
        currentComputerTable.beginPrinting();
        quizBackground.gameObject.SetActive(false);
    }

    public void wrong() {
        quizBackground.gameObject.SetActive(false);
    }

    private void generateQuestions() {
        currentQuestion = Random.Range(0, questions.Count);

        QuestionText.text = questions[currentQuestion].Questions;

        setAnswers();
    }

    public void askQuestions(ComputerTable computerTable) {
        this.currentComputerTable = computerTable;
        generateQuestions();
        quizBackground.gameObject.SetActive(true);
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
