using Game._Scripts;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    [CustomEditor(typeof(Board))]
    public class BoardCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Board board = (Board)target;
            if (GUILayout.Button("AutoGetSlots"))
            {
                board.GetSlots();
            }
        }
    }
}