using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    private GameManager gameManager;
    private PlayerInteraction playerInteraction;
    private int startHealth;
    [Header("WinScreen")]
    public GameObject winPanel;
    public Text win_diamondText, win_diamond5SideText;
    public Text total_diamondText, total_diamond5SideText;
    public Image win_diamond, win_diamond5Side;
    public Image total_diamond, total_diamond5Side;

    

    [HideInInspector]
    public static int total_Diamond_Amount = 0, total_Diamond5Side_Amount = 0;
    
    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameover_diamondText, gameover_diamond5SideText;
    public Image diamond, diamond5Side;


    void Awake()
    {
        instance = this;

        gameManager = FindObjectOfType<GameManager>();
        playerInteraction = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerInteraction>();
        
    }
    
    public void GameOverScreen() {
        gameOverPanel.SetActive(true);
        gameover_diamondText.text = "x " + playerInteraction.diamondAmount;
        gameover_diamond5SideText.text = "x " + playerInteraction.diamond_5_side_Amount;

    }
    public void WinScreen() {
        total_Diamond_Amount += playerInteraction.diamondAmount;
        total_Diamond5Side_Amount += playerInteraction.diamond_5_side_Amount;
        
        winPanel.SetActive(true);
        win_diamondText.text = "x " + playerInteraction.diamondAmount;
        win_diamond5SideText.text = "x " + playerInteraction.diamond_5_side_Amount;
        total_diamondText.text = "x " + total_Diamond_Amount;
        total_diamond5SideText.text = "x " + total_Diamond5Side_Amount;

    }
    
    
   


}
