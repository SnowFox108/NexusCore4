using NexusCore.Infrastructure.Helpers;

namespace NexusCore.Infrastructure.IdGenerator
{
    public class TimeBasedFriendlyIdProvider : IFriendlyIdProvider
    {
        public string GetFriendlyId(string prefix, string suffix = "")
        {
            return $"{prefix}{GetFriendlyId()}{suffix}";
        }

        private string GetFriendlyId()
        {
            var timeNow = DateFormater.DateTimeNow;
            return $"{timeNow.ToString("yy")}{timeNow.DayOfYear}-{timeNow.TimeOfDay.TotalMilliseconds}";
        }
    }
}
