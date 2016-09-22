using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP472_A_Search_Question
{
    public class Node
    {
        // Estimated cost to the goal
        public int heuristic;

        // A mapping of children nodes and their associated cost
        public Dictionary<Node, int> operations = new Dictionary<Node, int>();

        public string name;

        public Node(int heuristic, string name)
        {
            this.heuristic = heuristic;
            this.name = name;
        }

        public void MakeLink(int cost, Node node)
        {
            operations.Add(node, cost);
        }

        public int getCostTo(Node child)
        {
            return operations[child];
        }
    }
}
