using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private float velocityY = 0f;
    private float velocityX = 0f;
    [SerializeField]
    private float VelocityMultiplier = 3;
    private GameObject playerObj = null;
    private float xCoord;
    private float yCoord;
    private float denominator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        
        velocityX = FindMovementRatio('x');
        velocityY = FindMovementRatio('y');

        if (transform.position.x < playerObj.transform.position.x){
            velocityX = velocityX * -1;
        }
        if (transform.position.y < playerObj.transform.position.y){
            velocityY = velocityY * -1;
        }
        transform.position += new UnityEngine.Vector3(velocityX, velocityY, 0f) * VelocityMultiplier * Time.deltaTime;
        
    }

    float FindMovementRatio(char axis){
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        xCoord = transform.position.x - playerObj.transform.position.x;
        yCoord = transform.position.y - playerObj.transform.position.y;

        // Calculates what the length of the direct line between the player and enemy is.
        denominator = Mathf.Sqrt(xCoord*xCoord + yCoord*yCoord); 
        if(axis == 'x' && transform.position.x < playerObj.transform.position.x)
            return (xCoord / denominator);
        else if(axis == 'x' && transform.position.x > playerObj.transform.position.x)
            return -1f * (xCoord / denominator);

        if(axis == 'y' && transform.position.y < playerObj.transform.position.y)
            return (yCoord / denominator);
        else if(axis == 'y' && transform.position.y > playerObj.transform.position.y)
            return -1f * ( yCoord / denominator);
        
        return 0f;
    }
}
