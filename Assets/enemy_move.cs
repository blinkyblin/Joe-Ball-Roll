using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        player = GameObject.Find("Player");
    }

   
    void FixedUpdate()
    {
        enemyRB.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
