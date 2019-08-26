using System;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class DateChangedEvent : DomainEvent
    {
        public DateTime Date { get; }
        public DateChangedEvent(DateTime date)
        {
            Date = date;
        }
    }
}