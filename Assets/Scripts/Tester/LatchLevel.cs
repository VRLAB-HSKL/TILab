namespace TILab.Tester
{
    public class LatchLevel : Level
    {
        public override void Start()
        {
            base.Start();
            // TODO: @Saarli fix this
            Sequence = new SequenceItem[]
            {
                new SequenceItem("01", "10"),
                new SequenceItem("11", "10"),
                new SequenceItem("10", "01"),
                new SequenceItem("00", "11"),
            };
        }


    }
}