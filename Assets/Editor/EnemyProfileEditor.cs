using Enemy;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyProfile))]
public class EnemyProfileEditor : Editor
{
    private EnemyProfile ep;
    private void OnEnable()
    {
        ep = (EnemyProfile)target;
    }

    public override void OnInspectorGUI()
    {
        ep.HP = EditorGUILayout.FloatField("몬스터의 체력", ep.HP);
        ep.EXP = EditorGUILayout.FloatField("몬스터의 경험치 제공량", ep.EXP);
        
        GUILayout.Space(15f);
        
        ep.MoveSpeed = EditorGUILayout.FloatField("몬스터의 움직임 속도", ep.MoveSpeed);
        ep.ChaseRange = EditorGUILayout.FloatField("몬스터의 추적 감지 거리", ep.ChaseRange);

        GUILayout.Space(15f);
        
        ep.AttackDamage = EditorGUILayout.FloatField("몬스터의 공격력", ep.AttackDamage);
        ep.AttackSpeed = EditorGUILayout.IntSlider("플레이어의 초당 공격 횟수", ep.AttackSpeed,1,100);
        ep.AttackCheckRange = EditorGUILayout.FloatField("몬스터의 공격 사거리", ep.AttackCheckRange);
    }
}