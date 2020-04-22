using AdminnDeneme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminnDeneme.Common
{
	public class ResultProcess<T>
	{
		public Result<int> GetResult(MyECommerceEntities db)
		{
			Result<int> result = new Result<int>();
			int sonuc = db.SaveChanges();

			if (sonuc > 0)
			{
				result.UserMessage = "Basarili";
				result.IsSuccessed = true;
				result.ProcessResult = sonuc;
			}
			else
			{
				result.UserMessage = "Basarisiz";
				result.IsSuccessed = false;
				result.ProcessResult = sonuc;
			}
			return result;
		}

		public Result<List<T>> GetListResult(List<T> data)
		{
			Result<List<T>> result = new Result<List<T>>();
			if (data != null)
			{
				result.UserMessage = "işlem Başarılı";
				result.IsSuccessed = true;
				result.ProcessResult = data;
			}
			else
			{
				result.UserMessage = "işlem Başarısız";
				result.IsSuccessed = false;
				result.ProcessResult = data;
			}
			return result;
		}

		public Result<T> GetT(T data)
		{
			Result<T> result = new Result<T>();
			if (data != null)
			{
				result.IsSuccessed = true;
				result.UserMessage = "Başarılı";
				result.ProcessResult = data;
			}
			else
			{
				result.IsSuccessed = false; ;
				result.UserMessage = "Başarısız";
				result.ProcessResult = data;
			}
			return result;
		}
	}
}
