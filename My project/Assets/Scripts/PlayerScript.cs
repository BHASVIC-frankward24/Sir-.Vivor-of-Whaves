using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;



public class Playerscript : MonoBehaviour
{

    [SerializeField] private float VelocityMultiplier = 7f;
    [SerializeField] private int health = 3;

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetString("Reset") == "True")
            ResetPlayerData();
        else
        {
            LoadPlayerData();
        }
        
    }



    // Update is called once per frame
    public void Update()
    {

        if(transform.position.z >= 0)
        {
            transform.position += new UnityEngine.Vector3(0, 0, -1f);
        }



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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EVIL"))
        {
            DamagePlayer(1);
            print("Player took damage");
        }


        PlayerPrefs.SetInt("SystemHealth", health);
    }

    private void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        PlayerPrefs.SetString("Reset", "true");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loser Menu");

    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetFloat("XCoord", transform.position.x);
        PlayerPrefs.SetFloat("YCoord", transform.position.y);
        PlayerPrefs.SetInt("Health", health);
    }

    public void LoadPlayerData()
    {
        float X = PlayerPrefs.GetFloat("XCoord", 0);
        float Y = PlayerPrefs.GetFloat("YCoord", 0);
        transform.position = new UnityEngine.Vector3(X, Y, -1f);
        health = PlayerPrefs.GetInt("Health", 0);
    }

    public void ResetPlayerData()
    {
        transform.position = new UnityEngine.Vector3(-3.5f, -0.8f, -1f);
        health = 3;
        PlayerPrefs.SetInt("SystemHealth", 3);
        SavePlayerData();
    }


}

