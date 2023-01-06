using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    [SerializeField] public string Name { get; set; } 
    [SerializeField] public int Level { get; set; }
    [SerializeField] public int Hp { get; set; }
    [SerializeField] public int Ep { get; set; }
    [SerializeField] public int Exe { get; set; }
    [SerializeField] public int Atk { get; set; }
    [SerializeField] public int Dfe { get; set; }

    [SerializeField] public float MoveSpeed { get; set; }
    [SerializeField] public GameObject Target { get; set; }
    [SerializeField] public GameObject Player { get; set; }
    [SerializeField] private GameObject[] EvolutionTree;
    private List<GameObject> _monsterList = new List<GameObject>();

    private int _maxEvolutionStep = 2;

    [SerializeField] public int EvolutionStep 
    { 
        get => EvolutionStep;
        set
        {
            EvolutionStep = value;
            if(EvolutionStep > _maxEvolutionStep)
            {
                EvolutionStep = _maxEvolutionStep;
            }
            
            Summon(EvolutionStep);
        } 
    }

    private void OnEnable() 
    {
        Init();
        
    }

    private void Init()
    {
        // 활성화시 능력치 초기화
    }

    private void CreateEvolutionTreePool()
    {
        for(int i = 0; i < EvolutionTree.Length; i++)
        {
            _monsterList.Add(Instantiate(EvolutionTree[i]));
            _monsterList[i].transform.parent = transform;

        }
    }

    public void AttackTo()
    {
        
    }

    public void MoveTo()
    {

    }
    
    public void Summon(int EvolutionStep)
    {
        for(int i = 0; i < _monsterList.Count; i++)
        {
            if(EvolutionStep == i)
            {
                _monsterList[i].SetActive(true);
            }
            else
            {
                _monsterList[i].SetActive(false);
            }
        }
    }

}
