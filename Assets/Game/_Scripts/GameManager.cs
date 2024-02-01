using System;
using Game._Scripts.PlayerScripts;
using Game.Core.ObserverPattern;
using UnityEngine;
using UnityEngine.UI;

namespace Game._Scripts
{
    public enum GameMode
    {
        HumanVsHuman = 0,
        HumanVsAI = 1,
    }
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        // public Action StartGameAction;
        // public Action EndGameAction;
        public GameMode gameMode;

        public Button startNewGameBtn;

        public Player FirstPlayer;
        public Player SecondPlayer;

        public Player curPlayer;
        
        private void Awake()
        {
            if (Instance != null) Destroy(gameObject);
            Instance = this;
            // StartGame();
        }

        private void InitilizePlayers()
        {
            FirstPlayer = new HumanPlayer(ChessTeam.Down);
            if (gameMode == GameMode.HumanVsHuman)
            {
                SecondPlayer = new HumanPlayer(ChessTeam.Up);
            }
            else SecondPlayer = new AIPlayer(ChessTeam.Up);

            curPlayer = FirstPlayer;
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