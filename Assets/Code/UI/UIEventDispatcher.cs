using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventDispatcher : MonoBehaviour
{
    public static UIEventDispatcher Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public event Action OnButtonStartPress;

    public void ButtonStartPress()
    {
        OnButtonStartPress?.Invoke();
    }
}
