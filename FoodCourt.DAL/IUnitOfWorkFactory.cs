using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCourt.DAL
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork Create();
    }
}
