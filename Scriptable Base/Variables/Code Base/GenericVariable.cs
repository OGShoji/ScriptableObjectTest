using UnityEngine;
//Family Name
namespace Variable
{
					//Generic Type	//Inheritance	//Interface
	public class GenericVariable <T> : BaseVariable,ISerializationCallbackReceiver
	{
		public enum RuntimeMode{ReadOnly,ReadWrite}
		public enum PersistenceMode{None = 0, Persist = 1}
		
		[SerializeField] private RuntimeMode _runtimeMode;
		[SerializeField] private PersistenceMode _persistenceMode;
		[SerializeField] private T _initialValue;
		[SerializeField] private T _runtimeValue;

		public T InitialValue
		{
			get{return _initialValue;}
			set{_initialValue = value;}
		}
		public T RuntimeValue
		{
			get{return _runtimeValue;}
			set{_runtimeValue = value;}
		}
		// =>	- Lambda expression that allows us to perform a funtion and pass it back to our variable
		private bool _persistence => _persistenceMode == PersistenceMode.Persist;
		public T Value
		{
			//Allows you to Read
			//if _persistence is true then _initialValue else we are false so _runtimeValue
			get => _persistence ? _initialValue : _runtimeValue;
			set
			{
				switch (_runtimeMode)
				{
					case RuntimeMode.ReadOnly:
					Debug.Log("Attemped to set read only variable");
					break;
					case RuntimeMode.ReadWrite:
						if(_persistence)
						{
							_initialValue = value;
						}
						else
						{
							_runtimeValue = value;
						}
					break;
					default:
					Debug.Log("Attemped to set read only variable...Defualt");
					break;
				}
			}
		}
		public static implicit operator T (GenericVariable<T> variable)
		{
			return variable.Value;
		}
		
		/*Inheritance Behaviours*/
		public override void SaveToInitialValue()
		{
			_initialValue = _runtimeValue;
			Debug.Log("Save Runtime to Initial Value");
		}	
		/// <summary>
		///ToggleRuntimePersistence allows you to Toggle the _persistenceMode 
		///This means that if its None it becomes Persist and if its Persist it becomes None
		///AKA IT TOGGLES
		///</summary>
		public override void ToggleRuntimePersistence()
		{
			//Set _persistenceMode to the opposite mode
			_persistenceMode = (_persistenceMode == 0) ? (PersistenceMode) 1:0;
			//it toggles
		}
		/// <summary>
		///ToggleRuntimeMode allows you to Toggle the _runtimeMode 
		///This means that if its ReadOnly it becomes ReadWrite and if its ReadWrite it becomes ReadOnly
		///AKA IT TOGGLES
		///</summary>
		public override void ToggleRuntimeMode()
		{
			_runtimeMode = (_runtimeMode == 0) ? (RuntimeMode) 1:0;
		}
		/*Interface Behaviours*/
		public void OnBeforeSerialize()
		{
			
		}
		public void OnAfterDeserialize()
		{
			if(!_persistence)
			{
				_runtimeValue = _initialValue;
			}
		}
	}
}
