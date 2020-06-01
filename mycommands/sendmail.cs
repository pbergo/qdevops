using qdevopsbase.server;
using Qlik.Engine;
using Qlik.Sense.Client;
using Qlik.Sense.Client.Visualizations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json.Linq;

//namespace qdevopsbase.qlikcommands
//{

public class sendmail : iqlikcommand
{
	public qlikcommandparameters Params
	{
		get
		{
			return new qlikcommandparameters()
			{
				FullHelp = "Send Email Text and Images.",
				Parameters = new Dictionary<string, string>()
					{
						{ "app_id", "App Id" },
						{ "obj_id", "App Object Id" },
						{ "message", "Message" },
						{ "mailto", "To email field" }
					}
			};
		}
	}
	public string CommandId => "e=|sendmail=";
	public bool WillExecute { get; set; }
	public TextWriter output { get; set; }
	public string Content { get; set; }
	public int Priority { get; set; } = 10;

	public void SendMail(string toaddr, string msgBody, string titulo)
	{
		string fromaddr = "lucas.barbosa@desq.com.br";
		MailMessage msg = new MailMessage();
		msg.Subject = titulo;
		msg.From = new MailAddress(fromaddr);
		msg.Body = msgBody;
		msg.To.Add(new MailAddress(toaddr));
		SmtpClient smtp = new SmtpClient();
		smtp.Host = "smtp.gmail.com";
		smtp.Port = 587;
		smtp.UseDefaultCredentials = false;
		smtp.EnableSsl = true;
		NetworkCredential nc = new System.Net.NetworkCredential(fromaddr, "adfcyqpmuowlkdvf");
		smtp.Credentials = nc;
		smtp.Send(msg);
	}

	public void Execute(JObject args, ref ILocation loc, qlikcommandconfig conf)
	{
		//string[] args = command.Split(',');
		//string appid = args[0];
		//string objid = args[1];
		//string msg = args[2];
		//string num = args[3];
		//
		//output.WriteLine(appid);
		//output.WriteLine(objid);
		//output.WriteLine(msg);
		//output.WriteLine(num);
		//
		//IApp qapp = appops.GetAppFromIdString(ref loc, appid);
		//output.WriteLine(qapp.EvaluateEx("Sum(Desocupado)").Text);
	}
}
//}