using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterManager : MonoBehaviour
{
    private enum EvolutionStep
    {
        SMALL, LARGE, BIG
    }

    [SerializeField] private int _evolutionStep;
    [SerializeField] private GameObject[] _monster = new GameObject[3];

    public Transform MonsterPos { get; set; }
    private EvolutionStep _ss;

    private void Start() 
    {
        
    }



    public void ActivateMonster(int EvolutionStep)
    {
        if(EvolutionStep > 2)
        {
            return;
        }

        for(int i = 0; i < _monster.Length; i++)
        {
            if(EvolutionStep == i)
            {
                _evolutionStep = EvolutionStep;
                _monster[i].transform.SetPositionAndRotation(MonsterPos.position, MonsterPos.rotation);
                _monster[i].SetActive(true);
            }
            else
            {
                _monster[i].SetActive(false);
            }
            // Effect
        }
    }
}
