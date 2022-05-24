using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {
        public string tag;
        public GameObject Prefab;
        public int size;
    }

    public static SpawnManager instance;
    private void Awake()
    {
        instance = this;
    }

    public List<pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (pool pool in pools)
        {
            Queue<GameObject> ObjectQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                ObjectQueue.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, ObjectQueue);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        IObjectinterface pooledObj = objectToSpawn.GetComponent<IObjectinterface>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawned();
        }
        return objectToSpawn;
    }
    public void ReleaseObject(string tag, GameObject objects)
    {
        poolDictionary[tag].Enqueue(objects);
    }
}
