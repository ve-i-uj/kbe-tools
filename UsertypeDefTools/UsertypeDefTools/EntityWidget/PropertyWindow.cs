using System;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools.EntityWidget
{
	public partial class PropertyWindow : Form
	{
		EntityDef.Property m_property;
		private EntityDef m_entity;

		public PropertyWindow(EntityDef entity, EntityDef.Property property)
		{
			InitializeComponent();

			Initlize( entity, property );
		}

		void Initlize(EntityDef entity, EntityDef.Property property)
		{
			m_entity = entity;

			var strs = ( from t in BaseType.AllTypes
						 select t.TypeName() ).ToArray();
			m_cbb_type.Items.AddRange( strs );

			if( property == null )
				m_property = new EntityDef.Property();
			else
				m_property = property;

			m_txt_name.Text = m_property.Name;
			m_cbb_type.SelectedItem = m_property.Type.TypeName();
			m_txt_default.Text = m_property.Default == null ? "" : m_property.Default;
			m_txt_utype.Text = m_property.Utype.HasValue ? m_property.Utype.ToString() : "";

			foreach( EntityDef.Flags item in Enum.GetValues( typeof( EntityDef.Flags ) ) )
				m_cbb_flags.Items.Add( item );

			m_cbb_flags.SelectedItem = m_property.Flags;

			m_cb_persistent.Checked = m_property.Persistent.HasValue ? m_property.Persistent.Value : false;
			m_txt_databaseLength.Text = m_property.DatabaseLength.HasValue ? m_property.DatabaseLength.ToString() : "";

			foreach( EntityDef.IndexType item in Enum.GetValues( typeof( EntityDef.IndexType ) ) )
				m_cbb_index.Items.Add( item );

			m_cbb_index.Items.Add( "" );

			if( m_property.IndexType.HasValue )
				m_cbb_index.SelectedItem = m_property.IndexType.Value;
			else
				m_cbb_index.SelectedItem = "";
		}

		private void btn_OK_Click(object sender, EventArgs e)
		{
			string name = m_txt_name.Text.Trim();
			if( string.IsNullOrEmpty( name ) )
			{
				MessageBox.Show( "属性名称不能为空" );
				return;
			}
			if( m_entity.Properties.Any( p => p.Name == name && p != m_property ) )
			{
				MessageBox.Show( "属性名重复" );
				return;
			}
			m_property.Name = name;

			m_property.Type = BaseType.AllTypes.Find( t => t.TypeName().Equals( (string)m_cbb_type.SelectedItem ) );

			var defaultStr = m_txt_default.Text.Trim();
			if( string.IsNullOrEmpty( defaultStr ) )
				m_property.Default = null;
			else
				m_property.Default = defaultStr;

			var utypeStr = m_txt_utype.Text.Trim();
			if( !string.IsNullOrEmpty( utypeStr ) )
			{
				UInt16 utype;
				if( UInt16.TryParse( utypeStr, out utype ) )
					m_property.Utype = utype;
				else
				{
					MessageBox.Show( "Utype 必须为16位整数" );
					return;
				}
			}

			m_property.Flags = (EntityDef.Flags)m_cbb_flags.SelectedItem;

			m_property.Persistent = m_cb_persistent.Checked;

			var databaseLStr = m_txt_databaseLength.Text.Trim();
			if( !string.IsNullOrEmpty( databaseLStr ) )
			{
				uint dl;
				if( uint.TryParse( databaseLStr, out dl ) )
					m_property.DatabaseLength = dl;
				else
				{
					MessageBox.Show( "DatabaseLength 必须为uint类型" );
					return;
				}
			}

			try
			{
				m_property.IndexType = (EntityDef.IndexType)m_cbb_index.SelectedItem;
			}
			catch( Exception )
			{
				m_property.IndexType = null;
			}

			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		public EntityDef.Property Property
		{
			get { return m_property; }
		}
	}
}
