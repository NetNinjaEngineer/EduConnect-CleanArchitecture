using EduConnect.Domain.Commons;
using EduConnect.Domain.Entities.Common;
using System.Globalization;

namespace EduConnect.Domain.Entities
{
    public class Topic : BaseEntity, ILocalizableTopic
    {
        public string? TopicName { get; set; }
        public ICollection<Course> Courses { get; set; } = [];
        public string? TopicNameAr { get; set; }

        public List<string> GetLocalized()
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return [TopicNameAr];
            return [TopicName];
        }
    }
}
