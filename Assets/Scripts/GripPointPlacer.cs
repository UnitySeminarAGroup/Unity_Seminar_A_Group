using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GripPointPlacer : MonoBehaviour
{
	[SerializeField] int resolution = 30;
	[SerializeField] GameObject GripPointObj, GripObjParent;
	[SerializeField] BezierCurve curve1, curve2;
	[SerializeField] Color color1 = Color.white, color2 = Color.white;
	[SerializeField] float HorizontalRate, VerticalRate;
	[SerializeField, Range (0.001f, 1)] float ProductionRate = 0.001f, PlaceRate = 0.001f;
	void OnDrawGizmos ()
	{
		CurveProp ();
	}
	void CurveProp ()
	{
		if (curve1 && curve2)
		{
			curve1.resolution = resolution;
			curve2.resolution = resolution;
			curve1.drawColor = color1;
			curve2.drawColor = color2;
		}
	}
	public void CopyCurve1 ()
	{
		Vector3 localPos = curve2.transform.localPosition;
		DestroyImmediate (curve2.gameObject);
		GameObject obj = Instantiate (curve1.gameObject);
		obj.transform.parent = transform;
		obj.transform.localPosition = localPos;
		curve2 = obj.GetComponent<BezierCurve> ();
	}
	public void CopyCurve2 ()
	{
		Vector3 localPos = curve1.transform.localPosition;
		DestroyImmediate (curve1.gameObject);
		GameObject obj = Instantiate (curve2.gameObject);
		obj.transform.parent = transform;
		obj.transform.localPosition = localPos;
		curve1 = obj.GetComponent<BezierCurve> ();
	}
	public void PointPlace ()
	{
		if (GripObjParent == null)
		{
			GripObjParent = new GameObject ();
		}
		int n = 0;
		List<Transform> TraList = new List<Transform> ();
		List<float> distances = new List<float> ();
		for (float r = 0; r + PlaceRate < 1; r = r + PlaceRate)
		{
			Vector3 point1 = curve1.GetPointAt (r);
			Vector3 point2 = curve2.GetPointAt (r);
			Vector3 center = (point1 + point2) / 2;
			Vector3 normarizePoint1 = (point1 - center).normalized;
			Vector3 normarizePoint2 = (point2 - center).normalized;
			Vector3 next_point1 = curve1.GetPointAt (r + PlaceRate);
			Vector3 next_point2 = curve2.GetPointAt (r + PlaceRate);
			Vector3 normarizeDir1 = (next_point1 - point1).normalized;
			Vector3 normarizeDir2 = (next_point2 - point2).normalized;
			if (Random.value < ProductionRate)
			{
				GameObject obj = Instantiate (GripPointObj,
					center + normarizePoint1 * HorizontalRate * (Random.value - 0.5f) + normarizeDir1 * VerticalRate * (Random.value - 0.5f),
					Quaternion.Euler (Random.value * 360, Random.value * 360, Random.value * 360));
				obj.transform.parent = GripObjParent.transform;
				TraList.Add (obj.transform);
				n++;
			}
			if (Random.value < ProductionRate)
			{
				GameObject obj = Instantiate (GripPointObj,
					center + normarizePoint2 * HorizontalRate * (Random.value - 0.5f) + normarizeDir2 * VerticalRate * (Random.value - 0.5f),
					Quaternion.Euler (Random.value * 360, Random.value * 360, Random.value * 360));
				obj.transform.parent = GripObjParent.transform;
				TraList.Add (obj.transform);
				n++;
			}
		}
		for (int i = 0; i < TraList.Count; i++)
		{
			distances.Add (10f);
		}
		for (int i = 0; i < TraList.Count; i++)
		{
			for (int j = 0; j < TraList.Count; j++)
			{
				if (i != j)
				{
					float Distance = Vector3.Distance (TraList[i].position, TraList[j].position);
					if (Distance < distances[i])
					{
						distances[i] = Distance;
					}
				}
			}
		}
		Debug.Log (n + " GripPoints Set.");
		Debug.Log ("Max distance : " + distances.Max ());
		Debug.Log ("Average distance : " + distances.Average ());
		Debug.Log ("Min distance : " + distances.Min ());
	}
	public void DeleteGripPoints ()
	{
		if (GripObjParent != null)
		{
			DestroyImmediate (GripObjParent);
		}
	}
}