namespace AppForms.Model
{
    class Connection
    {
        private static readonly string ConnectionString = @"Persist Security Info=False;Data Source=DESKTOP-Q0SNIMC\SQLEXPRESS;Initial Catalog=APPFORM;User ID=sa;Password=1994";

        public static string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
