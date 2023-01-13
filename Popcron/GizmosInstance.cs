using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Popcron
{
	// Token: 0x0200002C RID: 44
	[ExecuteInEditMode]
	[AddComponentMenu("")]
	public class GizmosInstance : MonoBehaviour
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00007AE0 File Offset: 0x00005CE0
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00007B18 File Offset: 0x00005D18
		public static Material Material
		{
			get
			{
				GizmosInstance orCreate = GizmosInstance.GetOrCreate();
				bool flag = orCreate.overrideMaterial;
				Material material;
				if (flag)
				{
					material = orCreate.overrideMaterial;
				}
				else
				{
					material = GizmosInstance.DefaultMaterial;
				}
				return material;
			}
			set
			{
				GizmosInstance orCreate = GizmosInstance.GetOrCreate();
				orCreate.overrideMaterial = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00007B34 File Offset: 0x00005D34
		public static Material DefaultMaterial
		{
			get
			{
				bool flag = !GizmosInstance.defaultMaterial;
				if (flag)
				{
					Shader shader = Shader.Find("Hidden/Internal-Colored");
					GizmosInstance.defaultMaterial = new Material(shader)
					{
						hideFlags = (HideFlags)61
					};
					GizmosInstance.defaultMaterial.SetInt("_SrcBlend", 5);
					GizmosInstance.defaultMaterial.SetInt("_DstBlend", 10);
					GizmosInstance.defaultMaterial.SetInt("_Cull", 0);
					GizmosInstance.defaultMaterial.SetInt("_ZWrite", 0);
				}
				return GizmosInstance.defaultMaterial;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00007BC4 File Offset: 0x00005DC4
		internal static GizmosInstance GetOrCreate()
		{
			bool flag = GizmosInstance.hotReloaded || !GizmosInstance.instance;
			if (flag)
			{
				GizmosInstance[] array = UnityEngine.Object.FindObjectsOfType<GizmosInstance>();
				for (int i = 0; i < array.Length; i++)
				{
					GizmosInstance.instance = array[i];
					bool flag2 = i > 0;
					if (flag2)
					{
						bool isPlaying = Application.isPlaying;
						if (isPlaying)
						{
							UnityEngine.Object.Destroy(array[i]);
						}
						else
						{
							UnityEngine.Object.DestroyImmediate(array[i]);
						}
					}
				}
				bool flag3 = !GizmosInstance.instance;
				if (flag3)
				{
					GizmosInstance.instance = new GameObject(typeof(GizmosInstance).FullName).AddComponent<GizmosInstance>();
					GizmosInstance.instance.gameObject.hideFlags = (HideFlags)3;
				}
				GizmosInstance.hotReloaded = false;
			}
			return GizmosInstance.instance;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00007CA0 File Offset: 0x00005EA0
		private float CurrentTime
		{
			get
			{
				float num = 0f;
				bool isPlaying = Application.isPlaying;
				if (isPlaying)
				{
					num = Time.time;
				}
				return num;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00007CD0 File Offset: 0x00005ED0
		internal static void Submit(Vector3[] points, Color? color, bool dashed)
		{
			GizmosInstance orCreate = GizmosInstance.GetOrCreate();
			bool flag = orCreate.lastFrame != Time.frameCount;
			if (flag)
			{
				orCreate.lastFrame = Time.frameCount;
				orCreate.queueIndex = 0;
			}
			bool flag2 = orCreate.queueIndex >= orCreate.queue.Length;
			if (flag2)
			{
				Element[] array = new Element[orCreate.queue.Length + 4096];
				for (int i = orCreate.queue.Length; i < array.Length; i++)
				{
					array[i] = new Element();
				}
				Array.Copy(orCreate.queue, 0, array, 0, orCreate.queue.Length);
				orCreate.queue = array;
			}
			orCreate.queue[orCreate.queueIndex].color = color ?? Color.white;
			orCreate.queue[orCreate.queueIndex].points = points;
			orCreate.queue[orCreate.queueIndex].dashed = dashed;
			orCreate.queueIndex++;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00007DE4 File Offset: 0x00005FE4
		private void OnEnable()
		{
			this.queue = new Element[4096];
			for (int i = 0; i < 4096; i++)
			{
				this.queue[i] = new Element();
			}
			bool flag = GraphicsSettings.renderPipelineAsset == null;
			if (flag)
			{
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(this.OnRendered));
			}
			else
			{
				RenderPipelineManager.endCameraRendering += this.OnRendered;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00007E6C File Offset: 0x0000606C
		private void OnDisable()
		{
			bool flag = GraphicsSettings.renderPipelineAsset == null;
			if (flag)
			{
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(this.OnRendered));
			}
			else
			{
				RenderPipelineManager.endCameraRendering -= this.OnRendered;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00007EC1 File Offset: 0x000060C1
		private void OnRendered(ScriptableRenderContext context, Camera camera)
		{
			this.OnRendered(camera);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00007ECC File Offset: 0x000060CC
		private bool ShouldRenderCamera(Camera camera)
		{
			bool flag = !camera;
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				bool flag3 = false || camera.CompareTag("MainCamera");
				if (flag3)
				{
					flag2 = true;
				}
				else
				{
					Func<Camera, bool> cameraFilter = Gizmos.CameraFilter;
					bool flag4 = cameraFilter != null && cameraFilter(camera);
					flag2 = flag4;
				}
			}
			return flag2;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00007F2C File Offset: 0x0000612C
		private bool IsVisibleByCamera(Element points, Camera camera)
		{
			bool flag = !camera;
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				for (int i = 0; i < points.points.Length; i++)
				{
					Vector3 vector = camera.WorldToViewportPoint(points.points[i], camera.stereoActiveEye);
					bool flag3 = vector.x >= 0f && vector.x <= 1f && vector.y >= 0f && vector.y <= 1f;
					if (flag3)
					{
						return true;
					}
				}
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007FCC File Offset: 0x000061CC
		private void Update()
		{
			Gizmos.Line(default(Vector3), default(Vector3), null, false);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00007FFC File Offset: 0x000061FC
		private void OnRendered(Camera camera)
		{
			GizmosInstance.Material.SetPass(Gizmos.Pass);
			bool flag = !Gizmos.Enabled;
			if (flag)
			{
				this.queueIndex = 0;
			}
			bool flag2 = !this.ShouldRenderCamera(camera);
			if (flag2)
			{
				GL.PushMatrix();
				GL.Begin(1);
				GL.End();
				GL.PopMatrix();
			}
			else
			{
				Vector3 offset = Gizmos.Offset;
				GL.PushMatrix();
				GL.MultMatrix(Matrix4x4.identity);
				GL.Begin(1);
				bool flag3 = this.CurrentTime % 1f > 0.5f;
				float num = Mathf.Clamp(Gizmos.DashGap, 0.01f, 32f);
				bool frustumCulling = Gizmos.FrustumCulling;
				List<Vector3> list = new List<Vector3>();
				int i = 0;
				while (i < this.queueIndex)
				{
					bool flag4 = this.queue.Length <= i;
					if (flag4)
					{
						break;
					}
					Element element = this.queue[i];
					bool flag5 = frustumCulling;
					if (!flag5)
					{
						goto IL_FB;
					}
					bool flag6 = !this.IsVisibleByCamera(element, camera);
					if (!flag6)
					{
						goto IL_FB;
					}
					IL_290:
					i++;
					continue;
					IL_FB:
					list.Clear();
					bool dashed = element.dashed;
					if (dashed)
					{
						for (int j = 0; j < element.points.Length - 1; j++)
						{
							Vector3 vector = element.points[j];
							Vector3 vector2 = element.points[j + 1];
							Vector3 vector3 = vector2 - vector;
							bool flag7 = vector3.sqrMagnitude > num * num * 2f;
							if (flag7)
							{
								float magnitude = vector3.magnitude;
								int num2 = Mathf.RoundToInt(magnitude / num);
								vector3 /= magnitude;
								for (int k = 0; k < num2 - 1; k++)
								{
									bool flag8 = k % 2 == (flag3 ? 1 : 0);
									if (flag8)
									{
										float num3 = (float)k / ((float)num2 - 1f);
										float num4 = (float)(k + 1) / ((float)num2 - 1f);
										Vector3 vector4 = Vector3.Lerp(vector, vector2, num3);
										Vector3 vector5 = Vector3.Lerp(vector, vector2, num4);
										list.Add(vector4);
										list.Add(vector5);
									}
								}
							}
							else
							{
								list.Add(vector);
								list.Add(vector2);
							}
						}
					}
					else
					{
						list.AddRange(element.points);
					}
					GL.Color(element.color);
					for (int l = 0; l < list.Count; l++)
					{
						GL.Vertex(list[l] + offset);
					}
					goto IL_290;
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		// Token: 0x04000049 RID: 73
		private const int DefaultQueueSize = 4096;

		// Token: 0x0400004A RID: 74
		private static GizmosInstance instance;

		// Token: 0x0400004B RID: 75
		private static bool hotReloaded = true;

		// Token: 0x0400004C RID: 76
		private static Material defaultMaterial;

		// Token: 0x0400004D RID: 77
		private static Plane[] cameraPlanes = new Plane[6];

		// Token: 0x0400004E RID: 78
		private Material overrideMaterial;

		// Token: 0x0400004F RID: 79
		private int queueIndex = 0;

		// Token: 0x04000050 RID: 80
		private int lastFrame;

		// Token: 0x04000051 RID: 81
		private Element[] queue = new Element[4096];
	}
}
