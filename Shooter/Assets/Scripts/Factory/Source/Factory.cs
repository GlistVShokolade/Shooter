using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<Result, Object> : MonoBehaviour
{
    public static Factory<Result, Object> Instance;

    protected List<Result> Buffer = new List<Result>();

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public abstract Result Create(Object obj);
    public abstract void Remove(Result obj);
}