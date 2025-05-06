using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFX fx { get; private set; }
    #endregion

    [Header("KnockBack info")]
    [SerializeField] protected Vector2 knockbackDirection;//击退方向
    [SerializeField] private float knockbackDuration;//击退持续时间
    protected bool isKnocked;


    [Header("Collision Info")]
    public Transform attackCheck;
    public float attackCheckRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask GroundHow;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;

    public int FacingDirection { get; private set; } = 1;
    protected bool FacingRight = true;

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        fx =GetComponentInChildren<EntityFX>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
    }
    public virtual void Damage()
    {
        fx.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockback");
        Debug.Log(gameObject.name + " got hurt!");
    }

    protected virtual IEnumerator HitKnockback()
    {
        isKnocked = true;

        rb.velocity = new Vector2 (knockbackDirection.x * FacingDirection, knockbackDirection.y);
        yield return new WaitForSeconds(knockbackDuration);
        isKnocked = false;
    }

    #region Velocity
    public void setZeroVelocity() 
    {
        if (isKnocked)
            return;
        rb.velocity = new Vector2(0, 0);
    } 

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if(isKnocked)
            return;
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        TurnAroundController(_xVelocity);
    }
    #endregion

    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, GroundHow);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, wallCheckDistance, GroundHow);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * FacingDirection, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region Flip
    public void TurnAround()
    {
        FacingDirection *= -1;
        FacingRight = !FacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void TurnAroundController(float _x)
    {
        if (_x > 0 && !FacingRight)
            TurnAround();
        else if (_x < 0 && FacingRight)
            TurnAround();
    }
    #endregion
}
