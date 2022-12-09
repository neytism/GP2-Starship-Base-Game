using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  Copyright © 2022 Kyo Matias, Nate Florendo. All rights reserved.
//

public class Enemy : MonoBehaviour
{
    private Player _player;
    private float _damage = 1;
    public GameObject diePEffect;


    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Bullet"))
        {
            GameObject particle = Instantiate(diePEffect, transform.position, Quaternion.identity);
            Destroy(particle, 3);
           gameObject.SetActive(false);
           
           if (col.gameObject.tag.Equals("Player"))
           {
               _player.ReduceHealth(_damage);
           }
           
           Debug.Log("Player Damaged");
        }
    }

}
