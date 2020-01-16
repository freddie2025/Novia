using System;

namespace ParkingChargeCalculator.Stays
{
	public class ShortStay : BaseStay
	{
		private const decimal _charge = 1.10M;

		private readonly TimeSpan _startTimeOfDay = new TimeSpan(8, 0, 0); // 8AM

		private readonly TimeSpan _endTimeOfDay = new TimeSpan(18, 0, 0); // 6PM

		public override decimal Charge { get { return _charge; } }

		public ShortStay(DateTime startDate, DateTime endDate) : base(startDate, endDate)
		{
			StayType = Enums.StayType.ShortStay;
		}

		public override decimal CalculateCharge()
		{
			if (StartDate > EndDate) throw new ArgumentException($"EndDate {EndDate} cannot be before the StartDate {StartDate}");

			decimal total = 0;

			// Calculate Hours
			for (DateTime date = StartDate; date < EndDate; date = date.AddHours(1))
			{
				if (ValidDate(date))
					total += Charge;
			}

			// Calculate Minutes
			if (ValidDate(StartDate))
				total -= CalculateMinutes(StartDate.Minute);
			if (ValidDate(EndDate) && EndDate.Minute != 0)
				total -= CalculateMinutes(60 - EndDate.Minute);

			return Math.Abs(Math.Round(total, 2, MidpointRounding.AwayFromZero));
		}

		private bool ValidDate(DateTime date)
		{
			if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
			{
				if (date.TimeOfDay.Hours >= _startTimeOfDay.Hours && date.TimeOfDay.Hours < _endTimeOfDay.Hours)
				{
					return true;
				}
			}
			return false;
		}

		private decimal CalculateMinutes(int minutes)
		{
			if (minutes == 0)
				return 0;
			else 
				return (Charge / 60) * minutes;
		}
	}
}
