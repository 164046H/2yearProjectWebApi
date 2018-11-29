using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.GetModels;
using System.Linq;

namespace EMS.Data
{
    public class EventRepository
    {

        private readonly EMSContext _context;

        public EventRepository(EMSContext context)
        {
            _context = context;
        }


        public Boolean AddEvent(Event eve)
        {
            try
            {
                _context.Events.Add(eve);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //create a new event

        public Event GetEventDetails(string id)
        {

            var eve = _context.Events
                .Where(c => c.PKey == id).FirstOrDefault();
            
            return eve;

        }
        //get details of a selected event


        public Boolean RegisterForOneDaytrip(OneDayTripRegistrant reg)
        {
            try
            {
                _context.OneDayTripRegistrants.Add(reg);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //add registrant for one day trip


        public Boolean RegisterForTwoDaytrip(TwoDayTripRegistrants reg)
        {
            try
            {
                _context.TwoDayTripRegistrant.Add(reg);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Event> ViewUpComingEvents()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today);
            
            var even = _context.Events
                .Where(c => c.StartDate>=today)
               .ToList();
            return even;
        }


    }
}
