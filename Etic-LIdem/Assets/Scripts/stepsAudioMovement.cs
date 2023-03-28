using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepsAudioMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private Vector3 _patrolPositionOne;
    [SerializeField] private Vector3 _patrolPositionTwo;
    [SerializeField] private float _movementSpeed;

    private Vector3 _targetPosition;
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _targetPosition) < 0.2f)
        {
            if (_targetPosition == _patrolPositionOne)
            {
                _targetPosition = _patrolPositionTwo;
            }
            else
            {
                _targetPosition = _patrolPositionOne;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _targetPosition = _patrolPositionOne;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
