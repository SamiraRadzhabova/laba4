﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    public float speed; //швидкість ворожих м'ячів

    private int waveCount = SpawnManagerX.waveCount; // додала
 

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        // додала це 
        playerGoal = GameObject.Find("Player Goal");

    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        // змінила це enemyRb.AddForce(lookDirection * speed * Time.deltaTime); на :
        enemyRb.AddForce(lookDirection * speed *(waveCount * 3) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
