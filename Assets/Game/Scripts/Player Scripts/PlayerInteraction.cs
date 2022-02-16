using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Renderer myRenderer;
    private Renderer myRenderer2;
    private PlayerAnimator playerAnim;
    private PlayerMovement playerMovement;
    [HideInInspector]
    public  int earning = 1;
    public int health = 4,diamondAmount=0,diamond_5_side_Amount=0;
    [SerializeField]
    private GameObject barrierCollideEffect;
    [SerializeField]
    private GameObject blueDiamondEffect, whiteDiamondEffect;
    private GameManager gameManager;
    private bool canHit=true;
    

    
     void Awake()
    {
        playerAnim = GetComponent<PlayerAnimator>();
        playerMovement=GetComponent<PlayerMovement>();
        myRenderer = transform.GetChild(0).transform.GetComponent<Renderer>();
        myRenderer2 = transform.GetChild(1).transform.GetComponent<Renderer>();
        gameManager= FindObjectOfType<GameManager>();
        
    }

     
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.FINISHLINE)) {
            playerMovement.gameFinished = true;
            playerAnim.Victory(true);
            //Debug.Log("Health = "+ health);
            //Debug.Log("Diamond = " + diamondAmount);
            //Debug.Log("Diamond5SIDE = " + diamond_5_side_Amount);
            gameManager.GameFinished();

        }
        if (other.CompareTag(Tags.DIAMOND))
        {
            Instantiate(blueDiamondEffect, this.transform.position + new Vector3(0, 2f, 5f), Quaternion.identity);
            diamondAmount += earning;
            gameManager.showDiamondsAmount(diamondAmount);
            other.gameObject.SetActive(false);

        }
        if (other.CompareTag(Tags.DIAMOND_5SIDE))
        {
            Instantiate(whiteDiamondEffect, this.transform.position + new Vector3(0, 2f, 5f), Quaternion.identity);
            diamond_5_side_Amount += earning;
            gameManager.showDiamonds5SideAmount(diamond_5_side_Amount);
            other.gameObject.SetActive(false);
        }

    }
     void OnCollisionEnter(Collision target)
    {
        if (canHit&&target.gameObject.CompareTag(Tags.BARRIER)) {
            canHit = false;
            Instantiate(barrierCollideEffect, this.transform.position + new Vector3(0, 2f, 5f), Quaternion.identity);
            hitBarrier();
            canHit = true;
            
        }
        
    }
    void hitBarrier() {
        
        health--;
        gameManager.checkHealth();
        playerMovement.moveSpeed = 10f;
        StartCoroutine(speedUp());
        StartCoroutine(vanishPlayer(0f));
        StartCoroutine(appearPlayer(0.3f));
        StartCoroutine(vanishPlayer(0.6f));
        StartCoroutine(appearPlayer(0.9f));
        

    }
    IEnumerator vanishPlayer(float time) {
        yield return new WaitForSeconds(time);
        myRenderer.material.SetFloat("Vector1_f009b863126e4084bf1881bd3f78c1ef", 1f);//DissolveTimer float name 
        myRenderer2.material.SetFloat("Vector1_f009b863126e4084bf1881bd3f78c1ef", 1f);
    }
    IEnumerator appearPlayer(float time) {
        yield return new WaitForSeconds(time);
        myRenderer.material.SetFloat("Vector1_f009b863126e4084bf1881bd3f78c1ef", 0f);
        myRenderer2.material.SetFloat("Vector1_f009b863126e4084bf1881bd3f78c1ef", 0f);
    }
    IEnumerator speedUp() {
        yield return new WaitForSeconds(1f);
        playerMovement.moveSpeed = 20f;
    }
}
