using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterMovment : MonoBehaviour
{
    private enum State
    {
        IDLE, MOVE, ATTACK
    }
    [SerializeField] private float _moveArea;
    [SerializeField] private float _moveSpeed;
    private Vector3 _movePosition;
    [SerializeField] private Coroutine[] _stateCoroutine = new Coroutine[3];
    public GameObject Target
    {
        get => Target;
        set
        {
            if(value == null)
            {
                _isTargeting = false;
                MonsterState = (int)State.IDLE;
            }
            else
            {
                _isTargeting = true;
                Target = value;
                MonsterState = (int)State.MOVE;
            }
        }
    }
    private bool _isTargeting;
    public int MonsterState
    {
        get => MonsterState;
        set
        {
            MonsterState = value;
            SetState(MonsterState);
        }
    }



    private void SetState(int State)
    {

    }

    private void MoveToTarget()
    {
        _movePosition = new Vector3( Target.transform.position.x, 0f, Target.transform.position.z);
        float Dist = Vector3.Distance(_movePosition, transform.position);

        if(Dist >= 0.5)
        {
            transform.LookAt(Target.transform);
            transform.Translate(0f, 0f, _moveSpeed * Time.deltaTime);
        }
        else
        {
            
        }
    }

    private IEnumerator MoveCoroutine()
    {
        while(true)
        {
            transform.LookAt(Target.transform);
            transform.Translate(0f, 0f, _moveSpeed * Time.deltaTime);
            yield return GameManager.Instance.Cycle;
        }
    }
}
