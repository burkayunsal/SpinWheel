using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PrizeManager : Singleton<PrizeManager>
{
   [SerializeField] ItemData[] prizes;
   [SerializeField] private TextMeshProUGUI[] prizeTexts;
   
   public void AddPrize(Item item)
   {
      for (int i = 0; i < prizes.Length; i++)
      {
         if (prizes[i].type == item.type)
         {
            int _tempValue = item.value;
            
            if (ZoneManager.I.IsSuperZone())
            {
               int rndm = Random.Range(0, 10);
               prizes[i].amount += _tempValue * rndm;
            }
            
            prizes[i].amount += _tempValue;
            ScaleTween(i);
            break;
         }
      }
      UpdatePrizePanel();
   }

   private void UpdatePrizePanel()
   {
      for (int i = 0; i < prizes.Length; i++)
      {
         prizeTexts[i].text = "x " + prizes[i].amount;
      }
   }

   private void ScaleTween(int index)
   {
      prizeTexts[index].transform.DOScale(1.5f, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
      {
         prizeTexts[index].transform.DOScale(1f, 0.25f).SetEase(Ease.Linear);
      });
   }
}
