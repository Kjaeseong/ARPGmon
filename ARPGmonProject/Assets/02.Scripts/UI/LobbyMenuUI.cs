using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenuUI : MonoBehaviour
{
    private LobbyMainUI _main;
    [SerializeField] private MonsterMovement _monster;
    [SerializeField] private GameObject _food;
    [SerializeField] private GameObject _sandbag;
    [SerializeField] private float _coroutineCycle;
    [SerializeField] private float _exitCoroutineTime;
    [SerializeField] private GameObject _moveTarget;
    [SerializeField] private GameObject[] _buttons;


    private WaitForSeconds _cycle;
    private WaitForSeconds _exitCoroutine;
    private Coroutine _coroutine;
    private bool _isActiveCoroutine;



    private void Start() 
    {
        _main = GetComponentInParent<LobbyMainUI>();
        _cycle = new WaitForSeconds(_coroutineCycle);
        _exitCoroutine = new WaitForSeconds(_exitCoroutineTime);
    }

    public void InfoActivate()
    {
        _main.MonsterInfo.gameObject.SetActive(true);
    }

    public void Feed()
    {
        _monster.MonsterAction(_food);
        _coroutine = StartCoroutine(MonsterAction());
    }

    public void Training()
    {
        _monster.MonsterAction(_sandbag);
        _coroutine = StartCoroutine(MonsterAction());
    }

    public void OptionActivate()
    {
        _main.Option.gameObject.SetActive(true);
    }

    public void InventoryActivate()
    {
        _main.Inventory.gameObject.SetActive(true);
    }

    public void StartAdventure()
    {
        GameManager.Instance.Scene.Change("03.Adventure");
    }

    private IEnumerator MonsterAction()
    {
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].SetActive(false);
        }

        yield return _exitCoroutine;
        _monster.MonsterAction(_moveTarget);

        for(int i = 0; i < _buttons.Length; ++i)
        {
            _buttons[i].SetActive(true);
        }


    }



}
