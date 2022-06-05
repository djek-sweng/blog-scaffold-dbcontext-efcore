using System;

namespace Scaffold.Library.Data;

public partial class DatabaseContext
{
    public override int SaveChanges()
    {
        Console.WriteLine("Save changes.");

        return base.SaveChanges();
    }
}
