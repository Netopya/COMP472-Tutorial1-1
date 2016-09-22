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
        /*
            A basic A search algorithm

        */

        static void Main(string[] args)
        {
            Node S = new Node(10, "S");
            Node A = new Node(5, "A");
            Node B = new Node(8, "B");
            Node C = new Node(3, "C");
            Node D = new Node(2, "D");
            Node E = new Node(4, "E");
            Node G1 = new Node(0, "G1");
            Node G2 = new Node(0, "G2");

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

            List<Branch> frontier = new List<Branch>();
            List<Branch> visited = new List<Branch>();
            Branch result;

            frontier.Add(new Branch(S, null));

            while(true)
            {

                Branch current = frontier.MinBy(x => x.getCost() + x.leaf.heuristic);

                Console.WriteLine("Exploring " + current.leaf.name);

                if (current.leaf == G1 || current.leaf == G2)
                {
                    result = current;
                    break;
                }

                frontier.Remove(current);
                visited.Add(current);

                foreach(var op in current.leaf.operations)
                {
                    // Check if we have already visited a the node
                    if(visited.Count(x => x.leaf == op.Key) > 0)
                    {
                        continue;
                    }

                    // If we found a path to a node that is already in the frontier, check to see if it is better and replace it
                    var frontierContenders = frontier.Where(x => x.leaf == op.Key);
                    if(frontierContenders.Count() > 0)
                    {
                        Branch contender = frontierContenders.MinBy(x => x.getCost() + x.leaf.heuristic);
                        if(contender.getCost() + contender.leaf.heuristic > op.Key.heuristic + op.Value + current.getCost())
                        {
                            frontier.Remove(contender);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    // Add the valid child nodes to the frontier
                    frontier.Add(new Branch(op.Key, current));
                }
            }


            Console.WriteLine("Found: " + result.printPath());
            Console.ReadLine();
        }
    }
}
