using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
    [HideInInspector]
    public bool gameOver;
    
    private PlayerInteraction playerInteraction;
    private PlayerMovement playerMovement;

    
    public int healths = 3;
    
    public int earningCount = 1;

    public GameObject healthPrefab;

    private int levelNumber;
    private Animator fadeAnim;
    private PlayerAnimator playerAnim;
    [SerializeField]
    private Text diamondText,diamond5_Side_Text;
    
   

    void Awake()
    {
        playerInteraction = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerInteraction>();
        playerMovement = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerMovement>();
        playerAnim = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerAnimator>();
        levelNumber = PlayerPrefs.GetInt("Level", 1);
        fadeAnim = GameObject.Find("Fade").GetComponent<Animator>();
        playerInteraction.health = PlayerPrefs.GetInt("Health");
        playerInteraction.earning = PlayerPrefs.GetInt("Earning");
        healths= PlayerPrefs.GetInt("Health");
        for (int i = 0; i < healths; i++)
        {
            GameObject healthTemp = Instantiate(healthPrefab);
            healthTemp.transform.SetParent(GameObject.Find("Healths").transform);
            healthTemp.transform.position = GameObject.Find("Healths").transform.position;
        }

    }

    
    void Update()
    {
        if(!gameOver && playerInteraction.health <= 0) {
            gameOver = true;
            playerMovement.gameOver = true;
            playerAnim.gameObject.GetComponent<Animator>().enabled = false;
            GameUI.instance.GameOverScreen();
        }
    }

    public void setHealth(int healthIndex)
    {
        healths = healthIndex + 3;
        PlayerPrefs.SetInt("Health",healths);

    }
    public void setEarningAmount(int earningAmount)
    {
        earningCount = earningAmount + 1;
        PlayerPrefs.SetInt("Earning", earningCount);
    }
    public void checkHealth()
    {
        if (healths > 0)
        {
            healths--;
            GameObject.FindGameObjectWithTag(Tags.HEALTH).SetActive(false);
        }
    }
    public void showDiamondsAmount(int diamondAmount) {
        diamondText.text = "x " + diamondAmount;
    }   
    public void showDiamonds5SideAmount(int diamond5SideAmount) {
        diamond5_Side_Text.text = "x " + diamond5SideAmount;
    }

    public void GameFinished() {
        
        GameUI.instance.WinScreen();
        
        if (levelNumber >= SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("Level", levelNumber + 1);
        }
    }
    IEnumerator FadeIn(int SceneIndex)
    {
        fadeAnim.SetTrigger(AnimationTags.END);
        
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneIndex);
    }

    

    public void Restart() {
        StartCoroutine(FadeIn(SceneManager.GetActiveScene().buildIndex));
    }
    public void NextLevel() {
        StartCoroutine(FadeIn(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void Exit() {
        StartCoroutine(FadeIn(0));
    }


}
