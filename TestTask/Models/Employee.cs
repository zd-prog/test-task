using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
	[Table("employees")]
	public class Employee
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }
	}
}

