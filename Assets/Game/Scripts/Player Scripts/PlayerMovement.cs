using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myBody;
    private PlayerAnimator playerAnim;
    private SwerveInputSystem swerveInputSystem;
    [SerializeField]
    private float swerveSpeed = 0.5f;
    [SerializeField]
    private float maxSwerveAmount = 1f;
    //[SerializeField]
    //private float damping = 4f;
    public float moveSpeed = 10f;
    private Vector3 moveTemp;
    [SerializeField]
    private float minX, maxX;
    
    [HideInInspector]
    public bool gameFinished;
    
    [HideInInspector]
    public bool gameOver;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<PlayerAnimator>();
        swerveInputSystem = GetComponent<SwerveInputSystem>();
    }


    void Update()
    {
        if (!gameFinished&&!gameOver) { 
           playerBounds();
           movePlayer();
        }
        
        
        
    }
    void movePlayer() {
        moveTemp = transform.position;
        moveTemp.z += moveSpeed * Time.deltaTime;
        transform.position = moveTemp;
        if(myBody.velocity.sqrMagnitude > 0) {
            playerAnim.Run(true);    
        }
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        //Debug.Log("Swerve Amount : " + swerveAmount);
        transform.Translate(swerveAmount,0,0);
        //Vector3 horizontalTemp = new Vector3(swerveAmount, myBody.velocity.y, myBody.velocity.z);
        //myBody.velocity = Vector3.Slerp(myBody.velocity, horizontalTemp, damping);
    }
    void playerBounds() { 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y,
            transform.position.z);
    }
}
