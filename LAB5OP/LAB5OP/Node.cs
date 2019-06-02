namespace LAB5OP
{
    public class Node<T>
    {
        internal int nodeId = 0;
        internal Rectangle mbr = null;
        internal Rectangle[] entries = null;
        internal int[] ids = null;
        internal int level;
        internal int entryCount;

        public Node(int nodeId, int level, int maxNodeEntries)
        {
            this.nodeId = nodeId;
            this.level = level;
            entries = new Rectangle[maxNodeEntries];
            ids = new int[maxNodeEntries];
        }

        internal void addEntry(Rectangle r, int id)
        {
            ids[entryCount] = id;
            entries[entryCount] = r.copy();
            entryCount++;
            if (mbr == null)
            {
                mbr = r.copy();
            }
            else
            {
                mbr.add(r);
            }
        }

        internal void addEntryNoCopy(Rectangle r, int id)
        {
            ids[entryCount] = id;
            entries[entryCount] = r;
            entryCount++;
            if (mbr == null)
            {
                mbr = r.copy();
            }
            else
            {
                mbr.add(r);
            }
        }

        public Rectangle getEntry(int index)
        {
            if (index < entryCount)
            {
                return entries[index];
            }
            return null;
        }

        internal void reorganize(RTree<T> rtree)
        {
            int countdownIndex = rtree.maxNodeEntries - 1;
            for (int index = 0; index < entryCount; index++)
            {
                if (entries[index] == null)
                {
                    while (entries[countdownIndex] == null && countdownIndex > index)
                    {
                        countdownIndex--;
                    }
                    entries[index] = entries[countdownIndex];
                    ids[index] = ids[countdownIndex];
                    entries[countdownIndex] = null;
                }
            }
        }

        internal bool isLeaf()
        {
            return (level == 1);
        }

    }
}
