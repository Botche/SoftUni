using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methodInfos = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        var sb = new StringBuilder();

        foreach (var item in methodInfos.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{item.Name} will return {item.ReturnType}");
        }
        foreach (var item in methodInfos.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methodInfos = classType.GetMethods(
            BindingFlags.NonPublic | BindingFlags.Instance); 

        var sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var item in methodInfos)
        {
            sb.AppendLine($"{item.Name}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();
        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }


        return sb.ToString().Trim();
    }

    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        FieldInfo[] fieldInfos = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();


        sb.AppendLine($"Class under investigation: {classType}");

        foreach (var item in fieldInfos.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }
}

