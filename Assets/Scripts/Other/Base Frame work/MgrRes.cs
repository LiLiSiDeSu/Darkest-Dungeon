using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MgrRes : InstanceBaseAuto_Mono<MgrRes>
{
    public T Load<T>(string path) where T : Object
    {
        T res = Resources.Load<T>(path);

        if (res == null)
            Debug.Log(path + " is null");        

        if (res is GameObject)
            return Instantiate(res);
        else
            return res;
    }
    
    public void LoadAsync<T>(string path, UnityAction<T> callback) where T : Object
    {        
        StartCoroutine(ReallyLoadAsync(path, callback));
    }
    
    private IEnumerator ReallyLoadAsync<T>(string path, UnityAction<T> callback) where T : Object
    {        
        ResourceRequest r = Resources.LoadAsync<T>(path);
        yield return r;

        if (r.asset is GameObject)
            callback(Instantiate(r.asset) as T);
        else
            callback(r.asset as T);
    }
}
