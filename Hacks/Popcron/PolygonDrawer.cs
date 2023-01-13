using System;
using UnityEngine;

namespace Popcron
{
	// Token: 0x02000028 RID: 40
	public class PolygonDrawer : Drawer
	{
		// Token: 0x06000075 RID: 117 RVA: 0x00006C20 File Offset: 0x00004E20
		public override int Draw(ref Vector3[] buffer, params object[] values)
		{
			Vector3 vector = (Vector3)values[0];
			int num = (int)values[1];
			float num2 = (float)values[2];
			float num3 = (float)values[3];
			Quaternion quaternion = (Quaternion)values[4];
			float num4 = 360f / (float)num;
			num3 *= 0.017453292f;
			for (int i = 0; i < num; i++)
			{
				float num5 = Mathf.Cos(0.017453292f * num4 * (float)i + num3) * num2;
				float num6 = Mathf.Sin(0.017453292f * num4 * (float)i + num3) * num2;
                Vector3 vector2 = new Vector3(num5, num6);
                float num7 = Mathf.Cos(0.017453292f * num4 * (float)(i + 1) + num3) * num2;
				float num8 = Mathf.Sin(0.017453292f * num4 * (float)(i + 1) + num3) * num2;
                Vector3 vector3 = new Vector3(num7, num8);
                buffer[i * 2] = vector + quaternion * vector2;
				buffer[i * 2 + 1] = vector + quaternion * vector3;
			}
			return num * 2;
		}
	}
}
