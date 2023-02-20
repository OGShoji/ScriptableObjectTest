using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBase
{
	public class EventBase : MonoBehaviour
    {
        public class EventBase <T> : ScriptableObject
        {
            [SerializeField] private UnityEngine<T> EventResponses;

            public void Invoke(T context) => EventResponses?.Invoke(context);
            public void Add(UnityAction<T> action) => EventResponses.AddListener(action);
            public void Remove(UnityAction<T> action) => EventResponses.RemoveListener(action);
        }
    }

}

