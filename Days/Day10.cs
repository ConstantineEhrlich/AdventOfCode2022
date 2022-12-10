namespace Days;

public static class Day10
{
    public static int Resolve(IEnumerable<string> data)
    {
        Processor processor = new(data);
        Display display = new();
        while (!processor.ExecutionFinished)
        {
            processor.Tick();
            display.Tick(processor.Register);
        }
        display.Print();
        
        return processor.SignalSum; // Answer for first part
    }

    public class Display
    {
        private char[][] Matrix { get; set; }
        private (int row, int col) _scanner;

        public Display()
        {
            Matrix = new char[6][];
            for (int i = 0; i < 6; i++)
            {
                Matrix[i] = new char[40];
                for (int j = 0; j < 40; j++)
                {
                    Matrix[i][j] = '.';
                }
            }

            _scanner = (0, 0);
        }

        public void Tick(int position)
        {
            if (_scanner.col == 39)
            {
                _scanner.col = 0;
                _scanner.row++;
                if (_scanner.row == 6)
                {
                    _scanner.row = 0;
                }
            }
            else
            {
                _scanner.col++;
            }

            if (_scanner.col >= position - 1 & _scanner.col <= position + 1)
            {
                Matrix[_scanner.row][_scanner.col] = '#';
            }
        }

        public void Print()
        {
            foreach (var line in Matrix)
            {
                Console.WriteLine(String.Join(string.Empty, line));
            }
        }
    }


    private class Processor
    {
        public int SignalSum { get; private set; }
        public int Register { get; private set; } = 1;
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