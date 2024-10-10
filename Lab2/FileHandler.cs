namespace Lab2
{
    class FileHandler
    {
        private const string InputFileName = "Input.txt";
        private const string OutputFileName = "Output.txt";

        public static int ReadInput()
        {
            try
            {
                string[] input = File.ReadAllLines(InputFileName);
                return int.Parse(input[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading input file: " + ex.Message);
            }
        }

        public static void WriteOutput(int result)
        {
            try
            {
                File.WriteAllText(OutputFileName, result.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing output file: " + ex.Message);
            }
        }
    }
}
