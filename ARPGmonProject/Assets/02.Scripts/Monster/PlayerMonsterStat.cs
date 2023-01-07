using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterStat : MonoBehaviour
{
    public Stat<string> Name { get; set; } = new Stat<string>(GameManager.Instance.Data.Name);
    public Stat<int> Level { get; set; } = new Stat<int>(GameManager.Instance.Data.Level);
    public Stat<float> MaxHp { get; set; } = new Stat<float>(GameManager.Instance.Data.MaxHP);
    public Stat<float> Hp { get; set; } = new Stat<float>(GameManager.Instance.Data.HP);
    public Stat<float> MaxEp { get; set; } = new Stat<float>(GameManager.Instance.Data.MaxEP);
    public Stat<float> Ep { get; set; } = new Stat<float>(GameManager.Instance.Data.EP);
    public Stat<float> MaxExe { get; set; } = new Stat<float>(GameManager.Instance.Data.MaxEXE);
    public Stat<float> Exe { get; set; } = new Stat<float>(GameManager.Instance.Data.EXE);
    public Stat<int> Atk { get; set; } = new Stat<int>(GameManager.Instance.Data.ATK);
    public Stat<int> Dfe { get; set; } = new Stat<int>(GameManager.Instance.Data.DFE);

    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get; set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _target;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Hp.Value += 10;
        }
    }








}
