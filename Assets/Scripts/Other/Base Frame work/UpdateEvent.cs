using UnityEngine;
using UnityEngine.Events;

public class UpdateEvent : MonoBehaviour
{
    public UnityAction Event;

    private void Update()
    {
        Event?.Invoke();
    }

    public void AddEvent(UnityAction p_Event)
    {
        Event += p_Event;
    }
    public void Byby()
    {
        DestroyImmediate(this);
    }
}
