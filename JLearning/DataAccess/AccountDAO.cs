using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {

        public static Account SignIn(Account account)
        {
            try
            {
                using (var context = new JlearningContext())
                {
                    Account ac = context.Accounts.SingleOrDefault(x => x.Email == account.Email && x.Password == account.Password);

                    return ac;
                }
            }
            catch (Exception)
            {

                return null;
            }
            return null;
        }


        public static bool SignUp(Account account)
        {
            try
            {
                using (var context = new JlearningContext())
                {
                    context.Accounts.Add(account);

                    if (context.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        public static void UpdateAccount(Account a)
        {

            try
            {
                using (var context = new JlearningContext())
                {
                    context.Entry<Account>(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new Exception(e.Message);
            }
        }
        public static Account FindAccountByEmail(string email)
        {
            Account account = new Account();
            try
            {
                using (var context = new JlearningContext())
                {
                    account = context.Accounts.SingleOrDefault(x => x.Email == email);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return account;
        }
    }
}
