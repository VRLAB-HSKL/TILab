namespace TILab.Tester
{
    public class XORLevel : Level
    {
        public override void Start()
        {
            base.Start();
            Sequence = new SequenceItem[]
            {
                new SequenceItem("00", "0"),
                new SequenceItem("01", "1"),
                new SequenceItem("10", "1"),
                new SequenceItem("11", "0"),
            };
        }

    }
}
