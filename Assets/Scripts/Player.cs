 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.5f;
    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        // take current pos and assign start pos.
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 playerVector = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(playerVector * Time.deltaTime * _playerSpeed); 

        //if player y > than 0
        //then y = 0
        //if player x < -11
        //then x = 11
        //if x > 11
        //then x = -11

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        } else if (transform.position.y <-4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        if (transform.position.x > 10.5)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
        }
        else if (transform.position.x < -10.5)
        {
            transform.position = new Vector3(10, transform.position.y, 0);
        }




    }
}
