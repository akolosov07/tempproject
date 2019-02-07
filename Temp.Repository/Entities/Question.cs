using System.Collections.Generic;
namespace Temp.Repository.Entities
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Descr { get; set; }
        public int LevelEnum { get; set; }
        public int FileId { get; set; }

        public File File { get; set; }
        public ICollection<Answer> Answer { get; set; }
    }
}
