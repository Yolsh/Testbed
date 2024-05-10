using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W136___Binary_trees
{
    public class TreeNode
    {
        public string Data;
        public TreeNode left, right;

        public TreeNode Add(TreeNode val)
        {
            if (string.Compare(val.Data, Data) == -1 && left == null) 
            { 
                left = val;
                return null;
            }
            else if (right == null)
            {
                right = val;
                return null;
            }
            return val;
        }
    }
}
