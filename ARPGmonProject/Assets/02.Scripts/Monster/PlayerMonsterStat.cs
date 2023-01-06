using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterStat : MonoBehaviour
{
    public Stat<string> Name { get; set; }
    public Stat<int> Level { get; set; }
    public Stat<float> MaxHp { get; set; }
    public Stat<float> Hp { get; set; }
    public Stat<float> MaxEp { get; set; }
    public Stat<float> Ep { get; set; }
    public Stat<float> MaxExe { get; set; }
    public Stat<float> Exe { get; set; }
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
        Hp = new Stat<float>(GameManager.Instance.Data.HP);
        MaxHp = new Stat<float>(GameManager.Instance.Data.MaxHP);
        Ep = new Stat<float>(GameManager.Instance.Data.EP);
        MaxEp = new Stat<float>(GameManager.Instance.Data.MaxEP);
        Exe = new Stat<float>(GameManager.Instance.Data.EXE);
        MaxExe = new Stat<float>(GameManager.Instance.Data.MaxEXE);
        Atk = new Stat<int>(GameManager.Instance.Data.ATK);
        Dfe = new Stat<int>(GameManager.Instance.Data.DFE);
    }








}
