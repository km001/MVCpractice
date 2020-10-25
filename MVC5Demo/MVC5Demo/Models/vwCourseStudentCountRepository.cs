using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
	public  class vwCourseStudentCountRepository : EFRepository<vwCourseStudentCount>, IvwCourseStudentCountRepository
	{

	}

	public  interface IvwCourseStudentCountRepository : IRepository<vwCourseStudentCount>
	{

	}
}