using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    public string packJsonLink;
    public List<PackData> packList;
    public static ShopData instance;

    int numTry = 1;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        var url = packJsonLink.Trim();
        if (string.IsNullOrEmpty(url)) return;
    }
    
}
