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

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            player.TripleShotActive();
            //communicate with player scrip
            Destroy(this.gameObject);

        }


    }

}
