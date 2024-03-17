using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Transform _transform;
    Rigidbody2D _rb;
    Vector2 _velocity;
    public Vector2 _jumpForce = new Vector2(0,5);
    public Vector2 _respawnPos;
    PlayerManager _manager;
    public GameObject WC1;
    public GameObject WC2;
    public GameObject _rain;
    public Image _cloud;
    public SpriteRenderer _spriteRenderer;
    public Vector2 initCloudPos;
    public Vector2 endCloudPos;

    public GameObject states;


    public bool _grounded = false;
    public bool _canWallJumpR = false;
    public bool _canWallJumpL = false;
    public bool _HasJumpedR = false;
    public bool _HasJumpedL = false;
    public bool _winesClimbing = false;
    public bool _inWater = false;
    public bool _Storm = false;
    public bool _Raining = false;


    public float _maxVel;
    public float _speedFactor;
    public float _climbSpeed;
    public float _climbSpeedX;
    public float _frictionX;
    public float _frictionY;
    public float _velYFactor;
    public float _velYFactorWallJump;
    public float _wallJumpForceX;


    public LayerMask _groundLayer;
    public LayerMask _wallLayer;


    public float _timerFrictionX;
    public float _frictionDelay;


    float _basicGravityScale;
    float _basicMass;
    public float _waterMass;


    public int _jumpCount;
    public int _jumpMax;
    bool _climbingButt = false;
    bool _unClimbingButt = false;

    public Animator childAnimator;
    public Animator adultAnimator;
    public Animator oldAnimator;

    Animator _animator;
    void Start()
    {
        _jumpMax = 2;
        _transform = transform;
        _rb = GetComponent<Rigidbody2D>();
        _basicGravityScale = _rb.gravityScale;
        _basicMass = _rb.mass;
        _manager = GetComponent<PlayerManager>();


        _animator = childAnimator;
        adultAnimator.gameObject.SetActive(false);
        oldAnimator.gameObject.SetActive(false);
    }

    void Update()
    {
        Move();
        AddSpeedVelY();
        setAnim();
        if (_winesClimbing)
        {
            _rb.gravityScale = 0;
            if (_climbingButt)
            {
                _rb.velocity = new(0, _climbSpeed * Time.deltaTime);
            }
            else if (_unClimbingButt)
            {
                _rb.velocity = new(0, -_climbSpeed * Time.deltaTime);
            }
            else if (!_climbingButt || !_unClimbingButt)
            {
                _rb.velocity = new(_rb.velocity.x/_climbSpeedX, 0);
            }
        }
        else if (!_winesClimbing && !_Storm)
        {
            _rb.gravityScale = _basicGravityScale;
        }
    }

    public void ChangeAnimator(int age)
    {
        childAnimator.gameObject.SetActive(false);
        adultAnimator.gameObject.SetActive(false);
        oldAnimator.gameObject.SetActive(false);

        switch(age)
        {
            case 0:
                _animator = childAnimator;
                break;
            case 1:
                _animator = adultAnimator;
                break;
            case 2:
                _animator = oldAnimator;
                break;
            default:
                _animator = oldAnimator;
                break;
        }

        _animator.gameObject.SetActive(true);
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        _velocity = ctx.ReadValue<Vector2>();
    }

    private void setAnim()
    {
        if (_rb.velocity.x < -0.05f)
        {
            states.transform.localScale = new(-1f, 1f, 1f);
            _spriteRenderer.flipX = true;
        }
        else if ( _rb.velocity.x > 0.05f)
        {
            states.transform.localScale = new(1f, 1f, 1f);
            _spriteRenderer.flipX = false;
        }

        if (_grounded && Mathf.Abs(_rb.velocity.x) > 0.1f)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        if (_canWallJumpL || _canWallJumpR)
        {
            if(_animator.GetBool("WallSlide") == false)
            {
                _animator.Play("WallSlide");
                _animator.SetBool("WallSlide", true);
            }
            
        }
        else
        {
            _animator.SetBool("WallSlide", false);
        }

        if(_rb.velocity.y < -0.001f) 
        {
            _animator.SetBool("Falling", true);
        }
        else
        {
            _animator.SetBool("Falling", false);
        }

    }

    public void EnterWater()
    {
        _animator.SetBool("Swimming", true);
        _rb.velocity = Vector2.zero;
        _rb.mass = _waterMass;
        _grounded = false;
        _jumpCount = 2;
        _inWater = true;
    }

    public void ExitWater()
    {
        _animator.SetBool("Swimming", false);
        _rb.mass = _basicMass;
        _inWater = false;
    }
    public void IsGrounded()
    {
        if (!_winesClimbing && !_Storm)
        {
            _animator.SetBool("Jumping", false);
            _animator.SetBool("Grounded", true);
            _animator.Play("Idle", -1, 0f);
            _grounded = true;
            _rb.gravityScale = _basicGravityScale;
        }
        _rb.velocity = new(_rb.velocity.x, 0);
        _HasJumpedR = false;
        _HasJumpedL = false;
        _jumpCount = 0;
    }

    public void ExitGround()
    {
        _grounded = false;
        _animator.SetBool("Grounded", false);
    }

    private void Move()
    {
        if (_velocity.x != 0)
        {
            _rb.AddForce(new Vector2(_velocity.x * _speedFactor * Time.deltaTime, 0), ForceMode2D.Force) ;
            if (_rb.velocity.x >= _maxVel)
            {
                _rb.velocity = new Vector2(_maxVel, _rb.velocity.y);
            }
            else if (_rb.velocity.x <= -_maxVel)
            {
                _rb.velocity = new Vector2(-_maxVel, _rb.velocity.y);
            }
        }
        else if (Time.time > _timerFrictionX)
        {
            _rb.velocity = new (_rb.velocity.x * _frictionX , _rb.velocity.y);
        }
    }

    private void AddSpeedVelY()
    {
        if (!_winesClimbing)
        {
            if (_rb.velocity.y < 0 && ((!_canWallJumpR && !_canWallJumpL) && !_grounded))
            {
                _rb.velocity = new(_rb.velocity.x, _rb.velocity.y - _velYFactor);
            }
            else if (_rb.velocity.y < 0 && ((_canWallJumpR || _canWallJumpL) && !_grounded))
            {
                _rb.velocity = new(_rb.velocity.x, _rb.velocity.y + _velYFactorWallJump);
            }
        }
    }


    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (_jumpMax == 0)
                return;

            if (_grounded || _jumpCount < _jumpMax && (!_canWallJumpL && !_canWallJumpR)) 
            {
                _jumpCount++;
                Jumping();
            }
            else if (!_grounded && (_canWallJumpL || _canWallJumpR))
            {
                _jumpCount++;
                if (_canWallJumpL && !_HasJumpedL) { WallJump(false); }
                else if (_canWallJumpR && !_HasJumpedR) { WallJump(true); }
            }
        }
    }

    public void Jumping()
    {
        _animator.Play("Jump", -1, 0f);
        _animator.SetBool("Jumping", true);
        _animator.SetBool("Falling", false);
        _rb.velocity = new(_rb.velocity.x, 0);
        _rb.AddForce(_jumpForce, ForceMode2D.Impulse);
    }

    public void Climb(InputAction.CallbackContext ctx)
    {
        _climbingButt = ctx.ReadValueAsButton();    
    }

    public void UnClimb(InputAction.CallbackContext ctx)
    {
        _unClimbingButt = ctx.ReadValueAsButton();
    }

    public void P(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (ctx.performed && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    private void WallJump(bool _isRight)
    {
        if (_isRight)
        {
            _HasJumpedR = true;
            _HasJumpedL = false;
        }
        else if (!_isRight)
        {
            _HasJumpedR = false;
            _HasJumpedL = true;
        }
        _jumpForce.x = _isRight ? _wallJumpForceX : -_wallJumpForceX;
        _rb.velocity = new(0, 0);
        _rb.AddForce(_jumpForce, ForceMode2D.Impulse);
        _canWallJumpR = false; _canWallJumpL = false;
        _timerFrictionX = Time.time + _frictionDelay;
        _jumpForce.x = 0;
        _animator.SetBool("Jumping", true);
        _animator.SetBool("Falling", false);
    }

    public void Death()
    {
        StartCoroutine(DeathAnim());
        _rb.velocity = Vector2.zero;
        _transform.position = _respawnPos;
    }
    public IEnumerator DeathAnim()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = true;
    }
    public IEnumerator DoStorm(float _stormDuration, float _stormForce, GameObject se)
    {
        float time = 0f;
        _Storm = true;
        _rb.gravityScale = -_stormForce;
        se.SetActive(true);
        se.GetComponent<ParticleSystem>().Play();
        se.transform.position = _transform.position;
        yield return new WaitForSeconds(_stormDuration);

        _rb.gravityScale = _basicGravityScale;
        _Storm = false;
    }

    public void ActiveStorm(float s, float f, GameObject SE)
    {
        if (_manager.ageState >= 2 && !_Storm && _grounded)
            StartCoroutine(DoStorm(s, f, SE));
    }

    public IEnumerator DoRain(float _rainDuration)
    {
        _Raining = true;
        float time = 0f;
        while (time/(_rainDuration - 1) < 1)
        {
            time += Time.deltaTime;
            _cloud.transform.position = Vector2.Lerp(initCloudPos, endCloudPos, time / (_rainDuration - 1));
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.5f);
        _rain.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(_rainDuration);
        _rain.GetComponent<ParticleSystem>().Stop();
        time = 0f;
        while (time / (_rainDuration - 1) < 1)
        {
            time += Time.deltaTime;
            _cloud.transform.position = Vector2.Lerp(endCloudPos, initCloudPos, time / (_rainDuration - 1));
            yield return new WaitForEndOfFrame();
        }
        _Raining = false;
    }

    public void ActiveRain(float s)
    {
        if (!_Raining && _manager.ageState >= 2)
            StartCoroutine(DoRain(s));
    }
}
