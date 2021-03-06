﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] GameObject _player;
    [SerializeField] bool _canMove;
    [SerializeField] Collider _attackCollider;
    [SerializeField] Animator _animator;

    void Awake()
    {
        //_player = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.isStopped)
        {
            if (_player != null)
            {
                StartCoroutine(Attack());
                _animator.SetBool("isAttacking", true);
            }
            else
            {
                StopCoroutine(Attack());
                _animator.SetBool("isAttacking", false);
            }
        }

        if (!_animator.GetBool("isDead"))
        {
            if (_player != null)
            {
                if((transform.position - _player.transform.position).sqrMagnitude > _agent.stoppingDistance)
                {
                    _agent.isStopped = false;
                    _animator.SetBool("isRunning", true);
                    _agent.SetDestination(_player.transform.position);
                }
                else
                {
                    //Debug.Log("why");
                    _animator.SetBool("isRunning", false);
                    _agent.isStopped = true;
                }
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

    public void PlayDeathAnim()
    {
        StartCoroutine(DeathAnim());
    }

    IEnumerator DeathAnim()
    {
        _animator.SetBool("isDead", true);

        while(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            yield return null;
        }

        while(_animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            yield return null;
        }

        Destroy(gameObject); 
    }
}
