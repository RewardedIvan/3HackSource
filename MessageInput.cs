using System;
using ModuleType;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class MessageInput : TextInput
{
	// Token: 0x06000055 RID: 85 RVA: 0x000052FE File Offset: 0x000034FE
	public MessageInput()
	{
		this.text = PlayerPrefs.GetString("MessageText", "Type a message here");
	}

	// Token: 0x06000056 RID: 86 RVA: 0x0000531D File Offset: 0x0000351D
	public override void Update()
	{
		PlayerPrefs.SetString("MessageText", this.text);
	}
}
