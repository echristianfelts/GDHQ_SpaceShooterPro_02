 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.5f;
    public float horizontalInput;
    public float verticalInput;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _laserSpawnOffsetX = 0f;
    [SerializeField]
    private float _laserSpawnOffsetY = 0.75f;
    [SerializeField]
    private float _fireRate = 2.0f;
    private float _fireTime = -1f;
    [SerializeField]
    private float _healthPointsPlayer = 100f;
    [SerializeField]
    private float _enemyImpactDamage = 20f;
    private SpawnManager _spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        // take current pos and assign start pos.
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();//find the object.  Get the component.

        if (_spawnManager == null )
        {
            Debug.LogError("Spawn Manager is currently NULL.");

        }



    }

    // Update is called once per frame
    void Update()
    {

        CalculateMovement();

        // if I hit the space key...
        // Spawn a laser shot.

        if (Input.GetKeyDown(KeyCode.Space) && _fireTime < Time.time)
        {
            FireLaser();
        }



    }

    void CalculateMovement()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 playerVector = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(playerVector * Time.deltaTime * _playerSpeed);



        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y < -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x > 10f)
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }
        else if (transform.position.x < -10f)
        {
            transform.position = new Vector3(10f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        Debug.Log("Space Key Pressed");
        Vector3 laserSpawnOffset = new Vector3(_laserSpawnOffsetX, _laserSpawnOffsetY, 0);
        _fireTime = Time.time + _fireRate;

        Instantiate(_laserPrefab, transform.position + laserSpawnOffset, Quaternion.identity);

    }

    public void Damage()
    {
        _healthPointsPlayer -= _enemyImpactDamage;
        if (_healthPointsPlayer <= 0)
        {
            //communicate with Spawn Manager
            _spawnManager.OnPlayerDeath(); //Find the Game Object.  Get the componenet;
            Destroy(this.gameObject);
        }
        Debug.Log("Player Hitpoints: " + _healthPointsPlayer);

    }
}
