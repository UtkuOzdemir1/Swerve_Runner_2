using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewBase<T> : ViewBase
{
    public abstract void UpdateView(T updatedData);
}
public abstract class ViewBase : UIElement { }
