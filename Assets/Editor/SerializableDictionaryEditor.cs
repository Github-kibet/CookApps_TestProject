using System;
using UnityEditor;
using UnityEngine;

public class SerializableDictionaryEditor<T,TV>: Editor where T:SerializableDictionaryAsset<string,TV> where TV: UnityEngine.Object
{
    protected T _obj;
    private string _key;
    private TV _value;
    private static SerializableDictionary<string,TV> _serializableDictionary=new ();

    protected string TextTitle, ObjectTitle;
    
    protected virtual void OnEnable()
    {
        _obj = (T)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("적 스폰 설정", new GUIStyle(GUI.skin.window));
        
        _key = EditorGUILayout.TextField(TextTitle,_key);
        _value = (TV)EditorGUILayout.ObjectField(ObjectTitle,_value,typeof(TV), true);
        SerializedProperty serializedProperty = serializedObject.FindProperty("SerializableDictionary");

        var keys = serializedProperty.FindPropertyRelative("keys");
        var values = serializedProperty.FindPropertyRelative("values");
        
        string label = "애니메이션 추가";
        bool isContainsKey = false;

        if (_value != null)
        {

            for(int i=0;i<keys.arraySize;i++)
            {
                if (_key.ToString() == keys.GetArrayElementAtIndex(i).stringValue)
                {
                    isContainsKey = true;
                    label = "중복된 키 값이 있습니다.";
                }
            }
            
            if (GUILayout.Button(label)&&!isContainsKey)
            {
                _serializableDictionary = _obj.SerializableDictionary;
                _serializableDictionary.Add(_key,_value);
                _obj.SerializableDictionary = _serializableDictionary;
            }
        }

        EditorGUILayout.PropertyField(serializedProperty,new GUIContent("스폰 Dictionary"));
        
        GUILayout.EndVertical();
        
        GUILayout.Space(30f);

        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(_obj);

    }
}