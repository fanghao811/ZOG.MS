﻿using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace ZOGLAB.MMMS.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=MMMS; Trusted_Connection=True;");
            csb["Database"].ShouldBe("MMMS");
        }
    }
}
