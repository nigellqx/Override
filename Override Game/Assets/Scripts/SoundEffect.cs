using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

    [SerializeField] private SoundEffectSO soundEffectSO;
    private void Start() {
        SubmissionManager.Instance.onHomeworkSucceeded += SubmissionManager_onHomeworkSucceeded;
        SubmissionManager.Instance.onHomeworkFailed += SubmissionManager_onHomeworkFailed;
        Character.Instance.OnPickUp += Character_OnPickUp;
        Furniture.OnDrop += Furniture_OnDrop;
        Trashbin.OnTrashed += Trashbin_OnTrashed;
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
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
