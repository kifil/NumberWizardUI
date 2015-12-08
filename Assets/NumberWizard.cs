using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	//declare global variables
	int max;
	int min;
	int guess;
	
	
	public int maxGuessesAllowed = 10;
	public int currentGuessCount = 1;
	//access text UI elements
	public Text guessText;
	public Text titleText;
	public Text guessCountText;

	// Use this for initialization
	void Start () {
		//only happens at the very beginning of the program
		StartGame();	
	}
	
	//set up a new game
	void StartGame(){
		max = 1000;
		min = 1;
		guess = Mathf.FloorToInt(Random.Range(min,max+1));
		guessText.text = guess.ToString();
		
		max = max + 1;
	}

	//update after every guess
	void NextGuess(){	
		currentGuessCount++;
		//player chose a number the computer could not guess
		if(currentGuessCount >= maxGuessesAllowed ){
			Application.LoadLevel("Win");
		}
		else{
			//if the game continues, update teh guess
			guess = ((max + min) / 2);
			guessText.text = guess.ToString();
			titleText.fontSize += 2;
			guessCountText.text = currentGuessCount.ToString();
		}

	}
	
	Color CreateRandomColor(){
		return new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),1);
	}
	
	public void GuessHigher(){
		min = guess;
		guessText.color = CreateRandomColor();
		NextGuess();
	}
	
	public void GuessLower(){
		max = guess;
		guessText.color = CreateRandomColor();
		NextGuess();
	}
}
