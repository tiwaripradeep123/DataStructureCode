using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class BinarySearchTree
    {
        /// <summary>
        /// Simple flow. 
        /// 1. Check if root is null 
        /// 2. Check if value is same as room data
        /// 3. if value is less than root data, check in the left subtree
        /// 4. If value is greater than root data, check in the reight subtree.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool FindValue(BinaryTree root, int value)
        {
            if (root == null)
            {
                return false;
            }
            if (root.Data == value)
            {
                return true;
            }
            else if (root.Data > value)
            {
                return FindValue(root.LeftSubTree, value);
            }
            else
            {
                return FindValue(root.RightSubTree, value);
            }
        }
    }
}
