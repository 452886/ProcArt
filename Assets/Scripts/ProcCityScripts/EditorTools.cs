using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Demo
{
    [CustomEditor(typeof(Demo.Controller))]
    [CanEditMultipleObjects]
    public class GridGenerationEditor : Editor
    {
        SerializedProperty canvasWidth;
        SerializedProperty canvasHeight;
        SerializedProperty minRoomSize;
        SerializedProperty scale;

        public override void OnInspectorGUI()
        {
            Controller myGridGeneration = (Controller)target;

            GUILayout.Label("Generated objects");
            DrawDefaultInspector();
        }
    }
}