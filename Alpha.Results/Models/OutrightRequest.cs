namespace Alpha.Results.Models
{
	using Sunplus.Agent.Model.Entities;
	using System;

	public class OutRightRequest
	{
		public OutRightRequest()
		{
			DateTime currentDate = DateTime.Today;
			FromDate = currentDate;
			ToDate = currentDate;
		}

		public DateTime FromDate { get; set; }

		public DateTime ToDate { get; set; }

		public int SportType { get; set; }

		public int LeagueId { get; set; }

		public string Language
		{
			get
			{
				return UserSession.Current.Language;
			}
		}
	}
}