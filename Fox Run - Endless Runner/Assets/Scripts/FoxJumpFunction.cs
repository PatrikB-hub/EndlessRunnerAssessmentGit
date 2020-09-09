using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxJumpFunction : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public bool playerIsOnTheGround = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsOnTheGround)
        {
            rb2D.AddForce(new Vector3(0f, 6f, 0f), ForceMode2D.Impulse);
            playerIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col2D)
    {
        if (col2D.gameObject.tag == "platform")
        {
            playerIsOnTheGround = true;
        }
    }
}
