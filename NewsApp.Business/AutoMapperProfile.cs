using AutoMapper;
using NewsApp.DataAccessor.Entities;
using NewsApp.Contracts;
using System;

namespace NewsApp.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            
        }

        private void FromDataAccessorLayer()
        {
            
        }
    }
}
