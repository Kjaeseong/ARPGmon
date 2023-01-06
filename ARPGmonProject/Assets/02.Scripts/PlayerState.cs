using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.ARCoreExtensions;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private GameObject _lockOnTarget;
    [SerializeField] private MonsterStatus _playerMonster;
    private bool _isLockOn;

    private void Start() 
    {
        GameManager.Instance.Gps.SetEarthManager(GetComponentInChildren<AREarthManager>());
    }

    private void OnDisable() 
    {
        GameManager.Instance.Gps.SetEarthManager(null);
    }

    private void FixedUpdate() 
    {
        TargetLockOn();
    }

    private void AttackToTarget()
    {
        if(_isLockOn)
        {
            _playerMonster.Target = _lockOnTarget;
        }
        else
        {
            _playerMonster.Target = null;
        }
    }

    private void TargetLockOn()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    _lockOnTarget = hit.transform.gameObject;
                    _isLockOn = true;
                }
                else
                {
                    _lockOnTarget = null;
                    _isLockOn = false;
                }
            }
        }
    }

    public void Evolution()
    {
        _playerMonster.EvolutionStep++;
    }

}
