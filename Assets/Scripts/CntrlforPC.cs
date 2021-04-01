using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool faceRight = true;
    
    public float speed = 20f; // player speed
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //Run
        float moveX = Input.GetAxis("Horizontal");// player direction
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * 8000);
        //Flip player
        if (moveX > 0 && !faceRight) 
            flip ();
        else if(moveX < 0 && faceRight)
        flip ();
    }

    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
