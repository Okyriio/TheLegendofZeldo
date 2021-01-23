using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlayserState
{
    Walk,
    Attack,
    Interact
}
public class LinkMovement : MonoBehaviour
{
    public PlayserState currentState;
    [SerializeField] private float speed;
    private Rigidbody2D _myRigidbody;
    private Vector3 _change;
    private Animator _animator;

    void Start()
    {
        currentState = PlayserState.Walk;
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       _change = Vector3.zero;
       _change.x = Input.GetAxisRaw("Horizontal");
       _change.y = Input.GetAxisRaw("Vertical");
       if (Input.GetButtonDown("attack") && currentState != PlayserState.Attack)
       {
           StartCoroutine(AttackCo());
       }
       else if (currentState == PlayserState.Walk)
       {
           UpdateAnimationAndMove();
       }    

    }

    private IEnumerator AttackCo()
    {
        _animator.SetBool("Attacking", (true));
        currentState = PlayserState.Attack;
        yield return null;
        _animator.SetBool("Attacking", (false));
        yield return new WaitForSeconds(0.3f);
        currentState = PlayserState.Walk;
    }

    void UpdateAnimationAndMove()
    {
        if (_change != Vector3.zero)
        {
            MoveCharacter();
            _animator.SetFloat("xDir", _change.x);
            _animator.SetFloat("yDir", _change.y);
            _animator.SetBool("Moving", true);
        }
        else
        {
            _animator.SetBool("Moving", false);
        }
    }

    
    void MoveCharacter()
    {
        _myRigidbody.MovePosition(transform.position + _change * (speed * Time.deltaTime));
    }
}

