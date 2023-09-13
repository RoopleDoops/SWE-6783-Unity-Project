using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float gravity = -0.1f;

    private float x_move = 0f;
    private float y_move = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        int keyRight = 0;
        int keyLeft = 0;
        bool keyJump = Input.GetKeyDown("space");
        // Get horizontal direction
        if (Input.GetKey("right")) keyRight = 1;
        if (Input.GetKey("left")) keyLeft = 1;
        int dirHori = keyRight - keyLeft;
        // Move player
        transform.position += new Vector3(moveSpeed*dirHori, 0f, 0f);
        // Jump
        if (keyJump) y_move += jumpForce;

        transform.position += new Vector3(0f, y_move, 0f);

        if (transform.position.y > 0f)
        {
            if (transform.position.y + y_move >= 0f) transform.position += new Vector3(0f, y_move, 0f);
            else transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

        if (y_move > 0f)
        {
            y_move += gravity;
        }

    }
}
