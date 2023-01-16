﻿using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ModuleType
{
	// Token: 0x02000033 RID: 51
	public class TextInput : Module
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x0000A42C File Offset: 0x0000862C
		public override void Draw(Rect rect, Window wnd)
		{
            Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
            GUI.skin.label.alignment = (TextAnchor)3;
			GUI.skin.textField.alignment = (TextAnchor)3;
			GUI.skin.label.fontSize = Mathf.RoundToInt(23f * ModMain.scale);
			GUI.skin.textField.fontSize = Mathf.RoundToInt(21f * ModMain.scale);
			DrawUtils.DrawRect(rect, new Color(0.14117648f, 0.14117648f, 0.14117648f));
			DrawUtils.DrawRect(base.AddRect(rect, new Rect(4f, 4f, -8f, -8f)), new Color(0.11764706f, 0.11764706f, 0.11764706f));
			this.text = DrawUtils.DrawTextField(base.AddRect(rect, new Rect(4f, 4f, -8f, -8f)), this.text, Color.white);
			if (this.numberOnly)
			{
				this.text = Regex.Replace(this.text, "[^0-9 .]", "");
			}
			GUI.skin.label.alignment = (TextAnchor)4;
			try
			{
				if (vector.x > rect.x && vector.y > rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
				{
					DrawUtils.DrawDescription(this.description, this.GetHashCode());
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000067 RID: 103
		public string text;

		// Token: 0x04000068 RID: 104
		public string placeHolder;

		// Token: 0x04000069 RID: 105
		public bool numberOnly;

		// Token: 0x0400006A RID: 106
		public Color colour;
	}
}
