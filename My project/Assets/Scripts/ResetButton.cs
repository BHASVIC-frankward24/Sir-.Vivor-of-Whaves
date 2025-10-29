using UnityEngine;

public class ResetButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Onpress()
    {
        PlayerPrefs.SetString("Reset", "True");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
