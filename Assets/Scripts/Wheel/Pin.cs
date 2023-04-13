
using DG.Tweening;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isPrizeOn = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPrizeOn)
        {
            isPrizeOn = true;
            SpinManager.I.pinCollider.enabled = false;

            Item item = other.gameObject.GetComponent<Item>();

            if (item != null)
            {
                if (item.type == ItemType.Bomb)
                {
                    GameManager.OnLevelFailed();
                } 
                else
                {
                   // PrizeSprite ps = PoolManager.I.GetObject<PrizeSprite>();
                   // ps.icon.sprite = item.GetIcon();
                    ScaleTween(item);
                }
            }
        }
        
    }

    private void ScaleTween(Item item)
    {
        item.transform.DOScale(1.5f, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
        {
            item.transform.DOScale(1f, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
            {
                PrizeManager.I.AddPrize(item);
                UIManager.I.ToggleTakeOrContinue();
                isPrizeOn = false;
            });
        });
    }
}
