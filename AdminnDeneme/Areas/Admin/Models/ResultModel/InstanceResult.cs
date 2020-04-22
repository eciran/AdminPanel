using AdminnDeneme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminnDeneme.Areas.Admin.Models.ResultModel
{
	public class InstanceResult<T>
	{
		public Result<List<T>> resultList { get; set; }
		public Result<int> resultint { get; set; }
		public Result<T> resultT { get; set; }
	}
}