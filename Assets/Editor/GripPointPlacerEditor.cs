using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (GripPointPlacer))]
public class GripPointPlacerEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		//元のInspector部分を表示
		base.OnInspectorGUI ();

		GripPointPlacer gripPointPlacer = target as GripPointPlacer;
		//ボタンを表示
		if (GUILayout.Button ("Copy Curve1"))
		{
			gripPointPlacer.CopyCurve1 ();
		}
		if (GUILayout.Button ("Copy Curve2"))
		{
			gripPointPlacer.CopyCurve2 ();
		}
		if (GUILayout.Button ("Place GripPoints"))
		{
			gripPointPlacer.PointPlace ();
		}
		if (GUILayout.Button ("Delete GripPoints"))
		{
			gripPointPlacer.DeleteGripPoints ();
		}
	}
}