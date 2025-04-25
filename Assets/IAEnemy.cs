using UnityEngine;

public class IAEnemy : MonoBehaviour
{
    #region Publics

        

    #endregion


    #region Unity Api

    private void Start()
    {
        _moveToSecondPosition = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_moveToFirstPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetToMove1.position, _speed * Time.deltaTime);
            _spriteRenderer.flipX = true;
            
            if (Vector2.Distance(transform.position, _targetToMove1.position) < 0.5f)
            {
                _moveToFirstPosition = false;
                _moveToSecondPosition = true;
            }
        }

        if (_moveToSecondPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetToMove2.position, _speed * Time.deltaTime);
            _spriteRenderer.flipX = false;
            
            if (Vector3.Distance(transform.position, _targetToMove2.position) < 0.5f)
            {
                _moveToFirstPosition = true;
                _moveToSecondPosition = false;
            }
        }
        
    }
    

    #endregion


    #region Utils

        

    #endregion


    #region Main Methode

        

    #endregion
        
        
    #region Privates

    [SerializeField] private Transform _targetToMove1;
    [SerializeField] private Transform _targetToMove2;
    [SerializeField] private float _speed = 0.1f;
    private bool _moveToFirstPosition;
    private bool _moveToSecondPosition;
    private SpriteRenderer _spriteRenderer;

    #endregion
}
