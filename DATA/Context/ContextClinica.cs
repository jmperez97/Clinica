namespace DATA.Context
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Data.Entity;


	public class ContextClinica: DbContext
	{
		public ContextClinica()
		   : base("name=ContextClinica")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
