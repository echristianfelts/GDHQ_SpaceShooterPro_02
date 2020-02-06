using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField]
    private float _speed = -7f;

    private GameObject _playerGameObject;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private AudioClip _explosionAudio;

    private AudioSource _singleShotAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _singleShotAudioSource = GameObject.Find("SingleShot_Audio").GetComponent<AudioSource>();
        // _playerGameObject= 
        //_playerTest = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * (_speed + (Random.Range(-3f,-0f))));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player _playerGameObject = other.transform.GetComponent<Player>();
            _playerGameObject.Damage();

            GameObject newExplosion = Instantiate(_explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            newExplosion.transform.parent = _playerGameObject.transform;


            StartCoroutine(ExplosionSound());

            Destroy(this.gameObject);


        }


    }

    IEnumerator ExplosionSound()
    {
        _singleShotAudioSource.PlayOneShot(_explosionAudio, 0.7F);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    //SET UP PLAYER COLLISION
}
