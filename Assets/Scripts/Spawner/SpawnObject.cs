using UnityEngine;

public abstract class SpawnObject : MonoBehaviour
{
    protected PlayerCoin Target;

    public void SetTarget(PlayerCoin target)
    {
        Target = target;
    }
}
