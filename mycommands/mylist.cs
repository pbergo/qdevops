using System;
using System.IO;
using qdevopsbase.server;
using Qlik.Engine;
using System.Collections.Generic;

public class mylist : iqlikcommand
{
	public string CommandId => "w|mylist";
	public string HelpTip => "TEST - List all Apps from current Qlik server";
	public TextWriter output { get; set; }
	public void Execute(string command, ref ILocation loc)
	{
		IEnumerable<IAppIdentifier> apps_info = loc.GetAppIdentifiers();
		foreach (var item in apps_info)
		{
			output.WriteLine($"TEST - {item.AppId}");
		}
	}
}

