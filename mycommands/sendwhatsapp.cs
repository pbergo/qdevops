using qdevopsbase.server;
using Qlik.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

//namespace qdevopsbase.qlikcommands
//{
public class sendwhatsapp : iqlikcommand
	{
		public qlikcommandparameters Params
		{
			get
			{
				return new qlikcommandparameters()
				{
					FullHelp = "Send Whatsapp Text and Images.",
					Parameters = new Dictionary<string, string>()
					{
						{ "app_id", "App Id" },
						{ "obj_id", "App Object Id" },
						{ "message", "Mensagem" },
						{ "whatsappnumber", "WhatsApp number to send the text or images" }
					}
				};
			}
		}
		public string CommandId => "w=|sendwhatsapp=";
		public bool WillExecute { get; set; }
		public TextWriter output { get; set; }
		public string Content { get; set; }
		public int Priority { get; set; } = 10;

		public void Execute(JObject args, ref ILocation loc, qlikcommandconfig conf)
		{

			string appid = args["app_id"].ToString();
			string objid = args["obj_id"].ToString();
			string msg = args["message"].ToString();
			string num = args["whatsappnumber"].ToString();


			output.WriteLine(appid);
			output.WriteLine(objid);
			output.WriteLine(msg);
			output.WriteLine(num);


			//IApp qapp = qdevopsbase.server.appops.GetAppFromIdString(ref loc, appid);

			//string texto = qapp.EvaluateEx(" =Today()   ").Text;
			//output.WriteLine(texto);


			//var cobj = qapp.GetObject<Qlik.Sense.Client.Visualizations.WaterfallChart>(objid);

			//var res = cobj.ExportData(NxExportFileType.EXPORT_CSV_C);

			//output.WriteLine( res.Url);


		}
	}
//}