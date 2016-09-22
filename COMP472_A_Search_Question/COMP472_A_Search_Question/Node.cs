using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP472_A_Search_Question
{
    public class Node
    {
        public int heuristic;
        public List<Tuple<int, Node>> operations = new List<Tuple<int, Node>>();
        public List<Node> path = new List<Node>();
        public Node parent;

        public Node(int heuristic)
        {
            this.heuristic = heuristic;
        }

        public void MakeLink(int cost, Node node)
        {
            operations.Add(new Tuple<int, Node>(cost, node));
        }

        public int getCost(Node from)
        {
            if(from == this)
            {
                return 0;
            }

            if(parent == null && from == null)
            {
                throw new Exception();
            }

            int childCost = operations.First(x => x.Item2 == from).Item1;

            if (parent == null)
            {
                return childCost;
            }

            return parent.getCost(this) + childCost;
        }
    }
}
