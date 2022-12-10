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
    
    private Animator _animatorComponent;
    private bool _IsAbilityUsed;
    private Renderer _rendererComponent;
    
    
    private const string _aoe = "AOE";
    // Start is called before the first frame update


    private void Awake()
    {
        //_gameObject.SetActive(false);
        _animatorComponent = GetComponent<Animator>();
        _rendererComponent = GetComponent<Renderer>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
        _IsAbilityUsed = false;
        _animatorComponent.gameObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space) && _IsAbilityUsed == false)
        {
            AoeSkill();
        }
        else
        {
            _animatorComponent.gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    private void AoeSkill()
    {
        gameObject.SetActive(true);
        Debug.Log("AOE IS Pressed");
        _animatorComponent.gameObject.GetComponent<Animator>().enabled = true;
        _animatorComponent.Play(_aoe);
        //IsAOEUsed();
        
        Debug.Log("AnimationPlay");
    }
/*
    public void IsAOEUsed()
    {
        if (_IsAbilityUsed = true)
        {
            Debug.Log("ABILITY IS USED");
            EMP.SetActive(false);
        }
    }

*/
    public void Disable()
    {
        _rendererComponent.enabled = false;
    }

    public void Enable()
    {
        _rendererComponent.enabled = true;
    }
}

