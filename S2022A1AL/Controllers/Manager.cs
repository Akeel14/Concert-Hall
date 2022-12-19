// ************************************************************************************
// WEB524 Project Template V1 2224 == 330c386f-275a-4a0f-b682-905bd3cd6e93
// Do not change or remove the line above.
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

using AutoMapper;
using S2022A1AL.EntityModels;
using S2022A1AL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A1AL.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        public IMapper mapper;

        public Manager()
        {

            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<EntityModels.Venue, Models.VenueBaseViewModel>();
                cfg.CreateMap<Venue, VenueBaseViewModel>();
                cfg.CreateMap<VenueAddViewModel, Venue>();
                cfg.CreateMap<VenueBaseViewModel, VenueEditFormViewModel>();
               
            });

            mapper = config.CreateMapper();

            ds.Configuration.ProxyCreationEnabled = false;

            ds.Configuration.LazyLoadingEnabled = false;
        }

        public IEnumerable<VenueBaseViewModel> VenueGetAll()
        {
           
            return mapper.Map<IEnumerable<Venue>, IEnumerable<VenueBaseViewModel>>(ds.Venues.OrderBy(c => c.Company));
        }

        public VenueBaseViewModel VenueGetById(int id)
        {
            var o = ds.Venues.Find(id);

            return (o == null) ? null : mapper.Map<Venue, VenueBaseViewModel>(o);
        }

        public VenueBaseViewModel VenueAdd(VenueAddViewModel newVenue)
        {
            
            var addedItem = ds.Venues.Add(mapper.Map<VenueAddViewModel, Venue>(newVenue));
            ds.SaveChanges();
            
            return addedItem == null ? null : mapper.Map<Venue, VenueBaseViewModel>(addedItem);
        }

        public VenueBaseViewModel VenueEditVenueInfo(VenueEditViewModel venue)
        {
            var obj = ds.Venues.Find(venue.VenueId);
            if (obj == null)
            {
                return null;
            }
            else
            {
                ds.Entry(obj).CurrentValues.SetValues(venue);
                ds.SaveChanges();

                return mapper.Map<Venue, VenueBaseViewModel>(obj);
            }
        }

        
        public bool VenueDelete(int id)
        {
            var itemToDelete = ds.Venues.Find(id);
            if (itemToDelete == null)
                return false;
            else
            {
                ds.Venues.Remove(itemToDelete);
                ds.SaveChanges();
                return true;
            }
        }

    }
}