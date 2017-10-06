using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Spatial.Euclidean;
using Trajectories;
using KDTree;
using KDTree.Math;
using Sorting;
using Trees.BTree;
using BinaryTrees;
using Searching;

namespace gau_spatial
{

    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = { 42, 17, 12, 15, 4, 11, 31, 14 };
            int[] A = new int[4];
            int[] R = { 4, 5 };
            int[] L = { 8, 9 };
            Console.WriteLine(string.Join(".", nums));
            SimpleSorts<double>.InsertionSort(nums);
            Console.WriteLine(string.Join(".", nums));

            AVLTree<int> tree = new AVLTree<int>();
            tree.root = tree.Insert(tree.root, 10);
            tree.root = tree.Insert(tree.root, 20);
            tree.root = tree.Insert(tree.root, 30);
            tree.root = tree.Insert(tree.root, 40);
            tree.root = tree.Insert(tree.root, 50);
            tree.root = tree.Insert(tree.root, 25);

            Console.WriteLine("Preorder traversal" + " of constructed tree is : ");
            tree.InorderTraversal(tree.root);

            int searchelement = 17;
            int[] nums2 = { 42, 17, 12, 15, 4, 11, 31, 14 };
            Console.WriteLine(string.Join("", nums));
            CountingSorts.BucketSort(nums2);
            Console.WriteLine(string.Join("", nums));
            try
            {
                int result = SearchAlgorithms.BinarySeek(searchelement, nums2);
                Console.WriteLine("Found: " + (nums[result] == searchelement));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }

            BTree<int, int> btree = new BTree<int, int>();
            btree.Put(19, 19);
            btree.Put(26, 26);
            btree.Put(24, 24);
            btree.Put(14, 14);
            btree.Put(11, 11);
            btree.Put(12, 12);
            btree.Put(14, 14);
            btree.Put(4, 4);
            btree.Put(42, 42);
            Console.WriteLine(btree.ToString());
            Console.ReadLine();

        }
    }
}
