using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
//  Copyright © 2022 Kyo Matias, Nate Florendo. All rights reserved.
//

public class Player : MonoBehaviour
{
    [SerializeField] private Image HPBar;
    
    [SerializeField] private float _maxHealth = 10;
    [SerializeField] private float _currentHealth;

    public GameObject diePEffect;
    private void Awake()
    {
        _currentHealth = _maxHealth;
        HPBarUpdate();
    }
    
    public void ReduceHealth(float value)
    {

        if (_currentHealth > 0)
        {
            _currentHealth -= value;
            
            Debug.Log($"Health: {_currentHealth}");
            
            if (_currentHealth <= 0)
            {
                //gameOverSound.Play();
                GameObject particle = Instantiate(diePEffect, transform.position, Quaternion.identity);
                Destroy(particle, 3);
                gameObject.SetActive(false);
                
                Debug.Log("GAME OVER");
            }
        }
        HPBarUpdate();
    }
    
    private void HPBarUpdate()
    {
        HPBar.fillAmount =  _currentHealth/ _maxHealth;
    }

}
