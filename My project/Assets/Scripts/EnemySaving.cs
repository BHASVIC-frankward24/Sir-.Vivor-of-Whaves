using UnityEngine;

public class EnemySaving : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (PlayerPrefs.GetString("Reset") == "True")
        {
            ResetEnemyData();
        }
        else
        {
            LoadEnemyData();
        }
    }

    // Update is called once per frame
    public void SaveEnemyData()
    {
        PlayerPrefs.SetFloat("EVIL XCoord", transform.position.x);
        PlayerPrefs.SetFloat("EVIL YCoord", transform.position.y);
    }

    public void LoadEnemyData()
    {
        float X = PlayerPrefs.GetFloat("EVIL XCoord", 0);
        float Y = PlayerPrefs.GetFloat("EVIL YCoord", 0);
        transform.position = new UnityEngine.Vector3(X, Y, 0f);
    }

    public void ResetEnemyData()
    {
        transform.position = new UnityEngine.Vector3(2.000811f, -0.7526299f, -1f);
        SaveEnemyData();
    }
}
