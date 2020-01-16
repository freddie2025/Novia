using ParkingChargeCalculator.Stays;
using System;
using Xunit;

public class LongStayTests
{
	[Fact]
	public void CalculateChange_Example_Test()
	{
		// Arrange
		var startDate = new DateTime(2019, 9, 7, 7, 50, 0);
		var endDate = new DateTime(2019, 9, 9, 5, 20, 0);
		var expected = 22.50M;
		var longStay = new LongStay(startDate, endDate);

		// Act
		var actual = longStay.CalculateCharge();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void CalculateChange_MinimumCharge_Test()
	{
		// Arrange
		var startDate = new DateTime(2019, 9, 7, 0, 00, 0);
		var endDate = new DateTime(2019, 9, 7, 0, 00, 0);
		var expected = 7.50M;
		var longStay = new LongStay(startDate, endDate);

		// Act
		var actual = longStay.CalculateCharge();

		// Assert
		Assert.Equal(expected, actual);
	}
}