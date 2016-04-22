using UnityEngine;
using System.Collections;

namespace LOS {
[ExecuteInEditMode]
public class LOSVerticalOrder : MonoBehaviour {

	public float orderMultiplier = 100;
	public float orderOffset = 0;
	public bool isStatic = true;

	private LOSLightBase _light;
	private LOSLightBase light {
		get {
			if (_light == null) {
				_light = GetComponent<LOSLightBase>();
			}
			return _light;
		}
	}

	void Start () {
		UpdateSortOrder();
	}

	#if UNITY_EDITOR
	void Update () {
		if (!Application.isPlaying) UpdateSortOrder();
	}
	#endif

	void OnEnable () {
		if (!isStatic) StartCoroutine("SortCoroutine");
	}

	IEnumerator SortCoroutine () {
		while (enabled && !isStatic) {
			UpdateSortOrder();
			yield return new WaitForEndOfFrame();
		}
	}

	[ContextMenu("Update Sort Order")]
	public void UpdateSortOrder () {
		light.orderInLayer = (int)(-transform.position.y * orderMultiplier + orderOffset);
	}
}
}