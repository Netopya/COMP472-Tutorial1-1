using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace COMP472_A_Search_Question
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Node S = new Node(10);
            Node A = new Node(5);
            Node B = new Node(8);
            Node C = new Node(3);
            Node D = new Node(2);
            Node E = new Node(4);
            Node G1 = new Node(0);
            Node G2 = new Node(0);

            S.MakeLink(3, A);
            S.MakeLink(7, B);
            A.MakeLink(1, C);
            A.MakeLink(6, D);
            B.MakeLink(1, E);
            B.MakeLink(9, G2);
            C.MakeLink(2, S);
            C.MakeLink(4, D);
            D.MakeLink(6, G1);
            D.MakeLink(3, B);
            E.MakeLink(5, G2);
            G1.MakeLink(2, C);
            G2.MakeLink(8, B);

            List<Node> frontier = new List<Node>();
            List<Node> visited = new List<Node>();

            frontier.Add(S);

            Node result;
            while (true)
            {
                Node current = frontier.MinBy(x => S.getCost(x) + x.heuristic);

                if(current == G1 || current == G2)
                {
                    result = current;
                    break;
                }

                frontier.Remove(current);
                visited.Add(current);
                foreach(Tuple<int, Node> ops in current.operations)
                {
                    if (visited.Contains(ops.Item2))
                        continue;

                    if(frontier.Contains(ops.Item2))
                    {
                        Node oldParent = ops.Item2.parent;
                        int oldCost = S.getCost(ops.Item2);

                        ops.Item2.parent = current;
                        int newCost = S.getCost(ops.Item2);

                        if(oldCost < newCost)
                        {
                            ops.Item2.parent = oldParent;
                        }
                        continue;
                    }

                    ops.Item2.parent = current;
                    frontier.Add(ops.Item2);
                }
            }

            Console.WriteLine("Found something!");
        }
    }
}
