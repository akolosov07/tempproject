using System.Linq;
using Temp.DTO;
using Temp.DTO.Set;
using Temp.Settings;
namespace Temp.Repository
{
    /// <summary>
    /// Пользователи (репозиторий)
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }
        private IQueryable<Entities.User> _filterAndSortingQuery(string searchUserPrincipalName, string searchLastName,
            IQueryable<Entities.User> items, UserSortType? sortType, SortDirectionType? sortDirection,
            DTO.Enums.UserType userType)
        {
            items = items.Where(i => i.UserTypeEnum == (int)userType);
            if (!string.IsNullOrEmpty(searchUserPrincipalName))
                items = items.Where(i => i.UserPrincipalName.StartsWith(searchUserPrincipalName));
            if (!string.IsNullOrEmpty(searchLastName))
                items = items.Where(i => i.LastName.StartsWith(searchUserPrincipalName));
            if (sortType != null && sortDirection != null)
            {
                switch (sortType.Value)
                {
                    case (UserSortType.ByLastName):
                    {
                        items = sortDirection.Value == SortDirectionType.Asc
                            ? items.OrderBy(i => i.LastName)
                            : items.OrderByDescending(i => i.LastName);
                        break;
                    }
                    case (UserSortType.ByUserPrincipalName):
                    {
                        items = sortDirection.Value == SortDirectionType.Asc
                            ? items.OrderBy(i => i.UserPrincipalName)
                            : items.OrderByDescending(i => i.UserPrincipalName);
                        break;
                    }
                }
            }
            else
                items = items.OrderByDescending(i => i.Id);
            return items;
        }
        public Temp.DTO.Set.UserSet GetUserSet(string searchUserPrincipalName, string searchLastName,
            int page, SortDirectionType? sortDirection, DTO.Set.UserSortType? sortType,
            DTO.Enums.UserType userType)
        {
            using (var context = new LockTestContext())
            {
                page = page < 1 ? 1 : page;
                IQueryable<Entities.User> items = context.User;
                items = _filterAndSortingQuery(searchUserPrincipalName, searchLastName,
                    items, sortType, sortDirection, userType);
                var list = items.Skip((page - 1) * Config.ItemsPerPage).Take(Config.ItemsPerPage).ToList()
                    .Select(l => new DTO.User
                    {
                        Id = l.Id,
                        UserPrincipalName = l.UserPrincipalName,
                        LevelEnum = (DTO.Enums.Level)l.LevelEnum,
                        UserTypeEnum = (DTO.Enums.UserType)l.UserTypeEnum,
                        FirstName = l.FirstName,
                        LastName = l.LastName,
                        Descr = l.Descr
                    });
                var set = new DTO.Set.UserSet(list, items.Count(), Config.ItemsPerPage, page);
                return set;
            }
        }
    }
}
