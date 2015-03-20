// Raymond O'Shea EAD CA1
// This program creates a local server on IIS port num: 49875 and gives information back to a client via an Api Controller

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebForum.Models;

namespace WebForum.Controllers
{
    // Overrall route prefix for each Http response
    [RoutePrefix("timetable")]
    public class ForumController : ApiController
    {   
        // creates 5 User objects in a list
        private static List<Room> icon = new List<Room>()
        {
            new Room{Time = 9, Available = true},
            new Room{Time = 10, Available  = true},
            new Room{Time = 11, Available  = false},
            new Room{Time = 12, Available = false},
            new Room{Time = 13, Available = false},
            new Room{Time = 14, Available = true},
            new Room{Time = 15, Available  = true},
            new Room{Time = 16, Available  = false},
            new Room{Time = 17, Available = false}
        };

        private static List<Room> room233 = new List<Room>()
        {
            new Room{Time = 9, Available = false},
            new Room{Time = 10, Available  = false},
            new Room{Time = 11, Available  = false},
            new Room{Time = 12, Available = false},
            new Room{Time = 13, Available = true},
            new Room{Time = 14, Available = true},
            new Room{Time = 15, Available  = true},
            new Room{Time = 16, Available  = false},
            new Room{Time = 17, Available = true}
        };

        // Handles http requests from a client requesting everything in the list
        // A route prefix to return everything in the list
        [Route("icon")]
        public IHttpActionResult GetAllFromIcon()
        {
            return Ok(icon);                                                     
        }

         //Handles http requests from a client for a specified Id
         //A route prefix to return a specified Id entry
        [Route("icon/time/{time}")]
        public IHttpActionResult GetRoomByTimeFromIcon(int time)
        {
            // LINQ query which matches the Id a client requests to the Id in the list and if found returns to Client
            Room hour = icon.FirstOrDefault(w => w.Time == time);
            if (hour == null)
            {
                return NotFound();                                                  
            }
            return Ok(hour);                                                
        }

        [Route("233")]
        public IHttpActionResult GetAllFrom233()
        {
            return Ok(room233);
        }

        [Route("233/time/{time}")]
        public IHttpActionResult GetRoomByTimeFrom233Room(int time)
        {
            // LINQ query which matches the Id a client requests to the Id in the list and if found returns to Client
            Room hour = room233.FirstOrDefault(w => w.Time == time);
            if (hour == null)
            {
                return NotFound();
            }
            return Ok(hour);
        }
    }
}
