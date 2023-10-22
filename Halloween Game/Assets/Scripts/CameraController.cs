using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;

    //[SerializeField] float yBuffer = 4f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        // position cannot simply be player position since the z-axis is different.
        //transform.position = new Vector3(player.position.x, player.position.y+yBuffer, transform.position.z);
    }
}
