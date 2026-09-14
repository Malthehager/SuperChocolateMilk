namespace SuperChocolateMilk.UnitTests;

using Xunit;
using SuperChocolateMilk.Core;

public class RecipeHelpersTests
{
    [Fact]
    public void CombineVolumes_TwoPositiveVolumes_ReturnsSum()
    {
        int volumeA = 250;
        int volumeB = 500;

        int result = RecipeHelpers.CombineVolumes(volumeA, volumeB);

        Assert.Equal(750, result);
    }

    [Theory]
    [InlineData(1, 1000)]
    [InlineData(2, 2000)]
    [InlineData(0, 0)]
    [InlineData(5, 5000)]
    public void LitersToMilliliters_VariousLiters_ReturnsCorrectMilliliters(int liters, int expectedMl)
    {
        int result = RecipeHelpers.LitersToMilliliters(liters);

        Assert.Equal(expectedMl, result);
    }

    [Fact]
    public void CalculateMilkWeightGrams_GivenVolume_ReturnsWeightInGrams()
    {
        int volumeMl = 1000;

        double result = RecipeHelpers.CalculateMilkWeightGrams(volumeMl);

        Assert.Equal(1030, result);
    }

    [Theory]
    [InlineData(100, true)]
    [InlineData(0, false)]
    [InlineData(-50, false)]
    [InlineData(1, true)]
    public void IsValidBatchSize_VariousTotals_ReturnsExpectedValidity(int totalMl, bool expected)
    {
        bool result = RecipeHelpers.IsValidBatchSize(totalMl);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, "Whole Milk", "Tank-1: Whole Milk")]
    [InlineData(2, "Chocolate Mix", "Tank-2: Chocolate Mix")]
    public void FormatTankLabel_GivenIdAndContents_ReturnsFormattedLabel(int tankId, string contents, string expected)
    {
        string result = RecipeHelpers.FormatTankLabel(tankId, contents);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(500, 2)]
    [InlineData(501, 3)]
    [InlineData(250, 1)]
    [InlineData(0, 0)]
    public void CalculateRequiredBottles_VariousVolumes_ReturnsCeilingBottleCount(int totalVolumeMl, int expectedBottles)
    {
        int result = RecipeHelpers.CalculateRequiredBottles(totalVolumeMl);

        Assert.Equal(expectedBottles, result);
    }

    [Theory]
    [InlineData(100, 100, 85)]
    [InlineData(100, 50, 90)]
    [InlineData(100, 10, 100)]
    public void ApplyBulkDiscount_VariousBottleCounts_ReturnsDiscountedPrice(decimal basePrice, int bottleCount, decimal expected)
    {
        decimal result = RecipeHelpers.ApplyBulkDiscount(basePrice, bottleCount);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateSugarGrams_GivenVolume_ReturnsScaledSugarAmount()
    {
        int volumeMl = 240;

        double result = RecipeHelpers.CalculateSugarGrams(volumeMl);

        Assert.Equal(24, result);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(-10, false)]
    [InlineData(500, true)]
    [InlineData(499, false)]
    [InlineData(1000, true)]
    public void NeedsMaintenance_VariousBatchCounts_ReturnsExpectedResult(int totalBatchesRun, bool expected)
    {
        bool result = RecipeHelpers.NeedsMaintenance(totalBatchesRun);

        Assert.Equal(expected, result);
    }
}