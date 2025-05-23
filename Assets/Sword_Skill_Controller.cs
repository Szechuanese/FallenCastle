using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Skill_Controller : MonoBehaviour
{
    private Animation anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;
    private bool canRotate;

    private void Awake()
    {
        anim = GetComponentInChildren<Animation>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }

    public void SetupSword(Vector2 _dir, float _gravityScale)
    {
        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;
    }
    private void Update()
    {
        if (canRotate)
            transform.right = rb.velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canRotate = false;
        cd.enabled = false;

        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        transform.parent =collision.transform;
    }
}
