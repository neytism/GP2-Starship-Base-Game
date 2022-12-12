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
    [SerializeField] private float _damage = 1;
    public GameObject diePEffect;

    [SerializeField] private AudioClip _hitSound;
    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Bullet")) 
        {
            //deploys particle before destroying object
            //particle system can be converted to pooling system if time possible
            AudioSource.PlayClipAtPoint(_hitSound, gameObject.transform.position);
            GameObject particle = Instantiate(diePEffect, transform.position, Quaternion.identity);
            Destroy(particle, 3);
            

            if (col.gameObject.tag.Equals("Player")) {
               _player.ReduceHealth(_damage);
           }
           _player.AddKillCount();
            Destroy(gameObject);
        }
    }

}
