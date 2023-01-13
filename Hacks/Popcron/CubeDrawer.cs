using System;
using UnityEngine;

namespace Popcron
{
	// Token: 0x02000026 RID: 38
	public class CubeDrawer : Drawer
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00006860 File Offset: 0x00004A60
		public override int Draw(ref Vector3[] buffer, params object[] values)
		{
            Vector3 vector = (Vector3)values[0];
            Quaternion quaternion = (Quaternion)values[1];
            Vector3 vector2 = (Vector3)values[2];
            vector2 *= 0.5f;
            Vector3 vector3 = new Vector3(vector.x - vector2.x, vector.y - vector2.y, vector.z - vector2.z);
            Vector3 vector4 = new Vector3(vector.x + vector2.x, vector.y - vector2.y, vector.z - vector2.z);
            Vector3 vector5 = new Vector3(vector.x + vector2.x, vector.y + vector2.y, vector.z - vector2.z);
            Vector3 vector6 = new Vector3(vector.x - vector2.x, vector.y + vector2.y, vector.z - vector2.z);
            Vector3 vector7 = new Vector3(vector.x - vector2.x, vector.y - vector2.y, vector.z + vector2.z);
            Vector3 vector8 = new Vector3(vector.x + vector2.x, vector.y - vector2.y, vector.z + vector2.z);
            Vector3 vector9 = new Vector3(vector.x + vector2.x, vector.y + vector2.y, vector.z + vector2.z);
            Vector3 vector10 = new Vector3(vector.x - vector2.x, vector.y + vector2.y, vector.z + vector2.z);
            vector3 = quaternion * (vector3 - vector);
			vector3 += vector;
			vector4 = quaternion * (vector4 - vector);
			vector4 += vector;
			vector5 = quaternion * (vector5 - vector);
			vector5 += vector;
			vector6 = quaternion * (vector6 - vector);
			vector6 += vector;
			vector7 = quaternion * (vector7 - vector);
			vector7 += vector;
			vector8 = quaternion * (vector8 - vector);
			vector8 += vector;
			vector9 = quaternion * (vector9 - vector);
			vector9 += vector;
			vector10 = quaternion * (vector10 - vector);
			vector10 += vector;
			buffer[0] = vector3;
			buffer[1] = vector4;
			buffer[2] = vector4;
			buffer[3] = vector5;
			buffer[4] = vector5;
			buffer[5] = vector6;
			buffer[6] = vector6;
			buffer[7] = vector3;
			buffer[8] = vector7;
			buffer[9] = vector8;
			buffer[10] = vector8;
			buffer[11] = vector9;
			buffer[12] = vector9;
			buffer[13] = vector10;
			buffer[14] = vector10;
			buffer[15] = vector7;
			buffer[16] = vector3;
			buffer[17] = vector7;
			buffer[18] = vector4;
			buffer[19] = vector8;
			buffer[20] = vector5;
			buffer[21] = vector9;
			buffer[22] = vector6;
			buffer[23] = vector10;
			return 24;
		}
	}
}
