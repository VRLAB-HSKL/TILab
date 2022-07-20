namespace TILab.Tester
{
    public class AddierLevel : Level
    {
        public override void Start()
        {
            base.Start();
            Sequence = new SequenceItem[]
            {
                new SequenceItem("0000", "0000"),
                new SequenceItem("0001", "0001"),
                new SequenceItem("0010", "0010"),
                new SequenceItem("0011", "0011"),
                new SequenceItem("0100", "0001"),
                new SequenceItem("0101", "0010"),
                new SequenceItem("0110", "0011"),
                new SequenceItem("0111", "0100"),
                new SequenceItem("1000", "0010"),
                new SequenceItem("1001", "0011"),
                new SequenceItem("1010", "0100"),
                new SequenceItem("1011", "0101"),
                new SequenceItem("1100", "0011"),
                new SequenceItem("1101", "00100"),
                new SequenceItem("1110", "00101"),
                new SequenceItem("1111", "0110"),
            };
        }
    }
}