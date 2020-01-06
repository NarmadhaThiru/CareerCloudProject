using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        { }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {

            List<ValidationException> exceptions = new List<ValidationException>();
            List<String> _validURL = new List<string>() { ".ca", ".com", ".biz" };

            foreach (CompanyProfilePoco poco in pocos)
            {
                if (!String.IsNullOrEmpty(poco.CompanyWebsite) && !_validURL.Any(x => poco.CompanyWebsite.Contains(x)))
                {
                    exceptions.Add(new ValidationException(600, "Valid websites must end with the following extensions – .ca/.com/.biz"));
                }
                if (String.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is required"));
                }
                else
                {
                    string[] phoneComponents = poco.ContactPhone.Split('-');
                    if (phoneComponents.Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                    }
                    else
                    {
                        if (phoneComponents[0].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[1].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[2].Length != 4)
                        {
                            exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                        }
                    }
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
