using DatabaseCommunicator.Classes;
using System.Data.Entity;

namespace DatabaseCommunicator
{
   public class WoodStoreSeeder :
    DropCreateDatabaseAlways<WoodStoreDbContext>
    //DropCreateDatabaseIfModelChanges<WoodStoreDbContext>
    {
        protected override void Seed(WoodStoreDbContext ctx)
        {
            ctx.Accounts.Add(new Account("b", "b", false)); // customer account
            ctx.Accounts.Add(new Account("a", "a", true));  // Admin account
            base.Seed(ctx);
        }
    }
}
