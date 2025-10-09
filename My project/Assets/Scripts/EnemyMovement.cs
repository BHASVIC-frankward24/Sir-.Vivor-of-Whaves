using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float velocityY = 0f;
    private float velocityX = 0f;
    [SerializeField]
    private float VelocityMultiplier = 3;
    private GameObject playerObj = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocityX = 0f;
        velocityY = 0f;

        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        float xCoord = playerObj.transform.position.x;
        float yCoord = playerObj.transform.position.x;
        if (transform.position.y > yCoord)
            velocityY = -1f;

        else if (transform.position.y < yCoord)
            velocityY = 1f;

        if (transform.position.x > xCoord)
            velocityX = -1f;

        else if (transform.position.x < xCoord)
            velocityX = 1f;
        
        transform.position += new UnityEngine.Vector3(velocityX, velocityY, 0f) * VelocityMultiplier * Time.deltaTime;
        
    }
}
