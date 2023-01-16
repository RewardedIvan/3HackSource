using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000003 RID: 3
[Serializable]
public class SceneTile
{
	// Token: 0x06000005 RID: 5 RVA: 0x00002110 File Offset: 0x00000310
	public SceneTile()
	{
		this.positions.Add(new Vector2(364f, 192f));
		this.positions.Add(new Vector2(768f, 192f));
		this.positions.Add(new Vector2(1172f, 192f));
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002184 File Offset: 0x00000384
	public void Draw(Vector2 selectedSpot)
	{
        Rect rect = new Rect(0f, 0f, 384f, (float)(Screen.height - 384));
        rect.position = this.positions[(int)this.spot.x];
		if (this.spot == selectedSpot)
		{
			DrawUtils.DrawOutlinedRect(rect, DrawUtils.Accent(), 7f);
		}
		else
		{
			DrawUtils.DrawOutlinedRect(rect, Color.white, 4f);
		}
	}

	// Token: 0x04000002 RID: 2
	public string SceneName;

	// Token: 0x04000003 RID: 3
	public Vector2 spot;

	// Token: 0x04000004 RID: 4
	public List<Vector2> positions = new List<Vector2>();
}
