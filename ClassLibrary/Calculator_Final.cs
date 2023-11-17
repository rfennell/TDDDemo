namespace ClassLibrary
{
    public class Calculator_Final
    {
        public int Sum(string value)
        {
            var returnValue = 0;
            if (String.IsNullOrEmpty(value))
            {
                returnValue = 0;
            } else
            {
                var delimiters = new char[] { ',', '\n' };
                var values = value.Split(delimiters).Select(x => int.Parse(x));

                var negativeValues = values.Where(x => x < 0);
                if (negativeValues.ToArray().Length > 0)
                {
                    throw new InvalidOperationException();
                }
                returnValue = values.Sum();
            }
            return returnValue;
        }
    }
}