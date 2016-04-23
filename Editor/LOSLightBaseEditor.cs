using UnityEngine;
using UnityEditor;
using System.Collections;

namespace LOS.Editor {

	[CanEditMultipleObjects]
	[CustomEditor (typeof(LOSLightBase))]
	public class LOSLightBaseEditor : UnityEditor.Editor {

		protected SerializedProperty _isStatic;
		protected SerializedProperty _color;
		protected SerializedProperty _degreeStep;
		protected SerializedProperty _coneAngle;
		protected SerializedProperty _faceAngle;
		protected SerializedProperty _obstacleLayer;
		protected SerializedProperty _material;
		protected SerializedProperty _orderInLayer;
		protected SerializedProperty _sortingLayerName;

		private LOSLightBase light {
			get { return target as LOSLightBase; }
		}

		private LOSLightBase[] lights {
			get { return targets as LOSLightBase[]; }
		}

		protected virtual void OnEnable () {
			serializedObject.Update();

			_isStatic = serializedObject.FindProperty("isStatic");
			_obstacleLayer = serializedObject.FindProperty("obstacleLayer");
			_degreeStep = serializedObject.FindProperty("_degreeStep");
			_coneAngle = serializedObject.FindProperty("coneAngle");
			_faceAngle = serializedObject.FindProperty("_faceAngle");
			_color = serializedObject.FindProperty("color");
			_sortingLayerName = serializedObject.FindProperty("sortingLayerName");
			_orderInLayer = serializedObject.FindProperty("orderInLayer");
			_material = serializedObject.FindProperty("material");
		}


		public override void OnInspectorGUI () {
			serializedObject.Update();

			EditorUtility.SetSelectedWireframeHidden(light.GetComponent<Renderer>(), true);

			EditorGUILayout.PropertyField(_isStatic);

			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_obstacleLayer);
			EditorGUILayout.PropertyField(_degreeStep);
			EditorGUILayout.PropertyField(_coneAngle);
			if (_coneAngle.floatValue != 0) {
				EditorGUILayout.PropertyField(_faceAngle);
			}

			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_color);
			EditorGUILayout.PropertyField(_sortingLayerName);
			EditorGUILayout.PropertyField(_orderInLayer);
			EditorGUILayout.PropertyField(_material);
		}
	}

}