﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Models
{
    /// <summary>
    /// Summary description for Session
    /// </summary>
    public partial class Session
    {
        public static void Propose(string Email, string SessionTitle, string SessionAbstract)
        {
            var ctx = new ICCData();

            int eId = Event.GetNextEvent().Id;
            
            var session = new Session() 
            { Title = SessionTitle, Abstract = SessionAbstract, EventId = eId };
            
            ctx.Sessions.InsertOnSubmit(session);
            ctx.SubmitChanges();
            
            var user = ctx.Users.Where(u => string.Compare(u.Email, Email, true) == 0).FirstOrDefault();

            Speaker speak = new Speaker()
            { SessionId = session.Id, UserId = user.Id };

            ctx.Speakers.InsertOnSubmit(speak);
            ctx.SubmitChanges();
        }

        # region Extensibility Partials

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            //existing
            if (Id > 1)
                SetModified();
            else//new
                SetCreated(); SetModified();
        }

        private void SetCreated()
        {
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = HttpContext.Current.User.Identity.Name;
        }

        private void SetModified()
        {
            this.ModifiedOn = DateTime.Now;
            this.ModifiedBy = HttpContext.Current.User.Identity.Name;
        }

        #endregion
    }
}