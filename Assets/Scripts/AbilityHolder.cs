using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
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
<<<<<<< HEAD
    private AbilityManager _ability;
    private float _cooldownTime;
    
    private PlayerManager _playerManager;
    
    private float _duration;

    private float _activeTime;
    public float ActiveTime => _activeTime;
    
    
    [SerializeField] private Image _CDBar;
    private float _cooldown;
    private bool _isCoolDown;

    [SerializeField] public AudioClip _laserSound;
    [SerializeField] public AudioClip _explodeSound;
    [SerializeField] public AudioClip _swiftSound;
    
    public bool IsCoolDown
    {
        get => _isCoolDown;
        set => _isCoolDown = value;
    }
=======
    public AbilityManager Ability;
    private float cooldownTime;
    private float activeTIme;
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    public KeyCode key;
<<<<<<< HEAD

    private void Awake()
    {
        _playerManager = GameObject.FindObjectOfType<PlayerManager>();
        _ability = _playerManager.SelectAbilityType(_playerManager.selectedCharacter);
        _duration = _ability.ActiveTime;
        _cooldown = _ability.Cooldown;
        _CDBar.fillAmount = 1;
    }

=======
    
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
    void Update()
    {
        switch (state)
        {
           case AbilityState.ready:
               if (Input.GetKeyDown(key))
               {
<<<<<<< HEAD
                   _ability.Activate(gameObject);
                   state = AbilityState.active;
                   _activeTime = _ability.ActiveTime;
               }
               break;
           case AbilityState.active:
               if (_activeTime > 0)
               {
                   _activeTime -= Time.deltaTime;
                   _CDBar.fillAmount = _activeTime;

=======
                   Ability.Activate(gameObject);
                   state = AbilityState.active;
                   activeTIme = Ability.ActiveTime;
               }
               break;
           case AbilityState.active:
               if (activeTIme > 0)
               {
                   activeTIme -= Time.deltaTime;
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
               }
               else
               {
                   state = AbilityState.cooldown;
<<<<<<< HEAD
                   _cooldownTime = _ability.Cooldown;
               }
               break;
           case AbilityState.cooldown:
               if (_cooldownTime > 0)
               {
                   
                   _cooldownTime -= Time.deltaTime;
                   _CDBar.fillAmount = -(_cooldownTime - _ability.Cooldown) /  _ability.Cooldown;
                  
=======
                   cooldownTime = Ability.Cooldown;
               }
               break;
           case AbilityState.cooldown:
               if (cooldownTime > 0)
               {
                   cooldownTime -= Time.deltaTime;
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
               }
               else
               {
                   state = AbilityState.ready;
                   Debug.Log("Ability Ready");
               }
               break; 
        }
<<<<<<< HEAD

    }

    /*public void UpdateCDBar()
    {
        if (!_isCoolDown)
        {
            _isCoolDown = false;
            _CDBar.fillAmount = 1;
        }
        
        if (_isCoolDown)
        {
            _CDBar.fillAmount -= 1 / _cooldown * Time.deltaTime;
            if (_CDBar.fillAmount <= 0)
            {
                _CDBar.fillAmount = 0;
                _isCoolDown = false;
            }
        }
    }*/
    
    //for swift dash
    public void BeInvincible()
    {
        StartCoroutine(InvincibilityTime());
        
    }
    
    IEnumerator InvincibilityTime()
    {
        gameObject.GetComponent<Player>().IsInvincible = true;
        Debug.Log("isinvincible");
        yield return new WaitForSeconds(gameObject.GetComponent<AbilityHolder>()._duration + 1);
        gameObject.GetComponent<Player>().IsInvincible  = false;
        Debug.Log("isNotinvincible");
    }

    
    //for laser

    public void TurnOnLaser()
    {
        StartCoroutine(LaserTime());
        
    }
    IEnumerator LaserTime()
    {
        
        gameObject.GetComponent<Player>().Beam.SetActive(true);
        Debug.Log("Laser on");
        yield return new WaitForSeconds(gameObject.GetComponent<AbilityHolder>()._duration);
        gameObject.GetComponent<Player>().Beam.SetActive(false);
        Debug.Log("Laser off");
    }
    
    //for EMP
    
    public void Explode()
    {
        StartCoroutine(ExplosionTime());
        
    }
    
    IEnumerator ExplosionTime()
    {
        gameObject.GetComponent<Player>().AOE.SetActive(true);
        Debug.Log("Explode Start");
        yield return new WaitForSeconds(gameObject.GetComponent<AbilityHolder>()._duration);
        gameObject.GetComponent<Player>().AOE.SetActive(false);
        Debug.Log("Explode End");
    }

=======
    }
>>>>>>> ff8eb9e9b39fd100170aed4445efd7ced71805b1
}
