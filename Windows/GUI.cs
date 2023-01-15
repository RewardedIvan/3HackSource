using ModuleType;
using UnityEngine;

namespace Windows
{
	// Token: 0x0200001E RID: 30
	public class GUI : Window
	{
		// Token: 0x06000060 RID: 96 RVA: 0x000059EC File Offset: 0x00003BEC
		public class SearchI : TextInput
		{
			public SearchI()
			{
				this.text = PlayerPrefs.GetString("SearchValue", "");
				this.description = "Search in the menu";
			}

			// Token: 0x06000012 RID: 18 RVA: 0x00002575 File Offset: 0x00000775
			public override void Update()
			{
                PlayerPrefs.SetString("SearchValue", this.text);
            }
		}

		public class ScaleI : TextInput {
            public ScaleI()
            {
                this.text = ModMain.scale.ToString();
                this.description = "How big or small is the menu.";
				this.numberOnly = true;
            }

            public override void Update()
            {
				try
				{
                    ModMain.scale = float.Parse(this.text);
                } catch
				{
					// Dont care
				}
            }
        }
        public class WindowWidthI : TextInput
        {
            public WindowWidthI()
            {
                this.text = ModMain.windowwidth.ToString();
                this.description = "Width of the windows";
                this.numberOnly = true;
            }

            public override void Update()
            {
                try
                {
                    ModMain.windowwidth = float.Parse(this.text);
                }
                catch
                {
                    // Dont care
                }
            }
        }

        public class SpacingI : TextInput
        {
            public SpacingI()
            {
                this.text = ModMain.spacing.ToString();
                this.description = "Spacing of the modules";
                this.numberOnly = true;
            }

            public override void Update()
            {
                try
                {
                    ModMain.spacing = float.Parse(this.text);
                }
                catch
                {
                    // Dont care
                }
            }
        }

        public class AccentColor : DualSidedToggle
        {
            public AccentColor()
            {
                this.name = "Accent Color";
                this.name1 = "Chrome";
                this.name2 = "Color";
                this.description = "Should the accent color be chrome or a color of your choice";
            }

            public override void Update()
            {
                PlayerPrefs.SetString("ChromeAccent", (!this.rightOn).ToString());
            }
        }

        public GUI()
		{
			this.rect.position = new Vector2(370f, 20f);
			this.name = "GUI";
			
            this.modules.Add(new SearchI());
			this.modules.Add(new ScaleI());
			this.modules.Add(new WindowWidthI());
			this.modules.Add(new SpacingI());
			this.modules.Add(new AccentColor());
            // TODO Color wheel
        }
	}
}
