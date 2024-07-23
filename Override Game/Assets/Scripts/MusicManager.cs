using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";
    public static MusicManager Instance { get; private set; }

    private AudioSource audioSource;
    private float sound = .3f;

    private void Awake() {
        Instance = this;
        audioSource = GetComponent<AudioSource>();

        sound = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, .3f);
        audioSource.volume = sound;
    }
    public void changeSound() {
        sound += .1f;
        if (sound > 1f) {
            sound = 0f;
        }
        audioSource.volume = sound;

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, sound);
        PlayerPrefs.Save();
    }

    public float getSound() {
        return sound;
    }
}
