using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move down at 3 units
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        // When we leave the screen... 
        if (transform.position.y < -6f)
        {
            // Destroy 
            Destroy(this.gameObject);
        }

    }

    // onTriggerEnter
    void OnTriggerEnter2D(Collider2D other)
    {
        // only collectable by player. (use Tags)
        // when collected...  Destroy.
        if (other.tag == "Player")
        {

            //Player playerTest = other.transform.GetComponent<Player>();

            Debug.Log("TRIGGER: Power Up Collected");

            Destroy(this.gameObject);

        }


    }

}
