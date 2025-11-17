using UnityEngine;

public class HeartManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoseHeart()
    {
        transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, -1);
    }
    public void GainHeart()
    {
        transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, 0);
    }


    void Update()
    {
        
    }
}
