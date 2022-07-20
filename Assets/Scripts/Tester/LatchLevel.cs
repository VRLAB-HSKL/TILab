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
                new SequenceItem("00", "11"),
                new SequenceItem("01", "10"),
                new SequenceItem("10", "10"),
                new SequenceItem("11", "01"),
            };
        }


    }
}