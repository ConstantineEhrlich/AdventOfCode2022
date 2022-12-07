namespace Days;

public static class Day07
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        FileNode root = ParseInput(data.ToList());
        List<FileNode> nodes = root.Traverse();
        List<FileNode> dirs = nodes.Where(file => file.Size == 0).ToList();

        int totalSize = 0;
        foreach (FileNode dir in dirs)
        {
            if (dir.RecursiveSize <= 100_000)
            {
                totalSize += dir.RecursiveSize;
            }
        }
        
        int desiredSize = 30_000_000 - (70_000_000 - root.RecursiveSize);
        
        int smallest = dirs
            .Where(dir => dir.RecursiveSize >= desiredSize)
            .OrderBy(dir => dir.RecursiveSize)
            .First()
            .RecursiveSize;

        return (totalSize, smallest);
    }

    public static FileNode ParseInput(List<string> dataList)
    {
        FileNode rootNode = new(@"/", 0);
        FileNode currentNode = rootNode;
        
        for (int i = 0; i < dataList.Count; i++)
        {
            string input = dataList[i];
            if (input[0] == '$')
            {
                string[] command = input.Substring(2, input.Length-2).Split(' ');
                
                if (command[0] == "cd")
                {
                    if (command[1] == "..")
                    {
                        currentNode = currentNode.Parent
                                      ?? throw new ArgumentOutOfRangeException();
                    }
                    else if (command[1] == "/")
                    {
                        currentNode = rootNode;
                    }
                    else
                    {
                        currentNode = currentNode.Children.Find(file => file.Name == command[1])
                                      ?? throw new ArgumentOutOfRangeException();
                    }                       
                }
                
                if (command[0] == "ls")
                {
                    while (i < dataList.Count-1)
                    {
                        if (dataList[i+1][0] == '$')
                            break;
                        i++;
                        string[] fileInfo = dataList[i].Split(' ');
                        if (fileInfo[0] == "dir")
                        {
                            currentNode.AddChild(fileInfo[1], 0);
                        }
                        else
                        {
                            int.TryParse(fileInfo[0], out int fileSize);
                            currentNode.AddChild(fileInfo[1], fileSize);
                        }
                    }
                }
            }
        }
        return rootNode;
    }
    
    
}


public class FileNode
{
    public List<FileNode> Children { get; set; } = new();
    public FileNode? Parent { get; private set; }
    public readonly string Name;
    public readonly int Size;

    public FileNode(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public FileNode AddChild(string name, int size)
    {
        FileNode newNode = new(name, size)
        {
            Parent = this
        };
        this.Children.Add(newNode);
        return newNode;
    }

    public int RecursiveSize
    {
        get
        {
            int size = 0;
            CalculateSize(this, ref size);
            return size;
        }
    }

 
    private void CalculateSize(FileNode node, ref int size)
    {
        foreach (FileNode file in node.Children)
        {
            size += file.Size;
            CalculateSize(file, ref size);
        }
    }

    public List<FileNode> Traverse()
    {
        List<FileNode> list = new();
        Traverse(this, list);
        return list;
    }

    private void Traverse(FileNode node, List<FileNode> list)
    {
        list.Add(node);
        foreach (var nodeChild in node.Children)
        {
            Traverse(nodeChild, list);
        }
    }
 
    public override string ToString() => this.Name;
}