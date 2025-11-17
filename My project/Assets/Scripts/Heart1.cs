using UnityEngine;

public class Heart1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoseHeart()
    {
        transform.position = new UnityEngine.Vector3(0, 0, 0);
    }
    public void GainHeart()
    {
        transform.position += new UnityEngine.Vector3(0, 0, -1);
    }


    void Update()
    {
        if (PlayerPrefs.GetInt("SystemHealth", 0) <= 2)
        {
            LoseHeart();
        }
        else
        {
            GainHeart();
        }
    }
}
