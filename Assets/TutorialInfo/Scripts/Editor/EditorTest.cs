using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnMonster))]
public class EditorTest : Editor
{
    public override void OnInspectorGUI()
    {
        SpawnMonster spawnMonster = (SpawnMonster)target;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate Monsters"))
        {
            spawnMonster.SpawnMonsterObject();
        }
        GUILayout.EndHorizontal();
    }
}