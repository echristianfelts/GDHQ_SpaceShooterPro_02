﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    private float _dropTimer = 5f;
    //public GameObject _gameObjectPlayer;
    public float waitTime;
    public float xSpawnOffsetRange = 5f;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine(_dropTimer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnRoutine(float waitTime)
    {
        int count = 0;
        Vector3 enemyDropOffset = new Vector3(Random.Range((-1* xSpawnOffsetRange), xSpawnOffsetRange), 8f, 0);
        //Player playerTest = _gameObjectPlayer.GetComponent<Player>();
        while (_stopSpawning == false)
        {
            count += 1;
            GameObject newEnemy = Instantiate(_enemyPrefab,enemyDropOffset, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            Debug.Log("Spawn Routine Cycle Count: " + count);
            yield return new WaitForSeconds(waitTime);
        }

    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;

    }
}
