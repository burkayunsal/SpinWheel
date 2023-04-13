using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : Singleton<ItemSpawner>
{
    
    [SerializeField] private Transform midPoint,dot;
    [SerializeField] private ItemData[] possibleDatas;
    [SerializeField] private ItemData bombData;

    private float radius;

    private List<Item> lsItems = new List<Item>();
    private void Start()
    {
        radius = Vector3.Distance(midPoint.position, dot.position);
        SpawnItems();
    }

    private void SpawnItems()
    {
        for (int i = 0; i < Configs.GameSettings.itemCount; i++)
        {
            float angleStep = 360f / Configs.GameSettings.itemCount;
            float angle = i * angleStep;
            float radians = angle * Mathf.Deg2Rad;

            float x = midPoint.position.x + radius * Mathf.Cos(radians);
            float y = midPoint.position.y + radius * Mathf.Sin(radians);
            float z = midPoint.position.z;
            
            Item item = PoolManager.I.GetObject<Item>();
            item.transform.localPosition = new Vector3(x, y, z);
            item.transform.parent = midPoint;
            
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            
            lsItems.Add(item);
            
            int rndm = Random.Range(0, possibleDatas.Length);
            ItemData data = possibleDatas[rndm];
            item.Init(data);
        }
        AddBomb();

    }

    public void ReplaceItems()
    {
        List<Item> _tempList = new List<Item>();
        for (int i = 0; i < Configs.GameSettings.itemCount; i++)
        {
            Item newItem = PoolManager.I.GetObject<Item>();
            newItem.transform.position = lsItems[i].transform.position;
            newItem.transform.parent = midPoint;

            newItem.transform.localScale = Vector3.one;
            
           _tempList.Add(newItem);
            
            int rndm = Random.Range(0, possibleDatas.Length);
            ItemData data = possibleDatas[rndm];
            newItem.Init(data);

            lsItems[i].OnDeactivate();
        }
        
        lsItems.Clear();
        lsItems = _tempList;
        
        if(!(ZoneManager.I.IsSafeZone() || ZoneManager.I.IsSuperZone()))
            AddBomb();
    }
    
    private void AddBomb()
    {
        int rndm = Random.Range(0, lsItems.Count);
        lsItems[rndm].Init(bombData);
    }
    
}

public enum ItemType
{
    Cash,
    Gold,
    ElectricGrenade,
    M67,
    HealthShot,
    SnowBallGrenade,
    HealthShotAdrenaline,
    MedicalKit,
    C4,
    Emp,
    Bomb
}