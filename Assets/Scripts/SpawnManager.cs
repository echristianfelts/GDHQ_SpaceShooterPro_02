using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float waitTime;
    [SerializeField]
    private float _dropTimer = 5f;
    [SerializeField]
    private float _dropTimerPowerUp = 9f;
    public float xSpawnOffsetRange = 5f;
    [SerializeField]
    private GameObject _enemyPrefab;
    //[SerializeField]
    //private GameObject _TripleShotPowerUpPrefab;
    [SerializeField]
    private GameObject[] _powerUps;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine(_dropTimer));
        StartCoroutine(SpawnPowerUpRoutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnEnemyRoutine(float waitTime)
    {
        int count = 0;
        Vector3 enemyDropOffset = new Vector3(Random.Range((-1 * xSpawnOffsetRange), xSpawnOffsetRange), 8f, 0);
        //Player playerTest = _gameObjectPlayer.GetComponent<Player>();
        while (_stopSpawning == false)
        {
            count += 1;
            GameObject newEnemy = Instantiate(_enemyPrefab, enemyDropOffset, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            Debug.Log("Spawn Routine Cycle Count: " + count);
            yield return new WaitForSeconds(waitTime);
        }

    }

    IEnumerator SpawnPowerUpRoutine()  //randomize time
    {
        int count = 0;
        //Vector3 PowerUpDropOffset = new Vector3(Random.Range(-5f, 5f), 8f, 0);
        //randoRange = Random.Range(0f, 5f);
        //Player playerTest = _gameObjectPlayer.GetComponent<Player>();
        while (_stopSpawning == false)
        {

            yield return new WaitForSeconds(Random.Range(10f, 13f));
            Vector3 PowerUpDropOffset = new Vector3(Random.Range(-5f, 5f), 8f, 0);
            count += 1;

            int randomPowerUp = Random.Range(0,3);

            //GameObject newPowerUp = Instantiate(_TripleShotPowerUpPrefab, PowerUpDropOffset, Quaternion.identity);
            GameObject newPowerUp = Instantiate(_powerUps[randomPowerUp], PowerUpDropOffset, Quaternion.identity);

            newPowerUp.transform.parent = _enemyContainer.transform;

            Debug.Log("PowerUp Cycle Count: " + count);

        }

    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;

    }
}
