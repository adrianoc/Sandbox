namespace lib;

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
