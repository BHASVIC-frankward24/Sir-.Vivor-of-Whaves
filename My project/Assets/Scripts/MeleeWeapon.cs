using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private GameObject playerObj = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
        
       
    }

    // Update is called once per frame
    void Update()
    {
        float XCoord = playerObj.transform.position.x + 2;
        float YCoord = playerObj.transform.position.y + 2;   
        transform.position = new UnityEngine.Vector3(XCoord, YCoord, -1);
    }
}
