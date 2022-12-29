using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    private enum State
    {
        IDLE, RUN, ATTACK
    }

    private State _state = State.IDLE;

    [SerializeField][Range(0, 50)] private float _moveSpeed;
    [SerializeField][Range(0, 1000)] private int _hp;
    [SerializeField][Range(0, 50)] private int _attack;
    [SerializeField][Range(0, 50)] private float _moveArea;
    [SerializeField][Range(0, 100)] private int _DropExe;
    
    private MonsterMovement _playerMonMovement;
    private MonsterStatus _playerMonStatus;
    public Vector3 StartPosition { get; set; }
    private Vector3 _movePosition;
    private GameObject _lockOnTarget;

    private int _maxHp;
    private int _nowHp;
    private bool _isTherePlayerMonInCollider;
    private bool _isDie;
    private bool _isBattle;

    private Coroutine _moveCoroutine;
    private WaitForSeconds _coroutineCycle = new WaitForSeconds(0.02f);
    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PlayerMonster")
        {
            _playerMonMovement = other.gameObject.GetComponent<MonsterMovement>();
            _playerMonMovement.InEnemyCollider = true;
            _isTherePlayerMonInCollider = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "PlayerMonster")
        {
            _playerMonMovement.InEnemyCollider = false;
            _isTherePlayerMonInCollider = false;
        }
    }

    private void OnEnable() 
    {
        MonsterInit();    
    }

    private void MonsterInit()
    {
        _maxHp = _hp;
        _nowHp = _hp;
        _isDie = false;
        StartPosition = transform.position;
    }

    public void TakeDamage(int Damage)
    {
        _nowHp -= Damage;
        _isBattle = true;

        if(_nowHp <= 0)
        {
            _nowHp = 0;
            Die();
        }
    }

    private void Die()
    {
        //_playerMonStatus.GetExe(_DropExe);
        // 상위 객체에 리스폰 요청
        gameObject.SetActive(false);
    }

    private void Attack()
    {
        //_playerMonStatus.TakeDamage(_attack);
        // 애니메이션
    }

    private void MoveTargetSet()
    {
        float x = Random.Range(StartPosition.x - _moveArea, StartPosition.x + _moveArea);
        float z = Random.Range(StartPosition.z - _moveArea, StartPosition.z + _moveArea);

        _movePosition = new Vector3(x, -1.3f, z);
    }

    private void Move()
    {
        transform.LookAt(_movePosition);
        transform.Translate(transform.forward * _moveSpeed * Time.deltaTime);
    }

    private void MoveTargetSet(GameObject Target)
    {
        _movePosition = Target.transform.position;
    }
    
    private void StateMachine(int State)
    {
        StopAllCoroutines();
        _moveCoroutine = StartCoroutine(MoveCoroutine(State));
    }

    private IEnumerator MoveCoroutine(int State)
    {
        switch(_state)
        {
            
        }

        if(_isBattle)
        {
            MoveTargetSet(_lockOnTarget);
        }
        else
        {
            MoveTargetSet();
        }

        while(true)
        {
            float Distance = Vector3.Distance(_movePosition, transform.position);

            if(Distance > 0.2)
            {
                Move();
                yield return _coroutineCycle;
            }
            else
            {
                if(_isBattle)
                {
                    Attack();
                }
            }

        }
    }

    private IEnumerator LockOn(GameObject Target)
    {
        while(true)
        {
            yield return _coroutineCycle;
        }
    }
}
