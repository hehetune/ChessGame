using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game._Scripts.UI
{
    public class UI_InGame : MonoBehaviour
    {
        public TextMeshProUGUI playerTurn;
        public Button startNewGameBtn;

        public void SetPlayerTurnText(ChessColor chessColor)
        {
            playerTurn.text = "Current turn: " + chessColor.ToString();
        }
    }
}