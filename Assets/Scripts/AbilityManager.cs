using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEditor;
=======
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
using UnityEngine;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
<<<<<<< HEAD

public class AbilityManager : ScriptableObject
{
    public string Name;
=======
public class AbilityManager : ScriptableObject
{
    public new string Name;
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
    public float Cooldown;
    public float ActiveTime;
    
    public virtual void Activate(GameObject parent){}
}
