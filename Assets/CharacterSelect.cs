using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private GameObject Swifter;
    [SerializeField] private GameObject EMP;
    [SerializeField] private GameObject Laser;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button But1;
    [SerializeField] private Button But2;
    [SerializeField] private Button But3;

    private int SelectionValue;
    // Start is called before the first frame update
    void Start()
    {
        SelectionValue = 1;
    }

    private void Update()
    {
        switch(SelectionValue)
        {
            case 1:
                Swifter.SetActive(true);
                EMP.SetActive(false);
                Laser.SetActive(false);
                break;
            case 2:
                Swifter.SetActive(false);
                EMP.SetActive(true);
                Laser.SetActive(false);
                break;
            case 3:
                Swifter.SetActive(false);
                EMP.SetActive(false);
                Laser.SetActive(true);
                break;
                
                
        }
            
    }
    

    public void Pause()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;
        GameStateManager.Instance.SetState(newGameState);
    }
    
    
    

}
