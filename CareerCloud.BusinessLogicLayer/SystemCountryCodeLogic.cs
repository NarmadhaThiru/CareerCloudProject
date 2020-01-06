using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic
    {
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) 
        { }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {

            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, "Required"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, "Required"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            Add(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            Update(pocos);
        }
        public void Get(SystemCountryCodePoco[] pocos)
        {
            Get(pocos);
        }
        public void GetAll(SystemCountryCodePoco[] pocos)
        {
            GetAll(pocos);
        }
        public void Delete(SystemCountryCodePoco[] pocos)
        {
            
        }
    }
}
