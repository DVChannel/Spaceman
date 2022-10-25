using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    menu, inGame, gameOver
}

public class GameManager : MonoBehaviour
{   
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance; 
    
    private PlayerController controller;
    public int collectedObject = 0;
    // Start is called before the first frame update
    
    void Awake(){
        if(sharedInstance==null){sharedInstance = this;}
    }
    
    void Start()
    {
     controller = GameObject.Find("Player").GetComponent<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit") && currentGameState != GameState.inGame){
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
if(newGameState == GameState.menu){
    MenuManager.sharedInstance.ShowMainMenu();
    MenuManager.sharedInstance.HideGameMenu();
    MenuManager.sharedInstance.HideGameOverMenu();
}
else if (newGameState == GameState.inGame){ 
    LevelManager.sharedInstance.RemoveAllLevelBlocks();
    LevelManager.sharedInstance.GenerateInitialBlocks();
    controller.StartGame();
    MenuManager.sharedInstance.ShowMainMenu();
}
else if (newGameState == GameState.gameOver){
    MenuManager.sharedInstance.ShowMainMenu();    
    MenuManager.sharedInstance.HideGameMenu();
    MenuManager.sharedInstance.HideGameOverMenu();
}    

this.currentGameState = newGameState;
}


public void CollectedObject(Collectable collectable){
    collectedObject += collectable.value;
}
}
