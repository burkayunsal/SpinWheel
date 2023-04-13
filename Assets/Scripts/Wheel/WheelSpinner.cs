using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelSpinner : MonoBehaviour
{
   [SerializeField] private Transform wheel;
   private float rotationMultiplier = 0f;
   private bool isSpinning = false;
   
   public void Spin()
   {
      if (!isSpinning)
      {
         SpinManager.I.SpinPressed();
         StartCoroutine(SpeedUp(Random.Range(2f,3f)));
      }
   }

   IEnumerator SpeedUp(float speedUpTime)
   {
      isSpinning = true;
      for (int i = 0; i < speedUpTime * 10; i++)
      {
         rotationMultiplier += 15f;
         yield return new WaitForSeconds(0.1f);
      }
      StartCoroutine(SlowDown());
   }
   
   IEnumerator SlowDown()
   {
      while (rotationMultiplier > 0)
      {
         rotationMultiplier -= 6f;
         yield return new WaitForSeconds(0.1f);
      }
      SpinEnd();
   }

   private void SpinEnd()
   {
      isSpinning = false;
      SpinManager.I.SpinEnd();
   }
   
   private void Update()
   {
      if (rotationMultiplier > 0)
      {
         wheel.transform.Rotate(Vector3.forward, rotationMultiplier * Time.deltaTime);
      }
   }
}
