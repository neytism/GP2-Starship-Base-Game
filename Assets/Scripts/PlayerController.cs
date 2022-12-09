using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  Copyright © 2022 Kyo Matias, Nate Florendo. All rights reserved.
//

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireForce = 20f;
    [SerializeField] private float _fireRate = .1f;
    private float _nextFire = 0f;

    

    private Vector2 _moveDirection; 
    private Vector2 _mousePosition; 

    public float MoveSpeed => _moveSpeed;
    public Transform FirePoint => _firePoint;
    public float FireForce => _fireForce;
    public GameObject BulletPrefab => _bulletPrefab;

   

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            _weapon.FireWeapon();
        }

        _moveDirection = new Vector2(moveX, moveY).normalized;
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);

        Vector2 aimDirection = _mousePosition - _rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = aimAngle;
    }

    
}
