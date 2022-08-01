using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    public virtual void Initialize()
    {

    }
    public virtual void Activate(bool condition)
    {
        gameObject.SetActive(condition);
    }
}
