using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var nummbers = new int[] {54,62,45,12,1,15,78,0,2,3,154,5,2,5,9,8,62,0,5,2,55,6,25,888};
            
            var bst = new Bst(nummbers);
            var sortedarry = bst.treeviwe(nummbers);
        
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
            public Bst(int[] nums)
            {
                _nodes = new Node[nums.Length];
                MakeNodeArry(nums);
            }
            private Node[] _nodes;
            private List<int> sortedArry = new List<int> { };
            private Node node1 = new Node(0);
            private Node node2 = new Node(0);
            private void maping(int root,int root2)
            {
                node1 = SearchBetwinNodes(root);
                node2 = SearchBetwinNodes(root2);
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
                            maping(node1.childLeft.value, node2.value);
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
                            maping(node1.childRight.value, node2.value);
                        }

                    }
                }
            }
            private Node SearchBetwinNodes(int root)
            {
                for (int i = 0; i < _nodes.Length; i++)
                {
                    if (_nodes[i].value == root )
                    {
                        return _nodes[i];
                    }
                }
                return new Node(root);
            }
            public int[] treeviwe(int[] nummbers)
            {
                //var sortedArr = new int[nodes.Length];
                for (int i = 0; i < _nodes.Length - 1; i++)
                {
                    maping(nummbers[0], nummbers[i + 1]);
                }
                return sortingfaz(_nodes[0]);
            }
            private int[] sortingfaz(Node nodes)
            {
                if (nodes.childLeft != null)
                {
                    sortingfaz(nodes.childLeft);
                }
                //Console.WriteLine(nodes.value);
                sortedArry.Add(nodes.value);
                if (nodes.childRight != null)
                {
                    sortingfaz(nodes.childRight);
                }
                return sortedArry.ToArray();
            }
            public void insert(Node node)
            {

            }
            private void MakeNodeArry(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    _nodes[i] = new Node(arr[i]);
                }
            }

        }
    }
}
