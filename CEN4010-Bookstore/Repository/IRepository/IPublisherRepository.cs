﻿using CEN4010_Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN4010_Bookstore.Repository.IRepository
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        void Update(Publisher obj);
    }
}
