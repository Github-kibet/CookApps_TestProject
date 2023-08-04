using Player;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerProfile))]
public class PlayerProfileEditor : Editor
{
    private PlayerProfile pp;
    private void OnEnable()
    {
        pp = (PlayerProfile)target;
    }

    public override void OnInspectorGUI()
    {
        pp.HP = EditorGUILayout.FloatField("플레이어의 체력", pp.HP);
        pp.EXP = EditorGUILayout.FloatField("플레이어의 경험치 요구량", pp.EXP);
        
        GUILayout.Space(15f);
        
        pp.MoveSpeed = EditorGUILayout.FloatField("플레이어의 움직임 속도", pp.MoveSpeed);
        pp.ChaseRange = EditorGUILayout.FloatField("플레이어의 추적 감지 거리", pp.ChaseRange);

        GUILayout.Space(15f);
        
        pp.AttackDamage = EditorGUILayout.FloatField("플레이어의 공격력", pp.AttackDamage);
        pp.AttackSpeed = EditorGUILayout.IntSlider("플레이어의 초당 공격 횟수", pp.AttackSpeed,1,100);
        pp.Attack1Range = EditorGUILayout.FloatField("플레이어의 공격 사거리", pp.Attack1Range);
        
        GUILayout.Space(15f);
        
        pp.Attack2Range = EditorGUILayout.FloatField("플레이어의 공격2 범위", pp.Attack2Range);
        pp.Attack2CoolTime = EditorGUILayout.FloatField("플레이어의 공격2 재사용 대기시간", pp.Attack2CoolTime);
        
        
        GUILayout.Space(15f);
        
        pp.HpRegenTime = EditorGUILayout.FloatField("플레이어의 체력 재생 대기시간", pp.HpRegenTime);
       
    }
}