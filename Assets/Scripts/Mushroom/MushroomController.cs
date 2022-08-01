using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour, ICollectable
{
    [SerializeField] AudioClip clip;

    public void OnCollect()
    {
        Destroy(gameObject);
    }
}

public class FlowerController : MonoBehaviour, ICollectable
{
    public void OnCollect()
    {
        gameObject.SetActive(false);
    }
}

interface ICollectable
{
    void OnCollect();
}