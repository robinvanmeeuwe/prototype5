
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    
    // Hiermee worden alle variabelen gemaakt en een waarde gegeven.
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    // Dit zorgt ervoor dat we de prefabs een particle kunnen geven.
    public ParticleSystem explosionParticle;
    
    // Dit zorgt ervoor dat we de prefabs een point value kunnen geven.
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        // Dit maakt de connectie naar components
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        targetRb.AddForce(Randomforce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // verwijderen bij klikken
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);  
        }
    }

    // verwijdering van objecten
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // verschillende snelheden
    Vector3 Randomforce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // verschillende spawn posities
    Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}