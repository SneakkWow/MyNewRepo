using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float verticalInput;

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        if (verticalInput < 0)
        {
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime * horizontalInput * -1);
        }
        else
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * horizontalInput * -1);
        }

        
    }
}
