using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  Copyright © 2022 Kyo Matias, Nate Florendo. All rights reserved.
//

public class Weapon : MonoBehaviour
{
    
    
    private ObjectPool _bulletPool;
    [SerializeField] private int _bulletPoolCount = 10;
    
    [SerializeField] private PlayerController _player;
    
    
    private void Awake()
    {
        _bulletPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        _bulletPool.Initialize(_player.BulletPrefab,_bulletPoolCount); // size depends on fore rate of player
    }
    
    
    public void FireWeapon()
    {
        //get object from object pool instead of instantiating directly
        GameObject bullet = _bulletPool.CreateObject();
        bullet.GetComponent<Rigidbody2D>().AddForce(_player.FirePoint.up * _player.FireForce,ForceMode2D.Impulse);

    }
}
