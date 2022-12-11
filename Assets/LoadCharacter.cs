using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class LoadCharacter : MonoBehaviour
{
    public GameObject[] CharacterPreFabs;
    public Transform spawnPoint;

    private void Start()
    {
        int SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject prefab = CharacterPreFabs[SelectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        
    }
}
