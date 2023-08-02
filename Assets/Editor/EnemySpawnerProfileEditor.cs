using Manager;
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
}