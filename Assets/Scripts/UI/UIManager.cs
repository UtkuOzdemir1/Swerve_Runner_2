using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] PageBase[] elements;

    public override void Initialize()
    {
        foreach (var elem in elements)
        {
            elem.Initialize();
        }
    }

    public override void StateUpdate(GameState state)
    {
        DeactivateAll();
        Activate((int)state);
    }

    private void Activate(int index)
    {
        elements[index].Activate(true);
    }

    private void Deactivate(int index)
    {
        elements[index].Activate(false);
    }

    private void DeactivateAll()
    {
        foreach (var element in elements)
            element.Activate(false);
    }

    private void Reset()
    {
        elements = GetComponentsInChildren<PageBase>();
    }
}
