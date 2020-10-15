using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MTTask.Model
{
	class Ticket
	{
		public int Id { get; set; }		
		private DateTime _date {get;set;}
		public string Date
		{
			get
			{
			return _date.ToShortDateString();
			}
			set
			{
				_date = Convert.ToDateTime(value);
			}
		}
		private DateTime _time { get; set; }
		public string Time
		{
			get
			{
				return _time.ToShortTimeString();
			}
			set
			{
				_time = Convert.ToDateTime(value);
			}
		}
		public string Name { get; set; }
	}
}
