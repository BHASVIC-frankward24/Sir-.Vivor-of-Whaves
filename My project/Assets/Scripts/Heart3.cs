using Unity.VisualScripting;
using UnityEngine;

public class Heart3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoseHeart()
    {
        //Hide
        this.gameObject.SetActive(false);
    }
    public void GainHeart()
    {
        //Show
        this.gameObject.SetActive(true);
    }


    void Awake()
    {
  
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("SystemHealth", 0) <= 0)
        {
            LoseHeart();
        }
        else
        {
            GainHeart();
        }
    }
}
