using System.Collections.Generic;

namespace LAB5OP
{
    public class RTree<T>
    {
        // parameters of the tree
        private const int DEFAULT_MAX_NODE_ENTRIES = 10;
        internal int maxNodeEntries;
        int minNodeEntries;

        private Dictionary<int, Node<T>> nodeMap = new Dictionary<int, Node<T>>();

        // used to mark the status of entries during a Node&lt;T&gt; split
        private const int ENTRY_STATUS_ASSIGNED = 0;
        private const int ENTRY_STATUS_UNASSIGNED = 1;
        private byte[] entryStatus = null;
        private byte[] initialEntryStatus = null;


        private Stack<int> parents = new Stack<int>();
        private Stack<int> parentsEntry = new Stack<int>();

        // initialisation
        private int treeHeight = 1; // leaves are always level 1
        private int rootNodeId = 0;
        private int msize = 0;

        // Enables creation of new nodes
        //private int highestUsedNodeId = rootNodeId; 
        private int highestUsedNodeId = 0;

        List<int> nearestIds = new List<int>();

        private Dictionary<int, T> IdsToItems = new Dictionary<int, T>();
        private Dictionary<T, int> ItemsToIds = new Dictionary<T, int>();
        private volatile int idcounter = int.MinValue;

        //the recursion methods require a delegate to retrieve data
        private delegate void intproc(int x);

        public RTree()
        {
            init();
        }

        public RTree(int MaxNodeEntries, int MinNodeEntries)
        {
            minNodeEntries = MinNodeEntries;
            maxNodeEntries = MaxNodeEntries;
            init();
        }

        private void init()
        {

            if (maxNodeEntries < 2)
            {
                maxNodeEntries = DEFAULT_MAX_NODE_ENTRIES;
            }

            // The MinNodeEntries must be less than or equal to (int) (MaxNodeEntries / 2)
            if (minNodeEntries < 1 || minNodeEntries > maxNodeEntries / 2)
            {
                minNodeEntries = maxNodeEntries / 2;
            }

            entryStatus = new byte[maxNodeEntries];
            initialEntryStatus = new byte[maxNodeEntries];

            for (int i = 0; i < maxNodeEntries; i++)
            {
                initialEntryStatus[i] = ENTRY_STATUS_UNASSIGNED;
            }

            Node<T> root = new Node<T>(rootNodeId, 1, maxNodeEntries);
            nodeMap.Add(rootNodeId, root);
        }

        public void Add(Rectangle r, T item)
        {
            idcounter++;
            int id = idcounter;

            IdsToItems.Add(id, item);
            ItemsToIds.Add(item, id);

            add(r, id);
        }

        private void add(Rectangle r, int id)
        {
            add(r.copy(), id, 1);
            msize++;
        }

        private void add(Rectangle r, int id, int level)
        {

            Node<T> n = chooseNode(r, level);
            Node<T> newLeaf = null;

            if (n.entryCount < maxNodeEntries)
            {
                n.addEntryNoCopy(r, id);
            }
            else
            {
                newLeaf = splitNode(n, r, id);
            }
            Node<T> newNode = adjustTree(n, newLeaf);

            if (newNode != null)
            {
                int oldRootNodeId = rootNodeId;
                Node<T> oldRoot = getNode(oldRootNodeId);

                rootNodeId = getNextNodeId();
                treeHeight++;
                Node<T> root = new Node<T>(rootNodeId, treeHeight, maxNodeEntries);
                root.addEntry(newNode.mbr, newNode.nodeId);
                root.addEntry(oldRoot.mbr, oldRoot.nodeId);
                nodeMap.Add(rootNodeId, root);
            }

        }
    }
}
