using System.Runtime.CompilerServices;
using UnityEngine;

public class Playerscript : MonoBehaviour
{

    private float movementForce;
    private Rigidbody2D myRigidBody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementForce = 50;
    }
        
    
    // Update is called once per frame
    public void Update(){
        float v = 0;
        float h = 0;


        if (UnityEngine.Input.GetKey(KeyCode.W) && !UnityEngine.Input.GetKey(KeyCode.S))
        {
            v = 1;
        }
        if (UnityEngine.Input.GetKey(KeyCode.S) && !UnityEngine.Input.GetKey(KeyCode.W)){
            v = -1;
        }


        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * movementForce * Time.deltaTime;
        myRigidBody2D.MovePosition(myRigidBody2D.transform.position + tempVect);
    }

}

