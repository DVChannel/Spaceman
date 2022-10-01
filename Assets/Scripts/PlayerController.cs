using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

//variables movimiento 
public float jumpForce = 6f;
public float runningSpeed = 2f;
private Rigidbody2D rigidBody;
Animator animator;
const string STATE_ALIVE="isAlive";
const string STATE_ON_THE_GROUD="isOnTheGround";

    public LayerMask groundMask;

    void Awake(){
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUD, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            Jump();
        }        
        animator.SetBool(STATE_ON_THE_GROUD, IsTouchingTheGround());
        Debug.DrawRay(this.transform.position, Vector2.down*1.5f, Color.red);
    }

    void FixedUpdate(){
        if(GameManager.sharedInstance.currentGameState == GameState.inGame){
        if (rigidBody.velocity.x < runningSpeed){
            rigidBody.velocity = new Vector2(runningSpeed,
                                            rigidBody.velocity.y);
        }}else{
            rigidBody.velocity = Vector2(0, rigidBody.velocity.y);
        }
    }

    void Jump(){
        if (IsTouchingTheGround()){
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);}
    }

    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(this.transform.position,
                                            Vector2.down,
                                            1.5f,
                                            groundMask)){
                                                return true;
                                            }else{
                                                return false;
                                            }
    }
}
