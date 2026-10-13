using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckEnemyInAttackRange : Node
{
    private Transform _transform;
    private Animator _animator;
    private Animation _animation;
    private float _attackCounter = 0f;

    public CheckEnemyInAttackRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _animation = transform.GetComponent<Animation>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        _attackCounter += Time.deltaTime;
        Transform target = (Transform)t;
        if (Vector3.Distance(_transform.position, target.position) <= GuardBT.attackRange)
        {
            _animator.SetBool("Attacking", true);
            _animator.SetBool("Walking", false);

            if (((int)_attackCounter) % 2 == 0)
            {
                _animator.SetBool("Attacking", false);
            }

            state = NodeState.SUCCESS;
            return state;
        }

        _animator.SetBool("Attacking", false);
        _animator.SetBool("Walking", true);

        state = NodeState.FAILURE;
        return state;
    }
}