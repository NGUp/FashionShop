﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionShop.Models.Objects;
using System.Data;
using System.Data.SqlClient;

namespace FashionShop.Models
{
    public class AccountModel
    {
        private Provider provider;

        public AccountModel()
        {
            this.provider = new Provider();
        }

        /// <summary>
        /// Login Handler
        /// </summary>
        /// <param name="account">Account Model</param>
        /// <returns>state</returns>
        public string login(Account account)
        {
            string sql = String.Format(
                    "Select ID From Account Where Username = '{0}' And Password = '{1}' And Permission = {2}",
                    account.Username, account.Password, account.Permission);

            DataTable result = this.provider.executeQuery(sql);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            return result.Rows[0]["ID"].ToString();
        }

        /// <summary>
        /// Quantity of the accounts
        /// </summary>
        /// <returns>int</returns>
        public int total()
        {
            string sql = "Select (Count(ID) / 10 + 1) As Total From Account";

            DataTable result = this.provider.executeQuery(sql);

            return (int) result.Rows[0]["Total"];
        }

        /// <summary>
        /// Get accounts with limit
        /// </summary>
        /// <param name="page">Current page</param>
        /// <returns>The array of the accounts</returns>
        public Account[] get(int page)
        {
            SqlCommand command = new SqlCommand("usp_GetAllAccounts");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@page", SqlDbType.Int);
            command.Parameters["@page"].Value = page;

            DataTable result = this.provider.executeQueryFromStoredProcedure(command);
            Account[] accounts = new Account[result.Rows.Count];
            int index = 0;

            foreach (DataRow row in result.Rows)
            {
                Account account = new Account();
                account.ID = row["ID"].ToString();
                account.Birthday = DateTime.Parse(row["Birthday"].ToString());
                account.Name = row["Name"].ToString();
                account.Username = row["Username"].ToString();
                account.City = row["City"].ToString();
                account.State = (int)row["State"];
                account.Permission = (int)row["Permission"];
                accounts[index] = account;
                index++;
            }

            return accounts;
        }

        public Account one(string ID)
        {
            string sql = string.Format("Select * From Account Where ID = '{0}'", ID);
            DataTable result = this.provider.executeQuery(sql);
            DataRow row = result.Rows[0];

            Account account = new Account();
            account.ID = row["ID"].ToString();
            account.Birthday = DateTime.Parse(row["Birthday"].ToString());
            account.Name = row["Name"].ToString();
            account.Username = row["Username"].ToString();
            account.City = row["City"].ToString();
            account.State = (int)row["State"];
            account.Permission = (int)row["Permission"];

            return account;
        }
    }
}