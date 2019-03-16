using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    public EnemyPrefs enemyPref;
    private Vector3 currentMoveDir;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeMoveDirection());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(currentMoveDir * enemyPref.speed * Time.deltaTime);
        //transform.LookAt(currentMoveDir + transform.position);
        //transform.rotation = Quaternion.LookRotation(currentMoveDir);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentMoveDir, Vector3.up), 0.15F);
        Vector3 direction = (currentMoveDir - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(direction);
        transform.rotation = look;

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("currentMoveDir: " + currentMoveDir);
            
        }
    }

    IEnumerator changeMoveDirection() {
        while(true){
            currentMoveDir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            //currentMoveDir = new Vector3(1,0, 1);
            yield return new WaitForSeconds(enemyPref.changeDirectionRate);
        }
    }
}
