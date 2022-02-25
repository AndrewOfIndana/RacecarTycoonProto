using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameUI gameUI;

    public int money;
    private bool withinCheckpoint;
    private bool withinLap;

    public int lapMoney = 100;
    public int autoDriver1Level = 1;
    public int autoDriver2Level = 1;
    public int autoDriver3Level = 1;
    public int adRatio = 1;

    public GameObject PittstopScreen;
    public GameObject StatusScreen;

    private bool isCanvasOpen = false;
    void Start()
    {
        gameUI = GetComponent<GameUI>();
        withinCheckpoint = true;
        withinLap = false;
    }

    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            isCanvasOpen = !isCanvasOpen;
            gameUI.UpdateUI();
        }
        
        if(isCanvasOpen)
        {
            PittstopScreen.SetActive(true);
            StatusScreen.SetActive(true);
        }
        else
        {
            PittstopScreen.SetActive(false);
            StatusScreen.SetActive(false);
        }
    }

    public void LapReached()
    {
        if(withinLap)
        {
            AddMoney(lapMoney);
            withinLap = false;
            withinCheckpoint = true;
        }
    }

    public void CheckpointReached()
    {
        if(withinCheckpoint)
        {
            withinLap = true;
            withinCheckpoint = false;
        }
    }

    public void AddMoney(int funds)
    {
        money += (funds * adRatio);
        gameUI.UpdateUI();
    }

    public void LoseMoney(int funds)
    {
        money -= funds;
        gameUI.UpdateUI();
    }
}
