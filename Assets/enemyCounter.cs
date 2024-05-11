using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyCounter : MonoBehaviour
{
    // Use this for initialization
    public int enemiesLeft = 0;
    [SerializeField] public List<enemy_move> enemiesAlive;
    [SerializeField] private TextMeshProUGUI enemiesleft;
    bool killedAllEnemies = false;
    void Start()
    {
        enemiesLeft = 6; // or whatever;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        if (Input.GetKeyDown(KeyCode.A))
        {
            enemiesLeft--;
        }
        if (enemiesLeft == 0)
        {
            endGame();
        }
    }

    void endGame()
    {

        if (enemiesLeft <= 0)
        {
            killedAllEnemies = true;
            // trigger victory
        }
    }


    void OnGUI()
    {
        if (killedAllEnemies)
        {
            SceneManager.LoadScene(sceneName: "win");
        }
        else
        {
            GUI.Label(new Rect(0, 0, 300, 20), "Enemies Remaining: " + enemiesLeft);
        }
    }

    //create a ChechForVictory() method
    // in this you will check every time an enemy dies if the enemiesAlive List is empty. if it is empty you have won the game!
}

