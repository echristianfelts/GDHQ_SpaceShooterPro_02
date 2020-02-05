using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{
    private float _rotSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //constatnly rotate astroid on z
        //_rotSpeed += 1;
        transform.Rotate(Vector3.forward * _rotSpeed);
    }
}
