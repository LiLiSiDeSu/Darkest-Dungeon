using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MgrScene : InstanceBaseAuto_Mono<MgrScene>
{
    public void LoadScene(string name, UnityAction function)
    {
        SceneManager.LoadScene(name);
        function();
    }

    public void LoadSceneAsync(string name, UnityAction function)
    {
        _LoadSceneAsync(name, function);
    }

    public IEnumerator _LoadSceneAsync(string name, UnityAction function)
    {
        yield return SceneManager.LoadSceneAsync(name);
        function();
    }
}
