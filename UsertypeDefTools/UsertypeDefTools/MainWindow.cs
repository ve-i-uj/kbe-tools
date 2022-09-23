using Dev;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UsertypeDefTools.Widget;

namespace UsertypeDefTools
{
    public partial class MainWindow : Form
    {
        public static MainWindow Instance
        {
            get;
            private set;
        }

		bool m_isOpenProj;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Log.Instance.AddLogDevices(new ConsoleLog());
            Log.Instance.AddLogDevices(new FileLog(SlnConfig.Instance.DefaultPath + "/ToolsLog", true));
            TypeDefInitialize();
            EntityDefInitialize();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Instance.Dispose();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if( !m_isOpenProj )
			{
				MessageBox.Show("请先打开项目");
				return;
			}
            m_entityWidget.ValidateEntityDefData();
            EntityDef.WriteToFile(SlnConfig.Instance.EntityDefDir);
			BaseType.WriteToFile( SlnConfig.Instance.AliasPath );
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = SlnConfig.Instance.DefaultPath;
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
				if( SlnConfig.Initialize( folderBrowser.SelectedPath ) )
				{
					BaseType.LoadFromFile( SlnConfig.Instance.AliasPath );
					EntityDef.LoadFromFile( SlnConfig.Instance.EntityDefDir );
					RefreshEntityTree();
					m_isOpenProj = true;
				}
            }
        }

        #region TypeDef

        List<KeyValuePair<Func<Point>, Func<Point>>> m_pannelLines = new List<KeyValuePair<Func<Point>, Func<Point>>>();
        TreeNode m_rootNode;

        List<BaseType> AllTypes
        {
            get { return BaseType.AllTypes; }
        }

        void TypeDefInitialize()
        {
            InitTreeView();

            Instance = this;
        }

        void InitTreeView()
        {
            m_rootNode = new TreeNode("AllTypes");
            m_typeTreeView.Nodes.Add(m_rootNode);

            foreach (var item in AllTypes)
                AddNodeToTree(item);

            m_typeTreeView.ExpandAll();
        }

        #region Compoment Events

        private void m_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshPanel();
        }

        private void m_treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = m_typeTreeView.GetNodeAt(e.X, e.Y);
                if (tn != null) m_typeTreeView.SelectedNode = tn;
                if (tn != null)
                {
                    ContextMenu con = new ContextMenu();

                    MenuItem newType = new MenuItem("新建类型");
                    newType.Click += new EventHandler(OnClick_CreateNewType);

                    MenuItem delType = new MenuItem("删除类型");
                    delType.Click += new EventHandler(OnClick_DeleteType);

                    con.MenuItems.Add(newType);
                    if (tn.Tag != null)
                        con.MenuItems.Add(delType);

                    m_typeTreeView.ContextMenu = con;
                    con.Show(m_typeTreeView, new Point(e.X + 10, e.Y));
                    m_typeTreeView.ContextMenu = null;
                }
            }
        }

        private void m_panel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            var p = m_type_panel.PointToScreen(Point.Empty);
            System.Drawing.Size ps = new Size(p);
            foreach (var item in m_pannelLines)
            {

                e.Graphics.DrawLine(pen, Point.Subtract(item.Key(), ps), Point.Subtract(item.Value(), ps));
            }
        }

        #endregion

        private void OnClick_CreateNewType(object sender, EventArgs e)
        {
            TypeChooseWindow typeChooseWindow = new TypeChooseWindow();
            typeChooseWindow.ShowDialog();

            if (typeChooseWindow.DialogResult == System.Windows.Forms.DialogResult.OK)
                CreateNewType(typeChooseWindow.Type, typeChooseWindow.TypeName);
        }

        private void CreateNewType(Type type, string typeName)
        {
            BaseType t = null;
            if (type == typeof(AliasType))
            {
                t = new AliasType(typeName, null);
                AllTypes.Add(t);
                AddNodeToTree(t);
            }

            if (type == typeof(UserType))
            {
                t = new UserType(typeName);
                AllTypes.Add(t);
                AddNodeToTree(t);
            }

            RefershTypeTreeView();

            foreach (TreeNode item in m_rootNode.Nodes)
            {
                if (item.Text == typeName)
                {
                    m_typeTreeView.SelectedNode = item;
                    break;
                }
            }
        }

        public void RefershTypeTreeView()
        {
            AllTypes.Sort((a, b) =>
            {
                if (a.GetType() == b.GetType())
                    return a.Type.CompareTo(b.Type);

                if (a.GetType() == typeof(BaseType) || b.GetType() == typeof(UserType))
                    return -1;

                if (a.GetType() == typeof(UserType) || b.GetType() == typeof(BaseType))
                    return 1;

                throw new Exception();
            });

            int index = 0;
            foreach (TreeNode item in m_rootNode.Nodes)
            {
                var type = AllTypes[index++];
                item.Tag = type;
                item.Text = type.Type;
                UpdateNodeColor(item);
                if (index == AllTypes.Count)
                    break;
            }

            for (int i = index; i < m_rootNode.Nodes.Count; i++)
                m_rootNode.Nodes.RemoveAt(i);

            for (int i = index; i < AllTypes.Count; i++)
                AddNodeToTree(AllTypes[i]);
        }

        private void OnClick_DeleteType(object sender, EventArgs e)
        {
            var selectedType = m_typeTreeView.SelectedNode.Tag as BaseType;

            if (selectedType.GetType() == typeof(BaseType))
            {
                MessageBox.Show("基础类型不能删除");
                return;
            }

            BaseType referenecedBy = null;

            foreach (var item in BaseType.AllTypes)
            {
                if (item.GetType() == typeof(BaseType))
                    continue;

                var aliasType = item as AliasType;
                if (aliasType != null && IsReferencedType(aliasType.RealType, selectedType))
                {
                    referenecedBy = item;
                    break;
                }

                var userType = item as UserType;
                if (userType != null)
                {
                    foreach (var t in userType.Properties)
                    {
                        if (IsReferencedType(t.Type, selectedType))
                        {
                            referenecedBy = item;
                            break;
                        }
                    }
                }
                if (referenecedBy != null)
                    break;
            }

            if (referenecedBy != null)
                MessageBox.Show(string.Format("无法删除\n类型'{0}'被其他类型'{1}'引用", selectedType.Type, referenecedBy.Type));
            else
            {
                AllTypes.Remove(selectedType);
                m_rootNode.Nodes.Remove(m_typeTreeView.SelectedNode);
            }
        }

        private bool IsReferencedType(IType type, BaseType reference)
        {
            if (type == reference)
                return true;

            if (type.GetType() == typeof(BaseType))
                return false;

            var aliasType = type as AliasType;
            if (aliasType != null)
                return IsReferencedType(aliasType.RealType, reference);

            var arrayType = type as ArrayType;
            if (arrayType != null)
                return IsReferencedType(arrayType.ElementType, reference);

            var userType = type as UserType;
            if (userType != null)
            {
                foreach (var item in userType.Properties)
                    if (IsReferencedType(item.Type, reference))
                        return true;
                return false;
            }

            throw new Exception();
        }

        private void AddNodeToTree(IType t)
        {
            TreeNode node = new TreeNode(t.TypeName());
            node.Tag = t;
            m_rootNode.Nodes.Add(node);
            UpdateNodeColor(node);
        }

        private static void UpdateNodeColor(TreeNode node)
        {
            if (node.Tag.GetType() == typeof(BaseType))
                node.ForeColor = Color.Black;

            if (node.Tag.GetType() == typeof(AliasType))
                node.ForeColor = Color.Green;

            if (node.Tag.GetType() == typeof(UserType))
                node.ForeColor = Color.Brown;
        }

        public void AddLineToPanel(Func<Point> start, Func<Point> end)
        {
            m_pannelLines.Add(new KeyValuePair<Func<Point>, Func<Point>>(start, end));
        }

        public void UpdateNodeName(BaseType type)
        {
            foreach (TreeNode item in m_rootNode.Nodes)
            {
                if (item.Tag == type)
                {
                    item.Text = type.Type;
                    break;
                }
            }
        }

        public void RefreshPanel()
        {
            var nodeTag = m_typeTreeView.SelectedNode.Tag;

            m_type_panel.Controls.Clear();
            m_pannelLines.Clear();

            if (nodeTag == null)
                return;

            if (nodeTag.GetType() == typeof(BaseType))
                m_type_panel.Controls.Add(new UsertypeDefTools.Widget.BaseTypeWidget(nodeTag as BaseType));

            if (nodeTag.GetType() == typeof(AliasType))
                m_type_panel.Controls.Add(new UsertypeDefTools.Widget.AliasTypeWidget(nodeTag as AliasType));

            if (nodeTag.GetType() == typeof(UserType))
                m_type_panel.Controls.Add(new UsertypeDefTools.Widget.UserTypeWidget(nodeTag as UserType));

            m_type_panel.Refresh();
        }

        public Panel Panel
        {
            get { return m_type_panel; }
        }

        public IType CurrentSelectedType
        {
            get { return m_typeTreeView.SelectedNode.Tag as IType; }
        }

        #endregion

        #region EntityDef

        Dictionary<string, EntityDef> AllEntites
        {
            get { return EntityDef.AllEntityDefs; }
        }

        EntityDefWidget m_entityWidget;

        void EntityDefInitialize()
        {
            m_entityWidget = new EntityDefWidget();
            m_entity_panel.Controls.Add(m_entityWidget);
            m_entityWidget.Dock = DockStyle.Fill;
        }

        void RefreshEntityTree()
        {
            m_entityTreeView.Nodes.Clear();

            var i = from e in AllEntites where e.Value.IsInterface select e.Value;
            foreach (var item in i)
            {
                TreeNode t = new TreeNode(item.Name);
                t.Tag = item;
                t.ForeColor = Color.Blue;
                m_entityTreeView.Nodes.Add(t);
            }

            var d = from e in AllEntites where !e.Value.IsInterface select e.Value;
            foreach (var item in d)
            {
                TreeNode t = new TreeNode(item.Name);
                t.Tag = item;
                m_entityTreeView.Nodes.Add(t);
            }
        }

        private void m_entityTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_entityWidget.Reset((EntityDef)e.Node.Tag);
        }

        private void m_entityTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (!m_entityWidget.ValidateEntityDefData())
                e.Cancel = true;
            Log.Debug((e.Node.Tag as EntityDef).Name);
        }

        private void m_entityTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && m_entityWidget.ValidateEntityDefData())
            {
                TreeNode tn = m_entityTreeView.GetNodeAt(e.X, e.Y);
                if (tn != null) m_entityTreeView.SelectedNode = tn;
                if (tn != null)
                {
                    ContextMenu con = new ContextMenu();

                    MenuItem newType = new MenuItem("新建类型");
                    newType.Click += new EventHandler(OnClick_CreateNewEntityDef);

                    MenuItem delType = new MenuItem("删除类型");
                    delType.Click += new EventHandler(OnClick_DeleteEctityDef);

                    con.MenuItems.Add(newType);
                    if (tn.Tag != null)
                        con.MenuItems.Add(delType);

                    m_entityTreeView.ContextMenu = con;
                    con.Show(m_entityTreeView, new Point(e.X + 10, e.Y));
                    m_entityTreeView.ContextMenu = null;
                }
            }
        }

        private void OnClick_DeleteEctityDef(object sender, EventArgs e)
        {
            var entity = m_entityTreeView.SelectedNode.Tag as EntityDef;
            if (entity != null)
            {
                if (MessageBox.Show(string.Format("确定删除‘{0}’实体吗", entity.Name), "delete", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    AllEntites.Remove(entity.Name);
                    RefreshEntityTree();
                }
            }
        }

        private void OnClick_CreateNewEntityDef(object sender, EventArgs e)
        {
            string entityName = null;
            for (int i = 0; i < 9999; i++)
            {
                entityName = "Entity" + i.ToString();
                if (!AllEntites.Values.Any(a => a.Name == entityName))
                    break;
            }
            if (string.IsNullOrEmpty(entityName))
                entityName = Guid.NewGuid().ToString();

            var entity = new EntityDef(entityName, false);
            AllEntites.Add(entity.Name, entity);
            RefreshEntityTree();
            foreach (TreeNode item in m_entityTreeView.Nodes)
            {
                if (item.Tag == entity)
                {
                    m_entityTreeView.SelectedNode = item;
                    break;
                }
            }
        }

        #endregion
    }
}
