using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

using CallbackContext = UnityEngine.InputSystem.InputSystem.CallbackContext;

using Event
{
	[CreateAssetMenu(menuName = "Events/Input Action Event", fileName = "new Input Action Event")]

	public class InputAction : ScriptableObject
	{
		[SerializeField, Tooltip("In this slot you need to attach an Input Action Reference from the new Input System Actions \n you can make more of these. Right Click in Assets to make an Input Action. Good Luck")]
		private InputActionReference _input;
		[Space(), SerializeField, Tooltip""]
		private UnityEvent<CallbackContext> _actions;
		private void Awake()
		{
			hideFlags = HideFlags.DontUnloadUnusedAsset;
		}
		private void OnEnable()
		{
			hideFlags = HideFlags.DontUnloadUnusedAsset;
			if(!_input)
			{
				return;
			}
			_input.action.performed += Action.Invoke;
		}
		private void OnDisable()
		{
			if(!_input)
			{
				return;
			}
			_input.action.performed -= _actions.Invoke;
		}

		public void Invoke(CallbackContext context) => _actions.Invoke(context);
		public void Add(UnityAction<CallbackContext> action) => _actions.AddListener(action);
		public void Remove(UnityAction<CallbackContext> action) => _actions.RemoveListener(action);

		[RuntimeInitializeOnLoadMethod]
		private static void Load() => Resources.LoadAll("",typeof(InputAction));
	}
}
