using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 8f;
        transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed, transform.position.y, transform.position.z + Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed);
        if(health <= 0)
        {
            //Die
        }
    }
}
