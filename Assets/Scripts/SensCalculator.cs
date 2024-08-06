// Copyright takiido. All Rights Reserved

public class SensCalculator
{
    public float CalculateConversion(float inchesPer360, float gameSens, int dpi)
    {
        return 360.0f / (inchesPer360 * dpi * gameSens);
    }
}
