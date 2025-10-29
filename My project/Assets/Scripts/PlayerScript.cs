using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;



public class Playerscript : MonoBehaviour
{

    [SerializeField]
    private float VelocityMultiplier = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetString("Reset") == "True")
            ResetPlayerData();
        else
        {
            LoadPlayerData();
        }
        PlayerPrefs.SetString("Reset", "False");
    }



    // Update is called once per frame
    public void Update()
    {
        float horizontal = 0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }

        float vertical = 0f;
        if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
        }
        else if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;
        }


        transform.position += new UnityEngine.Vector3(horizontal, vertical, 0f) * VelocityMultiplier * Time.deltaTime;

    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetFloat("XCoord", transform.position.x);
        PlayerPrefs.SetFloat("YCoord", transform.position.y);
    }

    public void LoadPlayerData()
    {
        float X = PlayerPrefs.GetFloat("XCoord", 0);
        float Y = PlayerPrefs.GetFloat("YCoord", 0);
        transform.position = new UnityEngine.Vector3(X, Y, 0f);
    }

    public void ResetPlayerData()
    {
        transform.position = new UnityEngine.Vector3(-3.5f, -0.8f, -1f);
        SavePlayerData();
    }

}

