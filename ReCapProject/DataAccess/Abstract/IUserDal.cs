﻿using ReCapProject.Core.DataAccess;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}