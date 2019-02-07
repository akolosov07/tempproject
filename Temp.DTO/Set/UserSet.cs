using System.Collections.Generic;
namespace Temp.DTO.Set
{
    public class UserSet : BaseSet<User>
    {
        public UserSet(IEnumerable<User> set, int itemsCount, int itemsPerPage, int page)
            : base(set, itemsCount, itemsPerPage, page)
        { }
    }
    public enum UserSortType
    {
        ByLastName,
        ByUserPrincipalName
    }
}
