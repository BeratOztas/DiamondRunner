using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerAnimator playerAnim;
    private PlayerMovement playerMovement;
    public int health = 4,diamondAmount=0,diamond_5_side_Amount=0;
    [SerializeField]
    private GameObject barrierCollideEffect;
    [SerializeField]
    private GameObject blueDiamondEffect, whiteDiamondEffect;

    
     void Awake()
    {
        playerAnim = GetComponent<PlayerAnimator>();
        playerMovement=GetComponent<PlayerMovement>();
            
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.FINISHLINE)) {
            playerMovement.gameFinished = true;
            playerAnim.Victory(true);
        }
        if (other.CompareTag(Tags.BARRIER)) {
            
            

        }
        if (other.CompareTag(Tags.DIAMOND))
        {
            Instantiate(blueDiamondEffect, this.transform.position + new Vector3(0, 2f, 5f), Quaternion.identity);
            diamondAmount++;
            other.gameObject.SetActive(false);

        }
        if (other.CompareTag(Tags.DIAMOND_5SIDE))
        {
            Instantiate(whiteDiamondEffect, this.transform.position + new Vector3(0, 2f, 5f), Quaternion.identity);
            diamond_5_side_Amount++;
            other.gameObject.SetActive(false);
        }

    }
     void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag(Tags.BARRIER)) {
            Instantiate(barrierCollideEffect, this.transform.position + new Vector3(0, 2f, 5f), Quaternion.identity);
            health--;
            Debug.Log("Health = " + health);
            if (health == 0)
            {
                //LevelController.instance.GameOver();
                Debug.Log("GameOver");
            }
        }
        
    }
}
