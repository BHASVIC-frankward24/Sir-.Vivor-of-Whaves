using UnityEngine;

public class Heart3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoseHeart()
    {
        transform.position = new UnityEngine.Vector3(17.5f, 10f, 5f);
    }
    public void GainHeart()
    {
        transform.position = new UnityEngine.Vector3(17.5f, 10f, 1f);
    }


    void Update()
    {
        if (this == null)
            return;

        if (PlayerPrefs.GetInt("SystemHealth", 0) <= 0)
        {
            LoseHeart();
        }
        else
        {
            GainHeart();
        }
    }

    void OnDestroy()
    {
        Debug.Log("Heart3 has been destroyed");
    }
}
