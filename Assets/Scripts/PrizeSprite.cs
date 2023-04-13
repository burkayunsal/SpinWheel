
using UnityEngine;
using UnityEngine.UI;

public class PrizeSprite : PoolObject
{
    [SerializeField] public Image icon;
    public override void OnDeactivate()
    {
        gameObject.SetActive(false);
    }

    public override void OnSpawn()
    {
        gameObject.SetActive(true);
    }

    public override void OnCreated()
    {
        OnDeactivate();
    }
}
