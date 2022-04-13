using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarDontDestroy : MonoBehaviour
{
    public static VarDontDestroy instance;
    public int id;
    public string nickName;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

    }
}
