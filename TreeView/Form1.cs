using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView
{
    public partial class Form1 : Form
    {
        String path = @"C:\Program Files\";
        public Form1()
        {
            InitializeComponent();
            //loadTreeView();

            if (Directory.Exists(path))
            {
                TreeNode root = new TreeNode() { Text = path};
                tvShow.Nodes.Add(root);
                loadExplorer(root);
            }
        }

        void loadExplorer(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            try
            {
                // Lấy danh sách các thư mục con trong thư mục được chỉ định bởi root.Text
                var folderList = new DirectoryInfo(root.Text).GetDirectories();

                if (folderList.Count() == 0)
                {
                    return;
                }
                foreach (DirectoryInfo item in folderList) {
                    if (Directory.Exists(item.FullName)){
                        TreeNode Node= new TreeNode() { Text=item.FullName };
                        root.Nodes.Add(Node);
                        loadExplorer(Node);
                    }

                }
            }
            catch
            {
                return;
            }


        }
        void loadTreeView()
        {
            tvShow.CheckBoxes=true;
            tvShow.NodeMouseClick += TvShow_NodeMouseClick;

            TreeNode root1 = new TreeNode();
            root1.Text = "root1";
            root1.ImageIndex = 0;
            TreeNode node1= new TreeNode();
            node1.Text = "node1";
            node1.ImageIndex = 1;
            root1.Nodes.Add(node1);

            TreeNode root2 = new TreeNode();
            root2.Text = "root2";
            root2.ImageIndex = 2;
            tvShow.Nodes.Add(root1);
            tvShow.Nodes.Add(root2);
        }

        private void TvShow_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;
        }
    }
}
