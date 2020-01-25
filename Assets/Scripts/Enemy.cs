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
    //private float _randomXval = Random.Range(_xRangeMin, _xRangeMax);



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move enemy down @ 4 meters per second.
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        //if @ bottom of screen
        //respawn at top

        if (transform.position.y < -6f)
        {
            float randomXval = Random.Range(_xRangeMin, _xRangeMax);
            transform.position = new Vector3(randomXval, 8f, 0);
        }
        //randomize respawn position.

        // Detect Collison


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
            //if (playerTest != null) // If that thing desn't NOT exist.  Null Check.
            //{
                Debug.Log("TAG TRIGGER PLAYER");
                playerTest.Damage();
                Destroy(this.gameObject);
            //}
        }

        // if other is laser
        // Destroy laser
        // Destroy Self
        if (other.tag == "Laser")
        {
            Debug.Log("TAG TRIGGER LASER");
            float randomXval = Random.Range(_xRangeMin, _xRangeMax);
            Instantiate(this.gameObject, new Vector3(randomXval, 6.5f, 0f), Quaternion.identity);
            Destroy(other.gameObject);
            //if (transform.parent != null)
            //{
            //    Destroy(transform.parent.gameObject);

            //}
            Destroy(this.gameObject);

        }


    }

}
