using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;

public class PoolBuffer : InstanceBaseAuto_Mono<PoolBuffer>
{
    private Transform RootPool; 
    
    private Dictionary<string, GameObject> DicItemRoot;
    public Dictionary<string, List<GameObject>> DicPool;

    protected override void Start()
    {
        base.Start();

        RootPool = transform;
        DicItemRoot = new Dictionary<string, GameObject>();
        DicPool = new Dictionary<string, List<GameObject>>();
    }

    public GameObject TakeAndGet(string name)
    {        
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
        if (!DicItemRoot.ContainsKey(name + "_Root"))
        {
            GameObject obj = new GameObject(name + "_Root");            
            obj.transform.SetParent(RootPool);
            DicItemRoot.Add(obj.name, obj);
        }

        item.transform.SetParent(DicItemRoot[name + "_Root"].transform);

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
        Transform[] all = DicItemRoot[name].GetComponentsInChildren<Transform>();
        for (int i = 0; i < all.Length; i++)
        {
            Destroy(all[i]);
        }
    }    

    public void ClearAll()
    {
        Transform[] all = RootPool.GetComponentsInChildren<Transform>();
        for (int i = 0; i < all.Length; i++)
        {
            Destroy(all[i]);
        }
        DicItemRoot.Clear();
        DicPool.Clear();
    }
}
