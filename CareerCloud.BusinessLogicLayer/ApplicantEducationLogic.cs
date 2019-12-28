﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {}

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {

            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (ApplicantEducationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, "Blank major... Fix it! "));
                }
                else if (poco.Major.Length < 3){
                    exceptions.Add(new ValidationException(107, ""));
                }
                if(poco.StartDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, "Start date is wrong"));
                }
                if(poco.CompletionDate < poco.StartDate)
                {
                    exceptions.Add(new ValidationException(109, "That's wierd"));
                }
            }
        }
    }
}