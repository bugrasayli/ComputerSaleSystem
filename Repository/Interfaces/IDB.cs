using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Interfaces
{
    public interface IDB
    {
        SqlConnection getDB();

    }
}
