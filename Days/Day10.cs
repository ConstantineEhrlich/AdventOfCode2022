namespace Days;


public static class Day10
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        Processor processor = new(data);
        while (!processor.ExecutionFinished)
        {
            processor.Tick();
        }
        
        return (processor.SignalSum, 0);
    }


    private class Processor
    {
        public int SignalSum { get; private set; }
        public bool ExecutionFinished => Program.Count == 0;

        private int Cycle
        {
            get => _cycle;
            set
            {
                _cycle = value;
                if ((_cycle - 20) % 40 == 0)
                    SignalSum += Register*Cycle;
            }
        }

        private string? Instruction { get; set; }
        private int Register { get; set; } = 1;
        private Queue<string> Program { get; }
        private int _cycle = 0;
        
        public Processor(IEnumerable<string> programInput)
        {
            Program = new(programInput);
        }
        
        public void Tick()
        {
            if (Instruction == null)
            {
                Cycle++;
                Instruction = Program.Dequeue();
                if (Instruction == "noop")
                    Instruction = null;
            }

            else if (Instruction[..4] == "addx")
            {
                Cycle++;
                int.TryParse(Instruction[4..], out int value);
                Register += value;
                Instruction = null;
            }
        }
    }
}