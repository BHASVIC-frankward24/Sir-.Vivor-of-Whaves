using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Melee"))
        {
            int newKills = PlayerPrefs.GetInt("Kills") + 1;
            PlayerPrefs.SetInt("Kills", newKills);
            print("You have " + newKills + " kills!");
            gameObject.SetActive(false);
        }
    }
}