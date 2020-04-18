using System;

namespace DistribuitorServiciiMobile.Models
{
    public class AbonamentSms
    {
        public Guid Id { get; set; }
        public Guid? AbonamentId { get; set; }
        public Guid? SmsId { get; set; }

        public virtual Abonament Abonament { get; set; }
        public virtual SMS Sms { get; set; }
    }
}