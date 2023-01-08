using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterInfoUIController : MonoBehaviour
{
    private MonsterInfoUIView _view;
    [SerializeField] PlayerMonsterStat _monster;

    private void Awake() 
    {
        _view = GetComponent<MonsterInfoUIView>();

        _view.BackButton.BackMenuSet(_view.BackMenu);
        _view.BackButton.ParentUI = gameObject;
    }

    private void OnEnable() 
    {
        SetName();
        SetLevel();
        SetHp();
        SetEp();
        SetExe();
        SetAtk();
        SetDfe();
    }

    private void Start() 
    {
        _monster.Name.AddView(SetName);
        _monster.Level.AddView(SetLevel);
        _monster.Hp.AddView(SetHp);
        _monster.Ep.AddView(SetEp);
        _monster.Exe.AddView(SetExe);
        _monster.Atk.AddView(SetAtk);
        _monster.Dfe.AddView(SetDfe);
    }

    private void OnDestroy() 
    {
        _monster.Name.RemoveView(SetName);
        _monster.Level.RemoveView(SetLevel);
        _monster.Hp.RemoveView(SetHp);
        _monster.Ep.RemoveView(SetEp);
        _monster.Exe.RemoveView(SetExe);
        _monster.Atk.RemoveView(SetAtk);
        _monster.Dfe.RemoveView(SetDfe);
    }


    private void SetName()
    {
        _view.Name.text = _monster.Name.Value;
    }

    private void SetLevel()
    {
        _view.Level.text = _monster.Level.Value.ToString();
    }

    private void SetHp()
    {
        _view.Hp.text = $"{_monster.Hp.Value.ToString()} / {_monster.MaxHp.Value.ToString()}";
    }
    private void SetEp()
    {
        _view.Ep.text = $"{_monster.Ep.Value.ToString()} / {_monster.MaxEp.Value.ToString()}";
    }
    private void SetExe()
    {
        _view.Exe.text = $"{_monster.Exe.Value.ToString()} / {_monster.MaxExe.Value.ToString()}";
    }
    private void SetAtk()
    {
        _view.Atk.text = _monster.Atk.Value.ToString();
    }
    private void SetDfe()
    {
        _view.Dfe.text = _monster.Dfe.Value.ToString();
    }

}
