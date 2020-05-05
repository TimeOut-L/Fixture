using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace FixtureManagement.Models.Context
{
    public class FixtureDbContextHelper
    {
        public static FixtureManagerContext GetCurrentContext()
        {
            FixtureManagerContext _context = CallContext.GetData("FixtureManagement") as FixtureManagerContext;

            if (_context == null)
            {
                _context = new FixtureManagerContext();
                CallContext.SetData("FixtureManagement", _context);
            }
            return _context;
        }
    }
}