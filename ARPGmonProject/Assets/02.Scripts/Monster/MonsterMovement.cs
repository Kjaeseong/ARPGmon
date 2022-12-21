using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [field: SerializeField] public GameObject TargetObject { get; set; }
    [SerializeField][Range(0, 50)] private float _moveSpeed;
    [SerializeField] private bool _isMove;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _attackCycle;
    [SerializeField] private float _coroutineCycle;
    private WaitForSeconds _attackCorouCycle;
    private WaitForSeconds _corouCycle;
    private Coroutine _attackCoroutine;
    private Coroutine _moveCoroutine;

    private Coroutine[] _coroutine = new Coroutine[2];

    private bool _isRunCoroutine;

    public bool InEnemyCollider { get; set; }

    private void Start() 
    {
        _attackCorouCycle = new WaitForSeconds(_attackCycle);
        _corouCycle = new WaitForSeconds(_coroutineCycle);
    }

    private void OnEnable() 
    {
        //GameManager.Instance.PlayerMon = gameObject;
    }

    public void MoveToTarget(GameObject Target)
    {
        transform.LookAt(Target.transform.position);
        transform.Translate(transform.forward * _moveSpeed * Time.deltaTime);
    }

    private float DistToTarget(GameObject Target)
    {
        Vector3 monsterPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 targetPosition = new Vector3(Target.transform.position.x, 0f, Target.transform.position.z);
        return Vector3.Distance(targetPosition, monsterPosition);
    }

    public void MonsterAction(GameObject Target)
    {
        StopAction();
        _moveCoroutine = StartCoroutine(MoveCoroutine(Target));
    }

    private IEnumerator MoveCoroutine(GameObject Target)
    {
        _anim.SetBool("Run", true);
        while(true)
        {
            MoveToTarget(Target);

            if(Target.tag == "Enemy")
            {
                Debug.Log(Target.name);
                if(DistToTarget(Target) <= 0.5) // 임시로 거리판별 사용하였음. 추후 적 몬스터의 콜라이더에 들어가면 공격명령을 내리는 것으로 변경
                {
                    _anim.SetBool("Run",false);
                    yield return _attackCoroutine = StartCoroutine(AttackCoroutine(Target));
                    //_attackCoroutine = StartCoroutine(AttackCoroutine(Target));
                    yield break;
                }
            }
            else
            {
                if(DistToTarget(Target) <= 0.2)
                {
                    _anim.SetBool("Run",false);
                    transform.LookAt(
                        new Vector3(
                            Camera.main.transform.position.x,
                            transform.position.y,
                            Camera.main.transform.position.z
                        )
                    );
                    
                    yield break;
                }
            }
            yield return _corouCycle;
        }
    }

    public void StopAction()
    {
        StopAllCoroutines();
    }

    private IEnumerator AttackCoroutine(GameObject Target)
    {
        while(true) 
        {
            // TODO : 데미지 부여 코드 추가해야 함.
            transform.LookAt(Target.transform.position);
            _anim.SetTrigger("Attack");
            yield return _attackCorouCycle;
        }
    }






}
