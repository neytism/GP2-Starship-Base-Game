using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

//
//  Copyright © 2022 Kyo Matias, Nate Florendo. All rights reserved.
//

public class ObjectPool : MonoBehaviour
{
   [SerializeField] private GameObject _objectToPool;
   [SerializeField] private int _poolSize;

   private Queue<GameObject> _objectPool;

   public Transform spawnedObjectsParent;

   private void Awake()
   {
      _objectPool = new Queue<GameObject>(0);
   }

   public void Initialize(GameObject objectToPool, int poolSize = 10)
   {
      this._objectToPool = objectToPool;
      this._poolSize = poolSize;
   }

   public GameObject CreateObject()  //returns the game object
   {
      CreateObjectParentIfNeeded();

      GameObject spawnedObject = null;
      
      //creates gameobjects 

      if (_objectPool.Count < _poolSize)
      {
         spawnedObject = Instantiate(_objectToPool, transform.position, quaternion.identity);
         spawnedObject.name = transform.root.name + "_" + _objectToPool.name + "_" + _objectPool.Count;
         spawnedObject.transform.SetParent(spawnedObjectsParent);
      }
      else  
      {
         spawnedObject = _objectPool.Dequeue();
         spawnedObject.transform.position = transform.position;
         spawnedObject.transform.rotation = Quaternion.identity;
         spawnedObject.SetActive(true);
      }
      
      _objectPool.Enqueue(spawnedObject);
      return spawnedObject;
   }

   private void CreateObjectParentIfNeeded()
   {
      if (spawnedObjectsParent == null)
      {
         string name = "ObjectPool_" + _objectToPool.name;
         var parentObject = GameObject.Find(name);
         if (parentObject != null)
         {
            spawnedObjectsParent = parentObject.transform;
         }
         else
         {
            spawnedObjectsParent = new GameObject(name).transform;
         }
      }
   }
}
