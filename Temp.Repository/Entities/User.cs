namespace Temp.Repository.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserPrincipalName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeEnum { get; set; }
        public int LevelEnum { get; set; }
        public string Descr { get; set; }
    }
}
