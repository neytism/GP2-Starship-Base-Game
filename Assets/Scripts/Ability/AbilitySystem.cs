using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class AbilitySystem : MonoBehaviour
{
    public Image abilityImage;
    public float cooldown = 3f;
    private bool isCooldown = false;
    public KeyCode AbilityKey;
    private void Start()
    {
        abilityImage.fillAmount = 0;
    }

    private void Update()
    {
        {
            Ability1();
        }
    }

    private void Ability1()
    {
        if (Input.GetKey(AbilityKey) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage.fillAmount = 1;
            Debug.Log("Cooldown In Progress");
        }

        if (isCooldown)
        {
            abilityImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
