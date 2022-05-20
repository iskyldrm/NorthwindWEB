using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Northwind.WebMvc.Identity
{
    public class MyIdentityDbContext : IdentityDbContext<MyUser>
    {

        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options)
        {

        }
    }
}
