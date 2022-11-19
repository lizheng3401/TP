public abstract class BaseModule
{
    internal virtual int Priority
    {
        get
        {
            return 0;
        }
    }

    internal abstract void Tick(float elapseSeconds, float realElapseSeconds);

    internal abstract void ShutDown();
}