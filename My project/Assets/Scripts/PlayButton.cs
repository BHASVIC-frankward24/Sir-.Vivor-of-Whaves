using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class PlayButton : MonoBehaviour
{
    
    public void OnPress()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        print("Button pressed");
    }
    
}
