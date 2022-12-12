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
<<<<<<< HEAD
    public Vector2 _moveDirection;
=======
    //private Vector2 _moveDirection;
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
    
    //for aiming
    private Vector2 _mousePosition; 
    
    
    //for weapon
    private GameObject _weapon;
    private Transform _firePoint;
    private float _nextFire = 0f;

    private PlayerManager _playerManager;

<<<<<<< HEAD
    [SerializeField] private AudioSource _shootSound;
    
    
    public Transform FirePoint => _firePoint;

    private void Awake()
    {
        _playerManager = GameObject.FindObjectOfType<PlayerManager>();
        _weapon = _playerManager.SelectWeaponType(_playerManager.selectedCharacter);
=======

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
    }

    // Update is called once per frame
    private void Update()
    {
<<<<<<< HEAD
        _firePoint = _weapon.GetComponent<Transform>();
        
        //movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(moveX, moveY);
        
=======

>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //fire
        if (Input.GetMouseButton(0) && Time.time > _nextFire)
        {
            _shootSound.Play();
            _nextFire = Time.time + _weapon.GetComponent<Weapon>().FireRate;
            _weapon.GetComponent<Weapon>().FireWeapon();
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

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
    

    
}
