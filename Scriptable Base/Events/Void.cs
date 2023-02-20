using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Event
{
    [CreateAssetMenu(menuName = "Events/Void Event", fileName = "new Void Event")]

    public class Void : ScriptableObject
    {
        [SerializeField] private UnityEvent Event;

        public void Invoke() => Event?.Invoke;
        public void Add(UnityAction action) => Event.AddListener(action);
        public void Remove(UnityAction action) => Event.RemoveListener(action);
    }
}
