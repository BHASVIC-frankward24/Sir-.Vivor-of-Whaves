using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private GameObject playerObj = null;
    private GameObject EVILObj = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        if (EVILObj == null){
            EVILObj = GameObject.FindGameObjectWithTag("EVIL");
        }
    }

    public void OnPress()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        playerObj.GetComponent<Playerscript>().SavePlayerData();

        
        EVILObj.GetComponent<EnemySaving>().SaveEnemyData();
        

        UnityEngine.SceneManagement.SceneManager.LoadScene("Pause menu");
    }
    
}
