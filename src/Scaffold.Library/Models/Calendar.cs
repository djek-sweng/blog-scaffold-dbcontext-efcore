namespace Scaffold.Library.Models;

public partial class Calendar
{
    public static Calendar Create(string owner)
    {
        return new Calendar
        {
            Owner = owner
        };
    }

    public bool IsOwner(string owner)
    {
        return Owner.Equals(owner);
    }
}
