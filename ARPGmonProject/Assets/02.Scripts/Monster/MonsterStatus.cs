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
    


}
