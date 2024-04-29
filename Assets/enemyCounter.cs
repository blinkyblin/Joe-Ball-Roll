using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCounter : MonoBehaviour
{
    // Use this for initialization
    public int enemiesLeft = 0;
    [SerializeField] public List<enemy_move> enemiesAlive;
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
        killedAllEnemies = true;
    }

    void OnGUI()
    {
        if (killedAllEnemies)
        {
            GUI.Label(new Rect(0, 0, 200, 20), "all gone");
        }
        else
        {
            GUI.Label(new Rect(0, 0, 200, 20), "Enemies Remaining : " + enemiesLeft);
        }
    }

    //create a ChechForVictory() method
    // in this you will check every time an enemy dies if the enemiesAlive List is empty. if it is empty you have won the game!
}

