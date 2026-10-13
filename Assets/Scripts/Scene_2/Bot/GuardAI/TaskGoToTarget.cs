using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private Transform[] _waypoints;
    private int _waypointsValue = Random.Range(0, 3);

    public TaskGoToTarget(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, target.position, GuardBT.speed * Time.deltaTime);
            _transform.LookAt(target.position);

            if (Vector3.Distance(_transform.position, target.position) >= 10f)
            {
                Transform wp = _waypoints[_waypointsValue];
                _transform.position = Vector3.MoveTowards(_transform.position, wp.position, GuardBT.speed * Time.deltaTime);
                _transform.LookAt(wp.position);
            }
        }
        
        state = NodeState.RUNNING;
        return state;
    }

}