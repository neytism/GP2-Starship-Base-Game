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
    [SerializeField] public GameObject gameOverScreen;
    
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

        if (_currentHealth > 0) // if player is not dead
        {
            _currentHealth -= value;
            
            Debug.Log($"Health: {_currentHealth}");
            
            if (_currentHealth <= 0)  //if player is dead
            {
                
                //insert death sound here
                
                GameObject particle = Instantiate(diePEffect, transform.position, Quaternion.identity);
                Destroy(particle, 3);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                StartCoroutine(ShowGameOverScreen()); 
                
                Debug.Log("GAME OVER");
            }
        }
        Debug.Log("Player Damaged");
        HPBarUpdate();
    }
    
    private void HPBarUpdate() //updates health bar using image fill
    {
        HPBar.fillAmount =  _currentHealth/ _maxHealth;
    }
    
    IEnumerator ShowGameOverScreen() {
        yield return new WaitForSeconds(1.5f);
        gameOverScreen.SetActive(true);
        
        Time.timeScale = 0f;
    }

}