using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;

namespace EMS.Service
{
    public class EventServices
    {

        private readonly EMS.Data.EventRepository _data;

        private readonly EMSContext _context;
        public EventServices(EMSContext context)
        {
            _context = context;
            _data = new EMS.Data.EventRepository(_context);
        }

        public Boolean AddEvent(Event even)
        {
            return _data.AddEvent(even);
        }
        //add an event

        public Event GetEventDetails(string id)
        {
            return _data.GetEventDetails(id);
        }
        //method for get details of a selected event


        public Boolean RegisterForOneDayTrip(OneDayTripRegistrant reg)
        {
            return _data.RegisterForOneDaytrip(reg);
        }
        //add a registrant for single day trip


        public Boolean RegisterForTwoDayTrip(TwoDayTripRegistrants reg)
        {
            return _data.RegisterForTwoDaytrip(reg);
        }
        //add a registrant for multiple day trip


        public IEnumerable<Event> ViewUpComingEvents()
        {
            return _data.ViewUpComingEvents();
        }
        //get details of up coming events filter by startdate

    }
}
