using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour {
float playedTime;

 public Text timeDisplay;

    public int score = 0;
    public static GameManager inst;
    public int lifes = 1;
    public Text lifesText;
    public Text scoreText;
     [SerializeField] PlayerMovement playerMovement;
    

    public void IncrementScore ()
    {
     
        score = score + 1;
             scoreText.text = "Score: " + score.ToString();
        
	
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
    
 public void LoseLife (){
    lifes = lifes - 1;
    lifesText.text = "Lifes: " + lifes.ToString();
 }
   

    private void Awake ()
    {
        inst = this;
    }

    private void Start () {


	}

	private void Update () {
playedTime += Time.deltaTime;
     timeDisplay.text = "Time: " + Mathf.RoundToInt(playedTime).ToString();
     
}}