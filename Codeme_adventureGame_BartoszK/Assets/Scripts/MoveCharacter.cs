using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 1000f;
    public float rotSpeed = 800f;
    public GameController gameController;

    void Update()
    {
        if (!gameController.freezeControls)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }

        if (Input.GetKeyDown(KeyCode.I)) {
   
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            //int damAmount = collision.collider.gameObject.GetComponent<Enemy_movement>().GetBitePower();
            gameController.GetDamage(dam: collision.collider.gameObject.GetComponent<Enemy_movement>().GetBitePower());
            Debug.Log("Now, that was a bite!");
        }

        if (collision.collider.gameObject.tag == "Gate")
        {
            int gateNo = collision.collider.gameObject.GetComponent<KeyData>().keyNumber;
            if (gameController.GetKeySlot(gateNo - 1))
            {
                Destroy(collision.collider.gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key") {
            gameController.SetKeySlot(other.gameObject.GetComponent<KeyData>().keyNumber - 1);
            Destroy(other.gameObject);
        }

        if (other.tag == "WinSpot")
        {
            gameController.WinGame();
        }
    }
}
