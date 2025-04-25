using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    #region Publics
    

    #endregion


    #region Unity Api

    private void Start()
    {
        _myCollider = GetComponent<PolygonCollider2D>();
          _rigidbody2D = GetComponent<Rigidbody2D>();  
          //_renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!_isJumping)
        {
            _animator.SetFloat("Speed", Mathf.Abs(_rigidbody2D.linearVelocity.x));
            _rigidbody2D.linearVelocity = new Vector2(_xMove * _speed * Time.deltaTime, _rigidbody2D.linearVelocity.y);
        }
        else
        {
            Vector2 force = new Vector2(_horizontal * _airBornforce, 0);
            _rigidbody2D.AddForce(force, ForceMode2D.Force);
        }
    }

        

    private void Update()
    {
        _xMove = Mathf.SmoothDamp(_xMove,_horizontal, ref _velocity, _smoothtime);
        if (Physics2D.OverlapCircle(_GroundCheck.position, _radiusForCollisionCheck, LayerMask.GetMask("Ground"))
            || Physics2D.OverlapCircle(_GroundCheck.position, _radiusForCollisionCheck, LayerMask.GetMask("Mur"))
            )
        {
            _jumpnb = 0;
            _isJumping = false;
        }else
        {
            _isJumping = true; 
        }
        
            _timeSinceDesactivation += Time.deltaTime;

            if (_timeSinceDesactivation >= _timeToReactivate)
            {
                _myCollider.enabled = true;
            }
    }

    #endregion


    #region Utils

    public void Move2D(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;
        if (_horizontal < 0) _renderer.flipX = true;
        if(_horizontal > 0.1f) _renderer.flipX = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (_jumpnb < 1)
        {
            if (context.started)
            {
                _rigidbody2D.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
                _jumpnb += 1;

            }
        }
    }

    public void GetDawn(InputAction.CallbackContext context)
    {
        Collider2D hit =
            Physics2D.OverlapCircle(_GroundCheck.position, _radiusForCollisionCheck, LayerMask.GetMask("Mur"));
        if(hit != null)
            {
                // GameObject touchedObject = hit.gameObject;
                //
                // Collider2D col = touchedObject.GetComponent<BoxCollider2D>();
                //
                // col.enabled = false;
                //
                // _lastCollider = col;
                _myCollider.enabled = false;
                _timeSinceDesactivation = 0f;
            }
    }
    

    #endregion


    #region Main Methode

        

    #endregion
        
        
    #region Privates

    [SerializeField] private float _speed;
    [SerializeField] private float _radiusForCollisionCheck;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _smoothtime=.1f;
    [SerializeField] private float _airBornforce;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _GroundCheck;
    [SerializeField] private PolygonCollider2D _myCollider;
    
    private float _horizontal;
    private float _xMove;
    private float _velocity;
    
    private int _jumpnb;
    
    private bool _isJumping;
    
    private Rigidbody2D _rigidbody2D;
    private Collider2D _lastCollider;
    private float _timeSinceDesactivation;
    [SerializeField] private float _timeToReactivate;

    #endregion
}
