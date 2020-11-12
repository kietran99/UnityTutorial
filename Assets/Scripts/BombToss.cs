public class BombToss : AbstractToss
{
    public static event System.Action OnBombSlice;

    protected override void HandlePlayerCollision()
    {
        OnBombSlice?.Invoke();
        base.HandlePlayerCollision();
    }
}
