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

    // Start is called before the first frame update
    void Start()
    {
        // take current pos and assign start pos.
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        CalculateMovement();

        // ifg I hit the space key...
        // Spawn a laser shot.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Key Pressed");

            Instantiate(_laserPrefab, transform.position, Quaternion.identity);

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
}
