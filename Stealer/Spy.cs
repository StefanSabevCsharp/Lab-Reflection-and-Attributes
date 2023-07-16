using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        private object avtivator;

        public string StealFieldInfo(string className, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");
            Type type = Type.GetType(className);
            FieldInfo[] classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            Object instances = Activator.CreateInstance(type, new object[] { });
            foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instances)}");
            }
          
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);


            StringBuilder stringBuilder = new StringBuilder();

            foreach (var field in fieldInfos)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach(var method in classNonPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }



            return stringBuilder.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }



            return sb.ToString().TrimEnd();

        }

        public string CollectGettersAndSetters(string classname)
        {
            Type type = Type.GetType(classname);

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();
            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
