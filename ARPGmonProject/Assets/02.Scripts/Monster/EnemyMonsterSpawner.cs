using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMonsterSpawner : MonoBehaviour
{
    [Serializable]
    public struct MonsterGroup
    {
        [field: SerializeField] public int PoolSize { get; private set; }
        [field: SerializeField] public GameObject[] _prefabs { get; private set; }
        public GameObject[] Pool { get; set; }
    }

    [SerializeField] private MonsterGroup _lowMonsters;
    [SerializeField] private MonsterGroup _midMonsters;
    [SerializeField] private MonsterGroup _highMonsters;
    private Queue<GameObject> _respawnQueue = new Queue<GameObject>();

    [SerializeField] private float _respawnTime;
    [SerializeField] private float _respawnScope;

    private WaitForSeconds _time;
    private Coroutine _respawnCoroutine;

    private void Start() 
    {
        PoolInit();
    }

    private void PoolInit()
    {
        CreatePool(_lowMonsters._prefabs, _lowMonsters.Pool, _lowMonsters.PoolSize);
        CreatePool(_midMonsters._prefabs, _midMonsters.Pool, _midMonsters.PoolSize);
        CreatePool(_highMonsters._prefabs, _highMonsters.Pool, _highMonsters.PoolSize);
    }

    private void CreatePool(GameObject[] MonsterArr, GameObject[] Pool, int Size)
    {
        Pool =  new GameObject[Size];

        for(int i = 0; i < MonsterArr.Length; i++)
        {
            for(int j = 0; j < Size; j++)
            {
                Pool[j] = Instantiate(MonsterArr[i]);
                Pool[j].transform.parent = gameObject.transform;
                
                Pool[j].GetComponent<EnemyMonster>().Spawner = this;

                SetPosition(Pool[j]);
            }
        }
    }

    public void Respawn(GameObject Monster)
    {
        _respawnQueue.Enqueue(Monster);

        if(_respawnQueue.Count == 1)
        {
            _respawnCoroutine = StartCoroutine(RespawnCoroutine());
        }
    }

    private IEnumerator RespawnCoroutine()
    {
        while(true)
        {
            yield return _time;

            GameObject Monster = _respawnQueue.Dequeue();
            SetPosition(Monster);
            Monster.SetActive(true);

            if(_respawnQueue.Count < 1)
            {
                yield break;
            }
        }
    }

    private void SetPosition(GameObject Monster)
    {
        float x;
        float z;

        x = UnityEngine.Random.Range(Monster.transform.position.x - _respawnScope, Monster.transform.position.x + _respawnScope);
        z = UnityEngine.Random.Range(Monster.transform.position.z - _respawnScope, Monster.transform.position.z + _respawnScope);

        Monster.transform.position = new Vector3(x, Monster.transform.position.y, z);
    }
}