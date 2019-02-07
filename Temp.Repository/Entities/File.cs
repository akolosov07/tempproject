using System.Collections.Generic;
namespace Temp.Repository.Entities
{
    public partial class File
    {
        public File()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }

        public ICollection<Question> Question { get; set; }
    }
}
