using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
	[Table("time_reports")]
	public class TimeReport
	{
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("employees")]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("hours")]
        public float Hours { get; set; }

        [Column("date")]
        [DisplayFormat(DataFormatString = "{0:M/d/YYYY}")]
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

