using System;

namespace ParkingChargeCalculator.Stays
{
	public class LongStay : BaseStay
	{
		private const decimal _charge = 7.50M;
		public override decimal Charge { get { return _charge; } }

		public LongStay(DateTime startDate, DateTime endDate) : base(startDate, endDate)
		{
			StayType = Enums.StayType.LongStay;
		}

		public override decimal CalculateCharge()
		{
			if (StartDate > EndDate) throw new ArgumentException($"EndDate {EndDate} cannot be before the StartDate {StartDate}");

			return Charge * Math.Ceiling((decimal)(EndDate - StartDate.AddDays(-1)).TotalDays);
		}
	}
}
