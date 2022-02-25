using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameUI gameUI;
    public PlayerController player;

    [Header("Pittstop Costs Text")]
    public TextMeshProUGUI ticketUpgradeCostTxt;
    public TextMeshProUGUI autoDriver1CostTxt;
    public TextMeshProUGUI autoDriver2CostTxt;
    public TextMeshProUGUI autoDriver3CostTxt;
    public TextMeshProUGUI adUpgradeCostTxt;

    public TextMeshProUGUI speedUPCostTxt;
    public TextMeshProUGUI AVupCostTxt;
    public TextMeshProUGUI dragDownCostTxt;
    public TextMeshProUGUI adragDownCostTxt;

    public TextMeshProUGUI speedDownCostTxt;
    public TextMeshProUGUI AVdownCostTxt;
    public TextMeshProUGUI dragUpCostTxt;
    public TextMeshProUGUI adragUpCostTxt;
    public TextMeshProUGUI defaultTxt;

    public TextMeshProUGUI BigRedTxt;

    [Header("Pittstop Costs")]
    public int ticketUpgradeCost = 1000;
    public int autoDriver1Cost = 2000;
    public int autoDriver2Cost = 5000;
    public int autoDriver3Cost = 10000;
    public int adUpgradeCost = 20000;

    public int speedUPCost = 750;
    public int AVupCost = 800;
    public int dragDownCost = 900;
    public int adragDownCost = 1000;

    public int speedDownCost = 700;
    public int AVdownCost = 750;
    public int dragUpCost = 850;
    public int adragUpCost = 950;
    public int defaultRestoreCost = 50000;

    public int BigRedCost = 1000000; 

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameUI = GetComponent<GameUI>();
        UpdateCost();
    }

    void UpdateCost()
    {
        ticketUpgradeCostTxt.text = "Upgrade Ticket Sales - Cost: $ " + ticketUpgradeCost.ToString();
        autoDriver1CostTxt.text = "Upgrade Ticket Sales- Cost: $ " + autoDriver1Cost.ToString();
        autoDriver2CostTxt.text = "Upgrade Ticket Sales- Cost: $ " + autoDriver2Cost.ToString();
        autoDriver3CostTxt.text = "Upgrade Ticket Sales- Cost: $ " + autoDriver3Cost.ToString();
        adUpgradeCostTxt.text = "Ad Upgrade - Cost: $ " + adUpgradeCost.ToString();

        speedUPCostTxt.text = "Speed Upgrade - Cost: $ " + speedUPCost.ToString();
        AVupCostTxt.text = "Angular Velocity Upgrade - Cost: $ " + AVupCost.ToString(); 
        dragDownCostTxt.text = "Drag Decrease - Cost: $ " + dragDownCost.ToString(); 
        adragDownCostTxt.text = "Angular Drag Decrease - Cost: $ " + adragDownCost.ToString();

        speedDownCostTxt.text = "Speed Upgrade - Cost: $ " + speedUPCost.ToString();
        AVdownCostTxt.text = "Angular Velocity Upgrade - Cost: $ " + AVupCost.ToString(); 
        dragUpCostTxt.text = "Drag Increase - Cost: $ " + dragDownCost.ToString(); 
        adragDownCostTxt.text = "Angular Drag Increase - Cost: $ " + adragDownCost.ToString(); 
        defaultTxt.text = "Restore Default - Cost: $ " + defaultRestoreCost.ToString();

        BigRedTxt.text = "Race Big Red - Cost: $ " + BigRedCost.ToString();
    }

    public void TicketUpgrade()
    {
        if(gameManager.money >= ticketUpgradeCost)
        {
            if(gameManager.lapMoney <= 500)
            {
                gameManager.LoseMoney(ticketUpgradeCost);
                gameManager.lapMoney += 100;
                ticketUpgradeCost += 500;
                UpdateCost();
                gameUI.UpdateUI();
            }
        }
    }
    public void AutoDriver1()
    {
        if(gameManager.money >= autoDriver1Cost)
        {
            if(gameManager.autoDriver1Level <= 3)
            {
                gameManager.LoseMoney(autoDriver1Cost);
                gameManager.autoDriver1Level += 1;
                autoDriver1Cost += 1000;
                UpdateCost();
                gameUI.UpdateUI();
            }
        }
    }
    public void AutoDriver2()
    {
        if(gameManager.money >= autoDriver2Cost)
        {
            if(gameManager.autoDriver2Level <= 3)
            {
                gameManager.LoseMoney(autoDriver2Cost);
                gameManager.autoDriver2Level += 1;
                autoDriver2Cost += 2000;
                UpdateCost();
                gameUI.UpdateUI();
            }
        }
    }
    public void AutoDriver3()
    {
        if(gameManager.money >= autoDriver3Cost)
        {
            if(gameManager.autoDriver3Level <= 3)
            {
                gameManager.LoseMoney(autoDriver3Cost);
                gameManager.autoDriver3Level += 1;
                autoDriver3Cost += 5000;
                UpdateCost();
                gameUI.UpdateUI();
            }
        }
    }
    public void AdUpgrade()
    {
        if(gameManager.money >= adUpgradeCost)
        {
            if(gameManager.adRatio <= 5)
            {
                gameManager.LoseMoney(adUpgradeCost);
                gameManager.adRatio += 1;
                adUpgradeCost += 20000;
                UpdateCost();
                gameUI.UpdateUI();
            }
        }
    }

    public void SpeedUp()
    {
        if(gameManager.money >= speedUPCost)
        {
            if(player.speedLevel <= 10)
            {
                player.speedLevel += 1;
                player.UpdateSpeed();
                gameManager.LoseMoney(speedUPCost);
                gameUI.UpdateUI();
            }
        }
    }
    public void AVup()
    {
        if(gameManager.money >= AVupCost)
        {
            if(player.AVlevel <= 10)
            {
                player.AVlevel += 1;
                player.UpdateAV();
                gameManager.LoseMoney(AVupCost);
                gameUI.UpdateUI();
            }
        }
    }
    public void DragDown()
    {
        if(gameManager.money >= dragDownCost)
        {
            if(player.dragLevel >= 0)
            {
                player.dragLevel -= 1;
                player.UpdateDrag();
                gameManager.LoseMoney(dragDownCost);
                gameUI.UpdateUI();
            }
        }
    }
    public void ADragDown()
    {
        if(gameManager.money >= adragDownCost)
        {
            if(player.AdragLevel >= 0)
            {
                player.AdragLevel -= 1;
                player.UpdateADrag();
                gameManager.LoseMoney(adragDownCost);
                gameUI.UpdateUI();
            }
        }
    }

    public void Speeddown()
    {
        if(gameManager.money >= speedDownCost)
        {
            if(player.speedLevel >= 0)
            {
                player.speedLevel -= 1;
                player.UpdateSpeed();
                gameManager.LoseMoney(speedDownCost);
                gameUI.UpdateUI();
            }
        }
    }
    public void AVdown()
    {
        if(gameManager.money >= AVdownCost)
        {
            if(player.AVlevel >= 0)
            {
                player.AVlevel -= 1;
                player.UpdateAV();
                gameManager.LoseMoney(AVdownCost);
                gameUI.UpdateUI();
            }
        }
    }
    public void DragUp()
    {
        if(gameManager.money >= dragUpCost)
        {
            if(player.dragLevel <= 10)
            {
                player.dragLevel += 1;
                player.UpdateDrag();
                gameManager.LoseMoney(dragUpCost);
                gameUI.UpdateUI();
            }
        }
    }
    public void ADragUp()
    {
        if(gameManager.money >= adragUpCost)
        {
            if(player.AdragLevel <= 10)
            {
                player.AdragLevel += 1;
                player.UpdateADrag();
                gameManager.LoseMoney(adragUpCost);
                gameUI.UpdateUI();
            }
        }
    }
    public void DefaultR()
    {
        if(gameManager.money >= defaultRestoreCost)
        {
                player.DefaultRestore();
                gameManager.LoseMoney(defaultRestoreCost);
                gameUI.UpdateUI();
        }
    }

    public void BigRed()
    {
        if(gameManager.money >= BigRedCost)
        {
            gameManager.LoseMoney(BigRedCost);
            gameUI.UpdateUI();
        }
    }
}
