using System;
using System.Data;
using System.Text;

public class CodeSnippet
{
    public string ClassName, ObjectName, DataType;
    public List<CodeSnippet> CodeSnippets =  new List<CodeSnippet>(); 
    private const int _indentSize = 2;
    
    public CodeSnippet(){}
    public CodeSnippet(string className, string objectName, string datatype)
    {
        ClassName = className?? throw new ArgumentNullException(paramName: nameof(className));
        ObjectName = objectName?? throw new ArgumentNullException(paramName: nameof(objectName));
        DataType = datatype ?? throw new ArgumentNullException(paramName: nameof(datatype));
    }
    
    private string ToStringImplemantation(int indentSize)
    {
        var stringBuilder = new StringBuilder();
        var indentation = new string(' ', _indentSize * indentSize);
        stringBuilder.AppendLine($"{indentation}public {DataType} {ObjectName};");
        
        if(!string.IsNullOrWhiteSpace(ObjectName))
        {
            stringBuilder.Append(new string(' ', _indentSize * (indentSize + 1)));
            stringBuilder.AppendLine(ObjectName);
        }
        foreach(var codeSnippet in CodeSnippets)
        {
            stringBuilder.Append(codeSnippet.ToStringImplemantation(indentSize + 1);
        }
        return stringBuilder.ToString();
    }
    public override string ToString(){
        return ToStringImplemantation(0);
    }
}


public class CodeBuilder
{
    CodeSnippet _codeSnippet = new CodeSnippet();
    CodeSnippet _rootCodeSnippet = new CodeSnippet();
    public CodeBuilder(string rootClassName)
    {
        this._codeSnippet = rootClassName;
        rootClassName.ClassName = rootClassName;
    }
    
    public void AddField(string objectName, string property)
    {
        var codeSnippet = new CodeSnippet(ObjectName:objectName , Property: Property);
        _codeSnippet.Add(codeSnippet);
    }
    public override string ToString()
    {
        return _codeSnippet.ToString();
    }
    public void Clear()
    {
        _codeSnippet = new CodeSnippet{ ClassName = _codeSnippet}
    }
}


var cb = new CodeBuilder("Person")
.AddField("Name", "string")
.AddField("Age", "int");
Console.WriteLine(cb);

