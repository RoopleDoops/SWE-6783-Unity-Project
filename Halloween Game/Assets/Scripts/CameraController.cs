using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // position cannot simply be player position since the z-axis is different.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
