using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var nummbers = new int[] {54,62,45,12,1,15,78,0,2,3,154,5,2,5,9,8,62,0,5,2,55,6,25,888};
            var bst = new Bst();
            var nods = new Node[nummbers.Length];
            //convert int to node
            bst.MakeNodeArry(nummbers, nods);
            //make tree
            bst.treeviwe(nods);
            //sorting arry 
            var sorted = bst.sorting(nods[0]);
            //print the sorted arry 
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }
        public class Node
        {
            public  int value;
            public  Node childLeft;
            public  Node childRight;
            public Node(int root)
            {
                value = root;
            }
            
        }
        public class Bst
        {
            private List<int> sortedArry = new List<int> { };
            public void maping(Node node1, Node node2)
            {
                if (node2.value != node1.value)
                {
                    if (node2.value < node1.value)
                    {
                        if (node1.childLeft == null)
                        {
                            node1.childLeft = node2;
                        }
                        else
                        {
                            maping(node1.childLeft, node2);
                        }
                    }
                    if (node2.value > node1.value)
                    {
                        if (node1.childRight == null)
                        {
                            node1.childRight= node2;
                        }
                        else
                        {
                            maping(node1.childRight, node2);
                        }

                    }
                }
            }
            public void treeviwe(Node[] nodes)
            {
                //var sortedArr = new int[nodes.Length];
                for (int i = 0; i < nodes.Length - 1; i++)
                {
                    maping(nodes[0], nodes[i + 1]);
                }
            }
                //todo: make sorted arry
            public int[] sorting(Node nodes)
            {
                if (nodes.childLeft != null)
                {
                    sorting(nodes.childLeft);
                }
                //Console.WriteLine(nodes.value);
                sortedArry.Add(nodes.value);
                if (nodes.childRight != null)
                {
                    sorting(nodes.childRight);
                }
                return sortedArry.ToArray();
            }

            public void MakeNodeArry(int[] arr, Node[] nodes)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    nodes[i] = new Node(arr[i]);
                }
            }

        }
    }
}
