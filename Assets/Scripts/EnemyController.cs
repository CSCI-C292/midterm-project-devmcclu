using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] GameObject _player;
    [SerializeField] bool _canMove;
    [SerializeField] Collider _attackCollider;

    void Awake()
    {
        //_player = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        if(_agent.isStopped && _player != null)
        {
            StartCoroutine(Attack());
        }
        else
        {
            StopCoroutine(Attack());
        }
        
        if (_player != null)
        {
            if((transform.position - _player.transform.position).sqrMagnitude > _agent.stoppingDistance)
            {
                _agent.SetDestination(_player.transform.position);
            }
        }
    }

    IEnumerator Attack()
    {
        _attackCollider.enabled = true;
        yield return new WaitForSeconds(3);
        _attackCollider.enabled = false;
    }

    public void SetPlayerObject(GameObject playerObject)
    {
        _player = playerObject;
    }
}
