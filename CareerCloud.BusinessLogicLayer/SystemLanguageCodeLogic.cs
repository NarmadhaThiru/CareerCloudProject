using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic
    {
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) 
        { }

        protected void Verify(SystemLanguageCodePoco[] pocos)
        {

            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (SystemLanguageCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, "Required"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001, "Required"));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, "Required "));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            Add(pocos);
            /*IDataRepository<SystemLanguageCodePoco>.Add(pocos);*/
        }

        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            Update(pocos);
        }
        public void Get(SystemLanguageCodePoco[] pocos)
        {
            Get(pocos);
        }
        public void GetAll(SystemLanguageCodePoco[] pocos)
        {
            GetAll(pocos);
        }
        public void Delete(SystemLanguageCodePoco[] pocos)
        {

        }
    }
}
