 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.5f;
    [SerializeField]
    private float _playerSpeedBoost = 3.5f;
    public float horizontalInput;
    public float verticalInput;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _laserSpawnOffsetX = 0f;
    [SerializeField]
    private float _laserSpawnOffsetY = 0.75f;
    [SerializeField]
    private float _fireRate = 2.0f;
    private float _fireTime = -1f;
    [SerializeField]
    private int _healthPointsPlayer = 3;
    [SerializeField]
    private int _enemyImpactDamage = 1;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _powerUpTripleShot = false;
    [SerializeField]
    private float _TripleShotLifetime = 15.0f;
    [SerializeField]
    private bool _powerUpSpeedBoost = false;
    [SerializeField]
    private float _SpeedBoostLifetime = 6.0f;
    [SerializeField]
    private bool _powerUpShields = false;

    public int score = 0;

    [SerializeField]
    private UIManger _uiManager;
    private GameObject _gameOverScreen;



    //is Tripleshot active?
    //

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // take current pos and assign start pos.
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();//find the object.  Get the component.
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManger>();
        //_gameOverScreen = GameObject.Find("Canvas").get
            
            //.gameObject.SetActive(true);

//.transform.GetChild(0).gameObject.SetActive(true);


        if (_spawnManager == null )
        {
            Debug.LogError("Spawn Manager is currently NULL.");

        }

        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is currently NULL.");

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

            if (_powerUpTripleShot == true)
            {

                FireTripleShot();
                StartCoroutine(TrippleShotTimer(_TripleShotLifetime));
            }
            else
            {
                FireLaser();
            }
        }


    }

    void CalculateMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 playerVector = new Vector3(horizontalInput, verticalInput, 0);
        if (_powerUpSpeedBoost == true)
        {
            transform.Translate(playerVector * Time.deltaTime * (_playerSpeed + _playerSpeedBoost));
            StartCoroutine(SpeedBoostTimer(_SpeedBoostLifetime));
        }
            else
        {
            transform.Translate(playerVector * Time.deltaTime * _playerSpeed);
        }



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
        Debug.Log("Space Key Pressed Single");
        Vector3 laserSpawnOffset = new Vector3(_laserSpawnOffsetX, _laserSpawnOffsetY, 0);
        _fireTime = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + laserSpawnOffset, Quaternion.identity);
    }

    void FireTripleShot()
    {
        Debug.Log("Space Key Pressed Triple");
        //Vector3 laserSpawnOffset = new Vector3(_laserSpawnOffsetX, _laserSpawnOffsetY, 0);
        _fireTime = Time.time + _fireRate;
        Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
    }

    public void Damage()
    {

        // if sheilds is active
        if (_powerUpShields == true)
        // do nothing
        {
            _powerUpShields = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("<color=red>SHEILDS ARE DOWN..!!!</color>");
            return;
            // kill shields
        }

        else

        { _healthPointsPlayer -= _enemyImpactDamage; }
        _uiManager.UpdateLives(_healthPointsPlayer);


        if (_healthPointsPlayer <= 0)
        {
            //communicate with Spawn Manager
            _spawnManager.OnPlayerDeath(); 
            Debug.Log("<color=red>Player has been destroyed..!!!</color>");

            _uiManager.ActivateGameOverScreen(true);
            //_gameOverScreen.SetActive(true);
            //.transform.GetChild(0).gameObject.SetActive(true);


            Destroy(this.gameObject);
        }
        
        Debug.Log("Player Hitpoints: " + _healthPointsPlayer);
    }

    public void TripleShotActive()
    {
        //Trippleshot Active Var becomes true.
        _powerUpTripleShot = true;
        //
        //start power down timer for trippleshot powerup. (IENumerator)
    }

    //IENumerator Trippleshot Powerdown Routine timer.
    IEnumerator TrippleShotTimer(float killtime)
    {
        // Wait five seconds then
        //Set Trippleshot to false.
        {
            yield return new WaitForSeconds(killtime);
            _powerUpTripleShot = false;
        }
    }

    public void SpeedBoostActive()
    {
        //Trippleshot Active Var becomes true.
        _powerUpSpeedBoost = true;
        //
        //start power down timer for speedboost powerup. (IENumerator)
    }

    IEnumerator SpeedBoostTimer(float killtime)
    {
        // Wait five seconds then
        //Set SpeedBoost to false.
        {
            yield return new WaitForSeconds(killtime);
            _powerUpSpeedBoost = false;
        }
    }
    public void ShieldsActive()
    {
        //Trippleshot Active Var becomes true.
        _powerUpShields = true;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //this.GetComponent<Renderer>().material.color = new Vector4(1, 0, 0, 0);
        Debug.Log("SHIELDS ARE ACTIVE");
        //start power down timer for speedboost powerup. (IENumerator)
    }

    public void CalculateScoreEnemy_01(int EnemyPointValue)
    {
        score += EnemyPointValue;
        _uiManager.UpdateScore(score);

            Debug.Log("<color=yellow>AN ENEMY HAS BEEN KILLED</color>");
            Debug.Log("<color=yellow>Score :" + score + "</color>");

    }
}
