using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    menu, inGame, gameOver
}

public class GameManager : MonoBehaviour
{   public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance; 
    // Start is called before the first frame update
    
    void Awake(){
        if(sharedInstance==null){sharedInstance = this;}
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit")){
            StartGame();
        }        
    }
public void StartGame(){
SetGameState(GameState.inGame);
}

public void GameOver(){
    SetGameState(GameState.gameOver);
}

public void BackToMenu(){
    SetGameState(GameState.menu);
}

void SetGameState(GameState newGameState){
if(newGameState==GameState.menu){}
else if (newGameState==GameState.inGame){}
else if (newGameState==GameState.gameOver){}    
}

}
