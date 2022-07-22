namespace TILab.Tester
{
    public class AddierLevel : Level
    {
        public override void Start()
        {
            base.Start();
            Sequence = new SequenceItem[]
            {
                new SequenceItem("00", "00"),
                new SequenceItem("10", "01"),
                new SequenceItem("01", "01"),
                new SequenceItem("11", "10"),
            };
        }
    }
}