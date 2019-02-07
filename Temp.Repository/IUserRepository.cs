using Temp.DTO;
namespace Temp.Repository
{
    public interface IUserRepository
    {
        DTO.Set.UserSet GetUserSet(string searchUserPrincipalName, string searchLastName,
            int page, SortDirectionType? sortDirection, DTO.Set.UserSortType? sortType,
            DTO.Enums.UserType userType);
    }
}
