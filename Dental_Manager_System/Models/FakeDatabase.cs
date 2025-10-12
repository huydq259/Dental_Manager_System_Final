using Dental_Manager.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dental_Manager_System.Models
{
    public class FakeDatabase
    {
        public static List<User> Users { get; set; }
        static FakeDatabase()
        {
            Users = new List<User>
 {
 new User { Id = 1, Name = "Laptop HP Envy", Price = 28500000 },
 new Product { Id = 2, Name = "Apple Macbook Pro 14 inch", Price = 42000000
},
 new Product { Id = 3, Name = "Màn hình Dell Ultrasharp", Price = 8900000 },
 new Product { Id = 4, Name = "Bàn phím cơ Logitech G Pro", Price = 3800000 },
 new Product { Id = 5, Name = "Chuột không dây Logitech MX Master 3S", Price
= 2650000 },
 new Product { Id = 6, Name = "Tai nghe Sony WH-1000XM5", Price = 6990000
},new Product { Id = 7, Name = "Ổ cứng SSD Samsung 1TB", Price = 1750000 },
 new Product { Id = 8, Name = "Webcam Logitech C922", Price = 2100000 },
 new Product { Id = 9, Name = "Loa Bluetooth JBL Flip 6", Price = 2300000 },
 new Product { Id = 10, Name = "Router Wifi Asus RT-AX86U", Price = 5800000
}
 };
        }

    }
}