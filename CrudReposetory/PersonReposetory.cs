using CRUD_practice.Models;
using Dapper;
using Entities;
using ICrudReposetory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
 

namespace CrudReposetory
{
    public class PersonReposetory : IpersonReposetory
    {
        private readonly DapperContext _context;
        public PersonReposetory(DapperContext context)
        {
            _context = context;
        }
        public int AddPerson(Person person)

        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add(name: "@LastName", value: person.LastName, dbType: DbType.String);
                parameter.Add(name: "@FirstName", value: person.FirstName, dbType: DbType.String);
                parameter.Add(name: "@Age", value: person.Age, dbType: DbType.Int32);


                using (var connection = _context.CreateConnection())
                {
                    var data = connection.Query<Response>(
                            sql: @"[dbo].[Usp_Insertpersons]",
                            commandType: CommandType.StoredProcedure,
                            param: parameter).FirstOrDefault();
                    return data.Message;
                }
                
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }
     
    }
}
