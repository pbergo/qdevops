﻿using System;
using System.IO;
using qdevopsbase.server;
using Qlik.Engine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class mylist : iqlikcommand
{
	public qlikcommandparameters Params
	{
		get
		{
			return new qlikcommandparameters()
			{
				FullHelp = "TEST = List all Qlik Apps",
				Parameters = new Dictionary<string, string>()
			};
		}
	}
	public string CommandId => "mylist";
	public bool WillExecute { get; set; }
	public TextWriter output { get; set; }
	public string Content { get; set; }
	public int Priority { get; set; } = 10;

	public void Execute(JObject args, qlikcommandconfig conf)
	{
		IEnumerable<IAppIdentifier> apps_info = conf.loc.GetAppIdentifiers();
		foreach (var item in apps_info)
		{
			output.WriteLine($"TEST - {item.AppId}");
		}
	}



}

