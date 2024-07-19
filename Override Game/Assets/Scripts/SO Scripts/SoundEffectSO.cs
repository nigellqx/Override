using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SoundEffectSO : ScriptableObject {

    public AudioClip printing;
    public AudioClip submissionFail;
    public AudioClip submissionSucceeded;
    public AudioClip footstep;
    public AudioClip pickUp;
    public AudioClip drop;
    public AudioClip trash;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
}
