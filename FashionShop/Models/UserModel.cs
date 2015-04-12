using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data;

namespace FashionShop.Models
{
    public class UserModel
    {
        private Provider provider;

        public UserModel()
        {
            this.provider = new Provider();
        }

        /// <summary>
        /// Login Handler
        /// </summary>
        /// <param name="user">User Model</param>
        /// <returns></returns>
        public string login(User user)
        {
            string sql = String.Format(
                    "Select ID From Account Where Username = '{0}' And Password = '{1}' And Permission = {2}",
                    user.Username, user.Password, user.Permission);

            DataTable result = this.provider.executeQuery(sql);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            return result.Rows[0]["ID"].ToString();
        }
    }
}