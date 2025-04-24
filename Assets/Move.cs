using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    #region Publics

        

    #endregion


    #region Unity Api

    private void Start()
    {
          _rigidbody2D = GetComponent<Rigidbody2D>();  
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2(_horisontal * _speed * Time.deltaTime, _rigidbody2D.linearVelocity.y);
        Vector2 force = new Vector2(_horisontal * _speed, 0);
        _rigidbody2D.AddForce(force, ForceMode2D.Force);
    }
    
    #endregion


    #region Utils

    public void Move2D(InputAction.CallbackContext context)
    {
        _horisontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (Physics2D.OverlapCircle(_rigidbody2D.position, _radiusForCollisionCheck, LayerMask.GetMask("Ground")))
            { 
                _rigidbody2D.AddForce(Vector2.up*_forceJump, ForceMode2D.Impulse);
                
            }
        }
    }

    #endregion


    #region Main Methode

        

    #endregion
        
        
    #region Privates

    [SerializeField] private float _speed;
    [SerializeField]private float _radiusForCollisionCheck;
    [SerializeField] private float _forceJump;
    private Rigidbody2D _rigidbody2D;
    private float _horisontal;

    #endregion
}
