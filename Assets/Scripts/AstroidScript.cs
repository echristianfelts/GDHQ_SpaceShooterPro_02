﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{
    private float _rotSpeed = 1f;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private SpawnManager _spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

    }

// Update is called once per frame
void Update()
    {
        //constatnly rotate astroid on z
        //_rotSpeed += 1;
        transform.Rotate(Vector3.forward * _rotSpeed);
    }

    //Check for laser collision
    //instasiate the explosion at the position of the asteroid.
    //Destroy the explosion aftere it goes off.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            GameObject newExplosion = Instantiate(_explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            Debug.Log("<color=blue>ASTEROID/LASER COLISSION CHECK..!</color>");
            _spawnManager.StartSpawning();
            Destroy(other.gameObject);
            Destroy(this.gameObject, .25f);


        }
    }
}
