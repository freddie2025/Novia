using ParkingChargeCalculator.Stays;
using System;
using Xunit;

namespace ParkingChargeCalculatorTests
{
	public class ShortStayTests
	{
		[Fact]
		public void CalculateChange_OneHourInsideChargableHours_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 15, 8, 00, 0);
			var endDate = new DateTime(2020, 1, 15, 9, 00, 0);
			var expected = 1.10M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void CalculateChange_OneHourOutsideChargableHours_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 15, 18, 00, 0);
			var endDate = new DateTime(2020, 1, 15, 19, 00, 0);
			var expected = 0M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void CalculateChange_FifteenMinsInsideChargableHours_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 15, 8, 45, 0);
			var endDate = new DateTime(2020, 1, 15, 9, 00, 0);
			var expected = 0.275M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual, 2);
		}

		[Fact]
		public void CalculateChange_FifteenMinsEitherSideInsideChargableHours_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 15, 8, 45, 0);
			var endDate = new DateTime(2020, 1, 15, 9, 15, 0);
			var expected = 0.55M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual, 2);
		}

		[Fact]
		public void CalculateChange_WholeWeekdayInsideChargableHours_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 15, 8, 00, 0);
			var endDate = new DateTime(2020, 1, 15, 18, 00, 0);
			var expected = 11.0M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void CalculateChange_24HoursWeekdayInsideChargableHours_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 15, 00, 00, 0);
			var endDate = new DateTime(2020, 1, 15, 23, 59, 59);
			var expected = 11.0M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void CalculateChange_StayEntierlyOutsideAChargeablePeriodWeekend_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 11, 0, 0, 0);
			var endDate = new DateTime(2020, 1, 12, 23, 59, 59);
			var expected = 0M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void CalculateChange_StayEntierlyOutsideAChargeablePeriodOutsideHours_Test()
		{
			// Arrange
			var startDate = new DateTime(2020, 1, 9, 0, 0, 0);
			var endDate = new DateTime(2020, 1, 9, 8, 0, 0);
			var expected = 0M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void CalculateChange_StartDateBeforeEndDate_Test()
		{
			// Arrange
			var startDate = new DateTime(2019, 9, 10, 0, 00, 0);
			var endDate = new DateTime(2019, 9, 7, 0, 00, 0);
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			// Assert
			Assert.Throws<ArgumentException>(() => shortStay.CalculateCharge());
		}

		[Fact(Skip = "I'm not sure this information is correct")]
		public void CalculateChange_Example_Test()
		{
			// Arrange
			var startDate = new DateTime(2019, 9, 7, 16, 50, 0);
			var endDate = new DateTime(2019, 9, 9, 19, 15, 0);
			var expected = 12.28M;
			var shortStay = new ShortStay(startDate, endDate);

			// Act
			var actual = shortStay.CalculateCharge();

			// Assert
			Assert.Equal(expected, actual);
		}
	}
}