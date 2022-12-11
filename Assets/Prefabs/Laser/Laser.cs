using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject _beam;
    // Start is called before the first frame update
    void Start()
    {
        _beam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            activateLaser();
        }
    }

    void activateLaser()
    {
        _beam.SetActive(true);
        StartCoroutine("LaserTime");

    }
        public IEnumerator LaserTime()
    {
        yield return new WaitForSeconds(5);
        _beam.SetActive(false);
        
    }
}
