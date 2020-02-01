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

    [SerializeField ]
    private Image _livesImage; 
    [SerializeField]
    private Sprite[] _liveSprites;

    // Start is called before the first frame update
    void Start()
    {
        //_liveSprites[CurrentPlayerLives = 3];
        //Assign text component to the handle.

        _scoreText.text = "Score: " + 00;
    }

    // Update is called once per frame
    void Update()
    {
        //Player playerscore = _playerGameObject.transform.GetComponent<Player>();
        //_scoreText.text = "Score: " + 50; // playerscore.score;


    }

    public void UpdateScore(int playerScore)
    {
       
        _scoreText.text = "Score: " + playerScore.ToString();

    }


    public void UpdateLives(int currentLives)
    {

        Debug.Log("<color=blue>UPDATE LIVES METHOD ACCESSED...</color>");
        //display image sprite.
        //Cahnge sprite image based on current index.
        _livesImage.sprite = _liveSprites[currentLives];
    }
}

// Not talking to the gameobject, the player script. Find() and Getcomponent<>
// Find() and Getcomponent<>    @Thom Fox