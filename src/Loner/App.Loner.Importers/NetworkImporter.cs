using App.Loner.DataTypes;
using System.Collections.Generic;

namespace App.Loner.Importers
{
	public class NetworkImporter
	{
		public string Filename { get; set; }

		public NetworkImporter(string filename)
		{
			this.Filename = filename;
		}

		public List<Network> AggrigateNetwork()
		{
			Network network = new Network();
			network.Name = "test";

			return new List<Network>();
		}

	}
}
