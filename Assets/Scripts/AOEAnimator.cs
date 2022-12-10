using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class AOEAnimator : MonoBehaviour
{
    
    [SerializeField] private Animator _animatorComponent;
    private bool _abilityReady;
    private Renderer _rendererComponent;

    //[SerializeField] private float _cooldown;
    private bool _playCooldown;
    private KeyCode _space;
    
    private const string _aoe = "AOE";
    // Start is called before the first frame update


    private void Awake()
    {
        //gameObject.SetActive(false);
        _animatorComponent = GetComponent<Animator>();
        _rendererComponent = GetComponent<Renderer>();
    }

    private void Start()
    {
        
        _abilityReady = true;
        _animatorComponent.gameObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.Space) && _abilityReady == true)
        {
            AoeSkill();
        }
    }

    private void AoeSkill()
    {
        //gameObject.SetActive(true);
        Debug.Log("AOE IS Pressed");
        _animatorComponent.gameObject.GetComponent<Animator>().enabled = true;
        _animatorComponent.SetTrigger("OnTrigger");
        _abilityReady = false;
        StartCoroutine("wait");
        Debug.Log("AnimationPlay");
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Ability Charged");
        _abilityReady = true;
    }
}

