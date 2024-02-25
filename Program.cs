class Program
{
    static void Main(string[] args)
    {
        AVLTrees trees = new();
        Node<int> root = null;
        root = trees.RInsert(root, 50);
        root = trees.RInsert(root, 10);
        root = trees.RInsert(root, 20);
    }
}