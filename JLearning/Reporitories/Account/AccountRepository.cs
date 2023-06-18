using BusinessObjects.DTO.Account;
using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporitories
{
    public class AccountRepository : IAccountRepository
    {
        public bool ChangePassword(Account account)
        {
            throw new NotImplementedException();
        }

        public Account FindAccountByEmail(string email)=>AccountDAO.FindAccountByEmail(email);

        public Account SignIn(Account account) => AccountDAO.SignIn(account);
        public bool SignUp(Account account) => AccountDAO.SignUp(account);

        public void UpdateAccount(Account account)=> AccountDAO.UpdateAccount(account);
    }
}
