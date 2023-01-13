﻿using System;
using Modules;
using ModuleType;
using UnityEngine;

namespace Windows
{
	// Token: 0x0200001E RID: 30
	public class GUI : Window
	{
		// Token: 0x06000060 RID: 96 RVA: 0x000059EC File Offset: 0x00003BEC
		public class SearchInput : TextInput
        {
            public SearchInput()
            {
				// TODO this
                this.text = PlayerPrefs.GetString("SearchValue", "");
                this.description = "Search for something...";
            }

            // Token: 0x06000012 RID: 18 RVA: 0x00002575 File Offset: 0x00000775
            public override void Update()
            {
                PlayerPrefs.SetString("SearchValue", this.text);
            }
        }

		public GUI()
		{
			this.rect.position = new Vector2(370f, 20f);
			this.name = "GUI";
			this.render = true;
			this.modules.Add(new DebugModule());
			this.modules.Add(new WorldModule());
			this.modules.Add(new PlayerModule());
			this.modules.Add(new ClientModule());
			this.modules.Add(new SpeedhackModule());
			this.modules.Add(new OptionsModule());
			this.modules.Add(new StatusModule());
			this.modules.Add(new CreatorModule());
			this.modules.Add(new DisplayModule());
			this.modules.Add(new ReplayModule());

            this.modules.Add(new SearchInput());
        }
	}
}
