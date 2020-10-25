using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
	public  class vwCourseStudentsRepository : EFRepository<vwCourseStudents>, IvwCourseStudentsRepository
	{

	}

	public  interface IvwCourseStudentsRepository : IRepository<vwCourseStudents>
	{

	}
}