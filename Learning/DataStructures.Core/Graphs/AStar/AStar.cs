using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Graphs.AStar
{
    public class AStar
    {
        private readonly Dictionary<char, Node> _nodes;

        public AStar()
        {
            _nodes = new Dictionary<char, Node>();
        }

        public void AddEdge(char from, char to, int weight, int sourceHeuristic = -1)
        {
            var edge = new Edge()
            {
                To = to,
                Cost = weight
            };

            if(!_nodes.ContainsKey(from))
                _nodes.Add(from, new Node()
                {
                    From = from,
                    Edges = new List<Edge>()
                });

            _nodes[from].Edges.Add(edge);

            if (sourceHeuristic != -1)
                _nodes[from].HeuristicCost = sourceHeuristic;
        }

        public void FindRoute(char start, char goal)
        {
            _nodes.Add(goal, new Node()
            {
                From = goal,
                HeuristicCost = 0,
                Edges = null
            });

            var openNodes = new SortedSet<Node>(new NodeComparer())
            {
                _nodes[start]
            };
            _nodes[start].OriginatedFrom = '-';
            var closedNodes = new HashSet<char>();
            var hasReachedGoal = false;

            while (openNodes.Count > 0 && !hasReachedGoal)
            {
                var selectedNode = openNodes.First();
                openNodes.Remove(openNodes.First());
                closedNodes.Add(selectedNode.From);

                foreach (var nodeEdge in selectedNode.Edges)
                {
                    if (closedNodes.Contains(nodeEdge.To))
                        continue;

                    var cost = selectedNode.ActualCost + nodeEdge.Cost + _nodes[nodeEdge.To].HeuristicCost;
                    if (cost < _nodes[nodeEdge.To].Total)
                    {
                        _nodes[nodeEdge.To].ActualCost = selectedNode.ActualCost + nodeEdge.Cost;
                        _nodes[nodeEdge.To].Total = cost;
                        _nodes[nodeEdge.To].OriginatedFrom = selectedNode.From;
                        if(!openNodes.Any(it => it.From.Equals(nodeEdge.To)))
                            openNodes.Add(_nodes[nodeEdge.To]);
                    }

                    if (nodeEdge.To.Equals(goal))
                    {
                        Console.WriteLine("Reached to goal");
                        var index = goal;
                        while (index != start)
                        {
                            Console.Write(index + "->");
                            index = _nodes[index].OriginatedFrom;
                        }
                        Console.Write(start);
                        hasReachedGoal = true;
                        break;
                    }
                }
            }
        }

        #region Private methods

        

        #endregion
    }

    public class NodeComparer : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            if (x == null || y == null)
                throw new InvalidOperationException();

            var result = x.Total.CompareTo(y.Total);
            if (result == 0)
                result = x.HeuristicCost.CompareTo(y.HeuristicCost);

            return result;
        }
    }

    public class Node
    {
        // n to goal node
        public int HeuristicCost { get; set; }
        // start to n node
        public int ActualCost { get; set; }

        public int Total { get; set; } = int.MaxValue;

        public char From { get; set; }

        public char OriginatedFrom { get; set; }

        public List<Edge> Edges { get; set; }
    }

    public class Edge
    {
        public char To { get; set; }
        public int Cost { get; set; }
    }
}