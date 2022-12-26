using agrconclude.dal.Context;
using Microsoft.EntityFrameworkCore;

namespace agrconclude.dal;

public class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        context.Database.Migrate();
    }
}