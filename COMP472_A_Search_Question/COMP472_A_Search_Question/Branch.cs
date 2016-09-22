using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP472_A_Search_Question
{
    public class Branch
    {
        public Node leaf;
        public Branch parent;
        
        public Branch(Node leaf, Branch parent)
        {
            this.leaf = leaf;
            this.parent = parent;
        }

        public int getCost()
        {
            // No parent means we are at the top of the tree
            if(parent == null)
            {
                return 0;
            }

            return parent.leaf.getCostTo(leaf) + parent.getCost();
        }

        public string printPath()
        {
            if(parent == null)
            {
                return leaf.name;
            }

            return parent.printPath() + " > " + leaf.name;
        }
    }
}
