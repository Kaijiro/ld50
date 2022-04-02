using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem Instance;

    void Awake()
    {
        EventSystem.Instance = this;
    }

    public event Action OnPreciousSmashed;

    public void PreciousSmashed(){
        OnPreciousSmashed?.Invoke();
    }

    public event Action OnCatSplashed;

    public void CatSplashed(){
        OnCatSplashed?.Invoke();
    }

    public event Action OnShoot;

    public void Shoot(){
        OnShoot?.Invoke();
    }
}
