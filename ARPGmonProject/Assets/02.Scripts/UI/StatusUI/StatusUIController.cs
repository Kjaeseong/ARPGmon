using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusUIController : MonoBehaviour
{
    private StatusUIView _view;
    private PlayerMonsterStat _monsterStat;

    private void Start() 
    {
        // TODO : Get Monster Stat Component
        _view = GetComponent<StatusUIView>();
    }

    private void Init()
    {
        _monsterStat.Hp.AddView(Hp);
        _monsterStat.Ep.AddView(Ep);
        _monsterStat.Exe.AddView(Exe);
        _monsterStat.Level.AddView(Level);
        _view.Evolution.onClick.AddListener(Evolution);
    }

    private void Evolution()
    {
        // TODO : 진화 대응 로직 추가해야 함.
    }

    private void Hp()
    {
        _view.Hp.fillAmount = _monsterStat.Hp.Value / _monsterStat.MaxHp.Value;
    }

    private void Ep()
    {
        _view.Ep.fillAmount = _monsterStat.Ep.Value / _monsterStat.MaxEp.Value;
    }

    private void Exe()
    {
        _view.Exe.fillAmount = _monsterStat.Ep.Value / _monsterStat.MaxExe.Value;
    }

    private void Level()
    {
        _view.Level.text = _monsterStat.Level.ToString();
    }
}
