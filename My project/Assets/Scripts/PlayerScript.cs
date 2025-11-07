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

    private GameObject[] hearts;
    

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
        hearts[0] = GameObject.FindGameObjectWithTag("Heart 3");
        hearts[1] = GameObject.FindGameObjectWithTag("Heart 2");
        hearts[2] = GameObject.FindGameObjectWithTag("Heart 1");
        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EVIL"))
        {
            DamagePlayer(1);
        }
                

        for(int i = 3; i > 0; i--)
        {
            if(health < i)
            {
                hearts[3-i].GetComponent<HeartManager>().LoseHeart();
            }
        }
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

