using AdminnDeneme.Common;
using AdminnDeneme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminnDeneme.Repository
{

	public class CategoryRepository : DataRepository<Category, Guid>
	{
		private static MyECommerceEntities db = Tools.GetConnection();
		ResultProcess<Category> result = new ResultProcess<Category>();

		public override Result<int> Insert(Category item)
		{
			db.Categories.Add(item);
			return result.GetResult(db);
		}

		public override Result<int> Delete(Guid id)
		{
			Category deletedItem = db.Categories.SingleOrDefault(d => d.CategoryID == id);
			db.Categories.Remove(deletedItem);
			return result.GetResult(db);
		}

		public override Result<int> Update(Category item)
		{
			Category c = db.Categories.SingleOrDefault(u => u.CategoryID == item.CategoryID);
			c.CategoryName = item.CategoryName;
			c.Description = item.Description;
			return result.GetResult(db);
		}

		public override Result<List<Category>> List()
		{
			List<Category> catList = db.Categories.ToList();
			return result.GetListResult(catList);
		}

		public override Result<Category> GetObjById(Guid id)
		{
			Category c = db.Categories.SingleOrDefault(t => t.CategoryID == id);
			return result.GetT(c);
		}

		public override Result<List<Category>> GetLastObj(int quantity)
		{
			return result.GetListResult(db.Categories.OrderByDescending(p => p.CreatedDate).Take(quantity).ToList());
		}
	}
}
