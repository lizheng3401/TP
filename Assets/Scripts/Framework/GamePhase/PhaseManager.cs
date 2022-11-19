using Framework.GamePhase;
using GameCore.GamePhase;

public class PhaseManager
{
    public BasePhase CurrentPhase { get; private set; }

    public void Init()
    {
        
    }

    public void SetCurrentPhase(GamePhaseType phaseType)
    {
        CurrentPhase?.OnExit();
        switch (phaseType)
        {
            case GamePhaseType.GameStartupPhase:
                GameStartupPhase startupPhase = new GameStartupPhase();
                CurrentPhase = startupPhase;
                startupPhase.OnEnter();
                break;
            default:
                TPLog.LogFormat("Unknown PhaseType {0}", phaseType);
                break;
        }
    }
}