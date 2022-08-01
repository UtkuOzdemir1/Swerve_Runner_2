using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool>
{
    public List<GameObject> pooledObjects = new List<GameObject>();
    public List<GameObject> unavailables = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;

    public override void Initialize()
    {
        Create(amountToPool);
    }

    public override void StateUpdate(GameState state)
    {

    }
    public void Create(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Create();
        }
    }

    public GameObject Create()
    {
        GameObject tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
        tmp.transform.SetParent(transform);
        
        return tmp;
    }

    public GameObject GetPooledObject()
    {
        GameObject returnedObject = pooledObjects.First();

        if (returnedObject == null)
            returnedObject = Create();

        pooledObjects.Remove(returnedObject);
        unavailables.Add(returnedObject);
        return returnedObject;
    }
    
    public void Dismiss(GameObject gObject)
    {
        unavailables.Remove(gObject);
        pooledObjects.Add(gObject);
    }
}
