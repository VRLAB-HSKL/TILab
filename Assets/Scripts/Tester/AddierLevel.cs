namespace TILab.Tester
{
    public class AddierLevel : Level
    {
        public override void Start()
        {
            base.Start();
            Sequence = new SequenceItem[]
            {
                new SequenceItem("0000", "000"),
                new SequenceItem("0001", "001"),
                new SequenceItem("0010", "010"),
                new SequenceItem("0011", "011"),
                new SequenceItem("0100", "001"),
                new SequenceItem("0101", "010"),
                new SequenceItem("0110", "011"),
                new SequenceItem("0111", "100"),
                new SequenceItem("1000", "010"),
                new SequenceItem("1001", "011"),
                new SequenceItem("1010", "100"),
                new SequenceItem("1011", "101"),
                new SequenceItem("1100", "011"),
                new SequenceItem("1101", "100"),
                new SequenceItem("1110", "101"),
                new SequenceItem("1111", "110"),
            };
        }
    }
}