namespace TILab.Tester
{
    public class SequenceItem
    {
        public string Output { get; }
        public string Input { get; }
        
        public int WaitTicks { get; }

        public SequenceItem(string output, string input, int waitTicks = 50)
        {
            Output = output;
            Input = input;
            WaitTicks = waitTicks;
        }
    }
}