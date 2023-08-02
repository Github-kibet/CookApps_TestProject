using UnityEngine;

[System.Serializable]
public abstract class SerializableDictionaryAsset<K,V> : ScriptableObject
{
    public SerializableDictionary<K, V> SerializableDictionary;
}