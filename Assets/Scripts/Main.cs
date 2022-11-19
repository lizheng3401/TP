using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Start()
    {
        TPApplication.Instance.OnStartInit();
        TPApplication.Instance.AfterStartInit();
    }

    // Update is called once per frame
    private void Update()
    {
        TPApplication.Instance.Update();
    }

    private void FixedUpdate()
    {
        TPApplication.Instance.FixedUpdate();
    }

    private void LateUpdate()
    {
        TPApplication.Instance.LateUpdate();
    }
}
