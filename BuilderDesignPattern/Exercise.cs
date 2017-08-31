using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattern
{
    public class CodeField
    {
        public string Name, Type;
        private const int IndentSpace = 2;

        public CodeField()
        {

        }

        public CodeField(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }


        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', IndentSpace * indent);
            sb.AppendLine($"{i}public {Type} {Name};");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(1);
        }
    }

    public class ClassField
    {
        public string Name;
        public List<CodeField> Fields = new List<CodeField>();
        private const int IndentSpace = 2;

        public ClassField()
        {

        }
        public ClassField(string name)
        {
            this.Name = name;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', IndentSpace * indent);
            sb.Append($"{i}public class {Name}\n");
            sb.Append("{\n");
            foreach (var f in Fields)
                sb.Append(f);
            sb.Append("}");


            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }


    public class CodeBuilder
    {
        // TODO
        private readonly string rootName;
        ClassField root = new ClassField();

        public CodeBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }


        public CodeBuilder AddField(string name, string type)
        {
            var f = new CodeField(name, type);
            root.Fields.Add(f);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new ClassField { Name = rootName };
        }

    }
}
