using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Transform ghost;
    private Transform player;

    [SerializeField] private LayerMask solidWall;

    [SerializeField] private float moveSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        ghost = GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towrads player
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector2 pPos = player.position;
        Vector2 gPos = ghost.position;

        ghost.position = Vector2.MoveTowards(gPos, pPos, moveSpeed * Time.deltaTime);
    }
}
