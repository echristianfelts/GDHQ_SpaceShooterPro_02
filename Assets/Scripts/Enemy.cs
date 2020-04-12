using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float _speed = 4f;
    [SerializeField]
    private float _xRangeMin = -10f;
    [SerializeField]
    private float _xRangeMax = 10f;
    [SerializeField]
    private GameObject _playerGameObject;
    [SerializeField]
    private GameObject _enemyLaserPrefab;
    private int myEnemyScore = 10;

    private Player _playerTest;
    //private float _randomXval = Random.Range(_xRangeMin, _xRangeMax);

    //Add Handle to Animator Component...

    private Animator h_Animator;
    private Collider2D h_BoxCollider2d;
    [SerializeField]
    private AudioClip _explosionAudio;
    private AudioSource _singleShotAudioSource;
    private float _fireTime;
    private float _fireDeathTimer = 0f;
    private float _fireFlag = 0f;

    //Set FIRE FLAG





    // Start is called before the first frame update
    void Start()
    {
        _fireDeathTimer = (Random.Range(2f, 5f));
        _playerTest = GameObject.Find("Player").GetComponent<Player>();
        _singleShotAudioSource = GameObject.Find("SingleShot_Audio").GetComponent<AudioSource>();
        h_Animator = this.gameObject.GetComponent<Animator>();
        h_BoxCollider2d = this.gameObject.GetComponent<Collider2D>();

        if (_playerTest == null)
        {
            Debug.LogError("The _playerTest is Null in Enemy");
        }

        if (_singleShotAudioSource == null)
        {
            Debug.LogError("Single Shot Audio Source is currently NULL. ::ENEMY::");

        }

        if (h_Animator == null)
        {
            Debug.LogError("ANIMATOR is currently NULL. ::ENEMY::");

        }

        if (h_BoxCollider2d == null)
        {
            Debug.LogError("BOX COLLIDER is currently NULL. ::ENEMY::");

        }

        _fireTime = (Random.Range(1f, 2f));
 }

    // Update is called once per frame
    void Update()
    {
        //  if time > timer then drop bullet

        if (Time.time > _fireTime && _fireFlag == 0)
        {

            FireEnemyLaser();

        }
        //move enemy down @ 4 meters per second.
        transform.Translate(Vector3.down * Time.deltaTime * (_speed + (Random.Range(-3f, 0f))));

        //if @ bottom of screen
        //respawn at top

        if (transform.position.y < -6f)
        {
            float randomXval = Random.Range(_xRangeMin, _xRangeMax);
            transform.position = new Vector3(randomXval, 8f, 0);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit by: " + other.transform.name);

        // if other is Player
        // Damage Player
        // Destroy Self

        if (other.tag == "Player")
        {

            Player playerTest = other.transform.GetComponent<Player>();
            Debug.Log("TAG TRIGGER PLAYER");
            StartCoroutine(TriggerEnemy_01Explosion());
            _singleShotAudioSource.PlayOneShot(_explosionAudio, 0.7F);
            _speed = 1f;
            playerTest.Damage();

        }

        if (other.tag == "Laser")
        {
            //Debug.Log("TAG TRIGGER LASER");
            Instantiate(this.gameObject, new Vector3(Random.Range(_xRangeMin, _xRangeMax), 8f, 0f), Quaternion.identity);
            Destroy(other.gameObject);

            if (_playerGameObject != null)
            {
                _playerTest.CalculateScoreEnemy_01(myEnemyScore);

            }

            StartCoroutine(TriggerEnemy_01Explosion());
            _singleShotAudioSource.PlayOneShot(_explosionAudio, 0.7F);
            _speed = 2.5f;
            // set trigger for OnEnemyDeath
            Debug.Log("<color=blue>ReturnFromIENumerator Log Point.</color>");

            _fireDeathTimer = Time.time;

            StartCoroutine(TriggerEnemy_Off());
        }


    }

    IEnumerator TriggerEnemy_01Explosion()
    {
        Debug.Log("<color=red>PreTimer Explosion Log Point.</color>");
        h_Animator.SetTrigger("OnEnemyDeath");
        h_BoxCollider2d.enabled = false;
        _fireFlag += 1;
        yield return new WaitForSeconds(1.25f);
        Debug.Log("<color=blue>POSTTimer Explosion Log.</color>");
        Destroy(this.gameObject);

    }

    void FireEnemyLaser()
    {
        //Vector3 laserSpawnOffset = new Vector3(_laserSpawnOffsetX, _laserSpawnOffsetY, 0);
        _fireTime = Time.time + _fireTime + (Random.Range(1f, 3f));
        Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
        //play laser audioclip
    }

    IEnumerator TriggerEnemy_Off()
    {
        if (Time.time > _fireDeathTimer + 0.1f)
        {
            Destroy(this.gameObject);
        }
        yield return new WaitForSeconds(1.1f);

    }


}
