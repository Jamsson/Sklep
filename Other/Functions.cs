﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp
{
    public class Functions
    {
        public static string GenerateOrderCode()
        {
            string code;
            Random random = new Random();
            using (var db = new ShopDatabase()) {
                do
                {
                    code = string.Empty;
                    for (int i = 0; i < 12; i++)
                    {
                        code += random.Next(10).ToString();
                    }
                }
                while (db.Orders.Where(p => p.Code == code).FirstOrDefault() != null);
            }
            return code;
        }

        public static string Status(int id)
        {
            string statusStr = string.Empty;
            switch (id)
            {
                case 0:
                    statusStr = "Отправлено"; break;
                case 1:
                    statusStr = "Принято к реализации"; break;
                case 2:
                    statusStr = "Подготовлено к отправке"; break;
                case 3:
                    statusStr = "В доставке"; break;
                case 4:
                    statusStr = "Готово к сбору"; break;
                case 5:
                    statusStr = "Завершено"; break;
            }
            return statusStr;
        }

        public static int PermissionLevel(string role)
        {
            if (role == null)
                return 0;
            role = role.ToLower();
            if (role == "admin")
                return 5;
            if (role == "manager")
                return 4;
            if (role == "editor")
                return 3;
            if (role == "employee")
                return 2;
            return 1;
        }
    }
}
