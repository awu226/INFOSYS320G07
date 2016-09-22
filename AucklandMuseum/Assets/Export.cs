using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Make sure you get rid of the namespace that is automatically generated here.
class Export
{
	//List all the columns of your table here in the same format as below.
	public string ID { get; set; }
	public string CreatedAt { get; set; }
	public string UpdatedAt { get; set; }
	public string Version { get; set; }
	public string ExportYear { get; set; }
	public string ExportType { get; set; }
	public string ExportValue { get; set; }
	public string ValueCategory { get; set; }
}
