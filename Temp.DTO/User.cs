using Temp.DTO.Enums;
namespace Temp.DTO
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Уровень пользователя
        /// </summary>
        public Level LevelEnum { get; set; }
        /// <summary>
        /// Тип пользователя
        /// </summary>
        public UserType UserTypeEnum { get; set; }
        /// <summary>
        /// AD Login
        /// </summary>
        public string UserPrincipalName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Descr { get; set; }
        /// <summary>
        /// ctor
        /// </summary>
        public User() { }
    }
}
