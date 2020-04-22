using AdminnDeneme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminnDeneme.Common
{
	public class Tools
	{
		public static MyECommerceEntities db = null;
		public static MyECommerceEntities GetConnection()
		{
			if (db == null)
			{
				db = new MyECommerceEntities();
			}
			return db;
		}
	}
}
