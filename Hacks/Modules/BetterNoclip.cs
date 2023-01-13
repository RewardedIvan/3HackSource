using System;

namespace Modules
{
	// Token: 0x0200004C RID: 76
	[Serializable]
	internal class BetterNoclip : ModuleSetting
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x0000C39E File Offset: 0x0000A59E
		public BetterNoclip(Module p)
		{
			this.name = "Better";
			this.description = "Disables Spike Hitboxes and allows you to finish";
			this.enabled = true;
			this.pA = p;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000C3CC File Offset: 0x0000A5CC
		public override void Update()
		{
			this.boolValue = this.enabled;
			BetterNoclip.isEnabled = this.enabled;
		}

		// Token: 0x04000076 RID: 118
		public Module pA;

		// Token: 0x04000077 RID: 119
		public static bool isEnabled;
	}
}
