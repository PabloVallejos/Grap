using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 dir;
    Animator anima;
    SpriteRenderer spr;
    public Transform check;
    bool land;
    public float speed;
    public float jump;
    public float maxS;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        if (rb.velocity.x < maxS && rb.velocity.x > -maxS)
        {
            rb.AddForce(dir * speed);
            anima.SetBool("Moving", true);
        } else { anima.SetBool("Moving", false); }
        if (dir.x > 0)
        {
            spr.flipX = false;
        } else if (dir.x < 0) { spr.flipX = true; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            check = collision.gameObject.transform;
        }

        if (collision.gameObject.tag == "Pit")
        {
            transform.position = check.position;
            rb.velocity = Vector2.zero;
        }

        if (collision.gameObject.tag == "Bug")
        {
            collision.gameObject.GetComponent<Bug>().AddPoints();
        }
    }
}
