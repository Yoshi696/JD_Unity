using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySingleObject : MonoBehaviour
{
    public static DontDestroySingleObject Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
