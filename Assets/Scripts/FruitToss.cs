using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FruitToss : AbstractToss
{
    [SerializeField]
    private int score = 1;   

    public static event System.Action<int> OnFruitSlice;

    protected override void HandlePlayerCollision()
    {
        OnFruitSlice?.Invoke(score);
        base.HandlePlayerCollision();
    }    
}
