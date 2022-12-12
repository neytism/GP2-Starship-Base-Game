using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class selection : MonoBehaviour
{
    public GameObject[] Characters;
    public int SelectedCharacter = 0;

    public void NextCharacter()
    {
        Characters[SelectedCharacter].SetActive(false); 
           SelectedCharacter = (SelectedCharacter + 1) % Characters.Length;
        Characters[SelectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        Characters[SelectedCharacter].SetActive(false);
        SelectedCharacter--;
        if (SelectedCharacter < 0)
        {
            SelectedCharacter += Characters.Length;
        }
        Characters[SelectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

}
