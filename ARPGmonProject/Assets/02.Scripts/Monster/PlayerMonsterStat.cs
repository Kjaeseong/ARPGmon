using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterStat : MonoBehaviour
{
    public Stat<string> Name { get; set; }
    public Stat<int> Level { get; set; }
    public Stat<int> Hp { get; set; }
    public Stat<int> Ep { get; set; }
    public Stat<int> Exe { get; set; }
    public Stat<int> Atk { get; set; }
    public Stat<int> Dfe { get; set; }

    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get; set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _target;

    private void OnEnable() 
    {
        Init();
    }

    private void Init()
    {
        Name = new Stat<string>(GameManager.Instance.Data.Name);
        Level = new Stat<int>(GameManager.Instance.Data.Level);
        Hp = new Stat<int>(GameManager.Instance.Data.HP);
        Ep = new Stat<int>(GameManager.Instance.Data.EP);
        Exe = new Stat<int>(GameManager.Instance.Data.EXE);
        Atk = new Stat<int>(GameManager.Instance.Data.ATK);
        Dfe = new Stat<int>(GameManager.Instance.Data.DFE);
    }








}
