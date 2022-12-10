using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  Copyright © 2022 Kyo Matias, Nate Florendo. All rights reserved.
//

public class PlayerController : MonoBehaviour
{

    [HideInInspector] public Vector2 MoveDirection;
    //for movements
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    //private Vector2 _moveDirection;
    
    //for aiming
    private Vector2 _mousePosition; 
    
    
    //for weapon
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireForce = 20f;
    [SerializeField] private float _fireRate = .1f;
    private float _nextFire = 0f;

    
    public float MoveSpeed => _moveSpeed;
    public Transform FirePoint => _firePoint;
    public float FireForce => _fireForce;
    public GameObject BulletPrefab => _bulletPrefab;

    

    

   

    // Update is called once per frame
    private void Update()
    {

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //fire
        if (Input.GetMouseButton(0) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            _weapon.FireWeapon();
        }
    }

    void FixedUpdate()
    {
        //movement
        MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));// Direction Changed For Dash Ability
        //player full stop 
        //_rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
        
        //player drift
        _rb.AddForce(new Vector2(MoveDirection.x * _moveSpeed, MoveDirection.y * _moveSpeed));

        Vector2 aimDirection = _mousePosition - _rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;  //faces towards target
        _rb.rotation = aimAngle;
    }

    

    
}
