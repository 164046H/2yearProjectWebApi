using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.GetModels;

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






    }
}
