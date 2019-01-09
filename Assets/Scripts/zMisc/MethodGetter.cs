using System;
using System.Linq;

public static class MethodGetter {

    public static string ShowMethods(Type type)
    {
        string methodString = "";

        foreach (var method in type.GetMethods())
        {
            var parameters = method.GetParameters();
            var parameterDescriptions = string.Join
                (", ", method.GetParameters().Select(x => x.ParameterType + " " + x.Name).ToArray());

            Console.WriteLine("{0} {1} ({2})",
                              method.ReturnType,
                              method.Name,
                              parameterDescriptions);

            methodString += method.ReturnType + " " + method.Name + " " + parameterDescriptions + "---\n";
        }

        return methodString;
    }
}
