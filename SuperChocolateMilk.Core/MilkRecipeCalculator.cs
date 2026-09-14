namespace SuperChocolateMilk.Core;

public class MilkRecipeCalculator
{
    public static decimal CalculateChocolateSyrupRequired(int milkVolumeMl, string richnessLevel)
    {
        if (milkVolumeMl <= 0) return 0m;

        decimal baseSyrupMl = milkVolumeMl * 0.1m;

        return richnessLevel.ToUpper() switch
        {
            "LIGHT" => baseSyrupMl * 0.75m,
            "REGULAR" => baseSyrupMl,
            "EXTRA" => baseSyrupMl * 1.5m,
            "ULTRA_CHOCO" => baseSyrupMl * 2.0m,
            _ => baseSyrupMl
        };
    }
}
