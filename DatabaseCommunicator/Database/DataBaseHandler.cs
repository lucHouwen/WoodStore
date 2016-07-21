using DatabaseCommunicator.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCommunicator
{
    public static class DataBaseHandler
    {
        #region Public Methods

        // INSERTS   
        public static void InsertAccount(Account account)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
            }
        }       
        public async static void InsertToken(string token, int id)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                Account foundAccount = ctx.Accounts.Where(a => a.AccountID == id).Single();
                foundAccount.PasswordToken = token;
                await ctx.SaveChangesAsync();
            }
        }             
        public static Account GetAccount(Account account)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                if (ctx.Accounts.Any())
                {
                    return ctx.Accounts.Where(a => a.Username == account.Username && a.Password == account.Password).SingleOrDefault();
                }
                else { return null; }
            }
        }
        public static Account GetAccountByEmail(string email)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                if (ctx.Accounts.Any())
                {
                    return ctx.Accounts.Where(a => a.Email == email).SingleOrDefault();
                }
                else { return null; }
            }
        }
        public static Account GetAccountByID(int? id)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                if (ctx.Accounts.Any())
                {
                    return ctx.Accounts.Include("Person.Reservations.Rooms").Include("Person.CreditCard").Where(a => a.AccountID == id).SingleOrDefault();
                }
                else { return null; }
            }
        }             

        // OTHERS
        public static bool isAdminPassword(string pass)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                bool found = false;
                List<Account> admins = ctx.Accounts.Where(a => a.IsAdmin).ToList();
                foreach (Account a in admins)
                {
                    if (Hasher.Hash(a.Username + pass) == a.Password)
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        found = false;
                    }
                }
                if (found)
                { return true; }
                else { return false; }
            }
        }
        public static bool UsernameExist(Account checkAccount)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                try {
                    if (ctx.Accounts.Any() && ctx.Accounts.Any(a => a.Username == checkAccount.Username))
                    {
                        // exists
                        return true;
                    }
                    return false;
                }
                catch(Exception e)
                {
                    int i = 0; return false;
                }
            }
        }
        public static bool ConfirmAccount(string confirmationToken)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                try
                {
                    Account user = ctx.Accounts.Include("Address").SingleOrDefault(u => u.ConfirmationToken == confirmationToken);
                if (user != null) // .DbEntityValidationException
                {                               
                    user.IsConfirmed = true;
                    user.ConfirmationToken = null;
                    DbSet<Account> dbSet = ctx.Set<Account>();
                    dbSet.Attach(user);
                    ctx.Entry(user).State = EntityState.Modified;
                    ctx.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
                }
                catch (DbEntityValidationException e)
                {

                    throw;
                }
            }
        }
        public static bool EmailExist(string email)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                if (ctx.Accounts.Any(a => a.Email == email))
                {
                    return true;
                }
                else { return false; }
            }
        }
        public static bool ChangePassword(string passwordToken, string password)
        {
            using (WoodStoreDbContext ctx = new WoodStoreDbContext())
            {
                if (passwordToken == null || passwordToken == string.Empty)
                {
                    return false;
                }
                Account user = ctx.Accounts.SingleOrDefault(u => u.PasswordToken == passwordToken);
                if (user != null)
                {
                    string hashedPassword = Hasher.Hash(user.Username + password);
                    user.Password = hashedPassword;
                    user.PasswordToken = null;
                    DbSet<Account> dbSet = ctx.Set<Account>();
                    dbSet.Attach(user);
                    ctx.Entry(user).State = EntityState.Modified;
                    ctx.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        #endregion Public Methods
    }
}