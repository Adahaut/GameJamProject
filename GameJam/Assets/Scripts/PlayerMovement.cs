using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Transform _transform;
    Rigidbody2D _rb;
    Vector2 _velocity;
    public Vector2 _jumpForce = new Vector2(0,5);
    bool _grounded = false;
    public float _maxVel;
    public float _speedFactor;
    public float _frictionX;
    public float _frictionY;
    public float _velYFactor;
    public LayerMask _groundLayer;
    void Start()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AddSpeedVelY();
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        _velocity = ctx.ReadValue<Vector2>();
    }

    bool IsGrounded()
    {
        Vector2 position = _transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.55f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _groundLayer);
        if (hit.collider != null)
        {
            _rb.velocity = new(_rb.velocity.x, 0);
            return true;
        }

        return false;
    }
    private void Move()
    {
        if (_velocity.x != 0)
        {
            _rb.AddForce(new Vector2(_velocity.x * _speedFactor, 0), ForceMode2D.Force);
            if (_rb.velocity.x >= _maxVel)
            {
                _rb.velocity = new Vector2(_maxVel, _rb.velocity.y);
            }
            else if (_rb.velocity.x <= -_maxVel)
            {
                _rb.velocity = new Vector2(-_maxVel, _rb.velocity.y);
            }
        }
        else
        {
            _rb.velocity = new (_rb.velocity.x * _frictionX, _rb.velocity.y);
        }
    }

    private void AddSpeedVelY()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity = new(_rb.velocity.x, _rb.velocity.y - _velYFactor);
        }
    }

    private void RemoveSpeedVelY()
    {
        if (_rb.velocity.y > 0)
        {
            _rb.velocity = new(_rb.velocity.x, _rb.velocity.y - _frictionY);
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (IsGrounded()) 
            {
                Jumping();
            }
        }
    }

    public void Jumping()
    {
        _rb.velocity = new(_rb.velocity.x, 0);
        _rb.AddForce(_jumpForce, ForceMode2D.Impulse);
    }
}
