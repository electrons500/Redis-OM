using Redis.OM.Searching;
using Redis.OM;
using System;
using Redis_OM.Data.Model;

namespace Redis_OM.Data.Service
{
    public class UsersService
    {
        private readonly RedisCollection<Users> _Users;
        private readonly RedisConnectionProvider _provider;
        public UsersService(RedisConnectionProvider provider )
        { 
            _provider = provider;
            _Users = (RedisCollection<Users>)provider.RedisCollection<Users>();
        }

        //Insert data
        public bool AddUsers(Users users )
        {
            //var getUserKey = _Users.Insert( users,TimeSpan.FromMinutes(60));
            var getUserKey = _Users.Insert( users);
            if ( getUserKey != null )
            {
                return true;
            }
            return false;
        }

        //Get all users
        public List<Users> GetUsers()
        {
            return _Users.ToList();
        }

        //Get user by Id
        public List<Users> GetUsersById(string Id)
        {
            return _Users.Where(x => x.Id == Id).ToList();
        }

        //update user Age
        public bool UpdateAge(string id,int age)
        {
            foreach (var user in _Users.Where(x => x.Id == id))
            {
                user.Age = age;
            }
            _Users.Save();

            return true;
        }

        //delete user by id
        public bool DeleteUser(string id)
        {
           _provider.Connection.Unlink($"Users:{id}"); 
            return true;
          
        }

        //filter ages
        public List<Users> FilterByAge(int minAge,int maxAge)
        { 
            return _Users.Where(x => x.Age >= minAge && x.Age <= maxAge).ToList();
        }

         //filter by postal code
        public List<Users> FilterByPostalCode(string postalCode)  
        {
            var model = _Users.Where(x => x.Address!.PostalCode == postalCode).ToList();
            return model;
        }
         public List<Users> FilterBySkill(string skill)  
        {
            var model =  _Users.Where(x => x.Skills.Contains(skill)).ToList();
            return model;
        }

         public List<Users> FilterByStreetName(string streetName)    
        {
            var model = _Users.Where(x => x.Address!.StreetName == streetName).ToList();
            return model;
        }



    }
}
