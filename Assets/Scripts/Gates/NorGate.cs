namespace TILab
{
    public class NorGate : OrGate
    {
        protected override bool calculateOutput()
        {
            return !base.calculateOutput();
        }
    }
}