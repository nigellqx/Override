using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundEffect : MonoBehaviour {

    private const string PLAYER_PREFS_SOUND_EFFECT_VOLUME = "SoundEffectVolume";
    public static SoundEffect Instance { get; private set; }

    [SerializeField] private SoundEffectSO soundEffectSO;

    private float sound = 1f;

    private void Awake() {
        Instance = this;

        sound = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECT_VOLUME, 1f);
    }
    private void Start() {
        SubmissionManager.Instance.onHomeworkSucceeded += SubmissionManager_onHomeworkSucceeded;
        SubmissionManager.Instance.onHomeworkFailed += SubmissionManager_onHomeworkFailed;
        Character.Instance.OnPickUp += Character_OnPickUp;
        Furniture.OnDrop += Furniture_OnDrop;
        Trashbin.OnTrashed += Trashbin_OnTrashed;
        QuizManager.Instance.onWrongAnswer += QuizManager_onWrongAnswer;
        QuizManager.Instance.onCorrectAnswer += QuizManager_onCorrectAnswer;
    }

    private void QuizManager_onCorrectAnswer(object sender, System.EventArgs e) {
        playSoundEffect(soundEffectSO.correctAnswer, Camera.main.transform.position);
    }

    private void QuizManager_onWrongAnswer(object sender, System.EventArgs e) {
        playSoundEffect(soundEffectSO.wrongAnswer, Camera.main.transform.position);
    }

    private void Trashbin_OnTrashed(object sender, System.EventArgs e) {
        Trashbin trashbin = sender as Trashbin;
        playSoundEffect(soundEffectSO.trash, trashbin.transform.position);
    }

    private void Furniture_OnDrop(object sender, System.EventArgs e) {
        Furniture furniture = sender as Furniture;
        playSoundEffect(soundEffectSO.drop, furniture.transform.position);
    }

    private void Character_OnPickUp(object sender, System.EventArgs e) {
        playSoundEffect(soundEffectSO.pickUp, Character.Instance.transform.position);
    }

    private void SubmissionManager_onHomeworkFailed(object sender, System.EventArgs e) {
        SubmissionTable submissionTable = SubmissionTable.Instance;
        playSoundEffect(soundEffectSO.submissionFail, submissionTable.transform.position);
    }

    private void SubmissionManager_onHomeworkSucceeded(object sender, System.EventArgs e) {
        SubmissionTable submissionTable = SubmissionTable.Instance;
        playSoundEffect(soundEffectSO.submissionSucceeded, submissionTable.transform.position);
    }

    private void playSoundEffect(AudioClip audioClip, Vector3 position, float volume = 1f) {
        AudioSource.PlayClipAtPoint(audioClip, position, volume * sound);
    }

    public void changeSound() {
        sound += .1f;
        if (sound > 1f) {
            sound = 0f;
        }

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECT_VOLUME, sound);
        PlayerPrefs.Save();
    }

    public float getSound() {
        return sound;
    }
}
