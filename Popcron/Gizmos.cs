using System;
using UnityEngine;

namespace Popcron
{
	// Token: 0x0200002B RID: 43
	public class Gizmos
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00006FF4 File Offset: 0x000051F4
		private static string PrefsKey
		{
			get
			{
				bool flag = string.IsNullOrEmpty(Gizmos._prefsKey);
				if (flag)
				{
					Gizmos._prefsKey = string.Concat(new string[]
					{
						SystemInfo.deviceUniqueIdentifier,
						".",
						Application.companyName,
						".",
						Application.productName,
						".Popcron.Gizmos"
					});
				}
				return Gizmos._prefsKey;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000705C File Offset: 0x0000525C
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000070B0 File Offset: 0x000052B0
		public static int BufferSize
		{
			get
			{
				bool flag = Gizmos._bufferSize == null;
				if (flag)
				{
					Gizmos._bufferSize = new int?(PlayerPrefs.GetInt(Gizmos.PrefsKey + ".BufferSize", 4096));
				}
				return Gizmos._bufferSize.Value;
			}
			set
			{
				value = Mathf.Clamp(value, 0, int.MaxValue);
				int? bufferSize = Gizmos._bufferSize;
				int num = value;
				bool flag = !((bufferSize.GetValueOrDefault() == num) & (bufferSize != null));
				if (flag)
				{
					Gizmos._bufferSize = new int?(value);
					PlayerPrefs.SetInt(Gizmos.PrefsKey + ".BufferSize", value);
					Gizmos.buffer = new Vector3[value];
				}
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000711C File Offset: 0x0000531C
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00007170 File Offset: 0x00005370
		public static bool Enabled
		{
			get
			{
				bool flag = Gizmos._enabled == null;
				if (flag)
				{
					Gizmos._enabled = new bool?(PlayerPrefs.GetInt(Gizmos.PrefsKey + ".Enabled", 1) == 1);
				}
				return Gizmos._enabled.Value;
			}
			set
			{
				bool? enabled = Gizmos._enabled;
				bool flag = !((enabled.GetValueOrDefault() == value) & (enabled != null));
				if (flag)
				{
					Gizmos._enabled = new bool?(value);
					PlayerPrefs.SetInt(Gizmos.PrefsKey + ".Enabled", value ? 1 : 0);
				}
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000071C8 File Offset: 0x000053C8
		// (set) Token: 0x0600007F RID: 127 RVA: 0x0000721C File Offset: 0x0000541C
		public static float DashGap
		{
			get
			{
				bool flag = Gizmos._dashGap == null;
				if (flag)
				{
					Gizmos._dashGap = new float?(PlayerPrefs.GetFloat(Gizmos.PrefsKey + ".DashGap", 0.1f));
				}
				return Gizmos._dashGap.Value;
			}
			set
			{
				float? dashGap = Gizmos._dashGap;
				bool flag = !((dashGap.GetValueOrDefault() == value) & (dashGap != null));
				if (flag)
				{
					Gizmos._dashGap = new float?(value);
					PlayerPrefs.SetFloat(Gizmos.PrefsKey + ".DashGap", value);
				}
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00007270 File Offset: 0x00005470
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00007287 File Offset: 0x00005487
		[Obsolete("This property is obsolete. Use FrustumCulling instead.", false)]
		public static bool Cull
		{
			get
			{
				return Gizmos.FrustumCulling;
			}
			set
			{
				Gizmos.FrustumCulling = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00007291 File Offset: 0x00005491
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00007294 File Offset: 0x00005494
		[Obsolete("This property is obsolete. Subscribe to CameraFilter predicate instead and return true for your custom camera.", false)]
		public static Camera Camera
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00007298 File Offset: 0x00005498
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000072EC File Offset: 0x000054EC
		public static bool FrustumCulling
		{
			get
			{
				bool flag = Gizmos._cull == null;
				if (flag)
				{
					Gizmos._cull = new bool?(PlayerPrefs.GetInt(Gizmos.PrefsKey + ".FrustumCulling", 1) == 1);
				}
				return Gizmos._cull.Value;
			}
			set
			{
				bool? cull = Gizmos._cull;
				bool flag = !((cull.GetValueOrDefault() == value) & (cull != null));
				if (flag)
				{
					Gizmos._cull = new bool?(value);
					PlayerPrefs.SetInt(Gizmos.PrefsKey + ".FrustumCulling", value ? 1 : 0);
				}
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00007344 File Offset: 0x00005544
		// (set) Token: 0x06000087 RID: 135 RVA: 0x0000734B File Offset: 0x0000554B
		public static Material Material
		{
			get
			{
				return GizmosInstance.Material;
			}
			set
			{
				GizmosInstance.Material = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00007354 File Offset: 0x00005554
		// (set) Token: 0x06000089 RID: 137 RVA: 0x000073A4 File Offset: 0x000055A4
		public static int Pass
		{
			get
			{
				bool flag = Gizmos._pass == null;
				if (flag)
				{
					Gizmos._pass = new int?(PlayerPrefs.GetInt(Gizmos.PrefsKey + ".Pass", 0));
				}
				return Gizmos._pass.Value;
			}
			set
			{
				int? pass = Gizmos._pass;
				bool flag = !((pass.GetValueOrDefault() == value) & (pass != null));
				if (flag)
				{
					Gizmos._pass = new int?(value);
					PlayerPrefs.SetInt(Gizmos.PrefsKey + ".Pass", value);
				}
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000073F8 File Offset: 0x000055F8
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000074FC File Offset: 0x000056FC
		public static Vector3 Offset
		{
			get
			{
				bool flag = Gizmos._offset == null;
				if (flag)
				{
					string @string = PlayerPrefs.GetString(Gizmos.PrefsKey + ".Offset", string.Concat(new string[]
					{
						0.ToString(),
						",",
						0.ToString(),
						",",
						0.ToString()
					}));
					int num = @string.IndexOf(",");
					int num2 = @string.LastIndexOf(",");
					bool flag2 = num + num2 > 0;
					if (!flag2)
					{
						return Vector3.zero;
					}
					string[] array = @string.Split(new char[] { ","[0] });
					Gizmos._offset = new Vector3?(new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2])));
				}
				return Gizmos._offset.Value;
			}
			set
			{
				Vector3? offset = Gizmos._offset;
				Vector3 vector = value;
				bool flag = offset == null || (offset != null && offset.GetValueOrDefault() != vector);
				if (flag)
				{
					Gizmos._offset = new Vector3?(value);
					PlayerPrefs.SetString(Gizmos.PrefsKey + ".Offset", string.Concat(new string[]
					{
						value.x.ToString(),
						",",
						value.y.ToString(),
						",",
						value.y.ToString()
					}));
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000075A8 File Offset: 0x000057A8
		public static void Draw<T>(Color? color, bool dashed, params object[] args) where T : Drawer
		{
			bool flag = !Gizmos.Enabled;
			if (!flag)
			{
				Drawer drawer = Drawer.Get<T>();
				bool flag2 = drawer != null;
				if (flag2)
				{
					int num = drawer.Draw(ref Gizmos.buffer, args);
					Vector3[] array = new Vector3[num];
					Array.Copy(Gizmos.buffer, array, num);
					GizmosInstance.Submit(array, color, dashed);
				}
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007604 File Offset: 0x00005804
		public static void Lines(Vector3[] lines, Color? color = null, bool dashed = false)
		{
			bool flag = !Gizmos.Enabled;
			if (!flag)
			{
				GizmosInstance.Submit(lines, color, dashed);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000762A File Offset: 0x0000582A
		public static void Line(Vector3 a, Vector3 b, Color? color = null, bool dashed = false)
		{
			Gizmos.Draw<LineDrawer>(color, dashed, new object[] { a, b });
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000764D File Offset: 0x0000584D
		public static void Square(Vector2 position, Vector2 size, Color? color = null, bool dashed = false)
		{
			Gizmos.Square(position, Quaternion.identity, size, color, dashed);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000765F File Offset: 0x0000585F
		public static void Square(Vector2 position, float diameter, Color? color = null, bool dashed = false)
		{
			Gizmos.Square(position, Quaternion.identity, Vector2.one * diameter, color, dashed);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000767B File Offset: 0x0000587B
		public static void Square(Vector2 position, Quaternion rotation, Vector2 size, Color? color = null, bool dashed = false)
		{
			Gizmos.Draw<SquareDrawer>(color, dashed, new object[] { position, rotation, size });
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000076A8 File Offset: 0x000058A8
		public static void Cube(Vector3 position, Quaternion rotation, Vector3 size, Color? color = null, bool dashed = false)
		{
			Gizmos.Draw<CubeDrawer>(color, dashed, new object[] { position, rotation, size });
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000076D8 File Offset: 0x000058D8
		public static void Rect(Rect rect, Camera camera, Color? color = null, bool dashed = false)
		{
			rect.y = (float)Screen.height - rect.y;
			Vector2 vector = camera.ScreenToWorldPoint(new Vector2(rect.x, rect.y - rect.height));
			Gizmos.Draw<SquareDrawer>(color, dashed, new object[]
			{
				vector + rect.size * 0.5f,
				Quaternion.identity,
				rect.size
			});
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00007771 File Offset: 0x00005971
		public static void Bounds(Bounds bounds, Color? color = null, bool dashed = false)
		{
			Gizmos.Draw<CubeDrawer>(color, dashed, new object[]
			{
				bounds.center,
				Quaternion.identity,
				bounds.size
			});
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000077B0 File Offset: 0x000059B0
		public static void Cone(Vector3 position, Quaternion rotation, float length, float angle, Color? color = null, bool dashed = false, int pointsCount = 16)
		{
			float num = Mathf.Tan(angle * 0.5f * 0.017453292f) * length;
			Vector3 vector = rotation * Vector3.forward;
			Vector3 vector2 = position + vector * length;
			float num2 = 0f;
			Gizmos.Draw<PolygonDrawer>(color, dashed, new object[] { vector2, pointsCount, num, num2, rotation });
			for (int i = 0; i < 4; i++)
			{
				float num3 = (float)i * 90f * 0.017453292f;
				Vector3 vector3 = rotation * new Vector3(Mathf.Cos(num3), Mathf.Sin(num3)) * num;
				Gizmos.Line(position, position + vector3 + vector * length, color, dashed);
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000789C File Offset: 0x00005A9C
		public static void Sphere(Vector3 position, float radius, Color? color = null, bool dashed = false, int pointsCount = 16)
		{
			float num = 0f;
			Gizmos.Draw<PolygonDrawer>(color, dashed, new object[]
			{
				position,
				pointsCount,
				radius,
				num,
				Quaternion.Euler(0f, 0f, 0f)
			});
			Gizmos.Draw<PolygonDrawer>(color, dashed, new object[]
			{
				position,
				pointsCount,
				radius,
				num,
				Quaternion.Euler(90f, 0f, 0f)
			});
			Gizmos.Draw<PolygonDrawer>(color, dashed, new object[]
			{
				position,
				pointsCount,
				radius,
				num,
				Quaternion.Euler(0f, 90f, 90f)
			});
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000079A0 File Offset: 0x00005BA0
		public static void Circle(Vector3 position, float radius, Camera camera, Color? color = null, bool dashed = false, int pointsCount = 16)
		{
			float num = 0f;
			Quaternion quaternion = Quaternion.LookRotation(position - camera.transform.position);
			Gizmos.Draw<PolygonDrawer>(color, dashed, new object[] { position, pointsCount, radius, num, quaternion });
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00007A08 File Offset: 0x00005C08
		public static void Circle(Vector3 position, float radius, Quaternion rotation, Color? color = null, bool dashed = false, int pointsCount = 16)
		{
			float num = 0f;
			Gizmos.Draw<PolygonDrawer>(color, dashed, new object[] { position, pointsCount, radius, num, rotation });
		}

		// Token: 0x04000040 RID: 64
		private static string _prefsKey = null;

		// Token: 0x04000041 RID: 65
		private static int? _bufferSize = null;

		// Token: 0x04000042 RID: 66
		private static bool? _enabled = null;

		// Token: 0x04000043 RID: 67
		private static float? _dashGap = null;

		// Token: 0x04000044 RID: 68
		private static bool? _cull = null;

		// Token: 0x04000045 RID: 69
		private static int? _pass = null;

		// Token: 0x04000046 RID: 70
		private static Vector3? _offset = null;

		// Token: 0x04000047 RID: 71
		private static Vector3[] buffer = new Vector3[Gizmos.BufferSize];

		// Token: 0x04000048 RID: 72
		public static Func<Camera, bool> CameraFilter = (Camera cam) => false;
	}
}
