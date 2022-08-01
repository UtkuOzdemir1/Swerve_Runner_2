using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageBase : UIElement
{
    [SerializeField] protected ViewBase[] views;

    public override void Initialize()
    {
        base.Initialize();
        foreach (var view in views)
            view.Initialize();
    }

    public override void Activate(bool condition)
    {
        base.Activate(condition);
        foreach (var view in views)
            view.Activate(condition);
    }
}
