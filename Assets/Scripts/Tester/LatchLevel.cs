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
                new SequenceItem("10", "10"),
                new SequenceItem("00", "10"),
                new SequenceItem("01", "01"),
                new SequenceItem("00", "01"),
            };
        }


    }
}