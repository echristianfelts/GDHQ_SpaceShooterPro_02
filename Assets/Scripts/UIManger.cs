using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    // Handle to Text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //Assign text component to the handle.

    }

    // Update is called once per frame
    void Update()
    {
        Player playerscore = _playerGameObject.transform.GetComponent<Player>();
        _scoreText.text = "Score: " + playerscore.score;
    }
}

// Not talking to the gameobject, the player script. Find() and Getcomponent<>
// Find() and Getcomponent<>    @Thom Fox