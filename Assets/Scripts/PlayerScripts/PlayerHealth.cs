using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] healthUI;
    // Start is called before the first frame update
    public GameObject LoseScreenUI;
    void TakeDamage(){
        health--;
        if (health <= 0){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Mati lgsg restart, ganti tulisan game over
            PlayerLose();
        }
        healthUI[health].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemy")){
            TakeDamage();
        } else if (collision.CompareTag("Spikes")){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerLose();
        }
    }

    void PlayerLose(){
        LoseScreenUI.SetActive(true);
       
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MoveToMenu(){
        SceneManager.LoadScene("Main Menu");
    }
    public void StartNew(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
