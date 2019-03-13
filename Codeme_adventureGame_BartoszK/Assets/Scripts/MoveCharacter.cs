using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 1000f;
    public float rotSpeed = 800f;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotSpeed;
       // float strafe = Input.GetAxis("Horizontal2") * speed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        //strafe *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        //playerRB.AddRelativeForce(0, 0, translation);
        //playerRB.AddRelativeTorque(0, rotation, 0);
    }
}
