using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kills : MonoBehaviour
{
    private int enemyKilled = 0;

    public void UpdateScore()
    {
        enemyKilled++;
    }

    public void OnGUI()
    {
        GUI.contentColor = Color.yellow;
        GUI.Box(new Rect(5, 5, 20, 20), "Enemies killed: " + enemyKilled);
    }
}

