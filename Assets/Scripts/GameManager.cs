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
        if(sharedInstance==null){sharedInstance = this}
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void StartGame(){

}

public void GameOver(){
    
}

public void BackToMenu(){
    
}

void SetGameState(GameState newGameState){
if(newGameState==GameState.menu){}
else if (newGameState==GameState.inGame){}
else if (newGameState==GameState.gameOver){}    
}

}