using System;
using System.IO;
using qdevopsbase.server;
using Qlik.Engine;
using System.Collections.Generic;

public class mylistapp : iqlikcommand
{
	public string CommandId => "w|mylist";
	public string HelpTip => "TEST - List all Apps from current Qlik server";
	public TextWriter output { get; set; }
	public void Execute(string command, ref IHub hub)
	{
		IEnumerable<IAppIdentifier> apps_info = hub.GetAppList();
		foreach (var item in apps_info)
		{
			output.WriteLine($"TEST - {item.AppId}");
		}
	}
}

