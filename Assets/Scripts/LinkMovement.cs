using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinkMovement : MonoBehaviour
{
    [SerializeField]  float speed;
    private Vector2 _direction;
    private Vector2 _targetPos;
    private Animator _animator;
    private const float DashRange = 1.4f;
    private enum Facing
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    private Facing _facingDir = Facing.DOWN;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move() //Moves the player
    {
        transform.Translate(_direction * (speed * Time.deltaTime));
        if (_direction.x != 0 || _direction.y != 0)                          // PUT DEADZONE HERE
        {
              SetAnimatorMove(_direction);
        }
        else
        {
            _animator.SetLayerWeight(1,0);
        }
    }

    private void TakeInput() // Takes input to move the player
    {
        _direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
          _direction += Vector2.up;
          _facingDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.down; 
            _facingDir = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.left; 
            _facingDir = Facing.LEFT;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.right; 
            _facingDir = Facing.RIGHT;
        }
        
    }

    private void SetAnimatorMove(Vector2 _direction)
    {
        _animator.SetLayerWeight(1,1);
        _animator.SetFloat("xDir", _direction.x);
        _animator.SetFloat("yDir", _direction.y);

    }
}
