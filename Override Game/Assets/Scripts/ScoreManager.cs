using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start() {
        scoreText.text = "SCORE: " + score.ToString();
        SubmissionManager.Instance.onHomeworkCompleted += SubmissionManager_onHomeworkCompleted;
    }

    private void SubmissionManager_onHomeworkCompleted(object sender, System.EventArgs e) {
        score += 20;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
