using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementSound : MonoBehaviour {

    [SerializeField] private AudioClip audioSource;
    private Character character;
    private float footstepTimer;
    private float footstepTimerMax = .1f;

    private void Awake() {
        character = GetComponent<Character>();
    }

    private void Update() {
        footstepTimer -= Time.deltaTime;

        if (footstepTimer < 0f) {
            footstepTimer = footstepTimerMax;

            if (character.IsWalking()) {
                float volume = 100f;
                AudioSource.PlayClipAtPoint(audioSource, character.transform.position, volume);
            }
        }
    }
}
