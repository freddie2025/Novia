using ParkingChargeCalculator.Enums;
using System;

namespace ParkingChargeCalculator.Stays
{
	public abstract class BaseStay
	{	
		public StayType StayType { get; set; }
		public DateTime StartDate { get; private set; }
		public DateTime EndDate { get; private set; }
		public abstract decimal Charge { get; }

		public BaseStay(DateTime startDate, DateTime endDate)
		{
			StartDate = startDate;
			EndDate = endDate;
		}

		public abstract decimal CalculateCharge();
	}
}
