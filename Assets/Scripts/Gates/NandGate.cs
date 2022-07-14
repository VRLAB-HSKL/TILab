namespace TILab
{
    public class NandGate : AndGate
    {
        protected override bool calculateOutput()
        {
            return !base.calculateOutput();
        }
    }
}