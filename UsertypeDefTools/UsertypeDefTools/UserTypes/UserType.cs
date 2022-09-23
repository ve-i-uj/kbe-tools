using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

public interface IType
{
    string TypeName();
}

public class BaseType : IType
{
    public static List<BaseType> AllTypes;
    public static int BaseTypeCount;
    string m_typeName;

    static BaseType()
    {
        InitBaseType();
    }

    private static void InitBaseType()
    {
        AllTypes = new List<BaseType>();
        AllTypes.Add(new BaseType("UINT8"));
        AllTypes.Add(new BaseType("UINT16"));
        AllTypes.Add(new BaseType("UINT32"));
        AllTypes.Add(new BaseType("UINT64"));

        AllTypes.Add(new BaseType("INT8"));
        AllTypes.Add(new BaseType("INT16"));
        AllTypes.Add(new BaseType("INT32"));
        AllTypes.Add(new BaseType("INT64"));

        AllTypes.Add(new BaseType("FLOAT"));
        AllTypes.Add(new BaseType("DOUBLE"));

        AllTypes.Add(new BaseType("VECTOR2"));
        AllTypes.Add(new BaseType("VECTOR3"));
        AllTypes.Add(new BaseType("VECTOR4"));

        AllTypes.Add(new BaseType("STRING"));
        AllTypes.Add(new BaseType("UNICODE"));
        AllTypes.Add(new BaseType("PYTHON"));
        AllTypes.Add(new BaseType("PY_DICT"));
        AllTypes.Add(new BaseType("PY_TUPLE"));
        AllTypes.Add(new BaseType("PY_LIST"));
        AllTypes.Add(new BaseType("ENTITYCALL"));
        AllTypes.Add(new BaseType("BLOB"));

        BaseTypeCount = AllTypes.Count;
    }

    public BaseType(string typeName)
    {
        m_typeName = typeName;
    }

    public string TypeName()
    {
        return m_typeName;
    }

    public static string[] AllTypeNamesExlude(BaseType type)
    {
        return (from t in BaseType.AllTypes
                where t != type
                select t.TypeName()).ToArray();
    }

    public string Type
    {
        get { return m_typeName; }
        set
        {
            m_typeName = value;
            UsertypeDefTools.MainWindow.Instance.UpdateNodeName(this);
        }
    }

    public static void WriteToFile(string path)
    {
        XmlDocument doc = new XmlDocument();

        XmlElement root = doc.CreateElement("root");

        foreach (var item in AllTypes)
        {
            if (item.GetType() == typeof(BaseType))
                continue;

            root.AppendChild(item.GenerateXmlNode(doc));
        }

        doc.AppendChild(root);

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            using (XmlTextWriter writer = new XmlTextWriter(fileStream, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';
                doc.WriteTo(writer);

                writer.Close();
            }
            fileStream.Close();
        }
    }

    public static void LoadFromFile(string path)
    {
        var xml = File.ReadAllText(path);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);
        var root = xmlDoc.SelectSingleNode("root");
        InitBaseType();
        foreach (XmlNode xmlNode in root.ChildNodes)
        {
            if (xmlNode.FirstChild.InnerText.Trim() == "FIXED_DICT")
                AllTypes.Add(new UserType(xmlNode.Name));
            else
                AllTypes.Add(new AliasType(xmlNode.Name, null));
        }
        int index = BaseTypeCount;
        foreach (XmlNode xmlNode in root.ChildNodes)
            AllTypes[index++].InitWithXmlNode(xmlNode);

        UsertypeDefTools.MainWindow.Instance.RefershTypeTreeView();
    }

    protected virtual void InitWithXmlNode(XmlNode xmlNode)
    {
    }

    protected virtual XmlNode GenerateXmlNode(XmlDocument doc)
    {
        throw new InvalidOperationException("BaseType can't serialize");
    }
}

public class AliasType : BaseType
{
    IType m_realType = AllTypes[0];

