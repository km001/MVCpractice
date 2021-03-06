using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{
        public override IQueryable<Department> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }

        public Department GetOne(int id)
        {
            return this.All().FirstOrDefault(p => p.DepartmentID == id);
        }

        public override void Delete(Department entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;//迴避舊資料不符合新驗證而導致不能更新成刪除狀態的狀況
            entity.IsDeleted = true;
        }
    }

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}