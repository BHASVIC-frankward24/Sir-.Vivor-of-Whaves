using UnityEngine;

public class Heart1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoseHeart()
    {
        transform.position = new UnityEngine.Vector3(12.5f, 10f, 5f);
    }
    public void GainHeart()
    {
        transform.position = new UnityEngine.Vector3(12.5f, 10f, 1f);
    }


    void Awake()
    {
        transform.position = new UnityEngine.Vector3(12.5f, 10f, 1f);
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
