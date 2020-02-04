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
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //_liveSprites[CurrentPlayerLives = 3];
        //Assign text component to the handle.

        _scoreText.text = "Score: " + 00;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager:").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is NULL..!!");

        }


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

        //Debug.Log("<color=blue>UPDATE LIVES METHOD ACCESSED...</color>");
        //display image sprite.
        //Cahnge sprite image based on current index.
        _livesImage.sprite = _liveSprites[currentLives];
        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }

    //public void ActivateGameOverScreen(bool activeGameOverScreen)
    //{
    //    Debug.Log("<color=blue>ActivateGameOverScreen METHOD ACCESSED...</color>");
    //    //this.gameObject.transform.GetChild(2).gameObject.SetActive(activeGameOverScreen);

    //}

    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(.4f);
            _gameOverText.text = "GAME OVER";
        }

    }
}

// Not talking to the gameobject, the player script. Find() and Getcomponent<>
// Find() and Getcomponent<>    @Thom Fox