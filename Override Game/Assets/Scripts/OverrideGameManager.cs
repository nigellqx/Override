using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideGameManager : MonoBehaviour
{
    private enum Gamestate { 
        WaitingToStart,
        StartCountdown,
        GamePlaying,
        GameOver,
    }

    public static OverrideGameManager Instance { get; private set; }

    public event EventHandler onGamestateChanged;

    private Gamestate gamestate;
    private float waitingToStartTimer = 1f;
    private float startCountdownTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 120f;

    private void Awake() {
        Instance = this;
        gamestate = Gamestate.WaitingToStart;
    }

    private void Update() {
        switch (gamestate) { 
            case Gamestate.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f) {
                    gamestate = Gamestate.StartCountdown;
                    onGamestateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case Gamestate.StartCountdown:
                startCountdownTimer -= Time.deltaTime;
                if (startCountdownTimer < 0f) {
                    gamestate = Gamestate.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    onGamestateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case Gamestate.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f) {
                    gamestate = Gamestate.GameOver;
                    onGamestateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case Gamestate.GameOver:
                break;
        }
    }

    public bool isGamePlaying() {
        return gamestate == Gamestate.GamePlaying;
    }

    public bool isStartCountdown() {
        return gamestate == Gamestate.StartCountdown;
    }

    public float getCountdownTimer() {
        return startCountdownTimer;
    }

    public bool isGameOver() { 
        return gamestate == Gamestate.GameOver;
    }

    public float getGamePlayingTimer() {
        return gamePlayingTimer / gamePlayingTimerMax;
    }
}
