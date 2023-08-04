using System.Collections.Generic;
using Manager;
using UnityEngine;
using UnityEngine.Pool;
using Util.Layer;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]private EnemySpawnerProfile Profile;
    
    public int PoolIndex;

    private Dictionary<string, ObjectPool<GameObject>> poolDictionary;

    private float SpawnTime = 0f;
    private float SpawnCount = 0f;

    private RaycastHit[] startGroundRayHit = new RaycastHit[1];
    private RaycastHit[] endGroundRayHit = new RaycastHit[1];
    
    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        CreateClone();

        SpawnTime = Time.time;
        SpawnCount = Profile.SpawnCount;
    }

    private void Update()
    {
        if (SpawnCount > 0)
        {
            if (SpawnTime < Time.time)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        GameObject clone = Pop("Normal");
        
        clone.transform.position = GetSpawnPoint();

        SpawnTime = Time.time + Profile.SpawnTime;
        --SpawnCount;
    }

    private Vector3 GetSpawnPoint()
    {
        Camera mainCam = Camera.main;

        Vector3 startPos = mainCam.ScreenToWorldPoint(Vector3.zero);
        Vector3 endPos = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        Physics.RaycastNonAlloc(startPos, mainCam.transform.forward, startGroundRayHit, mainCam.farClipPlane,
            GetLayerMasks.Ground);
        Physics.RaycastNonAlloc(endPos, mainCam.transform.forward, endGroundRayHit, mainCam.farClipPlane,
            GetLayerMasks.Ground);

        Vector3 startGroundPoint = startGroundRayHit[0].point;
        Vector3 endGroundPoint = endGroundRayHit[0].point;

        float xPos = Random.Range(startGroundPoint.x, endGroundPoint.x);
        float zPos = Random.Range(startGroundPoint.z, endGroundPoint.z);

        return new Vector3(xPos, startGroundPoint.y, zPos);
    }

    private void Initialize()
    {
        if (Profile == null) Profile = Resources.Load<EnemySpawnerProfile>("ScriptableObject/Spawn/EnemySpawnerProfile");
    }

    //오브젝트 풀링
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
        
        Debug.LogError("존재 하지 않는 키 호출" + key);
        return null;
    }
    
    private void Push(string key, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(key)) return;
        poolDictionary[key].Release(obj);
        ++SpawnCount;
    }
}
