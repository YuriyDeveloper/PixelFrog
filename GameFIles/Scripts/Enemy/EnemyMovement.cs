using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected LayerMask _layerMaskGround;
    [SerializeField] private Transform _checkForTurnBackPoint;
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private bool _onGround;
    private bool _rayCastForTurnBack;
    private bool _canTurnBack;

    private int _moveDirection;


    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _moveDirection = 1;
        _canTurnBack = true;
    }

    private void FixedUpdate()
    {
        ToMove();
    }

    private void ToMove()
    {
        _rigidbody.velocity = new Vector2(_moveDirection * _moveSpeed, _rigidbody.velocity.y);
        TurnBack();
    }

    //protected void CheckGround()
    //{
    //    _onGround = Physics2D.OverlapBox(_checkGroundPoint.position, new Vector2(1, 0.1F), 0, layerMaskGround);
    //}

    //private void ToJump()
    //{
    //    _rayCastForJump = Physics2D.Raycast(_checkingJumpAreaPoint.position, Vector2.down, 0.1F, layerMaskGround);
    //    _rayCastForJumpTwo = Physics2D.Raycast(_checkingJumpAreaPointTwo.position, Vector2.down, 0.1F, layerMaskGround);
    //    if (!_rayCastForJump & _rayCastForJumpTwo & _onGround) { rigidbody.velocity = new Vector2(directionForMove * 3, 15); }
    //    if (!_onGround) { jumping = true; }
    //    else { jumping = false; }
    //    if (rigidbody.velocity.y < -0.01F) { fall = true; }
    //    else { fall = false; }
    //}

    private void TurnBack()
    {
        _rayCastForTurnBack = Physics2D.Raycast(_checkForTurnBackPoint.position, Vector2.down, 0.3F);
       
        if (!_rayCastForTurnBack && _canTurnBack)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
            _canTurnBack = false;
            StartCoroutine(CanTurnBackCoroutine());
            switch (_moveDirection)
            {
                case -1:
                    _moveDirection = 1;
                break;
                case 1:
                    _moveDirection = -1;
                break;
            }
        }
    }

    private IEnumerator CanTurnBackCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        _canTurnBack = true;
    }
}
