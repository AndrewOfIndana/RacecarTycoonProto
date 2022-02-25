using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    private GameManager gameManager;
    private ShopManager shopManager;
    public TextMeshProUGUI moneyTxt;
    public PlayerController player;
    public TextMeshProUGUI speedTxt;
    public TextMeshProUGUI AVtxt;
    public TextMeshProUGUI dragTxt;
    public TextMeshProUGUI AdragTxt;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        shopManager = GetComponent<ShopManager>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        moneyTxt.text = "$ " + gameManager.money.ToString();
        speedTxt.text = "Speed: " + player.speed.ToString();
        AVtxt.text = "Angular Velocity: " + player.angularVelocityFloat.ToString();
        dragTxt.text = "Drag: " + player.dragVisual.ToString();
        AdragTxt.text = "Angular Drag: " + player.AdragVisual.ToString();
    }
}
