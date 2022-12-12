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
<<<<<<< HEAD
[CreateAssetMenu]
public class LaserAbility : AbilityManager
{
    public override void Activate(GameObject parent)
    {
        AbilityHolder player = parent.GetComponent<AbilityHolder>();

        AudioSource.PlayClipAtPoint(player._laserSound, player.transform.position);
        player.TurnOnLaser();
        Debug.Log("Laser ABILITY ");
    }
    
    
}
=======
public class LaserAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
