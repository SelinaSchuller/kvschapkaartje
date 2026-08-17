public static class LocationCalculator
{
    public static (int Meter, int Plank, int Positie, int Breedte) Calculate(string code)
    {
        string digits = new string(code.Where(char.IsDigit).ToArray());

        if (digits.Length != 12)
            throw new ArgumentException($"Verwachtte 12 cijfers, kreeg er {digits.Length}: '{code}'");

        int meter    = int.Parse(digits.Substring(4, 2));
        int plank    = int.Parse(digits.Substring(6, 1));
        int positie  = int.Parse(digits.Substring(7, 3));
        int breedte  = int.Parse(digits.Substring(10, 2));

        return (meter, plank, positie, breedte);
    }
}