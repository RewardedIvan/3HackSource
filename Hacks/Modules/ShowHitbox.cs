using System;
using System.Collections.Generic;
using Popcron;
using UnityEngine;

namespace Modules
{
	// Token: 0x0200004E RID: 78
	[Serializable]
	internal class ShowHitbox : Module
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x0000C4B9 File Offset: 0x0000A6B9
		public ShowHitbox()
		{
			this.name = "Show Hitbox";
			this.description = "Shows the hitboxes";
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000C4E4 File Offset: 0x0000A6E4
		public override void Update()
		{
			bool flag = ShowHitbox.camera == null;
			if (flag)
			{
				ShowHitbox.camera = new GameObject("sus Camera").AddComponent<Camera>().gameObject;
				ShowHitbox.camera.GetComponent<Camera>().tag = "MainCamera";
				ShowHitbox.camera.GetComponent<Camera>().depth = 1f;
				ShowHitbox.camera.GetComponent<Camera>().cullingMask = -1;
				UnityEngine.Object.DontDestroyOnLoad(ShowHitbox.camera);
			}
			foreach (Camera camera in UnityEngine.Object.FindObjectsOfType<Camera>())
			{
				ShowHitbox.camera.transform.position = camera.transform.position;
				ShowHitbox.camera.transform.rotation = camera.transform.rotation;
				ShowHitbox.camera.GetComponent<Camera>().fieldOfView = camera.fieldOfView;
			}
			bool enabled = this.enabled;
			if (enabled)
			{
				foreach (Collider collider in UnityEngine.Object.FindObjectsOfType<Collider>())
				{
					Popcron.Gizmos.Enabled = true;
					bool flag2 = collider.gameObject.tag == "Hazard";
					if (flag2)
					{
						Popcron.Gizmos.Cube(collider.transform.position, collider.transform.rotation, new Vector3(0.15f, 0.15f, 0.3f), new Color?(Color.red), false);
					}
					else
					{
						Popcron.Gizmos.Cube(collider.transform.position, collider.transform.rotation, new Vector3(collider.bounds.size.x * collider.transform.localScale.x, collider.bounds.size.y * collider.transform.localScale.y, collider.bounds.size.z * collider.transform.localScale.z), new Color?(Color.red), false);
					}
				}
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000C710 File Offset: 0x0000A910
		public Vector3[] GetColliderVertexPositions(GameObject _object)
		{
			Vector3[] array = new Vector3[8];
			Matrix4x4 localToWorldMatrix = _object.transform.localToWorldMatrix;
			Quaternion rotation = _object.transform.rotation;
			_object.transform.rotation = Quaternion.identity;
			Vector3 extents = _object.GetComponent<Collider>().bounds.extents;
			array[0] = localToWorldMatrix.MultiplyPoint3x4(extents);
			array[1] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, extents.z));
			array[2] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(extents.x, extents.y, -extents.z));
			array[3] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, -extents.z));
			array[4] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, extents.z));
			array[5] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(-extents.x, -extents.y, extents.z));
			array[6] = localToWorldMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, -extents.z));
			array[7] = localToWorldMatrix.MultiplyPoint3x4(-extents);
			_object.transform.rotation = rotation;
			return array;
		}

		// Token: 0x04000079 RID: 121
		public int a = 11;

		// Token: 0x0400007A RID: 122
		public static GameObject camera;

		// Token: 0x0400007B RID: 123
	}
}
