using AutoMapper;
using Rapido_BusinessEntities.Dtos;
using Rapido_BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_ServiceLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        //create the constructor for this class and inside the constructor we will create
        //the mapping configuration for the source and destination objects using the CreateMap method of the AutoMapper library.
        public AutoMapperProfile()
        {
            //=================syntax for creating the mapping configuration=================
            // CreateMap<SourceClass, DestinationClass>();
            // Example:
            // CreateMap<UserEntity, UserDTO>();
            //===========================================
            CreateMap<EmployeeDto, Employee>();//this is used to map the data of EmployeeDto class object to Employee class object
            CreateMap<Employee, EmployeeDto>();//this is used to map the data of Employee class object to EmployeeDto class object
            CreateMap<DepartmentDto, Department>();//this is used to map the data of DepartmentDto class object to Department class object
            CreateMap<Department, DepartmentDto>();//this is used to map the data of Department class object to DepartmentDto class object
            CreateMap<OrdersDto, Orders>();//this is used to map the data of OrdersDto class object to Orders class object
            CreateMap<Orders, OrdersDto>();//this is used to map the data of Orders class object to OrdersDto class object
            CreateMap<RestaurantDto, Restaurant>();//this is used to map the data of RestaurantDto class object to Restaurant class object
            CreateMap<Restaurant, RestaurantDto>();//this is used to map the data of Restaurant class object to RestaurantDto class object
            CreateMap<UserSignInDto, UserSignIn>();//this is used to map the data of UserSignInDto class object to UserSignIn class object
            CreateMap<UserSignIn, UserSignInDto>();//this is used to map the data of UserSignIn class object to UserSignInDto class object
            CreateMap<UserSignUpDto, UserSignUp>();//this is used to map the data of UserSignUpDto class object to UserSignUp class object
            CreateMap<UserSignUp, UserSignUpDto>();//this is used to map the data of UserSignUp class object to UserSignUpDto class object

        }
    }
}