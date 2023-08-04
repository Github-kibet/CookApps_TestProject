using Manager;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawnerProfile))]
public class EnemySpawnerProfileEditor : SerializableDictionaryEditor<EnemySpawnerProfile,GameObject>
{
    protected override void OnEnable()
    {
        base.OnEnable();
        TextTitle = "몬스터 이름";
        ObjectTitle = "몬스터 프리팹";
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _obj.SpawnCount = EditorGUILayout.IntField("몬스터의 동시 생성 가능한 최대 수 ", _obj.SpawnCount);
        _obj.SpawnTime = EditorGUILayout.IntField("몬스터의 생성 주기 ", _obj.SpawnCount);
    }
}