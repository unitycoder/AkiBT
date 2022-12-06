namespace Kurisu.AkiBT.Extend
{
    [AkiInfo("Decorator:直到子结点返回Success为止返回Running")]
    [AkiLabel("WaitSuccess等待成功")]
public class WaitSuccess : Decorator
{
    protected override Status OnDecorate(Status childeStatus)
    {
        if(childeStatus==Status.Success)
            return Status.Success;
        else
            return Status.Running;
    }
}
}