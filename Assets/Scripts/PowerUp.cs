using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    // ID for Powerups
    // 0 = Tripleshot
    // 1 = Speed
    // 2 = Sheilds
    [SerializeField]
    private int _powerupID;

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
            if (player != null)
            {
                switch (_powerupID)
                {
                    case 0:
                        Debug.Log("Pick up is Tripleshot.");
                        player.TripleShotActive();
                        break;
                    case 1:
                        Debug.Log("Pick up is Speed.");
                        break;
                    case 2:
                        Debug.Log("Pick up is Shields.");
                        break;

                    default:
                        Debug.Log("Only socres of 50 or 100 get readouts..!");
                        break;
                }
            }
            Destroy(this.gameObject);

        }


    }

}