    public AliasType(string aliasName, IType realType)
        : base(aliasName)
    {
        m_realType = realType;
    }

    public IType RealType
    {
        get { return m_realType; }
        set { m_realType = value; }
    }

    protected override XmlNode GenerateXmlNode(XmlDocument doc)
    {
        var e = doc.CreateElement(TypeName());

        if (m_realType is BaseType)
            e.InnerText = m_realType.TypeName();
        else
        {
            var array = m_realType as ArrayType;
            if (array == null)
                throw new InvalidOperationException();

            e.InnerXml = array.GetXmlText();
        }

        return e;
    }

    protected override void InitWithXmlNode(XmlNode xmlNode)
    {
        m_realType = xmlNode.GetIType();
    }
}

public class UserType : BaseType
{
    public class Field
    {
        public string FieldName;
        public IType Type = AllTypes[0];

        internal XmlNode GenerateXmlNode(XmlDocument doc)
        {
            var type = doc.CreateElement(FieldName);
            var e = doc.CreateElement("Type");

            if (Type is BaseType)
                e.InnerText = Type.TypeName();
            else
            {
                var array = Type as ArrayType;
                if (array == null)
                    throw new InvalidOperationException();

                e.InnerXml = array.GetXmlText();
            }

            type.AppendChild(e);
            return type;
        }

        internal void InitWithXmlNode(XmlNode xmlNode)
        {
            FieldName = xmlNode.Name.Trim();

            Type = xmlNode.SelectSingleNode("Type").GetIType();
        }
    }

    public string ImplementedBy;
    public List<Field> Properties = new List<Field>();

    public UserType(string userTypeName)
        : base(userTypeName)
    {
    }

    protected override XmlNode GenerateXmlNode(XmlDocument doc)
    {
        var e = doc.CreateElement(TypeName());

        e.InnerText = "FIXED_DICT";

        if (!string.IsNullOrEmpty(ImplementedBy))
        {
            var impl = doc.CreateElement("implementedBy");
            impl.InnerText = ImplementedBy;
            e.AppendChild(impl);
        }

        var p = doc.CreateElement("Properties");
        foreach (var item in Properties)
            p.AppendChild(item.GenerateXmlNode(doc));

        e.AppendChild(p);

        return e;
    }

    protected override void InitWithXmlNode(XmlNode xmlNode)
    {
        var implNode = xmlNode.SelectSingleNode("implementedBy");
        if (implNode != null)
            ImplementedBy = implNode.InnerText.Trim();

        foreach (XmlNode item in xmlNode.SelectSingleNode("Properties"))
        {
            var field = new Field();
            field.InitWithXmlNode(item);
            Properties.Add(field);
        }
    }
}

public class ArrayType : IType
{
    public static readonly string ArrayTyteStr = "Array...";
    IType m_elementType = BaseType.AllTypes[0];

    public ArrayType(IType type)
    {
        m_elementType = type;
    }

    internal ArrayType(XmlNode xmlNode)
    {
        m_elementType = xmlNode.GetIType();
    }

    public string TypeName()
    {
        return ArrayTyteStr;
    }

    public IType ElementType
    {
        get { return m_elementType; }
        set { m_elementType = value; }
    }

    internal string GetXmlText()
    {
        var array = m_elementType as ArrayType;
        if (array != null)
            return string.Format("ARRAY <of> {0} </of>", array.GetXmlText());

        return string.Format("ARRAY <of> {0} </of>", m_elementType.TypeName());
    }
}


static class ITypeHelper
{
    public static IType GetIType(this XmlNode xmlNode)
    {
        if (xmlNode.FirstChild.InnerText.Trim() != "ARRAY")
            return BaseType.AllTypes.Find(e => e.TypeName() == xmlNode.InnerText.Trim());
        else
            return new ArrayType(xmlNode.SelectSingleNode("of"));
    }
}