class AVLTrees
{

    public Node<int> root { get; set; }

    public int NodeHeight(Node<int> node)
    {
        int hl, hr;
        hl = node != null && node.lchild != null ? node.lchild.hight : 0;
        hr = node != null && node.rchild != null ? node.rchild.hight : 0;

        return hl > hr ? hl + 1 : hr + 1;
    }
    public int BalanceFactor(Node<int> node)
    {
        int hl, hr;
        hl = node != null && node.lchild != null ? node.lchild.hight : 0;
        hr = node != null && node.rchild != null ? node.rchild.hight : 0;

        return hl - hr;
    }

    public Node<int> LLRotation(Node<int> node)
    {
        Node<int> pl = node.lchild;
        Node<int> plr = pl.rchild;
        pl.rchild = node;
        node.lchild = plr;
        node.hight = NodeHeight(node);
        pl.hight = NodeHeight(pl);
        if (root == node) return pl;
        return pl;
    }
    public Node<int> LRRotation(Node<int> node)
    {
        Node<int> pl = node.lchild;
        Node<int> plr = pl.rchild;

        pl.rchild = plr.lchild;
        node.lchild = plr.rchild;

        plr.lchild = pl;
        plr.rchild = node;

        pl.hight = NodeHeight(pl);
        node.hight = NodeHeight(node);
        plr.hight = NodeHeight(plr);

        if (node == root) root = plr;
        return plr;
    }
    public Node<int> RRRotation(Node<int> node)
    {
        Node<int> pr = node.rchild;
        Node<int> plr = pr.lchild;

        pr.lchild = node;
        node.rchild = plr;


        pr.hight = NodeHeight(pr);
        node.hight = NodeHeight(node);

        if (node == root) root = pr;
        return pr;
    }
    public Node<int> RLLRotation(Node<int> node)
    {
        return node;
    }
    public Node<int> RLRotation(Node<int> node)
    {
        Node<int> pr = node.rchild;
        Node<int> plr = pr.lchild;

        pr.lchild = plr.rchild;
        node.rchild = plr.lchild;

        plr.rchild = pr;
        plr.lchild = node;

        pr.hight = NodeHeight(pr);
        node.hight = NodeHeight(node);
        plr.hight = NodeHeight(pr);

        if (node == root) root = pr;
        return plr;
    }
    public Node<int> RInsert(Node<int> root, int key)
    {
        //O(logn)
        Node<int> n = null;
        if (root == null)
        {
            n = new() { data = key, lchild = null, rchild = null, hight = 1 };
            return n;
        }
        if (key < root.data) root.lchild = RInsert(root.lchild, key);
        else if (key > root.data) root.rchild = RInsert(root.rchild, key);
        else return null;
        root.hight = NodeHeight(root);

        if (BalanceFactor(root) == 2 && BalanceFactor(root.lchild) == 1)
            return LLRotation(root);
        else if (BalanceFactor(root) == 2 && BalanceFactor(root.lchild) == -1)
            return LRRotation(root);
        else if (BalanceFactor(root) == -2 && BalanceFactor(root.lchild) == -1)
            return RRRotation(root);
        else if (BalanceFactor(root) == 2 && BalanceFactor(root.lchild) == 1)
            return RLRotation(root);



        return root;
    }
}