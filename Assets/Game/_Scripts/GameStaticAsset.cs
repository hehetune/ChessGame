using System;
using System.Collections.Generic;
using Game.Helper;
using UnityEngine;

namespace Game._Scripts
{
    [Serializable]
    public class ChessSpriteItem
    {
        [SerializeField] public ChessRole chessRole;
        [SerializeField] public Sprite chessSprite;
    }

    [Serializable]
    public class ChessSpriteDict
    {
        [SerializeField] ChessSpriteItem[] chessSprites;

        public Dictionary<ChessRole, Sprite> ToDict()
        {
            Dictionary<ChessRole, Sprite> dict = new();
            foreach (var item in chessSprites)
            {
                dict[item.chessRole] = item.chessSprite;
            }

            return dict;
        }
    }

    public class GameStaticAsset : MonoBehaviour
    {
        public static GameStaticAsset Instance;
        [SerializeField] public ChessSpriteDict whiteChessSprites;
        [SerializeField] public ChessSpriteDict blackChessSprites;

        public Dictionary<ChessRole, Sprite> whiteChessSpritesDict;
        public Dictionary<ChessRole, Sprite> blackChessSpritesDict;

        public void Awake()
        {
            if (Instance != null) Destroy(gameObject);
            Instance = this;

            whiteChessSpritesDict = whiteChessSprites.ToDict();
            blackChessSpritesDict = blackChessSprites.ToDict();
        }
    }
}