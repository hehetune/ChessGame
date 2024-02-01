using System;
using Game.Core.ObserverPattern;
using UnityEngine;
using UnityEngine.UI;

namespace Game._Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        // public Action StartGameAction;
        // public Action EndGameAction;

        public Button startNewGameBtn;

        private void Awake()
        {
            if (Instance != null) Destroy(gameObject);
            Instance = this;
            // StartGame();
        }

        public void StartGame()
        {
            Subject.Notify(EventKey.StartGame);
            // StartGameAction?.Invoke();
        }

        public void EndGame()
        {
            Subject.Notify(EventKey.EndGame);
            // EndGameAction?.Invoke();
        }

        public void NewGame()
        {
            EndGame();
            StartGame();
        }
    }
}