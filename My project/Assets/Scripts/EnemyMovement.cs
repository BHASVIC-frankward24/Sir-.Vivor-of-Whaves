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
        
        velocityX = FindMovementRatio('x');
        velocityY = FindMovementRatio('y');
        
        transform.position += new UnityEngine.Vector3(velocityX, velocityY, 0f) * VelocityMultiplier * Time.deltaTime;
        
    }

    float FindMovementRatio(char axis){
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        xCoord = transform.position.x - playerObj.transform.position.x;
        yCoord = transform.position.y - playerObj.transform.position.y;

        denominator = Mathf.Sqrt(xCoord*xCoord + yCoord*yCoord); // Calculates what the length of the direct line between the player and enemy is.
        if(axis == 'x' && transform.position.x < playerObj.transform.position.x)
            return (xCoord / denominator);
        else if(axis == 'x' && transform.position.x > playerObj.transform.position.x)
            return (-1 * xCoord / denominator);

        if(axis == 'y' && transform.position.y < playerObj.transform.position.y)
            return (yCoord / denominator);
        else if(axis == 'y' && transform.position.y > playerObj.transform.position.y)
            return (-1 * yCoord / denominator);
        
        return 0f;
    }
}
