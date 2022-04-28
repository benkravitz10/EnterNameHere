using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	[SerializeField] private GameObject LevelSelectorCanvas;
	[SerializeField] private GameObject MainMenuCanvas;

	// public variables
	public int score=0;

	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public float startTime=5.0f;
	
	public Text mainScoreDisplay;
	public Text mainTimerDisplay;

	public GameObject gameOverScoreOutline;

	

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;
	public bool destroyTargets = false;

	public GameObject playAgainButtons;
	public string playAgainLevelToLoad;

	public GameObject nextLevelButtons;
	public string nextLevelToLoad;

	private float currentTime;

	// setup the game
	void Start () {

		gameIsOver = false;
		canBeatLevel = false;
		score = 0;

		// set the current time to the startTime specified
		currentTime = startTime;

		//Sets the mainTimer to correctly
		if(mainTimerDisplay)
        {
			mainTimerDisplay.text = currentTime.ToString();

        }

		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();

		// init scoreboard to 0
		if(mainScoreDisplay)mainScoreDisplay.text = "0";

		// inactivate the gameOverScoreOutline gameObject, if it is set
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (false);

		// inactivate the playAgainButtons gameObject, if it is set
		if (playAgainButtons)
			playAgainButtons.SetActive (false);

		// inactivate the nextLevelButtons gameObject, if it is set
		if (nextLevelButtons)
			nextLevelButtons.SetActive (false);
	}

	// this is the main game event loop
	void Update()
	{
		if (!gameIsOver)
		{
			if (canBeatLevel && (score >= beatLevelScore))
			{  // check to see if beat game
				BeatLevel();
			}
			else if (currentTime < 0)
			{ // check to see if timer has run out
				EndGame();


			}
			else
			{ // game playing state, so update the timer
				currentTime -= Time.deltaTime;
				if (mainTimerDisplay)
					mainTimerDisplay.text = currentTime.ToString("0.00");
			}
		}

		if(score >= beatLevelScore)
        {
			canBeatLevel = true;
        }

	}

	void EndGame() {
		// game is over
		gameIsOver = true;
		destroyTargets = true;

		// repurpose the timer to display a message to the player
		if (mainTimerDisplay)
			mainTimerDisplay.text = "GAME OVER";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);
	
		// activate the playAgainButtons gameObject, if it is set 
		if (playAgainButtons)
			playAgainButtons.SetActive (true);

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
	
	void BeatLevel() {
		// game is over
		canBeatLevel = true;
		destroyTargets = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "LEVEL COMPLETE";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);

		// activate the nextLevelButtons gameObject, if it is set 
		if (nextLevelButtons)
			nextLevelButtons.SetActive (true);
		
		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music


	}

	// public function that can be called to update the score or time
	public void targetHit (int scoreAmount, float timeAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();
		
		// increase the time by the timeAmount
		currentTime += timeAmount;
		
		// don't let it go negative
		if (currentTime < 0)
			currentTime = 0.0f;

		// update the text UI
		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}

	// public function that can be called to restart the game
	public void RestartGame ()
	{
		// we are just loading a scene (or reloading this scene)
		// which is an easy way to restart the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// public function that can be called to go to the next level of the game
	public void NextLevel ()
	{
		// we are just loading the specified next level (scene)
        SceneManager.LoadScene(nextLevelToLoad);
	}

	public void LoadLevelSelector()
    {
		if(!MainMenuCanvas)
        {
			MainMenuCanvas = GameObject.Find("Main Canvas").gameObject;

		}
		MainMenuCanvas.SetActive(false);

        if (!LevelSelectorCanvas)
        {
			Debug.Log("inactive");
        }

        LevelSelectorCanvas.SetActive(true);
		Debug.Log("test");
    }

	public void StartGame()
    {
		SceneManager.LoadScene(0);
    }

	public void LevelOneButtonHandler()
    {

    }

	public void LevelTwoButtonHandler()
    {

    }
	

}
