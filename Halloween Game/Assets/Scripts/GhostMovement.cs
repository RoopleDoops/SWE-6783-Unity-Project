using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Transform ghost;
    private SpriteRenderer sprite;
    private Transform player;
    private Vector2 targetPos;
    [SerializeField] private LayerMask solidWall;
    [SerializeField] private float moveSpeed = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        ghost = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towrads player
        ChasePlayer();

        UpdateSprite();
    }

    private void ChasePlayer()
    {
        // Slowly lerp towards player position
        Vector2 pPos = player.position;
        Vector2 gPos = ghost.position;
        targetPos = Vector2.Lerp(targetPos, pPos, 0.01f);

        ghost.position = Vector2.MoveTowards(gPos, targetPos, moveSpeed * Time.deltaTime);
    }

    private void UpdateSprite()
    {
        // Flip sprite depending on player x value
        if (player.position.x < ghost.position.x) sprite.flipX = false;
        else sprite.flipX = true;
    }
}
