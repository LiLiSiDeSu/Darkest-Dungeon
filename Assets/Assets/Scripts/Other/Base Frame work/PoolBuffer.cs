using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;

public class PoolBuffer : InstanceBaseAuto_Mono<PoolBuffer>
{
    private Transform RootPool; 
    
    private Dictionary<string, GameObject> RootDicItem;
    public Dictionary<string, List<GameObject>> DicPool;

    private void Start()
    {
        RootPool = transform;
        RootDicItem = new Dictionary<string, GameObject>();
        DicPool = new Dictionary<string, List<GameObject>>();
    }

    public GameObject TakeAndGet(string name)
    {
        if (DicPool[name].Count == 0)
            Debug.Log("--- PoolBuffer: " + name + " is null ---");

        DicPool[name][0].SetActive(true);
        DicPool[name][0].transform.parent = null;
        GameObject obj = DicPool[name][0];
        DicPool[name].RemoveAt(0);
        return obj;
    }

    /// <summary>
    /// 放进缓存池
    /// </summary>
    /// <param name="Active">对象在缓存池的激活状态</param>
    /// <param name="item">对象</param>
    /// <param name="name">对象在缓存池的名字(名字一般就直接是对象的gameObject.name)</param>    
    public void Push(bool Active, GameObject item, string name)
    {        
        if (!RootDicItem.ContainsKey("Root_" + name))
        {
            GameObject obj = new GameObject("Root_" + name);            
            obj.transform.SetParent(RootPool);
            RootDicItem.Add(obj.name, obj);
        }

        item.transform.SetParent(RootDicItem["Root_" + name].transform);

        if (!DicPool.ContainsKey(name))
        {
            DicPool.Add(name, new List<GameObject>());
        }

        DicPool[name].Add(item);

        item.SetActive(Active);
    }

    public bool ContainKey(string name)
    {
        return DicPool.ContainsKey(name);
    }

    public void ClearOne(string name)
    {
        Transform[] all = RootDicItem[name].GetComponentsInChildren<Transform>();
        for (int i = 0; i < all.Length; i++)
        {
            Destroy(all[i].gameObject);
        }
    }    

    public void ClearAll()
    {
        Transform[] all = RootPool.GetComponentsInChildren<Transform>();
        for (int i = 0; i < all.Length; i++)
        {
            Destroy(all[i].gameObject);
        }
        RootDicItem.Clear();
        DicPool.Clear();
    }
}
