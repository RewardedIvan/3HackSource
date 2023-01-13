using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules
{
	// Token: 0x02000038 RID: 56
	public class SceneSwitcher : Module
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000AA30 File Offset: 0x00008C30
		public SceneSwitcher()
		{
			this.name = "Scene Switcher";
			this.description = "Switch Scenes by holding " + this.keybind.ToString();
			this.keybind = (KeyCode)13;
			this.enabled = false;
			this.tiles.Add(new SceneTile());
			SceneTile sceneTile = new SceneTile();
			sceneTile.spot = Vector2.right;
			this.tiles.Add(sceneTile);
			SceneTile sceneTile2 = new SceneTile();
			sceneTile2.spot = Vector2.right * 2f;
			this.tiles.Add(sceneTile);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000AAE2 File Offset: 0x00008CE2
		public override void Update()
		{
			this.description = "Switch Scenes by holding " + this.keybind.ToString();
			this.SceneSwitcherOpen = Input.GetKey(this.keybind);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000AB18 File Offset: 0x00008D18
		public override void OnDraw()
		{
		}

		// Token: 0x0400006D RID: 109
		public bool SceneSwitcherOpen;

		// Token: 0x0400006E RID: 110
		public Vector2 selectedSpot;

		// Token: 0x0400006F RID: 111
		public List<SceneTile> tiles = new List<SceneTile>();
	}
}
