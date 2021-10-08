using System;

namespace covid19.Models
{
	public class Covid : BaseEntity
	{
		public string Country { get; set; }
		public string CountryCode { get; set; }
		public string Province { get; set; }
		public string City { get; set; }
		public string CityCode { get; set; }
		public float Lat { get; set; }
		public float Lon { get; set; }
		public int Cases { get; set; }
		public string Status { get; set; }
		public DateTime Date { get; set; }
	}
}
