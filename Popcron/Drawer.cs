// FOSS https://github.com/popcron/gizmos

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Popcron
{
	// Token: 0x02000025 RID: 37
	public abstract class Drawer
	{
		// Token: 0x0600006D RID: 109
		public abstract int Draw(ref Vector3[] buffer, params object[] args);

		// Token: 0x0600006E RID: 110 RVA: 0x000066A2 File Offset: 0x000048A2
		public Drawer()
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000066AC File Offset: 0x000048AC
		public static Drawer Get<T>() where T : class
		{
			bool flag = Drawer.typeToDrawer == null;
			if (flag)
			{
				Drawer.typeToDrawer = new Dictionary<Type, Drawer>();
				Drawer.typeToDrawer.Add(typeof(CubeDrawer), new CubeDrawer());
				Drawer.typeToDrawer.Add(typeof(LineDrawer), new LineDrawer());
				Drawer.typeToDrawer.Add(typeof(PolygonDrawer), new PolygonDrawer());
				Drawer.typeToDrawer.Add(typeof(SquareDrawer), new SquareDrawer());
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						bool isAbstract = type.IsAbstract;
						if (!isAbstract)
						{
							bool flag2 = type.IsSubclassOf(typeof(Drawer)) && !Drawer.typeToDrawer.ContainsKey(type);
							if (flag2)
							{
								try
								{
									Drawer drawer = (Drawer)Activator.CreateInstance(type);
									Drawer.typeToDrawer[type] = drawer;
								}
								catch (Exception ex)
								{
									Debug.LogError(string.Format("couldnt register drawer of type {0} because {1}", type, ex.Message));
								}
							}
						}
					}
				}
			}
			Drawer drawer2;
			bool flag3 = Drawer.typeToDrawer.TryGetValue(typeof(T), out drawer2);
			Drawer drawer3;
			if (flag3)
			{
				drawer3 = drawer2;
			}
			else
			{
				drawer3 = null;
			}
			return drawer3;
		}

		// Token: 0x0400003C RID: 60
		private static Dictionary<Type, Drawer> typeToDrawer;
	}
}
