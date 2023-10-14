using System.Linq.Expressions;
using Mono.Cecil;

public class D
{
    public static void Main(string []args)
    {
        //var o = new lib.G1<int>.NG2<string, bool>();
        //o.Show();
        using var a = AssemblyDefinition.ReadAssembly(typeof(D).Assembly.Location);

        var m = a.MainModule.GetType("D").Methods.Single(m => m.Name == "M");

        Console.WriteLine(m);

        var p = m.Parameters[0];
        TypeReference r = p.ParameterType.DeclaringType.Resolve();
        Console.WriteLine($"Resolved: {r != null }");
        
        Console.WriteLine(p.ParameterType.FullName);
        Console.WriteLine($"[{p.Name}] {p.ParameterType.DeclaringType.FullName} : {p.ParameterType.DeclaringType.HasGenericParameters} / {r?.HasGenericParameters}");

        var forceResolve = args.Length == 1 && args[0] == "force";
        DumpType(() => p.ParameterType, forceResolve);
        DumpType(() => p.ParameterType.DeclaringType, forceResolve);
    }

    static void DumpType(Expression<Func<TypeReference>> exp, bool forceResolve)
    {
        MemberExpression m = (MemberExpression)exp.Body;
        var r = exp.Compile()();
        r = r.GetElementType();

        Console.WriteLine(m.Member.Name);

        if (forceResolve)
        {
            r = r.Resolve();
            System.Console.WriteLine("*** force resolve ***");
        }
        
        Console.WriteLine($"\t[{r.GetType().Name}] {r.FullName}: {r.HasGenericParameters}");
        if (r.HasGenericParameters)
            foreach(var gp in r.GenericParameters)
                System.Console.WriteLine($"\t\t{gp.Name} (Owner= {gp.Owner.GetHashCode():X} : {gp.Owner})");

        if (r is GenericInstanceType git)
        {
            System.Console.WriteLine($"\tHasGenericArguments: {git.HasGenericArguments}");
        }
    }

    //public static lib.G1<int> M(lib.G1<int>.NG2<string, bool> ng2)  => null;
    public static void M(lib.G1<int>.NG2<string, bool> ng2)  {}
}


namespace Local
{
    public class G1<T>
    {
        public class NG2<U,S>
        {
            public void Show()
            {
                Console.WriteLine( $"""
                                T = {typeof(T).Name}
                                U = {typeof(U).Name}
                                S = {typeof(S).Name}
                                """);
            }        
        }
    }
}
