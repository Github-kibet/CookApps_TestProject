using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Manager;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]private EnemySpawnerProfile Profile;
    
    public int PoolIndex;

    private Dictionary<string, ObjectPool<GameObject>> poolDictionary;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        CreateClone();
    }

    private void Update()
    {
        
    }

    private void Initialize()
    {
        if (Profile == null) Profile = Resources.Load<EnemySpawnerProfile>("ScriptableObject/Spawn/EnemySpawnerProfile");
    }

    //������Ʈ Ǯ��
    private void CreateClone()
    {
        poolDictionary = new Dictionary<string, ObjectPool<GameObject>>();
        foreach (var obj in Profile.SerializableDictionary)
        {
            var pool = new ObjectPool<GameObject>(
                () => InstantiatePrefab(obj),
                instance => instance.SetActive(true),
                instance => instance.SetActive(false),
                null, true, PoolIndex);
            poolDictionary.Add(obj.Key, pool);
        }
    }

    private GameObject InstantiatePrefab(KeyValuePair<string, GameObject> pair)
    {
        var instance = Instantiate(pair.Value);
        instance.AddComponent<SpawnCallback>().ReturnAction = value => Push(pair.Key, value);
        instance.SetActive(false);
        return instance;
    }
    
    
    public GameObject Pop(string key)
    {
        if (poolDictionary.ContainsKey(key)) return poolDictionary[key].Get();
        
        Debug.LogError("���� ���� �ʴ� Ű ȣ��" + key);
        return null;
    }
    
    private void Push(string key, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(key)) return;
        poolDictionary[key].Release(obj);
    }
}
