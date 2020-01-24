using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    private float _dropTimer = 5f;
    //public GameObject _gameObjectPlayer;
    public float waitTime;
    [SerializeField]
    private GameObject _enemyPrefab;
    public float xSpawnOffsetRange = 5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine(_dropTimer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn game object every 5 seconds.
    // Create a coroutine of type IEnumerator  -- Yeild Events
    //While loop.
    IEnumerator SpawnRoutine(float waitTime)
    {
        int count = 0;
        Vector3 enemyDropOffset = new Vector3(Random.Range((-1* xSpawnOffsetRange), xSpawnOffsetRange), 8f, 0);
        //Player playerTest = _gameObjectPlayer.GetComponent<Player>();
        while (count >=0  )
        {
            //while loop (infinite loop) 
            count += 1;
            Instantiate(_enemyPrefab,enemyDropOffset, Quaternion.identity);
            Debug.Log("Spawn Routine Timer Cycle Count: " + count);
            //instansiate enemy prefab
            // yeild wait for 5 seconds
            yield return new WaitForSeconds(waitTime);
        }

        }
}
