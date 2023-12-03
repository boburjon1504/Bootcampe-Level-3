namespace PracitseSomething;

public class MyList<T> : List<T>  where T : User
{
    public int this[string a] => this.IndexOf(this.FirstOrDefault(u=>u.FirstName==a));
}

public class User
{
    public string FirstName { get; set; } 
}