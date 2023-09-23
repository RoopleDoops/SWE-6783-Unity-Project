using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;

    [SerializeField] private LayerMask solidWall;

    [SerializeField] private float moveSpeed = 4f;
    private float dirHori = 1f; // initial direction of x-axis movement
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = new Vector2(dirHori * moveSpeed, rb.velocity.y);
        if (hitWall())
        {
            dirHori = -dirHori; //flip direction
        }
        else
        {
            rb.velocity = moveVec; // commit to movement
        }
    }

    private bool hitWall()
    {
        Vector2 dirVec = Vector2.right;
        if (dirHori == -1) dirVec = Vector2.left;

        return Physics2D.BoxCast(col.bounds.center, col.bounds.size*0.9f, 0f, dirVec, 0.1f, solidWall);
    }
}
