using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        
            public void PrintMethodsByAuthor()
            {
                Type type = typeof(StartUp);
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                foreach (MethodInfo method in methods)
                {
                    if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                    {
                        var atrributes = method.GetCustomAttributes(typeof(AuthorAttribute), false);
                        foreach (AuthorAttribute att in atrributes)
                        {
                            Console.WriteLine($"{method.Name} is writen by {att.Name}");
                        }
                    }
                }
            }
        
    }
}