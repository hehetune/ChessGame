using System;
using Game._Scripts.PlayerScripts;
using Game._Scripts.UI;
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

        public Player FirstPlayer;
        public Player SecondPlayer;
        public ChessColor firstPlayerChessColor;
        public ChessColor secondPlayerChessColor;
        public int currentTurnIndex = 0;

        public Player curPlayer;

        private UI_InGame UI_InGame;
        
        private void Awake()
        {
            if (Instance != null) Destroy(gameObject);
            Instance = this;
            // StartGame();

            UI_InGame = FindObjectOfType<UI_InGame>();
        }

        private void InitilizePlayers()
        {
            FirstPlayer = new HumanPlayer(ChessTeam.Down, firstPlayerChessColor);
            if (gameMode == GameMode.HumanVsHuman)
            {
                SecondPlayer = new HumanPlayer(ChessTeam.Up, secondPlayerChessColor);
            }
            else SecondPlayer = new AIPlayer(ChessTeam.Up, secondPlayerChessColor);

            curPlayer = FirstPlayer;
            UI_InGame.SetPlayerTurnText(curPlayer.chessColor);
        }

        public void StartGame()
        {
            InitilizePlayers();
            Subject.Notify(EventKey.StartGame);
            
            // StartGameAction?.Invoke();
        }

        public ChessColor GetChessColorByChessTeam(ChessTeam chessTeam)
        {
            return chessTeam == FirstPlayer.chessTeam ? firstPlayerChessColor : secondPlayerChessColor;
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

        public void OnPlayerPerformedAction()
        {
            SwitchPlayer();
            Subject.Notify(EventKey.UnmarkSlot);
        }

        public void SwitchPlayer()
        {
            curPlayer = curPlayer == FirstPlayer ? SecondPlayer : FirstPlayer;
        }
    }
}