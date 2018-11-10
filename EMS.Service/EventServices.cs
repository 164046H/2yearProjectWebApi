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

    }
}
