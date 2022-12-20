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
    private WaitForSeconds _cycle;

    private Coroutine _attackCoroutine;
    private bool _isRunCoroutine;

    private void Start() 
    {
        _cycle = new WaitForSeconds(_attackCycle);
    }

    private void OnEnable() 
    {
        GameManager.Instance.PlayerMon = gameObject;
    }

    public void MoveToTarget(Vector3 Target)
    {
        transform.LookAt(Target);

        Vector3 monsterPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 targetPosition = new Vector3(Target.x, 0f, Target.z);
        float Distance = Vector3.Distance(targetPosition, monsterPosition);

        if(Distance > 0.5)
        {
            transform.Translate(transform.forward * _moveSpeed * Time.deltaTime);
        }
        else
        {
            if(TargetObject.tag == "Enemy")
            {
                _attackCoroutine = StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        _isRunCoroutine = true;

        while(true)
        {
            _anim.SetTrigger("Attack");
            yield return _cycle;
        }
    }

    public void StopAttack()
    {
        if(_isRunCoroutine)
        {
            _isRunCoroutine = false;
            StopCoroutine(_attackCoroutine);
        }
    }



}
