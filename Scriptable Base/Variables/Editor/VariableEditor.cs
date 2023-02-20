using UnityEngine;
using UnityEditor;

namespace Variable
{ 
	[CustomEditor(typeof(BaseVariable),true)]
	[CanEditMultipleObjects]
	public class VariableEditor : Editor
	{
		//have a private version of the BaseVariable data
		private SerializedProperty persistentMode;
		private SerializedProperty runtimeMode;
		private SerializedProperty initialValue;
		private SerializedProperty runtimeValue;
		private void OnEnable()
		{
			//Connect our version of the data to the actual data of BaseVariable
			persistentMode = serializedObject.FindProperty("_persistenceMode");
			runtimeMode = serializedObject.FindProperty("_runtimeMode");
			initialValue = serializedObject.FindProperty("_initialValue");
			runtimeValue = serializedObject.FindProperty("_runtimeValue");
		}
		public override void OnInspectorGUI()
		{
			//display any value changes between the 2/update eachother
			serializedObject.Update();
			//Can Touch...yeah thats fine
			EditorGUILayout.PropertyField(persistentMode);
			EditorGUILayout.PropertyField(runtimeMode);
			EditorGUILayout.PropertyField(initialValue);
			
			//NO TOUCHY!!
			EditorGUI.BeginDisabledGroup(true);
			EditorGUILayout.PropertyField(runtimeValue);
			EditorGUI.EndDisabledGroup();
			
			//Runtime save button interaction toggle
			EditorGUI.BeginDisabledGroup(persistentMode.boolValue == true);
			if(GUILayout.Button("Save Runtime to Initial Value"))
			{
				(target as BaseVariable).SaveToInitialValue();
			}
			EditorGUI.EndDisabledGroup();

			if(target) 
			{
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}


