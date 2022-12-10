using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class AbilityHolder : MonoBehaviour
{
    public AbilityManager Ability;
    private float cooldownTime;
    private float activeTIme;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    public KeyCode key;
    
    void Update()
    {
        switch (state)
        {
           case AbilityState.ready:
               if (Input.GetKeyDown(key))
               {
                   Ability.Activate(gameObject);
                   state = AbilityState.active;
                   activeTIme = Ability.ActiveTime;
               }
               break;
           case AbilityState.active:
               if (activeTIme > 0)
               {
                   activeTIme -= Time.deltaTime;
               }
               else
               {
                   state = AbilityState.cooldown;
                   cooldownTime = Ability.Cooldown;
               }
               break;
           case AbilityState.cooldown:
               if (cooldownTime > 0)
               {
                   cooldownTime -= Time.deltaTime;
               }
               else
               {
                   state = AbilityState.ready;
                   Debug.Log("Ability Ready");
               }
               break; 
        }
    }
}
