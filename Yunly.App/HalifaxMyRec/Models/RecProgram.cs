using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yunly.App.Crawler.HalifaxMyRec.Models
{
    public partial class RecProgram
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("Id")]
        public int? ProgramId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Instructor { get; set; }
        public string StartDate { get; set; }
        public int? TotalSessions { get; set; }
        public int? RemainingSessions { get; set; }
        public int? TotalCapacity { get; set; }
        public int? AvailableCapacity { get; set; }
        public int? MinAgeMonths { get; set; }
        public int? MaxAgeMonths { get; set; }
        public int? SessionDurationMins { get; set; }
        public string PaymentPlanTemplateId { get; set; }
        public string NextSessionStartDate { get; set; }
        public string Language { get; set; }
        public int? WholeCourseBookingType { get; set; }
        public bool? DirectDebitPayment { get; set; }
        public bool? BlockBookingPayment { get; set; }
        public string WeekDays
        {
            get
            {
                return string.Join(',', DaysOfWeek);
            }
            set
            {
                DaysOfWeek = value.Split(',').Select(x => int.Parse(x)).ToList();
            }
        }
        public bool? PaymentPlanAvailable { get; set; }
        public DateTime? StartDateFormatted { get; set; }
        public DateTime? NextSessionStartDateFormatted { get; set; }
    }
}
