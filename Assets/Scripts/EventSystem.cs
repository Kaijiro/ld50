using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem Instance;

    void Awake()
    {
        EventSystem.Instance = this;
    }

    public event Action<GameObject> OnPreciousReached;

    public void PreciousReached(GameObject precious){
        OnPreciousReached?.Invoke(precious);
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
