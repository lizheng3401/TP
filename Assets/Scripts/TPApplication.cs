using System;
using System.Collections;

using UnityEngine;

using Framework.GamePhase;

public class TPApplication: Singleton<TPApplication>
{
    public void OnStartInit()
    {
        GlobalVars.Init();
        GlobalVars.ModuleManager.Init();
        GlobalVars.PhaseManager.Init();
    }

    public void AfterStartInit()
    {
        GlobalVars.PhaseManager.SetCurrentPhase(GamePhaseType.GameStartupPhase);
    }

    internal void Update()
    {
        GlobalVars.ModuleManager.Tick(Time.timeScale, Time.deltaTime);
    }

    internal void FixedUpdate()
    {
        
    }

    internal void LateUpdate()
    {
        
    }
    
    
}