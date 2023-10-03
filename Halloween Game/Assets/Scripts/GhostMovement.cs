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
    [SerializeField] private float moveSpeedBase = 1.5f;
    [SerializeField] private float moveSpeedCatchUp = 3f;
    [SerializeField] private float catchUpDistance = 8f;
    [SerializeField] private float activateDistance = 8f;
    private float moveSpeed;
    private bool activated = false; // starts chase with player

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = moveSpeedBase;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        ghost = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards player
        GetPlayerDistance();

        if (activated) ChasePlayer();

        UpdateSprite();
    }

    private void GetPlayerDistance()
    {
        // increase speed to catch up with player if too far away
        Vector2 pPos = player.position;
        Vector2 gPos = ghost.position;
        float pDist = Vector2.Distance(pPos, gPos);
        if (pDist < activateDistance) activated = true;
        if (pDist >= catchUpDistance) moveSpeed = pDist/catchUpDistance * moveSpeedCatchUp;
        else moveSpeed = moveSpeedBase;
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
