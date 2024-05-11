using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyBall : MonoBehaviour
{

    [SerializeField] private enemyCounter enemyCounter;

    
    //create a reference to the game manager
    private void Update()
    {
        if(transform.position.y < -10)
        {
            //talk to the game manager reference and remove this object from the enemiesAlive List
            
            if (tag == "Enemy")
            {
                Debug.Log("an enemy has perished");

                enemyCounter.enemiesLeft--;

            }
            if (tag == "Player")
            {
                Debug.Log("you died");
                SceneManager.LoadScene(sceneName: "lose");
            }
            
            Destroy(gameObject);

           
            // int indexNumber = 0;
            // foreach (enemy_move enemy_Move in enemyCounter.enemiesAlive) 
            //{
            //how to determine if entry x is the one that died

            //if the object that was just activated = object in list remove it from the list. 
            //   indexNumber++;
            //  enemyCounter.enemiesAlive.RemoveAt(indexNumber);
            //}

        }
    }
}
