using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private PlayerMovement move;
    private SpriteRenderer sprite;
    private BoxCollider2D bCollider;
    private int health = 3;
    private bool dead;
    private float iTime = 0;
    [SerializeField] private float iTimeMax = 1f; // length of player invincibility after getting hit

    //Audio add in
    [SerializeField] 
    private AudioSource hitSoundEffect;
    [SerializeField] 
    private AudioSource lossSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMovement>();
        sprite = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        bCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Countdown player invincibility time
        if (iTime > 0f)
        {
            iTime -= Time.deltaTime;
            if (iTime <= 0f)
            {
                iTime = 0f;
                changeAlpha(1f); // reset player alpha
            }    
        }
    }

    // Hazard collision
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (iTime <= 0f && collision.gameObject.CompareTag("Hazard"))
        {
            // Trigger invincibility timer and transparent draw effect
            changeAlpha(0.5f);
            move.hitJump();
            iTime = iTimeMax;
            // Reduce health and resolve
            health -= 1;
            //play hit effect
            hitSoundEffect.Play();
        }
    }

    //Resetting happens in Failstate
    public void killPlayer() 
    {
        Destroy(GameObject.Find("BGM"));
        dead = true;
        bCollider.enabled = false; //player falls through ground
        move.enabled = false; //player loses control
        lossSoundEffect.Play();
    }

    public bool isDead()
    {
        return dead;
    }
    // Alters player's sprite alpha
    private void changeAlpha(float alpha)
    {
        Color newCol = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        sprite.color = newCol;
    }
    public int getCurrentHealth()
    {
        return health; 
    }
    public void setCurrentHealth(int sentHealth)
    {
        health = sentHealth;
    }
}
